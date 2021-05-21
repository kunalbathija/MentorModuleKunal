import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable, Subject } from "rxjs";
import { CartProductModel } from "../models/cartProductModel";

@Injectable({
    providedIn: 'root'
})
export class CartService {

    //sizeChanged =  new Subject<number>();
    //size!: any;

    cartProducts: CartProductModel[] =[];

    constructor(private http: HttpClient){}

    getCount(){
        //return this.http.get('https://localhost:44325/api/product/cart/size');
        return this.cartProducts.length;
    }

    // getAllCartProducts(): Observable<CartProductModel[]>{
    //     return this.http.get<CartProductModel[]>('https://localhost:44325/api/product/cart/products');
    // }

    getAllCartProducts(){
        return this.cartProducts.slice();
    }

    addProductToCart(newCartProduct: CartProductModel){
        //return this.http.post('https://localhost:44325/api/product/cart/add', newCartProduct);
        if( ! this.cartProducts.find(x => x.id == newCartProduct.id)){
            this.cartProducts.push(newCartProduct);
        }
    }

    emptyCart(){
        //return this.http.delete('https://localhost:44325/api/product/cart/delete');
        this.cartProducts = [];
    }

    buyNow(cartProducts: CartProductModel[]){
        return this.http.post('https://localhost:44343/api/buynow', cartProducts)
    }
}