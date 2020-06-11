[<AutoOpen>]
module PartitioningOperators

let linq20 () =
    let numbers = [| 5; 4; 1; 3; 9; 8; 6; 7; 2; 0; |]
    let first3Numbers = numbers |> Array.take 3
    printfn ""
    printfn "First 3 numbers:"
    first3Numbers |> Array.iter (printfn "%i")
