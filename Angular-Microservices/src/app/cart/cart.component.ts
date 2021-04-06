import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Subscription } from 'rxjs';
import { CartService } from '../shared/cart.service';
import { Product } from '../shared/product';

@Component({
  selector: 'app-cart',
  templateUrl: './cart.component.html',
  styleUrls: ['./cart.component.css']
})
export class CartComponent implements OnInit {

  cartProducts!: Product[];

  private subscription: Subscription = new Subscription();

  constructor(private cartService: CartService, private router: Router) { }

  ngOnInit(): void {
    this.subscription.add(this.cartService.getAllCartProducts()
                        .subscribe(result => {
                          this.cartService.cartProducts = result;
                          this.cartProducts = result;
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

}
