import { Component, OnInit } from '@angular/core';
import { Product } from 'src/app/services/interfaces/Product';
import { ProductService } from 'src/app/services/product-service/product.service';

@Component({
  selector: 'app-order-wooden-skateboard',
  templateUrl: './order-wooden-skateboard.component.html',
  styleUrls: ['./order-wooden-skateboard.component.css']
})
export class OrderWoodenSkateboardComponent implements OnInit {

  constructor(private productService : ProductService) { }
  
  productsArray: Product[] = [];
  woodenSkateboards: Product[] = [];

  ngOnInit(): void {
    this.productService.getAllProducts().subscribe(product => 
      { this.productsArray = product
      
      console.log(this.productsArray)

      this.woodenSkateboards = this.productsArray.filter(x => x.typeOfProduct == 1 && x.nameOfProduct != "BANZAI OG ALUMINIUM SKATEBOARD" );
      
      });

    

  }

  addToCart(product: Product) {
    this.productService.getProductById(product).subscribe(() =>
    (this.productsArray
      .find(p => p.id == product.id)));
   
      this.productService.addToCart(product);
    }

}