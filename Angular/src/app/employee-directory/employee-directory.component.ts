import { Component, OnDestroy, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Subscription } from 'rxjs';
import { EmployeeListService } from '../shared/employee-list.service';
import { Employee } from '../shared/employee';
import { LoginService } from '../shared/login.service';

@Component({
  selector: 'app-directory',
  templateUrl: './employee-directory.component.html',
  styleUrls: ['./employee-directory.component.css']
})
export class EmployeeDirectoryComponent implements OnInit, OnDestroy {

  private employeeSubscription!: Subscription;

  constructor(private router: Router, private elService: EmployeeListService, private loginService: LoginService) { }

  employees!: Employee[];

  ngOnInit(): void {

    this.employees = this.elService.getEmployees();
    // this.employeeSubscription = this.elService.employeeChanged.subscribe(
    //   (employees: Employee[]) => {
    //     this.employees = employees;
    //   });

  }

  onAddEmployee(){
    this.router.navigate(['/add']);
  }

  ngOnDestroy(){
    //this.employeeSubscription.unsubscribe();
  }

  onLogout(){
    this.router.navigate(['/login']);
    this.loginService.logout();
  }

}
