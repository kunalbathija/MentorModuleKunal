import { Component, OnDestroy, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Subscription } from 'rxjs';
import { CartService } from '../services/cart.service';
import { CartProductModel } from '../models/cartProductModel';
import { Product } from '../models/product';
import { ProductsService } from '../services/products.service';

@Component({
  selector: 'app-products',
  templateUrl: './products.component.html',
  styleUrls: ['./products.component.css']
})
export class ProductsComponent implements OnInit, OnDestroy {

  products!: Product[];
  cartSize!: any;

  private subscription: Subscription = new Subscription();

  constructor(private productService: ProductsService, private cartService: CartService
    ,private router: Router){}

  ngOnInit(){
    this.subscription.add(this.productService.getProducts()
                        .subscribe(result => {
                          this.productService.products = result;
                          this.products = result;
                        }, error => {
                          console.log(error)
                        }));
    
    this.subscription.add(this.cartService.getCount()
                        .subscribe(res => {
                          //console.log(res);
                          this.cartSize = res
                        }, error=> {
                          console.log(error)
                        }));

    
  }

  goToCart(){
    this.router.navigate(['/cart']);
  }

  addToCart(i: number, name: string){
    const newCartProduct: CartProductModel ={
      id: i,
      name: name,
      quantity: 0
    }
    this.subscription.add(this.cartService.addProductToCart(newCartProduct)
                      .subscribe(res => {
                        this.cartSize = res
                        console.log(res)
                      }, error=> {
                        
                        console.log(error)
                      }));
  }

  ngOnDestroy(){
    this.subscription.unsubscribe();
  }

}
