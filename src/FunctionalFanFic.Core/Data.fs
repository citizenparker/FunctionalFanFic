(* 
  This approach to data storage TOTALLY sucks for a variety of reasons.
  It's appropriate only for prototyping.
  Don't try this at home, even if your parents are around.
*)
module Data

open System
open System.IO

let private getFileName (file:string) = String.Format (Config.FilePathFormat,file)

let readAll file parser filter =
  getFileName file
    |> File.ReadAllLines
    |> Array.toList
    |> List.map parser
    |> List.filter filter

let store file unParser value = 
  File.AppendAllText (getFileName file, unParser value)