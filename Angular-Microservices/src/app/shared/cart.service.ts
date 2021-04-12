import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable, Subject } from "rxjs";
import { CartProductModel } from "./cartProductModel";
import { Product } from "./product";

@Injectable({
    providedIn: 'root'
})
export class CartService {

    //sizeChanged =  new Subject<number>();
    //size!: any;

    cartProducts!: CartProductModel[];

    constructor(private http: HttpClient){}

    getCount(){
        return this.http.get('https://localhost:44325/api/product/cart/size');
    }

    getAllCartProducts(): Observable<CartProductModel[]>{
        return this.http.get<CartProductModel[]>('https://localhost:44325/api/product/cart/products');
    }

    addProductToCart(newCartProduct: CartProductModel){
        return this.http.post('https://localhost:44325/api/product/cart/add', newCartProduct);
    }

    emptyCart(){
        return this.http.delete('https://localhost:44325/api/product/cart/delete');
    }

    buyNow(cartProducts: CartProductModel[]){
        return this.http.post('https://localhost:44343/api/buynow', cartProducts)
    }
}