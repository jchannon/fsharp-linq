[<AutoOpen>]
module Restrictors

open System
open System.IO
open System.Text.Json

let linq1 () =
    let numbers = [| 5; 4; 1; 3; 9; 8; 6; 7; 2; 0 |]
    let filteredNumbers = numbers |> Array.filter (fun x -> x < 5)
    Console.WriteLine "Numbers <5 :"
    filteredNumbers |> Array.iter Console.WriteLine

let linq2 () =
    let products = getProductList ()
    let soldOutProducts = products |> List.filter (fun x -> x.UnitsInStock = 0)
    soldOutProducts |> List.iter (fun x -> printfn "%s is sold out!" x.ProductName)

let linq3 () =
    let products = getProductList ()
    let soldOutProducts = products |> List.filter (fun x -> x.UnitsInStock > 0 && x.UnitPrice > 3.00)
    soldOutProducts |> List.iter (fun x -> printfn "%s is in stock and costs more than 3.00" x.ProductName)

[<CLIMutable>]
type Order =
    { OrderId: int
      OrderDate: DateTimeOffset
      Total: Double }

[<CLIMutable>]
type Customer =
    { CustomerId: string
      CompanyName: string
      Address: string
      City: string
      Region: string
      PostalCode: string
      Country: string
      Phone: string
      Orders: System.Collections.Generic.List<Order> }

let getCustomerList () =
    let json = File.ReadAllText("customers.json")
    let settings = new JsonSerializerOptions()
    settings.PropertyNameCaseInsensitive <- true

    //could use https://www.nuget.org/packages/FSharp.SystemTextJson/ to prevent casting of list types and handling option types
    let customers = JsonSerializer.Deserialize<System.Collections.Generic.List<Customer>>(json, settings)
    List.ofSeq customers

let linq4 () =
    let customers = getCustomerList ()
    let waCustomers = customers |> List.filter (fun x -> x.Region = "WA")
    printfn "Customers from Washington and their orders:"
    waCustomers
    |> List.iter (fun x ->
        printfn "Customer %s %s" x.CustomerId x.CompanyName
        List.ofSeq x.Orders |> List.iter (fun y -> printfn "Order %i : %s" y.OrderId (y.OrderDate.ToString("O"))))
let linq5 () =
    let digits = [| "zero"; "one"; "two"; "three"; "four"; "five"; "six"; "seven"; "eight"; "nine" |]

    let filtereddigits =
        digits
        |> Array.mapi (fun x index -> index, x)
        |> Array.filter (fun (x, index) -> x.Length < index)
        |> Array.map fst
   
    filtereddigits |> Array.iter (fun x -> printfn "The word %s is shorter than its value" x)