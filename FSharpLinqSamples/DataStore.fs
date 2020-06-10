[<AutoOpen>]
module DataStore

open System

type Product =
    { ProductId: string
      ProductName: string
      Category: string
      UnitPrice: Double
      UnitsInStock: int }

let getProductList () =
    [ { ProductId = "1"
        ProductName = "Chai"
        Category = "Beverages"
        UnitPrice = 19.00
        UnitsInStock = 39 }
      { ProductId = "2"
        ProductName = "Chang"
        Category = "Beverages"
        UnitPrice = 18.00
        UnitsInStock = 17 }
      { ProductId = "3"
        ProductName = "Aniseed Syrup"
        Category = "Condiments"
        UnitPrice = 10.00
        UnitsInStock = 13 }
      { ProductId = "4"
        ProductName = "Chef Anton's Cajun Seasoning"
        Category = "Condiments"
        UnitPrice = 22.00
        UnitsInStock = 53 }
      { ProductId = "5"
        ProductName = "Chef Anton's Gumbo Mix"
        Category = "Condiments"
        UnitPrice = 25.00
        UnitsInStock = 127 }
      { ProductId = "6"
        ProductName = "Sauerkraut"
        Category = "Produce"
        UnitPrice = 9.00
        UnitsInStock = 27 }
      { ProductId = "7"
        ProductName = "Alice Mutton"
        Category = "Meat/Poultry"
        UnitPrice = 36.00
        UnitsInStock = 0 } ]
