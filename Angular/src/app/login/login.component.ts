import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { LoginService } from './login.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  username='';
  password='';
  error: string | null = null;

  constructor(private loginService: LoginService, private router: Router, private route: ActivatedRoute) { }

  ngOnInit(): void {
    if(localStorage.getItem('userData')){
      this.router.navigate(['/directory']);
    }
  }

  login(){
    const result = this.loginService.login(this.username, this.password);
    if(result){
      this.router.navigate(['/directory']);
    }else{
      this.error = this.loginService.error;
    }
  }

}
