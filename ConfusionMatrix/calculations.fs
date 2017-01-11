namespace ConfusionMatrix.Calculations

[<AutoOpen>]
module Simple =
    open NUnit.Framework

    let add x y = x + y

    [<Test>]
    let ``When 2 is added to 2 expect 4``() = 
        Assert.AreEqual(add 2 2, 2+2)

    let flags = [1;0;0;0;1;1;]
    let sumFlags = flags |> List.sumBy (fun i -> i)

    [<Test>]
    let ``Sum of three ones is 3``() = 
        Assert.AreEqual(sumFlags, 3)
