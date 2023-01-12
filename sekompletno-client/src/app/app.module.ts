import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppComponent } from './app.component';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { HomeComponent } from './components/home/home.component';
import { OrderItemComponent } from './components/order-item/order-item.component';
import { OrderComponent } from './components/order/order.component';
import { LoginComponent } from './components/login/login.component';
import { NavComponent } from './components/nav/nav.component';
import { RegisterComponent } from './components/register/register.component';
import { AuthService } from './services/auth-service/auth.service';
import { OrderService } from './services/order-service/order.service';
import { AppRoutingModule } from './app.routing.module';
import { HttpClient, HttpClientModule } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { ProductService } from './services/product-service/product.service';
import { ShoppingCartComponent } from './components/shopping-cart/shopping-cart.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { LayoutModule } from '@angular/cdk/layout';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatButtonModule } from '@angular/material/button';
import { MatSidenavModule } from '@angular/material/sidenav';
import { MatIconModule } from '@angular/material/icon';
import { MatListModule } from '@angular/material/list';
import { MatGridListModule } from '@angular/material/grid-list';
import { MatCardModule } from '@angular/material/card';
import { MatMenuModule } from '@angular/material/menu';
import {MatFormFieldModule} from '@angular/material/form-field'
import { MatInputModule } from "@angular/material/input";
import { MatNativeDateModule } from '@angular/material/core';
import {  MatDialogModule } from '@angular/material/dialog';
import { ProductComponent } from './components/order/product/product.component';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { MatPaginatorModule} from '@angular/material/paginator';
import { ShippingPolicyComponent } from './components/policies/shipping-policy/shipping-policy.component';
import { PrivacyPolicyComponent } from './components/policies/privacy-policy/privacy-policy.component';
import { TermsAndConditionsComponent } from './components/policies/terms-and-conditions/terms-and-conditions.component';
import { AboutComponent } from './components/about/about.component';
import { OrderSkateboardComponent } from './components/order/order-skateboard/order-skateboard.component';
import { OrderStreetwearComponent } from './components/order/order-streetwear/order-streetwear.component';
import { OrderAccessoriesComponent } from './components/order/order-accessories/order-accessories.component';
import { OrderAluminiumSkateboardComponent } from './components/order/order-aluminium-skateboard/order-aluminium-skateboard.component';
import { OrderWoodenSkateboardComponent } from './components/order/order-wooden-skateboard/order-wooden-skateboard.component';
import { NgxImageZoomModule } from 'ngx-image-zoom';


@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    OrderItemComponent,
    OrderComponent,
    LoginComponent,
    NavComponent,
    RegisterComponent,
    ShoppingCartComponent,
    ProductComponent,
    ShippingPolicyComponent,
    PrivacyPolicyComponent,
    TermsAndConditionsComponent,
    AboutComponent,
    OrderSkateboardComponent,
    OrderStreetwearComponent,
    OrderAccessoriesComponent,
    OrderAluminiumSkateboardComponent,
    OrderWoodenSkateboardComponent,
  ],
  imports: [
    BrowserModule,
    FontAwesomeModule,
    AppRoutingModule,
    HttpClientModule,
    ReactiveFormsModule,
    BrowserAnimationsModule,
    MatToolbarModule,
    MatButtonModule,
    MatSidenavModule,
    MatIconModule,
    MatListModule,
    MatGridListModule,
    MatCardModule,
    MatMenuModule,
    LayoutModule,
    MatFormFieldModule,
    MatInputModule,
    MatNativeDateModule,
    FormsModule,
    BrowserModule,
    MatDialogModule,
    NgbModule,
    MatPaginatorModule,
    MatDialogModule,
    NgxImageZoomModule
    
    
    
  ],
  providers: [
    AuthService,
    OrderService,
    ProductService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
