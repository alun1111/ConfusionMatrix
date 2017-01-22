namespace ConfusionMatrix.Calculations

[<AutoOpen>]
module Simple =
    open NUnit.Framework

    let dualFlags = [true,true;false,false;true,false;false,true;false,false]

    let trueNegative (point: bool * bool) =
        match point with
        | false,false -> 1
        | _ -> 0

    let truePositive (point: bool * bool) =
        match point with
        | true,true -> 1
        | _ -> 0

    let falseNegative (point: bool * bool) =
        match point with
        | false,true -> 1
        | _ -> 0

    let falsePositive (point: bool * bool) =
        match point with
        | true,false -> 1
        | _ -> 0

    let sumOfMatchedTuples matcher = dualFlags |> List.map(fun x -> matcher x) |> List.sum
    
    let sumOfTrueNegative = sumOfMatchedTuples trueNegative 
    let sumOfTruePositive = sumOfMatchedTuples truePositive 
    let sumOfFalseNegative = sumOfMatchedTuples falseNegative 
    let sumOfFalsePositive = sumOfMatchedTuples falsePositive 

    [<Test>]
    let ``There should be two true negative``()=
        Assert.AreEqual(sumOfTrueNegative, 2)

    [<Test>]
    let ``There should be one false positive``()=
        Assert.AreEqual(sumOfFalsePositive, 1)

    [<Test>]
    let ``There should be one false negative``()=
        Assert.AreEqual(sumOfFalseNegative, 1)

    [<Test>]
    let ``There should be one true positive``()=
        Assert.AreEqual(sumOfTruePositive, 1)
