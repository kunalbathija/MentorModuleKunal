import { Component, OnDestroy, OnInit, ViewChild } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Subscription } from 'rxjs';
import { LoginService } from '../shared/login.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit, OnDestroy {

  username=''
  password = ''
  error: string | null = null;

  private subscription: Subscription = new Subscription();

  constructor(private loginService: LoginService, private router: Router, private route: ActivatedRoute) { }

  ngOnInit(): void {
    if(localStorage.getItem('userData')){
      this.router.navigate(['/directory']);
    }
  }

  login(){
    const user = {"username": this.username, "password": this.password}
    this.subscription = this.loginService.login(user)
                        .subscribe(responseData => {
                            console.log(responseData);
                            if(responseData){
                              localStorage.setItem('userData', JSON.stringify(user));
                              this.loginService.isUserLoggedIn = true;
                              this.router.navigate(['/directory']);
                            }else{
                              this.loginService.isUserLoggedIn = false;
                            }
                          }, error => {
                              console.log(error.message);
                              this.loginService.error="Invalid username or password";
                              this.error = this.loginService.error;
                      });

    // if(this.loginService.isUserLoggedIn){
    //   this.router.navigate(['/directory']);
    // }else{
      
    // }
    
  }

  ngOnDestroy(){
    this.subscription.unsubscribe();
  }

}
