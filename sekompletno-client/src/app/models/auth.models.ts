import { OrderRequestModel } from "./order.models"

export class RegisterRequestModel{
    constructor(
        firstname: string,
        lastname: string,
        username: string,
        password: string,
        confirmpassword: string,
        address: string, 
        city: string,
        phonenumber: number,
        email: string
    ){
        this.FirstName = firstname
        this.LastName = lastname
        this.Username = username 
        this.Password = password
        this.ConfirmPassword = confirmpassword
        this.Address = address
        this.City = city
        this.PhoneNumber = phonenumber
        this.Email = email
    }
    FirstName : string
    LastName : string
    Username : string
    Password : string
    ConfirmPassword : string 
    Address : string
    City : string 
    PhoneNumber : number
    Email : string
}
export class LoginRequestModel{
    constructor(username : string,
                password : string){
    this.Username = username
    this.Password = password
    }
    Password : string
    Username : string
}
export class CustomerModel{
    constructor(
        id: number,
        username: string,
        password: string,
        firstName: string,
        lastName: string,
        fullName: string,
        token: string,
        orderList: OrderRequestModel
    ){
        this.Id = id,
        this.Username = username,
        this.Password = password,
        this.FirstName = firstName,
        this.LastName = lastName,
        this.FullName = fullName,
        this.Token = token,
        this.OrderList = orderList

    }
    Id:number
    Username:string
    Password:string
    FirstName:string
    LastName:string
    FullName:string
    Token:string
    OrderList: OrderRequestModel
    
}