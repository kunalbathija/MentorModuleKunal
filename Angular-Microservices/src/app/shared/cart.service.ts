import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable, Subject } from "rxjs";
import { Product } from "./product";

@Injectable({
    providedIn: 'root'
})
export class CartService {

    //sizeChanged =  new Subject<number>();
    //size!: any;

    cartProducts!: Product[];

    constructor(private http: HttpClient){}

    // getCountNumber(): number{
    //     this.http.get('https://localhost:44325/api/product/cart/size')
    //     .subscribe(res => {
    //         this.size = res;
    //         //console.log(size);
    //     }, error=> {
    //         console.log(error)
    //     });

    //     return this.size;

    // }

    getCount(){
        return this.http.get('https://localhost:44325/api/product/cart/size');
    }

    getAllCartProducts(): Observable<Product[]>{
        return this.http.get<Product[]>('https://localhost:44325/api/product/cart/products');
    }

    addProductToCart(i: number){
        //this.getCountNumber();
        //this.sizeChanged.next(this.size);
        return this.http.post('https://localhost:44325/api/product/cart/add', i);
    }

    emptyCart(){
        return this.http.delete('https://localhost:44325/api/product/cart/delete');
    }
}