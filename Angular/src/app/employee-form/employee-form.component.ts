import { Component, OnInit, ViewChild } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';
import { EmployeeListService } from '../shared/employee-list.service';
import { Employee } from '../shared/employee';

@Component({
  selector: 'app-employee-form',
  templateUrl: './employee-form.component.html',
  styleUrls: ['./employee-form.component.css']
})
export class EmployeeFormComponent implements OnInit {

  @ViewChild('myForm') employeeForm!: NgForm;

  genders = ['Male', 'Female'];

  employee: Employee = {
    emp_id : '',
    name: '',
    team: '',
    designation: '',
    gender: '',
    doj!: new Date()
  }

  constructor(private elSerivce: EmployeeListService, private router: Router) { }

  ngOnInit(): void {
  }

  onSubmit(){
    // const tempDate1 = this.employeeForm.value.doj  
    // const tempDate2 = tempDate1.getDate()+"/"+tempDate1.getMonth()+"/"+tempDate1.getFullYear();

    // this.employee.emp_id = this.employeeForm.value.emp_id;
    // this.employee.name = this.employeeForm.value.name;
    // this.employee.team = this.employeeForm.value.team;
    // this.employee.designation = this.employeeForm.value.designation;
    // this.employee.gender = this.employeeForm.value.gender;
    //this.employee.doj = tempDate2;

    this.elSerivce.addEmployee(this.employee);

    this.router.navigate(['/directory']);

  }

}
