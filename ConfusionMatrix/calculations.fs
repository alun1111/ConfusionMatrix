namespace ConfusionMatrix.Calculations

[<AutoOpen>]
module Simple =
    open NUnit.Framework

    let testData = [
        true,true;
        false,false;
        true,false;
        false,true;
        false,false
        true,true;
        false,false;
        true,true;
        true,true;
        false,false
        true,false;
        false,true;
        false,true;
        false,false;
        false,false
        ]

    let tn (point: bool * bool) =
        match point with
        | false,false -> 1
        | _ -> 0

    let tp (point: bool * bool) =
        match point with
        | true,true -> 1
        | _ -> 0

    let fn (point: bool * bool) =
        match point with
        | false,true -> 1
        | _ -> 0

    let fp (point: bool * bool) =
        match point with
        | true,false -> 1
        | _ -> 0

    let matchedSums tupleList matcher = tupleList |> List.map(fun tuple -> matcher tuple) |> List.sum

    let precision dataSet =
        let tp = decimal(matchedSums dataSet tp)
        let fp = decimal(matchedSums dataSet fp) 
        System.Math.Round(tp / (tp + fp), 3)

    let recall dataSet =
        let tp = decimal(matchedSums dataSet tp)
        let fn = decimal(matchedSums dataSet fn) 
        System.Math.Round(tp / (tp + fn), 3)

    [<Test>]
    let ``There should be 6 true negative``()=
        Assert.AreEqual(6m, decimal(matchedSums testData tn))

    [<Test>]
    let ``There should be 2 false positive``()=
        Assert.AreEqual(2m, decimal(matchedSums testData fp))

    [<Test>]
    let ``There should be 3 false negative``()=
        Assert.AreEqual(3m, decimal(matchedSums testData fn))

    [<Test>]
    let ``There should be 4 true positive``()=
        Assert.AreEqual(4m, decimal(matchedSums testData tp))

    [<Test>]
    let ``The precision should be: 0.667m``()=
        Assert.AreEqual(0.667m, precision testData)
    [<Test>]
    let ``The recall should be: 0.571m``()=
        Assert.AreEqual(0.571m, recall testData)
