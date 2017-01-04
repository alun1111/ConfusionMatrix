namespace SuaveRestApi.Rest
open Newtonsoft.Json.FSharp
[<AutoOpen>]
module RestFul =
    type RestResource<'a> = {
        GetAll : unit -> 'a seq
    }
    // 'a -> WebPart
    let JSON v =
      let jsonSerializerSettings = new JsonSerializerSettings()
      jsonSerializerSettings.ContractResolver <- new CamelCasePropertyNamesContractResolver()

      JsonConvert.SerializeObject(v, jsonSerializerSettings)
      |> OK
      >=> Writers.setMimeType "application/json; charset=utf-8"


