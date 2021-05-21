import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Subscription } from 'rxjs';
import { ProductsService } from '../services/products.service';

import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-add-product',
  templateUrl: './add-product.component.html',
  styleUrls: ['./add-product.component.css']
})
export class AddProductComponent implements OnInit {

  newProduct = {
    name: '',
    description: '',
    availability: 0
  }

  private subscription: Subscription = new Subscription();

  constructor(private productsService: ProductsService, private router: Router,
    private toastr: ToastrService) { }

  ngOnInit(): void {
  }

  onSubmit(){
    console.log(this.newProduct);
    this.subscription = this.productsService.addNewProduct(this.newProduct)
        .subscribe(res => {
          if(res == 1){
            this.router.navigate(['products'])
            this.showSuccess();
          }
        }, error => {
          console.log(error);
          this.showError();
        });
  }

  showSuccess() {
    this.toastr.success('New Product Added', 'Success');
  }

  showError() {
    this.toastr.success('Something went wrong', 'Error');
  }

}
