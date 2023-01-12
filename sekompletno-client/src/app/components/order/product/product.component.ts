import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { Product } from 'src/app/services/interfaces/Product';
import { ProductService } from 'src/app/services/product-service/product.service';

@Component({
  selector: 'app-product',
  templateUrl: './product.component.html',
  styleUrls: ['./product.component.css']
})
export class ProductComponent implements OnInit {

  product: Product | undefined
  productId: number | undefined
  products: Product[] = []

  image : string | any

  productsLeft : number | any
  typeOfProduct : number | any

  similarProducts : Product[] = [];

  data : any = []
  
  

  constructor(private activatedRoute: ActivatedRoute,
    private productService: ProductService) { }
    
    
    ngOnInit(): void {
    let parseNumber = String(this.productId)
    parseNumber = this.activatedRoute.snapshot.paramMap.get("id")!

    this.productService.getAllProducts().subscribe((products) => {
      this.products = products
      let toNumber = Number(parseNumber)
      this.similarProducts = this.products.filter(x => x.typeOfProduct == 1);

      this.product = this.products.find(x => x.id == toNumber)

      this.productsLeft = this.product?.productsLeft

      this.image = this.product?.image
      this.typeOfProduct = this.product?.typeOfProduct
      
      console.log(this.product)
      
    })

    

    }

  

  addToCart() {
    console.log(this.data)

    let size = this.data[0]
    let sizeToNumber : any = Number(size);

    sizeToNumber = this.product?.size

    
      this.productService.addToCart(this.product!);
    }

  }
