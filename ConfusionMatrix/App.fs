namespace ConfusionMatrix

module App =
    open Suave
    open Suave.Web
    open ConfusionMatrix.Calculations
    open ConfusionMatrix.Rest
    open ConfusionMatrix.Db

    [<EntryPoint>]
    let main argv =
        let runsWebPart = rest "runs" {
            GetAll = Db.getPairs 
        }

        startWebServer defaultConfig runsWebPart
        0

