open System
open System.Drawing
open System.Windows.Forms

// Create a form to display the graphics
let width, height = 800, 800         
let form = new Form(Width = width, Height = height)
let box = new PictureBox(BackColor = Color.White, Dock = DockStyle.Fill)
let image = new Bitmap(width, height)
let graphics = Graphics.FromImage(image)
//The following line produces higher quality images, 
//at the expense of speed. Uncomment it if you want
//more beautiful images, even if it's slower.
//Thanks to https://twitter.com/AlexKozhemiakin for the tip!
//graphics.SmoothingMode <- System.Drawing.Drawing2D.SmoothingMode.HighQuality
let brush = new SolidBrush(Color.FromArgb(0, 0, 0))

box.Image <- image
form.Controls.Add(box) 

// Compute the endpoint of a line
// starting at x, y, going at a certain angle
// for a certain length. 
let endpoint x y angle length =
    x + length * cos angle,
    y + length * sin angle

let flip x = (float)height - x

// Utility function: draw a line of given width, 
// starting from x, y
// going at a certain angle, for a certain length.
let drawLine (target : Graphics) (brush : Brush) 
             (x : float) (y : float) 
             (angle : float) (length : float) (width : float) =
    let x_end, y_end = endpoint x y angle length
    let origin = new PointF((single)x, (single)(y |> flip))
    let destination = new PointF((single)x_end, (single)(y_end |> flip))
    let pen = new Pen(brush, (single)width)
    target.DrawLine(pen, origin, destination)

let drawCircle (target:Graphics) (brush:Brush) (stroke:float) (x:float) (y:float) (width:float) (height:float) =
    let pen = new Pen(Color.FromArgb(0, 0, 0), (single)stroke)
    target.DrawEllipse(pen, (single)x, (single)y, (single)width, (single)height)

let draw x y angle length width = 
    drawLine graphics brush x y angle length width

let drawC x y radius =
    drawCircle graphics brush 1. (x-radius) (y-radius) (2.*radius) (2.*radius)


let pi = Math.PI
let maxDepth = 6

let rec drawSymmetric depth x y angle length width =
    draw x y angle length width

    if (depth > maxDepth) then ignore()
    else
        let newX,newY = endpoint x y angle length
        drawSymmetric (depth + 1) newX newY (angle + 0.3) (length * 0.8) (width * 0.7)
        drawSymmetric (depth + 1) newX newY (angle - 0.3) (length * 0.8) (width * 0.7)
        drawSymmetric (depth + 1) newX newY (angle + 0.3) (length * 0.8) (width * 0.7)
        drawSymmetric (depth + 1) newX newY (angle - 0.3) (length * 0.8) (width * 0.7)

let rec drawCirclSymm depth x y radius =
    // draw the circle
    drawC x y radius

    if (depth > maxDepth) then ignore()
    else
        let newRadius = radius/2.
        //drawCirclSymm (depth + 1) x y newRadius
        drawCirclSymm (depth + 1) (x + radius) (y) newRadius
        drawCirclSymm (depth + 1) (x - radius) (y) newRadius
        drawCirclSymm (depth + 1) (x) (y + radius) newRadius
        drawCirclSymm (depth + 1) (x) (y - radius) newRadius


// Now... your turn to draw
// The trunk
//draw 250. 50. (pi*(0.5)) 100.0 4.

//drawSymmetric 0 400. 400. (pi * 0.5) 90. 10.

//drawCirclSymm 0 400. 400. 300. 300.

//draw 0. 0. (pi*1.) 10. 4.

//drawC 400. 400. 100.
drawCirclSymm 0 400. 400. 100.


form.ShowDialog()

(* To do a nice fractal tree, using recursion is
probably a good idea. The two following link might
come in handy if you have never used recursion in F#:
http://en.wikibooks.org/wiki/F_Sharp_Programming/Recursion
*)