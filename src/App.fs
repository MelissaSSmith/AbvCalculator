module AbvCalculator

open Fable.Core
open Fable.Core.JsInterop
open Fable.Import
let Abv og fg = (og - fg) * 131.25

let TransformToFloat (e : string) = e |> float

let TransformToString r = r |> string

let calculateResult e1 e2  = 
    Abv (TransformToFloat e1) (TransformToFloat e2)
    |> TransformToString

let init() =
    let og = Browser.document.getElementById("og").innerText
    let fg = Browser.document.getElementById("fg").innerText
    let result = Browser.document.getElementById("standardAbv")
    result.innerText = calculateResult og fg

init()