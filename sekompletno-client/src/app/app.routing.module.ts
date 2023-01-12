import { NgModule } from "@angular/core";
import { RouterModule, Routes } from "@angular/router";
import { AboutComponent } from "./components/about/about.component";

import { HomeComponent } from "./components/home/home.component";
import { LoginComponent } from "./components/login/login.component";
import { OrderAccessoriesComponent } from "./components/order/order-accessories/order-accessories.component";
import { OrderAluminiumSkateboardComponent } from "./components/order/order-aluminium-skateboard/order-aluminium-skateboard.component";
import { OrderSkateboardComponent } from "./components/order/order-skateboard/order-skateboard.component";
import { OrderStreetwearComponent } from "./components/order/order-streetwear/order-streetwear.component";
import { OrderWoodenSkateboardComponent } from "./components/order/order-wooden-skateboard/order-wooden-skateboard.component";
import { OrderComponent } from "./components/order/order.component";
import { ProductComponent } from "./components/order/product/product.component";
import { PrivacyPolicyComponent } from "./components/policies/privacy-policy/privacy-policy.component";
import { ShippingPolicyComponent } from "./components/policies/shipping-policy/shipping-policy.component";
import { TermsAndConditionsComponent } from "./components/policies/terms-and-conditions/terms-and-conditions.component";
import { RegisterComponent } from "./components/register/register.component";
import { ShoppingCartComponent } from "./components/shopping-cart/shopping-cart.component";

const routes: Routes =  [
    {path:'', redirectTo: "/home", pathMatch: 'full'},
    {path:'home', pathMatch: 'full', component: HomeComponent},
    {path:'login', pathMatch: 'full', component: LoginComponent},
    {path:'register', pathMatch: 'full', component: RegisterComponent},
    {path:'order', pathMatch: 'full', component: OrderComponent},
    {path:'order-skateboard', pathMatch: 'full', component: OrderSkateboardComponent},
    {path:'order-streetwear', pathMatch: 'full', component: OrderStreetwearComponent},
    {path:'order-aluminium-skateboard', pathMatch: 'full', component: OrderAluminiumSkateboardComponent},
    {path:'order-wooden-skateboard', pathMatch: 'full', component: OrderWoodenSkateboardComponent},
    {path:'order-accessories', pathMatch: 'full', component: OrderAccessoriesComponent},
    {path:'about', pathMatch: 'full', component: AboutComponent},
    {path:'order/product/:id', pathMatch: 'full', component: ProductComponent},
    {path:'shoppingCart', pathMatch: 'full', component: ShoppingCartComponent},
    {path:'shipping-policy', pathMatch: 'full', component: ShippingPolicyComponent},
    {path:'privacy-policy', pathMatch: 'full', component: PrivacyPolicyComponent},
    {path:'terms-and-conditions', pathMatch: 'full', component: TermsAndConditionsComponent},
    
    

]

@NgModule({
    imports: [RouterModule.forRoot(routes)],
    exports: [RouterModule]
})

export class AppRoutingModule   {}