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
