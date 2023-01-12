import { Component, OnInit } from '@angular/core';
import { Product } from 'src/app/services/interfaces/Product';
import { ProductService } from 'src/app/services/product-service/product.service';

@Component({
  selector: 'app-order-streetwear',
  templateUrl: './order-streetwear.component.html',
  styleUrls: ['./order-streetwear.component.css']
})
export class OrderStreetwearComponent implements OnInit {

  
  productsArray: Product[] = [];
  streetwear: Product[] = [];

  constructor(private productService : ProductService) { }

  ngOnInit(): void {
    this.productService.getAllProducts().subscribe(product => 
      { this.productsArray = product
      
      console.log(this.productsArray)

      this.streetwear = this.productsArray.filter(x => x.typeOfProduct == 2);
      
      });

    

  }

  addToCart(product: Product) {
    this.productService.getProductById(product).subscribe(() =>
    (this.productsArray
      .find(p => p.id == product.id)));
   
      this.productService.addToCart(product);
    }

}