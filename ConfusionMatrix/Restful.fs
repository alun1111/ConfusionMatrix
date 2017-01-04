namespace ConfusionMatrix.Rest

[<AutoOpen>]
module Restful =
    open Newtonsoft.Json
    open Newtonsoft.Json.Serialization
    open Suave
    open Suave.Operators
    open Suave.Http
    open Suave.Successful
    open Suave.Filters

    type RestResource<'a> = {
        GetAll : unit -> 'a seq
    }

    let JSON v =
        let jsonSerializerSettings = new JsonSerializerSettings()
        jsonSerializerSettings.ContractResolver <- new CamelCasePropertyNamesContractResolver()

        JsonConvert.SerializeObject(v, jsonSerializerSettings)
        |> OK
        >=> Writers.setMimeType "application/json; charset=utf-8"

    let rest resourceName resource =
        let resourcePath = "/" + resourceName
        let getAll = warbler (fun _ -> resource.GetAll () |> JSON)
        path resourcePath >=> GET >=> getAll
