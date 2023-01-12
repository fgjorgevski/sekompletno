import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { MatDialog, MatDialogRef } from '@angular/material/dialog';
import { Router } from '@angular/router';
import { last } from 'rxjs';
import { RegisterRequestModel } from 'src/app/models/auth.models';
import { AuthService } from 'src/app/services/auth-service/auth.service';
import { Customer } from 'src/app/services/interfaces/Customer';
import { LoginComponent } from '../login/login.component';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent   {

  users : Customer[] = []
  usernameExist : boolean = false;
  hide = true;
  
    registerForm = new FormGroup({
      Username: new FormControl('', Validators.required),
      Password: new FormControl('', Validators.required),
      ConfirmPassword: new FormControl('', Validators.required),
      FirstName: new FormControl('', Validators.required),
      LastName: new FormControl('', Validators.required),
      Address: new FormControl('', Validators.required),
      City: new FormControl('', Validators.required),
      PhoneNumber: new FormControl("", Validators.required),
      Email: new FormControl('', [Validators.required, Validators.email]),
    })
  
    
    dialogRef: MatDialogRef<RegisterComponent> | undefined;

    constructor(private dialog: MatDialog,
                private _authService: AuthService,
                private _router: Router,
                ) {}
         
      
    
  
    onSubmit(){
  
  
      let username = this.registerForm.value.Username
      let password = this.registerForm.value.Password
      let confirmPassword = this.registerForm.value.ConfirmPassword
      let firstName = this.registerForm.value.FirstName
      let lastName = this.registerForm.value.LastName
      let address = this.registerForm.value.Address
      let city = this.registerForm.value.City
      let phonenumber = this.registerForm.value.PhoneNumber
      let email = this.registerForm.value.Email
  
      let number = Number(phonenumber)
      
      this.usernameExist = this.users.every(x => x.username == username);
      console.log(this.usernameExist)
    
      

      let registerRequestModel = new RegisterRequestModel(firstName!,lastName!,username!,password!,confirmPassword!,address!,city!,number,email!,)
      
      this._authService.getAllCustomers().subscribe((user) => {
        this.users = user;
        console.log(this.users)
      });



      this._authService.register(registerRequestModel).subscribe({
        next: data => console.log(data),
        error: err => {
          console.warn(err)
          console.log(this.usernameExist)
         
        },
        complete: () =>{
          this.closeDialog();
          this.openDialog()
          this._router.navigate(["/home"]), {relativeTo: this._router};
          console.log(registerRequestModel);
        }
      })
      
    }
    openDialog(){
      this.dialog.open(LoginComponent)  
    }
    
    closeDialog(){
      this.dialog.closeAll()
    }

   
  

}
