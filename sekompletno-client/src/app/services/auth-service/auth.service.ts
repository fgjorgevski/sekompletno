import { Injectable } from '@angular/core';
import { HttpClient } from "@angular/common/http";
import { LoginRequestModel, RegisterRequestModel } from 'src/app/models/auth.models';
import { BehaviorSubject, map, Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Customer } from '../interfaces/Customer';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  public users : any = []
  public userList = new BehaviorSubject<any>([])
  constructor(private _httpClient: HttpClient) { }

  register(model: RegisterRequestModel): Observable<any> {
    let url = `${environment.apiServerBaseUrl}api/customer/register`;
    return this._httpClient.post<any>(url, model);
  }

  login(model: LoginRequestModel): Observable<any> {
    let url = `${environment.apiServerBaseUrl}api/customer/authenticate`
    this.users.push(model)
    this.userList.next(this.users);

    return this._httpClient.post<any>(url, model)
    
  }
  
  getAllCustomers(): Observable<any>{
    let url = `${environment.apiServerBaseUrl}api/customer/getallusers`;
    return this._httpClient.get<any>(url)
  }
  getUserById(customer: Customer): Observable<any>{
    let url = `${environment.apiServerBaseUrl}api/customer/getuserbyid?=${customer.id }`;
    return this._httpClient.get<Customer>(url)
  }
  getUsers(){
    return this.userList.asObservable();
  }
  


}
