import { Customer } from "../services/interfaces/Customer"
import { Product } from "../services/interfaces/Product"

export class ProductRequestModel{
    constructor(
        id : number,
        price : number,
        nameOfProduct : string,
        size : number,
        typeOfColors : number,
        typeOfProduct : number,
        image : string,
        productsLeft : number,
        description : string
    ){
        this.Id = id
        this.Price = price
        this.NameOfProduct = nameOfProduct
        this.TypeOfProduct = typeOfProduct
        this.Size = size
        this.TypeOfColors = typeOfColors
        this.Image = image
        this.ProductsLeft = productsLeft
        this.Description = description
    }
    Id : number
    Price : number
    NameOfProduct : string
    Size : number
    TypeOfColors : number
    TypeOfProduct
    Image : string
    ProductsLeft : number
    Description : string
}
export class OrderRequestModel{
    constructor(
        customerId : number,
        customer : Customer,
        price : number,
        productRequestModel : ProductRequestModel
    ){
        this.CustomerId = customerId
        this.Customer = customer
        this.Price = price
        this.ProductRequestModel = productRequestModel

    }
    CustomerId : number
    Customer : Customer
    Price : number
    ProductRequestModel : ProductRequestModel
}
