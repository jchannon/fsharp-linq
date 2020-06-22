[<AutoOpen>]
module SetOperators

let linq46 () =
    let factorsOf300 = [| 2; 2; 3; 5; 5 |]
    let g = factorsOf300 |> Array.distinct

    let uniqueFactors = factorsOf300 |> Array.distinct
    printfn ""
    printfn "Prime factors of 300:"
    uniqueFactors |> Array.iter (printfn "%i")


let extensiontest () =
    let numbers = [|1;2;3;|]
    let nonumbers = Array.empty<int>
    let first = numbers |> Array.tryHeadInt
    printfn "%i" first
    let first = nonumbers |> Array.tryHeadInt
    printfn "%i" first
    let first = nonumbers |> Array.tryHead |> Option.defaultValue 0
    printfn "%i" first