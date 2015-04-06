namespace FSharpening

open NUnit.Framework
open FsUnit
open HtmlAgilityPack
open System.Net
open System.Runtime.Serialization
open System.Diagnostics
open System.Xml
open System.Text
open System.IO

module HtmlToText = 

    [<Test>]
    let HtmlConvertTest () =    
        
        HtmlUtil.ConvertHtml("<p>Test<br>Two<p>") |> should equal "Test\r\nTwo"

    // Just a sample unit test to parse an html file
    [<Test>]
    let HtmlFileTest () =

        let readLines filePath = File.ReadAllLines(filePath)

        
        let htmlLines = readLines("../../assets/so.html")

        let result = Array.fold (fun acc elem -> acc + elem) "" htmlLines


        use sr = new StreamWriter("result.txt", false)
        
        sr.Write(HtmlUtil.ConvertHtml(result))
                
        1 |> should equal 1

