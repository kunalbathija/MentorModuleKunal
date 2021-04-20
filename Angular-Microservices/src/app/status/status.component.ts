import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { StatusService } from '../services/status.service';

@Component({
  selector: 'app-status',
  templateUrl: './status.component.html',
  styleUrls: ['./status.component.css']
})
export class StatusComponent implements OnInit {

  success!: boolean;
  errorMessage!: string|null;

  constructor(private statusService: StatusService, private router: Router) { }

  ngOnInit(): void {
    this.success = this.statusService.success;
    this.errorMessage = this.statusService.errorMessage;
  }

  goToProducts(){
    this.router.navigate(['/products']);
  }

  goToCart(){
    this.router.navigate(['/cart']);
  }

}
