import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { faCartShopping, faGears, faRightToBracket } from '@fortawesome/free-solid-svg-icons';
import { AuthService } from 'src/app/services/auth-service/auth.service';
import { Customer } from 'src/app/services/interfaces/Customer';
import { ProductService } from 'src/app/services/product-service/product.service';
import { MatDialog } from "@angular/material/dialog";
import { LoginComponent } from '../login/login.component';
import { RegisterComponent } from '../register/register.component';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css']
})
export class NavComponent implements OnInit {
  
  public totalItems : number = 0;
  isAdmin : boolean = false;
  faCartShopping = faCartShopping
  faRightToBracket = faRightToBracket
  faGears = faGears
  token : string = ""
  isLogged : boolean = false
  dialogOpened : boolean = false;

  public curentCustomer : Customer | undefined  
  
  constructor(private productService : ProductService,
              private _router : Router,
              private authService : AuthService,
              private dialog : MatDialog) { 

  }

  ngOnInit(): void {

    this.authService.getAllCustomers().subscribe(customer =>{
      let user = this.findUser(customer)
      console.log(user)
      this.curentCustomer = user
    })


    this.productService.getProductsFromList()
    .subscribe(res =>{
      this.totalItems = res.length
      })

      let token = localStorage.getItem("token")
    if(!token){
      this.isLogged = false
    }else{
      // this.isHeAdmin()
      this.isLogged = true
      // console.log(this.isAdmin)
    }
  
  
    
  }
 

  logOut(){
    localStorage.clear()
    this.isAdmin = false;
    window.location.reload()
    this._router.navigate(["/home"]), {relativeTo: this._router}
  }

//   isHeAdmin(): boolean{
// // ================================================
//     let id = localStorage.getItem('id')
//     let parsedId = Number(id);
//     console.log(parsedId)

//     console.log(this.curentCustomer)
//     if(parsedId == 1){
//       return this.isAdmin = true;
//     }
//     console.log('false')
    
//     return false;
//     // ================================================================
//   }

  openDialog(){
    if(this.dialog != null){
      this.dialog.closeAll();
    }
    this.dialog.open(LoginComponent)
  }
  openRegisterDialog(){
    if(this.dialog != null){
      this.dialog.closeAll();
    }
      this.dialogOpened = true;
      this.dialog.open(RegisterComponent)
  }
  
  private findUser(arrOfCustomers: Customer[] | any): Customer {
    let id = localStorage.getItem("id")
    let parsedId = +id!
    if (parsedId == null || parsedId == 0) {
      console.warn("please login")
    }
    let customer = arrOfCustomers.find((x: { id: number; }) => x.id == parsedId)
    return customer;
  }

}
