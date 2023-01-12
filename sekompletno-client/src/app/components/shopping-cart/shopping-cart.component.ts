import { InputModalityDetector } from '@angular/cdk/a11y';
import { createInjectableType } from '@angular/compiler';
import { Component, Injectable, Input, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { Router } from '@angular/router';
import { parse } from '@fortawesome/fontawesome-svg-core';
import { identity } from 'rxjs';
import { CustomerModel } from 'src/app/models/auth.models';
import { OrderRequestModel, ProductRequestModel } from 'src/app/models/order.models';
import { AuthService } from 'src/app/services/auth-service/auth.service';
import { Customer } from 'src/app/services/interfaces/Customer';
import { Product } from 'src/app/services/interfaces/Product';
import { OrderService } from 'src/app/services/order-service/order.service';
import { ProductService } from 'src/app/services/product-service/product.service';
import { LoginComponent } from '../login/login.component';
import { OrderItemComponent } from '../order-item/order-item.component';
import { OrderComponent } from '../order/order.component';

@Component({
  selector: 'app-shopping-cart',
  templateUrl: './shopping-cart.component.html',
  styleUrls: ['./shopping-cart.component.css']
})
export class ShoppingCartComponent implements OnInit {


  products: Product[] = []
  isArrayEmpty: boolean = true
  users: Customer[] = []
  orderCompleted: boolean | any = false
  
  
  loggedUser: Customer | any
  isUserLogged : boolean = false
  tottalPrice: number | any

  serverMessaage: string | any = ""

  token: string | any = "";
  constructor(private productService: ProductService,  
    private orderService: OrderService,
    private authService: AuthService,
    private _router: Router,
    private dialog : MatDialog
  ) {
  }

  ngOnInit(): void {
    this.productService.getProductsFromList()
      .subscribe(res => {
        this.products = res

        if (this.products.length > 0) {
          this.isArrayEmpty = false
        }

        this.authService.getAllCustomers().subscribe((user) => {
          this.users = user;
          this.loggedUser = this.findUser(this.users)
        })
      })
      this.tottalPrice = this.productService.getTotalPrice()

  }

  buyProducts() {
    for (let index = 0; index < this.products.length; index++) {

      let product = new ProductRequestModel(this.products[index].id,this.products[index].price,this.products[index].nameOfProduct,this.products[index].size,this.products[index].typeOfColors,
                                            this.products[index].typeOfProduct,this.products[index].image,this.products[index].productsLeft,this.products[index].description)

      let order = new OrderRequestModel(this.loggedUser.id, this.loggedUser, this.tottalPrice, product)
      console.log(this.products)


      this.orderService.createOrder(order).subscribe({
        next: data => {
          console.log(data);
          this.orderCompleted = true
          console.log(data)
        },
        error: (err) =>{
          console.error(err)
        },
        complete: () => {
          this.orderCompleted = true
          console.log(this.orderCompleted)
          this._router.navigate(['/home'])
        }
      })
    }
  }

  

  onDelete(){

  }
  
  
  private findUser(arrOfCustomers: Customer[] | any): Customer {
    let id = localStorage.getItem("id")
    let parsedId = +id!
    if (parsedId == null || parsedId == 0) {
      this.isUserLogged = true
      console.warn("please login")
    }
    let customer = arrOfCustomers.find((x: { id: number; }) => x.id == parsedId)
    return customer;
  }
   openDialog(){
    this.dialog.open(LoginComponent);
  }

  
}