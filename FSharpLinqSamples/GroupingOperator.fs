[<AutoOpen>]
module GroupingOperators

let linq40 () =
    let numbers = [| 5; 4; 1; 3; 9; 8; 6; 7; 2; 0 |]
    let numberGroups = numbers |> Array.groupBy (fun x -> x % 5)
    printfn ""
    numberGroups
    |> Array.iter (fun x ->
        printfn "Numbers with a remainder of %i when divided by 5:" (fst x)
        (snd x) |> Array.iter (printfn "%i"))

let linq41 () =
    let words = [| "blueberry"; "chimpanzee"; "abacus"; "banana"; "apple"; "cheese" |]
    let wordGroups = words |> Array.groupBy (fun x -> string x.[0])
    wordGroups
    |> Array.iter (fun (x, y) ->
        printfn "Words that start with the letter %s:" x
        (y) |> Array.iter (printfn "%s"))


let linq42 () =
    let products = getProductList ()
    let orderGroups = products |> List.groupBy (fun x -> x.Category)
    printfn ""
    orderGroups
    |> List.iter (fun (category, products) ->
        printfn "%s:" category
        products |> List.iter (printfn "%A"))

let linq43 () =
    let customers = getCustomerList ()
    let customerOrderGroups =
        customers |> List.map (fun x ->
                         {| CompanyName = x.CompanyName
                            YearGroups =
                                (if isNull x.Orders then List.empty<Order> else List.ofSeq x.Orders
                                 |> List.groupBy (fun x -> x.OrderDate.Year))
                                |> List.map (fun (year, orders) ->
                                    {| Year = year
                                       MonthGroups = orders |> List.groupBy (fun x -> x.OrderDate.Month) |}) |})
    printfn ""
    printfn "%A" customerOrderGroups
