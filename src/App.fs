module AbvCalculator

open Fable.Core
open Fable.Core.JsInterop
open Fable.Import.Browser
open AbvEquations
open Transformations

type IJQuery = 
    [<Emit("$0.click($1)")>]
    abstract OnClick : (obj -> unit) -> IJQuery

    [<Emit("$1.val()")>]
    abstract Value : (obj -> unit) -> string

module JQuery =

  [<Emit("window['$']($0)")>]
  let ready (handler: unit -> unit) : unit = jsNative
  
  [<Emit("$2.css($0, $1)")>]
  let css (prop: string) (value: string) (el: IJQuery) : IJQuery = jsNative
  
  [<Emit("$1.addClass($0)")>]
  let addClass (className: string) (el: IJQuery) : IJQuery = jsNative
  
  [<Emit("$1.click($0)")>]
  let click (handler: obj -> unit)  (el: IJQuery) : IJQuery = jsNative

  [<Emit("window['$']($0)")>]
  let select (selector: string) : IJQuery = jsNative

  [<Emit("$0.val()")>]
  let value (el: IJQuery) : string = jsNative

let calculateResult e1 e2  = 
    Abv (TransformToFloat e1) (TransformToFloat e2)
    |> TransformToString

let mainLoop ev =
    let og = JQuery.select("#og").Value 
    let fg = document.getElementById("fg").innerText
    console.log og
    let result = document.getElementById "standardAbv"
    result.innerText = calculateResult fg fg
    |> ignore

JQuery.select("#calculate")
    .OnClick(mainLoop)
    |> ignore