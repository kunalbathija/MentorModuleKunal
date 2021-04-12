import { Component, OnDestroy, OnInit, ViewChild } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';
import { Subscription } from 'rxjs';
import { CartService } from '../shared/cart.service';
import { CartProductModel } from '../shared/cartProductModel';
import { Product } from '../shared/product';
import { StatusService } from '../shared/status.service';

@Component({
  selector: 'app-cart',
  templateUrl: './cart.component.html',
  styleUrls: ['./cart.component.css']
})
export class CartComponent implements OnInit, OnDestroy {


  cartProducts!:  CartProductModel[];
  
  private subscription: Subscription = new Subscription();

  constructor(private cartService: CartService, private router: Router, private statusService: StatusService) { }

  ngOnInit(): void {
    this.subscription.add(this.cartService.getAllCartProducts()
      .subscribe(result => {
        this.cartService.cartProducts = result;
        this.cartProducts = result;
        const size = this.cartProducts.length;
      }, error => {
        console.log(error)
      }));

  }

  goToProducts(){
    this.router.navigate(['/products']);
  }

  emptyCart(){
    this.subscription.add(this.cartService.emptyCart().subscribe(res => {
      window.location.reload();
    }, error=>{
      console.log(error)
    }))
  }


  buyNow(){
    console.log(this.cartProducts);
    this.subscription.add(this.cartService.buyNow(this.cartProducts).subscribe(res => {
      this.statusService.success = true;
      console.log(res)
      this.statusService.errorMessage = res.toString();
      this.router.navigate(['/status']);
    }, error => {
      this.statusService.success = false;
      this.statusService.errorMessage = error.error;
      console.log(error)
      this.router.navigate(['/status']);
    }));
  }

  ngOnDestroy(){
    this.subscription.unsubscribe();
  }

}
