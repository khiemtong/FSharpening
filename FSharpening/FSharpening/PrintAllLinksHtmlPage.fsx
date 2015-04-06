// This file is a script that can be executed with the F# Interactive.  
// It can be used to explore and test the library project.
// Note that script files will not be part of the project build.

#r "bin/Debug/HtmlAgilityPack.dll"

open HtmlAgilityPack
open System.Net
open System.Runtime.Serialization
open System.Diagnostics

let printHtmlNode (htmlNode:HtmlNode) = 
    printfn "%s" (htmlNode.GetAttributeValue("href", null))

// Prints a sequence n, using print function printFn
let printSeq n printFn = 
    Seq.iter printFn n

// Dynamic casting
let tryCast<'a> o = 
    match box o with
        | :? 'a as output -> Some output
        | _ -> None

let parseUrl (url:string) = 

    let wc = new WebClient()
    let lines = wc.DownloadString(url)


    let htmlDoc = new HtmlDocument();
    htmlDoc.LoadHtml(lines);

    let nodes = htmlDoc.DocumentNode.SelectNodes("//a[@href]");

    nodes |> tryCast<seq<HtmlNode>> |> Option.iter (fun it -> (printSeq it printHtmlNode))

parseUrl "http://google.com"