import { Injectable } from "@angular/core";
import { Subject } from "rxjs";
import { Employee } from "./employee";

@Injectable({
    providedIn: 'root'
})
export class EmployeeListService {

    //employeeChanged = new Subject<Employee[]>();

    private employees: Employee[] = [
        {
            emp_id: 'EMP100', 
            name: 'Kunal', 
            team: 'Team1', 
            designation: 'Developer', 
            gender: 'Male',
            doj: new Date(2021, 6, 1)
        },
        {
            emp_id: 'EMP101', 
            name: 'Krishna', 
            team: 'Team2', 
            designation: 'Tester', 
            gender: 'Female',
            doj: new Date(2021, 6, 15) 
        }
    ];

    addEmployee(employee: Employee){
        this.employees.push(employee);
        //this.employeeChanged.next(this.employees.slice());
    }

    getEmployees(){
        return this.employees.slice();
    }

    getEmp(){
        return this.employees.slice();
    }

}