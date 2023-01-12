import { NumberInput } from '@angular/cdk/coercion';
import { Component, EventEmitter, Input, OnInit, Output, ViewChild } from '@angular/core';
import { MatPaginator, PageEvent } from '@angular/material/paginator';
import { faDiagramNext, faMoneyCheck } from '@fortawesome/free-solid-svg-icons';
import { end } from '@popperjs/core';
import { ProductRequestModel } from 'src/app/models/order.models';
import { Product } from 'src/app/services/interfaces/Product';
import { OrderService } from 'src/app/services/order-service/order.service';
import { ProductService } from 'src/app/services/product-service/product.service';

@Component({
  selector: 'app-order',
  templateUrl: './order.component.html',
  styleUrls: ['./order.component.css']
})
export class OrderComponent implements OnInit {
  
  productsArray: Product[] = [];
  accessoriesAndStreetwear: Product[] = [];
  product: Product | undefined
pageSize: NumberInput;
pageSizeOptions: number[] | readonly number[] | undefined;
  

  // pageEvent : any;
  // pageSlice = this.productsArray.slice(0, 10)
  // @ViewChild(MatPaginator)
  // paginator?: MatPaginator

  
  constructor(private productService: ProductService, ) { }
  

  
  ngOnInit(): void {
    this.productService.getAllProducts().subscribe(product => 
      { this.productsArray = product
      

      this.accessoriesAndStreetwear = this.productsArray.filter(x => x.typeOfProduct == 2 || x.typeOfProduct == 3);
      
      });



    // this.pageEvent = new PageEvent()
  }


  addToCart(product: Product) {
    this.productService.getProductById(product).subscribe(() =>
    (this.productsArray
      .find(p => p.id == product.id)));
      
      this.productService.addToCart(product);
    }

    // getPageIndex(){
    //   if (!this.pageEvent.pageIndex)
    //   {
    //     return 0;
    //   }
    //   else
    //   {
    //     return this.pageEvent.pageIndex;
    //   }
    // }
    // onPageChange(event: PageEvent) {
    //   console.log(event);
    //   console.log(event.pageIndex)
    //   let startIndex = event.pageIndex * event.pageSize;
    //   let endIndex = startIndex + event.pageSize;
    //   if (endIndex > this.productsArray.length) {
    //     endIndex = this.productsArray.length;
    //   }

    
    //   this.pageSlice = this.productsArray.slice(startIndex, endIndex);
    // } 
    
    
  
  }

  

  
  









