[<AutoOpen>]
module ProjectionOperators

let linq6 () =
    let numbers = [| 5; 4; 1; 3; 9; 8; 6; 7; 2; 0 |]
    let numsPlusOne = numbers |> Array.map (fun x -> x + 1)
    printfn ""
    printfn "Numbers + 1:"
    numsPlusOne |> Array.iter (fun x -> printfn "%i" x)

let linq7 () =
    let products = getProductList ()
    let productNames = products |> List.map (fun x -> x.ProductName)
    printfn ""
    printfn "Product Names:"
    productNames |> List.iter (fun x -> printfn "%s" x)

let linq8 () =
    let numbers = [| 5; 4; 1; 3; 9; 8; 6; 7; 2; 0 |]
    let strings = [| "zero"; "one"; "two"; "three"; "four"; "five"; "six"; "seven"; "eight"; "nine" |]
    let textNums = numbers |> Array.map (fun x -> strings.[x])
    printfn ""
    printfn "Number strings:"
    textNums |> Array.iter (fun x -> printfn "%s" x)

let linq9 () =
    let words = [| "aPPLE"; "BlUeBeRrY"; "cHeRry" |]
    let upperLowerWords =
        words |> Array.map (fun x ->
                     {| Upper = x.ToUpper()
                        Lower = x.ToLower() |})
    upperLowerWords |> Array.iter (fun x -> printfn "Uppercase: %s, Lowercase: %s" x.Upper x.Lower)

let linq10 () =
    let numbers = [| 5; 4; 1; 3; 9; 8; 6; 7; 2; 0 |]
    let strings = [| "zero"; "one"; "two"; "three"; "four"; "five"; "six"; "seven"; "eight"; "nine" |]
    let digitOddEvens =
        numbers |> Array.map (fun x ->
                       {| Digit = strings.[x]
                          Even = x % 2 = 0 |})
    digitOddEvens |> Array.iter (fun x -> printfn "The digit %s is %s." x.Digit (if x.Even then "even" else "odd"))

let linq11 () =
    let products = getProductList ()
    let productInfos =
        products |> List.map (fun x ->
                        {| ProductName = x.ProductName
                           Category = x.Category
                           Price = x.UnitPrice |})
    printfn ""
    printfn "Product Info:"
    productInfos |> List.iter (fun x -> printfn "%s is in the category %s and costs %f per unit." x.ProductName x.Category x.Price)

let linq12() =
    let numbers = [| 5; 4; 1; 3; 9; 8; 6; 7; 2; 0 |]
    let numsInPlace = numbers |> Array.mapi (fun index x -> {|Num = x; InPlace = x = index|})
    printfn ""
    printfn "Number: In-place?"
    numsInPlace |> Array.iter (fun x-> printfn "%i : %b" x.Num x.InPlace)

let linq13() =
    let numbers = [| 5; 4; 1; 3; 9; 8; 6; 7; 2; 0 |]
    let strings = [| "zero"; "one"; "two"; "three"; "four"; "five"; "six"; "seven"; "eight"; "nine" |]
    let textNums = numbers |> Array.choose (fun x -> if x < 5 then Some strings.[x] else None)
    printfn ""
    printfn "Numbers < 5"
    textNums |> Array.iter (fun x-> printfn "%s" x)