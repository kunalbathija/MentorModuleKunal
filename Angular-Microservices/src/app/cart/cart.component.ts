import { Component, OnInit, ViewChild } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';
import { Subscription } from 'rxjs';
import { CartService } from '../shared/cart.service';
import { CartProductModel } from '../shared/cartProductModel';
import { Product } from '../shared/product';

@Component({
  selector: 'app-cart',
  templateUrl: './cart.component.html',
  styleUrls: ['./cart.component.css']
})
export class CartComponent implements OnInit {

  @ViewChild('myForm') CartBuyNowForm!: NgForm;

  cartProducts!: Product[];

  cartBuyNowProducts: CartProductModel[] = [];
  cartBuyNowProduct: CartProductModel = {
    id: 0,
    name: '',
    quantity: 0
  }

  private subscription: Subscription = new Subscription();

  constructor(private cartService: CartService, private router: Router) { }

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

  //Messed up
  buyNow(){
    // for(let i=0;i<this.cartProducts.length;i++){
    //   const x = this.cartProducts[i].name
    //   console.log(this.CartBuyNowForm.value.id-i);
    //   //console.log(this.CartBuyNowForm.value.quantity-i);
    //   var tempCartProduct!: CartProductModel;
    //   //tempCartProduct.id = this.CartBuyNowForm.value.id-i;
    // }
    this.cartBuyNowProducts.push(this.cartBuyNowProduct);
    console.log(this.cartBuyNowProducts);
  }

}
