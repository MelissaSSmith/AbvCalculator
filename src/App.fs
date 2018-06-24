module AbvCalculator

open Fable.Core
open Fable.Core.JsInterop
open Fable.Import.Browser
open AbvEquations
open Transformations

type IJQuery = 
    [<Emit("$0.click($1)")>]
    abstract OnClick : (obj -> unit) -> IJQuery

module JQuery =

  [<Emit("window['$']($0)")>]
  let ready (handler: unit -> unit) : unit = jsNative
  
  [<Emit("$2.css($0, $1)")>]
  let css (prop: string) (value: string) (el: IJQuery) : IJQuery = jsNative
  
  [<Emit("$1.click($0)")>]
  let click (handler: obj -> unit)  (el: IJQuery) : IJQuery = jsNative

  [<Emit("window['$']($0)")>]
  let select (selector: string) : IJQuery = jsNative

let calculateStandardAbv e1 e2  = 
    Abv (TransformToDecimal e1) (TransformToDecimal e2)
    |> RoundToPrecisonThree
    |> TransformToString

let calculateAlternateAbv e1 e2  = 
    AlternateAbv (TransformToDecimal e1) (TransformToDecimal e2)
    |> RoundToPrecisonThree
    |> TransformToString

let calculateTotalCalories e1 e2  = 
    TotalCal (TransformToDecimal e1) (TransformToDecimal e2)
    |> RoundToPrecisonTwo
    |> TransformToString

let mainLoop ev =
    let og = document.getElementById("og")?value
    let fg = document.getElementById("fg")?value
    document.getElementById("standardAbv")?innerHTML <- calculateStandardAbv og fg
    document.getElementById("alternateAbv")?innerHTML <- calculateAlternateAbv og fg
    document.getElementById("totalCarbs")?innerHTML <- calculateTotalCalories og fg
    |> ignore

JQuery.select("#calculate")
    .OnClick(mainLoop)
    |> ignore