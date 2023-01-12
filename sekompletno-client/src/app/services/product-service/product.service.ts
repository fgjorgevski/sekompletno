import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Product } from '../interfaces/Product';
import {HttpClient, HttpHeaders} from '@angular/common/http'
import { ProductRequestModel } from 'src/app/models/order.models';

@Injectable({
  providedIn: 'root'
})
export class ProductService {


  public cartItemList : any =[]
  public productList = new BehaviorSubject<any>([]);


  constructor(private _httpClient:HttpClient) {
   }

  addProductToDb(productRequestModel: ProductRequestModel): Observable<Product>{
    let url = `${environment.apiServerBaseUrl}api/product/CreateProduct`;
    this.cartItemList.push(productRequestModel);
    this.productList.next(this.cartItemList);
    return this._httpClient.post<Product>(url, productRequestModel);
    
  }

  getAllProducts(): Observable<Product[]>{

    let url = `${environment.apiServerBaseUrl}api/product/GetAllProducts`;
    return this._httpClient.get<Product [] >(url)
    

  }

  getProductById(product : Product): Observable<Product>{
    let url = `${environment.apiServerBaseUrl}api/product/GetProductById?id=${product.id}`;
    return this._httpClient.get<Product>(url)
  }
  
  addToCart(product : Product){
    if (this.cartItemList.indexOf(product) !== -1) {
      alert("product exist")
      return false
    }
    else{
      this.cartItemList.push(product);
      this.productList.next(this.cartItemList);
      console.log(this.cartItemList)
      
      return true
    }
  }
  

  getProductsFromList(){
    return this.productList.asObservable()
  }
  
  deleteProductFromDb(id : number) : Observable<any>{
    let url = `${environment.apiServerBaseUrl}api/product/GetProductById?id=${id}`;
    return this._httpClient.delete<any>(url);
    
  }
  deleteProductFromArray(id : number){
    
  }

  getTotalPrice() : number{
    let total = 0;
    this.cartItemList.map((p : any) =>{
      total += p.price
    })
    return total
  }

}
