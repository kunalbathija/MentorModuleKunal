import { Component, OnDestroy, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Subscription } from 'rxjs';
import { CartService } from '../shared/cart.service';
import { Product } from '../shared/product';
import { ProductsService } from '../shared/products.service';

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

    // this.subscription.add(this.cartService.sizeChanged.subscribe(res => {
    //   this.cartSize = res;
    // }));
    
  }

  goToCart(){
    this.router.navigate(['/cart']);
  }

  addToCart(i: number){
    this.subscription.add(this.cartService.addProductToCart(i)
                      .subscribe(res => {
                        //console.log(res)
                      }, error=> {
                        console.log(error)
                      }));
    //window.location.reload();
  }

  ngOnDestroy(){
    this.subscription.unsubscribe();
  }

}
