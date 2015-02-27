namespace GameOfLife.UnitTests.FSharp

open NUnit.Framework

type public Cell() = 
    member this.IsAlive = false



type public World() = 
    member this.Cells = new [3,3]


[<TestFixture>]
type CellTests() = 
    member this.X = "F#"

    [<Test>]
    member this.SumTest() = 
        let sum = 1 + 1
        Assert.AreEqual(sum,2)

    [<Test>]
    member this.World_WhenEvolves_DeadCellWith0NeighboursStaysDead() =         
        let cell = new Cell()
        Assert.IsFalse(cell.IsAlive)
        




