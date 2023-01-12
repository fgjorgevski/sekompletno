import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { MatDialog } from '@angular/material/dialog';
import { Router } from '@angular/router';
import { LoginRequestModel } from 'src/app/models/auth.models';
import { AuthService } from 'src/app/services/auth-service/auth.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent  {
  
  hide: any;
  isLogged : boolean | undefined = true
  matdialogclose : boolean = false


  loginForm = new FormGroup({
    Username: new FormControl('', Validators.required),
    Password: new FormControl('', Validators.required)
  })
  constructor(private _authService: AuthService,
              private _router: Router,
              private dialog : MatDialog) { }


  closeDialog(){
    this.dialog.closeAll()
  }              
  onSubmit(){
    let username = this.loginForm.value.Username
    let password = this.loginForm.value.Password

    let loginRequestModel = new LoginRequestModel(username!, password!)

    this._authService.login(loginRequestModel).subscribe({
      next: data => {
        localStorage.setItem("id", data.id),
        localStorage.setItem("token", data.token)
      },
      error: err => {this.isLogged = false},
      complete:() =>{
        this.closeDialog()
        this._router.navigate(['/home']),{relativeTo: this._router}
      }

    })
  }    

}
