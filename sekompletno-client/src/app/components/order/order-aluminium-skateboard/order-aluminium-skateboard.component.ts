import { Component, OnInit } from '@angular/core';
import { Product } from 'src/app/services/interfaces/Product';
import { ProductService } from 'src/app/services/product-service/product.service';

@Component({
  selector: 'app-order-aluminium-skateboard',
  templateUrl: './order-aluminium-skateboard.component.html',
  styleUrls: ['./order-aluminium-skateboard.component.css']
})
export class OrderAluminiumSkateboardComponent implements OnInit {

  productsArray: Product[] = [];
  aluminiumSkateboards: Product[] = [];

  constructor(private productService : ProductService) { }

  ngOnInit(): void {
    this.productService.getAllProducts().subscribe(product => 
      { this.productsArray = product
      
      console.log(this.productsArray)

      this.aluminiumSkateboards = this.productsArray.filter(x => x.typeOfProduct == 1 || x.nameOfProduct == "BANZAI OG ALUMINIUM SKATEBOARD") ;
      
      console.log(this.aluminiumSkateboards)
      });

    

  }

  addToCart(product: Product) {
    this.productService.getProductById(product).subscribe(() =>
    (this.productsArray
      .find(p => p.id == product.id)));
   
      this.productService.addToCart(product);
    }

}