import { Component, OnInit, ViewChild } from '@angular/core';
import { faThumbsDown } from '@fortawesome/free-solid-svg-icons';
import { OwlOptions } from 'ngx-owl-carousel-o';
import { AuthService } from 'src/app/services/auth-service/auth.service';
import { Customer } from 'src/app/services/interfaces/Customer';
import { Product } from 'src/app/services/interfaces/Product';
import { ProductService } from 'src/app/services/product-service/product.service';
import { Back, Power1,   } from "gsap";
import { AnimateService } from 'ngx-owl-carousel-o/lib/services/animate.service';
import { animate, state, style, transition, trigger } from '@angular/animations';
import { NgbCarousel, NgbSlideEvent, NgbSlideEventSource } from '@ng-bootstrap/ng-bootstrap';
import { Router } from '@angular/router';


@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css'],
  animations:[
      trigger('fadeOut', [
        transition('void => *',[
          style({  transform: 'translateY(-20px)', opacity: 0}),
          animate(2000, style({ transform: 'translateY(50px)', opacity: 1 }))
        ])
      ])
  ]
})
export class HomeComponent implements OnInit {


  public currentCustomer : Customer | undefined
  public arrOfProduct : Product[] = []
  public arrOfImages : string[] = []

 


  

  constructor(private _userService : AuthService, 
              private _productService : ProductService,
              private _router : Router) { }

  ngOnInit(): void {
    this._userService.getAllCustomers().subscribe(
      customer =>{
        this.currentCustomer = customer

        this._productService.getAllProducts().subscribe((prod) =>{
          this.arrOfProduct = prod
          });
        })
        
        
      }
      
      
  }
   


