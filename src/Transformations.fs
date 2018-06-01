module Transformations

open Fable.Core

[<Emit("isNaN(parseFloat($0)) ? null : parseFloat($0)  ")>]
let ParseFloat (e : string) : float option = jsNative

let TransformToString r = r |> string

let TransformToFloat (e: string) = 
    match ParseFloat e with
    | Some value -> value |> float
    | None -> 0.0

