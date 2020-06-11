[<AutoOpen>]
module OrderingOperators

open System

let linq28 () =
    let words = [| "cherry"; "apple"; "blueberry" |]
    let sortedWords = words |> Array.sort
    printfn ""
    printfn "The sorted list of words"
    sortedWords |> Array.iter (printfn "%s")

let linq29 () =
    let words = [| "cherry"; "apple"; "blueberry" |]
    let sortedWords = words |> Array.sortBy (fun x -> x.Length)
    printfn ""
    printfn "The sorted list of words (by length):"
    sortedWords |> Array.iter (printfn "%s")

let linq30 () =
    let products = getProductList ()
    let sortedProducts = products |> List.sortBy (fun x -> x.ProductName)
    printfn ""
    printfn "The sorted list of products:"
    sortedProducts |> List.iter (printfn "%A")

let linq31 () =
    let words = [| "aPPLE"; "AbAcUs"; "bRaNcH"; "BlUeBeRrY"; "ClOvEr"; "cHeRry" |]
    let sortedWords = words |> Array.sortWith (fun x y -> String.Compare(x, y, StringComparison.OrdinalIgnoreCase))
    printfn ""
    printfn "The sorted list of words case insensitive"
    sortedWords |> Array.iter (printfn "%s")

let linq32 () =
    let doubles = [| 1.7; 2.3; 1.9; 4.1; 2.9 |]
    let sortedDoubles = doubles |> Array.sortDescending
    printfn ""
    printfn "The doubles from highest to lowest:"
    sortedDoubles |> Array.iter (printfn "%A")

let linq36 () =
    let words = [| "aPPLE"; "AbAcUs"; "bRaNcH"; "BlUeBeRrY"; "ClOvEr"; "cHeRry" |]

    let sortedWords =
        words
        |> Array.sortWith (fun x y -> String.Compare(x, y, StringComparison.OrdinalIgnoreCase))
        |> Array.sortBy (fun x -> x.Length)
    printfn ""
    printfn "The sorted list of words case insensitive"
    sortedWords |> Array.iter (printfn "%s")

let linq37 () =
    let products = getProductList ()

    let sortedProducts =
        query {
            for p in products do
                sortBy p.Category
                thenByDescending p.UnitPrice
                select p
        }

    let fpp =
        products
        |> List.map (fun x -> (x.Category, x.UnitPrice))
        |> List.sortByDescending (fun (cat, price) -> (price, cat))

    printfn ""
    printfn "The sorted list of products:"
    sortedProducts |> Seq.iter (printfn "%A")
    fpp |> Seq.iter (printfn "%A")