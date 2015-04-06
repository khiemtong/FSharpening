// how do we handle n-parameter functions?
let complex (a:int) (b:bool) (c:float) (d:double) =
    ()



// int -> (bool -> float -> double -> unit)
let interm1 = complex 1

// bool -> (float -> double)
let interm2 = interm1 true

// float -> (double)
let interm3 = interm2 1.0

// double -> unit
let interm4 = interm3 1.0




















let complex2 (a:int) =
    let interm1 (b:bool) = 
        let interm2 (c:float) =
            let interm3 (d:double) =
                ()
                //a.ToString() + " " + b.ToString() + " " + c.ToString() + " " + d.ToString()
            interm3
        interm2
    interm1









let complex2result = complex2 1 false 1. 1.