namespace ConfusionMatrix.Calculations

[<AutoOpen>]
module Simple =
    open NUnit.Framework

    let add x y = x + y

    [<Test>]
    let ``When 2 is added to 2 expect 4``() = 
        Assert.AreEqual(add 2 2, 2+2)


