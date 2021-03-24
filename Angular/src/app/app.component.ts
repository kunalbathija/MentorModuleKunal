import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { LoginService } from './shared/login.service';
import { map } from 'rxjs/operators';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit{
  title = 'EmployeeApp';
  apiString!: any;

  constructor(private loginService: LoginService, private http: HttpClient) {}

  ngOnInit(){
    this.loginService.autoLogin();
    //this.getString();
  }

  // getString(){
  //   this.http.get('https://localhost:44346/api/login')
  //   //.pipe(map( response => response.json()))
  //   .subscribe(result => {
  //     this.apiString = result
  //   }, error => {
  //     console.log(error);
  //   })
  // }
}
