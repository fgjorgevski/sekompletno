import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { faBoltLightning, faCartPlus, faTimes } from '@fortawesome/free-solid-svg-icons';
import { Product } from 'src/app/services/interfaces/Product';
import { ProductService } from 'src/app/services/product-service/product.service';



@Component({
  selector: 'app-order-item',
  templateUrl: './order-item.component.html',
  styleUrls: ['./order-item.component.css']
})
export class OrderItemComponent implements OnInit {
  
  
  productsLeft : boolean = false
  
  @Input()  product: Product | undefined ;
  @Output() addItemToCart : EventEmitter<Product> = new EventEmitter
  faCartPlus = faCartPlus;
  
  constructor() { }

  ngOnInit(): void {
    if(this.product?.productsLeft! <= 0){
      this.productsLeft = false;
    }

  }

  addToCart(product: Product | undefined){

    this.addItemToCart?.emit(product);
  }
 
  

}

