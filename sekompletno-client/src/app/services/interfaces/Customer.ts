import { OrderRequestModel } from "src/app/models/order.models";

export interface Customer {
    id: number
    username: string
    password: string
    firstName: string
    lastName: string
    fullName: string
    token: string
    orderList: OrderRequestModel

}