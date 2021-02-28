import { Injectable } from "@angular/core";
import { Subject } from "rxjs";
import { Employee } from "./employee.model";

@Injectable({
    providedIn: 'root'
})
export class EmployeeListService {

    employeeChanged = new Subject<Employee[]>();

    private employees: Employee[] = [
        new Employee('EMP100', 'Kunal','Team1','Developer','Male','1/6/2021'),
        new Employee('EMP101', 'Kajal','Team2','Tester','Female','15/6/2021')
    ];

    addEmployee(employee: Employee){
        this.employees.push(employee);
        this.employeeChanged.next(this.employees.slice());
    }

    getEmployees(){
        return this.employees.slice();
    }

    getEmp(){
        return this.employees.slice();
    }

}