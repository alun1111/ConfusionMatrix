namespace ConfusionMatrix.Db
open System.Collections.Generic

module Db =
    type pair = {
        Id : int
        Predicted : bool
        Actual : bool
    }

    let private pairStorage = new List<pair>()
    let getPairs () =
        let testDb = [
            {Id = 1; Predicted = false; Actual = true};
            {Id = 1; Predicted = true; Actual = true};
            {Id = 1; Predicted = true; Actual = false};
        ]
        pairStorage.AddRange(testDb)
        pairStorage |> Seq.map (fun p -> p)