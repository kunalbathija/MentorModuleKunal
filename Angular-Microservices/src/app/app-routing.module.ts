import { NgModule } from "@angular/core";
import { RouterModule, Routes } from "@angular/router";
import { AddProductComponent } from "./add-product/add-product.component";
import { CartComponent } from "./cart/cart.component";
import { ProductsComponent } from "./products/products.component";
import { StatusComponent } from "./status/status.component";

const appRoutes: Routes = [
    {path: '', component: ProductsComponent, pathMatch: 'full'},
    {path: 'products', component: ProductsComponent},
    {path: 'cart', component: CartComponent},
    {path: 'status', component: StatusComponent},
    {path: 'addProduct', component: AddProductComponent},
    {path: '**', redirectTo: '/products'}
]

@NgModule({
    imports: [RouterModule.forRoot(appRoutes)],
    exports: [RouterModule]
})
export class AppRoutingModule{}