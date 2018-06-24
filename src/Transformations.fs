module Transformations

open Fable.Core
open System

[<Emit("isNaN(parseFloat($0)) ? null : parseFloat($0)  ")>]
let ParseFloat (e : obj) : float option = jsNative

let TransformToString r = r |> string

let TransformToDecimal e = 
    match ParseFloat e with
    | Some value -> value |> decimal
    | None -> 0.0m

let RoundDecimal (input : decimal) (precision: int) = 
    Math.Round(input, precision)

let RoundToPrecisonTwo x =
    RoundDecimal x 2

let RoundToPrecisonThree x =
    RoundDecimal x 3