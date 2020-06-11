[<AutoOpen>]
module PartitioningOperators

let linq20 () =
    let numbers = [| 5; 4; 1; 3; 9; 8; 6; 7; 2; 0 |]
    let first3numbers = numbers |> Array.take 3
    printfn ""
    printfn "First 3 numbers:"
    first3numbers |> Array.iter (printfn "%i")

let linq21 () =
    let customers = getCustomerList ()

    let waCustomers =
        customers
        |> List.filter (fun x -> x.Region = "WA")
        |> List.collect (fun i1 -> List.ofSeq i1.Orders |> List.map (fun i2 -> (i1, i2)))
        |> List.map (fun x ->
            {| CustomerId = (fst x).CustomerId
               OrderId = (snd x).OrderId
               OrderDate = (snd x).OrderDate |})
        |> List.take 3
    printfn ""
    printfn "First 3 orders in WA"
    waCustomers |> List.iter (printfn "%A")

let linq22 () =
    let numbers = [| 5; 4; 1; 3; 9; 8; 6; 7; 2; 0 |]
    let first3numbers = numbers |> Array.skip 4
    printfn ""
    printfn "All but first 4 numbers:"
    first3numbers |> Array.iter (printfn "%i")

let linq23 () =
    let customers = getCustomerList ()

    let waCustomers =
        customers
        |> List.filter (fun x -> x.Region = "WA")
        |> List.collect (fun i1 -> List.ofSeq i1.Orders |> List.map (fun i2 -> (i1, i2)))
        |> List.map (fun x ->
            {| CustomerId = (fst x).CustomerId
               OrderId = (snd x).OrderId
               OrderDate = (snd x).OrderDate |})
        |> List.skip 2
    printfn ""
    printfn "All but first 2 orders in WA:"
    waCustomers |> List.iter (printfn "%A")

let linq24() =
    let numbers = [| 5; 4; 1; 3; 9; 8; 6; 7; 2; 0 |]
    let firstNumbersLessThan6 = numbers |> Array.takeWhile (fun x -> x < 6)
    printfn ""
    printfn "First numbers less than 6:"
    firstNumbersLessThan6 |> Array.iter (printfn "%i")
    
let linq26() =
    let numbers = [| 5; 4; 1; 3; 9; 8; 6; 7; 2; 0 |]
    let allButFirst3Numbers = numbers |> Array.skipWhile (fun x -> (x % 3 <> 0))
    printfn ""
    printfn "All elements starting from first element divisible by 3:"
    allButFirst3Numbers |> Array.iter (printfn "%i")