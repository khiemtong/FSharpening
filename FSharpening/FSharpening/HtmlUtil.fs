namespace FSharpening


open HtmlAgilityPack
open System.Net
open System.Runtime.Serialization
open System.Diagnostics
open System.Xml
open System.Text

module HtmlUtil =

    let rec private ConvertTo (node:HtmlNode) = 
        
        let sb = new StringBuilder()

        let parseChildren (node:HtmlNode) = 
            if (node.HasChildNodes) then 
                    for childNode in node.ChildNodes do
                        sb.Append(ConvertTo(childNode):string) |> ignore

        match node.NodeType with
            | HtmlNodeType.Text -> 

                let parentName = node.ParentNode.Name
                let nodeText = (node :?> HtmlTextNode).Text

                if parentName <> "script" 
                    && parentName <> "style" 
                    && nodeText.Trim().Length > 0
                    && not (HtmlNode.IsOverlappedClosingElement(nodeText))  then                   
                    sb.Append (WebUtility.HtmlDecode(nodeText)) |> ignore

            | HtmlNodeType.Document -> 

                parseChildren(node)

            | HtmlNodeType.Element -> 
                
                match node.Name with
                    | "p" -> sb.Append "\r\n" |> ignore
                    | "br" -> sb.Append "\r\n" |> ignore
                    | _ -> ()

                parseChildren(node)

            | _ -> ()
            
        sb.ToString()

        
    let ConvertHtml(html:string) = 
        
        let htmlDoc = new HtmlDocument();
        htmlDoc.LoadHtml(html);

        ConvertTo(htmlDoc.DocumentNode).Trim()

    let ConvertUrlToText(url:string) =
        
        let wc = new WebClient()
        let lines = wc.DownloadString(url)

        ConvertHtml(lines)
