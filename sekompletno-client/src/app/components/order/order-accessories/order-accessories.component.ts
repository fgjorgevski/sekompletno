import { Component, OnInit } from '@angular/core';
import { Product } from 'src/app/services/interfaces/Product';
import { ProductService } from 'src/app/services/product-service/product.service';

@Component({
  selector: 'app-order-accessories',
  templateUrl: './order-accessories.component.html',
  styleUrls: ['./order-accessories.component.css']
})
export class OrderAccessoriesComponent implements OnInit {

  productsArray: Product[] = [];
  accessories: Product[] = [];

  constructor(private productService : ProductService) { }

  ngOnInit(): void {

    this.productService.getAllProducts().subscribe(product => 
      { this.productsArray = product
      
      console.log(this.productsArray)

      this.accessories = this.productsArray.filter(x => x.typeOfProduct == 3);
      
      console.log(this.accessories)
      });
  }

  
  addToCart(product: Product) {
    this.productService.getProductById(product).subscribe(() =>
    (this.productsArray
      .find(p => p.id == product.id)));
   
      this.productService.addToCart(product);
    }
}
