namespace FSharpening

open System
open NUnit.Framework
open FsUnit

module CommandLine =

    let readIntInput() = 

        let input = Console.ReadLine()

        match Int32.TryParse(input) with
        | true, result -> printf "%d" result
        | _ -> printf "Invalid input"
