import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { getJSON } from 'jquery';
import { find, Observable } from 'rxjs';
import { ProductComponent } from 'src/app/components/order/product/product.component';
import { OrderRequestModel, ProductRequestModel } from 'src/app/models/order.models';
import { environment } from 'src/environments/environment';
import { Product } from '../interfaces/Product';

@Injectable()
export class OrderService{
    constructor(private _httpClient: HttpClient) {}

    createOrder(model: OrderRequestModel,
                 ) : Observable<any> {

            
        let url = `${environment.apiServerBaseUrl}api/order/CreateOrder`;
        
        
        let parseDocument = JSON.stringify(model)
        JSON.parse(parseDocument);
        let headers = new HttpHeaders({
            "Content-Type" : "application/json; charset=utf-8",
            "Authorization" : `Bearer ${localStorage.getItem("token")}`
          });


        return this._httpClient.post(url, parseDocument, { headers, responseType:'text' });
    }


    private createHeaders(token: string) : HttpHeaders
    {
        return new HttpHeaders({
            'Content-Type' : 'application/json; charset=utf-8', 
            'Authorization' : `Bearer ${token}`
        })
    }
}