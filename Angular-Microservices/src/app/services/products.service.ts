import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { Product } from "../models/product";


@Injectable({
    providedIn: 'root'
})
export class ProductsService{
    
    products!: Product[];

    constructor(private http: HttpClient){}

    getProducts(): Observable<Product[]>{
        return this.http.get<Product[]>('https://localhost:44325/api/product');
    }

    addNewProduct(newProdct: any){
        return this.http.post('https://localhost:44325/api/product/add',newProdct);
    }

}