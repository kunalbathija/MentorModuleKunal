import { NgModule } from "@angular/core";
import { RouterModule, Routes } from "@angular/router";
import { CartComponent } from "./cart/cart.component";
import { ProductsComponent } from "./products/products.component";

const appRoutes: Routes = [
    {path: '', component: ProductsComponent, pathMatch: 'full'},
    {path: 'products', component: ProductsComponent},
    {path: 'cart', component: CartComponent},
    {path: '**', redirectTo: '/products'}
]

@NgModule({
    imports: [RouterModule.forRoot(appRoutes)],
    exports: [RouterModule]
})
export class AppRoutingModule{}