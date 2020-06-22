[<AutoOpen>]
module Array

    let tryHeadInt (ls: array<'a>) =
        let res = ls |> Array.tryHead
        match res with
        | Some x -> x
        | None -> 0