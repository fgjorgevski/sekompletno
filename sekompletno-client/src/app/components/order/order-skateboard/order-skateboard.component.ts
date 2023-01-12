import { Component, OnInit } from '@angular/core';
import { Product } from 'src/app/services/interfaces/Product';
import { ProductService } from 'src/app/services/product-service/product.service';

@Component({
  selector: 'app-order-skateboard',
  templateUrl: './order-skateboard.component.html',
  styleUrls: ['./order-skateboard.component.css']
})
export class OrderSkateboardComponent implements OnInit {

  productsArray: Product[] = [];
  skateboards: Product[] = [];

  constructor(private productService : ProductService) { }

  ngOnInit(): void {
    this.productService.getAllProducts().subscribe(product => 
      { this.productsArray = product

      this.skateboards = this.productsArray.filter(x => x.typeOfProduct == 1);
      });

    

  }

  addToCart(product: Product) {
    this.productService.getProductById(product).subscribe(() =>
    (this.productsArray
      .find(p => p.id == product.id)));
   
      this.productService.addToCart(product);
    }

}
