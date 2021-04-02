# st-sales-tax
Sales Taxes Problem

There are a variety of items for sale at a store. When a customer purchases items, they receive a receipt. The receipt
lists all of the items purchased, the sales price of each item (with taxes included), the total sales taxes for all items,
and the total sales price.

Basic sales tax applies to all items at a rate of 10% of the item’s list price, with the exception of books, food, and
medical products, which are exempt from basic sales tax. An import duty (import tax) applies to all imported items at
a rate of 5% of the shelf price, with no exceptions.

Write an application that takes input for shopping baskets and returns receipts in the format shown below, calculating
all taxes and totals correctly. When calculating the sales tax, round the value up to the nearest 5 cents. For example, if
a taxable item costs $5.60, an exact 10% tax would be $0.56, and the final price after adding the rounded tax of $0.60
should be $6.20.

---

## Examples
### Example 1
> **Input**
> 1 Book at 12.49
> 1 Book at 12.49
> 1 Music CD at 14.99
> 1 Chocolate bar at 0.85
> **Output**
> Book: 24.98 (2 @ 12.49)
> Music CD: 16.49
> Chocolate bar: 0.85
> Sales Taxes: 1.50
> Total: 42.32

### Example 2
> **Input**
> 1 Imported box of chocolates at 10.00
> 1 Imported bottle of perfume at 47.50
> **Output**
> Imported box of chocolates: 10.50
> Imported bottle of perfume: 54.65
> Sales Taxes: 7.65
> Total: 65.15

### Example 3
> **Input**
> 1 Imported bottle of perfume at 27.99
> 1 Bottle of perfume at 18.99
> 1 Packet of headache pills at 9.75
> 1 Imported box of chocolates at 11.25
> 1 Imported box of chocolates at 11.25
> **Output**
> Imported bottle of perfume: 32.19
> Bottle of perfume: 20.89
> Packet of headache pills: 9.75
> Imported box of chocolates: 23.70 (2 @ 11.85)
> Sales Taxes: 7.30
> Total: 86.53

---

## Explanation
The approach for the solution was to create 2 main classes, `ShoppingCart`, to handle the list of products and the receipt printing. And `Product`, to handle all the product properties and taxes calculation.

Considering the input is a string array the classes `ShoppingCartBuilder`, `ProductBuilder` and `ProductAdapter` helps with the initialization and conversion to the corresponding objects.

To calculate the corresponding tax,the *`ITax`* interface declares the  method for this, and `Tax` and `NoTax` classes, defines the proper behavior.

Some classes implements interfaces to keep abstraction and dependency to a basic level.

---

## Assumptions
* The input text is a string array
* Each string on the array have the following syntax:
```
    "1 book at 12.49"
    
    quantity: 1
    empty space
    product name: book
    empty space
    at
    empty space
    price: 12.49
```
* Quantity is always an int value greater than 0
* Price is a decimal value
* Imported products, the product name starts with **Imported**
* Products with tax exceptions the name can contain the following text: 
    *  book
    *  books
    *  chocolate
    *  chocolates
    *  pill
    *  pills
    *  medicine
* If the product have the same name and price will be grouped

---

## Execution
The code is a .Net Core Console Application. Running directly will show the examples defined early by default. 

If other input is required, a string array can be passed as an argument.

    dotnet run “1 Imported box of chocolates at 10.00” “1 Imported bottle of perfume at 47.50”

---

## Unit Testing
Xunit used for testing:
* Full functionality
    * Example 1 data
    * Example 2 data
    * Example 3 data
* `ProductAdapter` class
    * Handles string from array conversion to Product object
* `Product` class
    * Calculation of product price after taxes