import { HttpClient } from "@angular/common/http";
import { Injectable, OnDestroy } from "@angular/core";
import { Subscription } from "rxjs";

@Injectable({
    providedIn: 'root'
})  
export class LoginService implements OnDestroy{

    private subscription: Subscription = new Subscription();

    constructor(private http: HttpClient) {}

    //user= {username:'kunal', password:'123'} ;
    error='';
    isUserLoggedIn = false;

    login(username: string, password: string): boolean{
        const user = {"username": username, "password": password}
        this.subscription = this.http.post('https://localhost:44346/api/login', user)
                        .subscribe(responseData => {
                            console.log(responseData);
                            if(responseData){
                                localStorage.setItem('userData', JSON.stringify(user));
                                this.isUserLoggedIn = true;
                            }else{
                                this.isUserLoggedIn = false;
                            }
                        }, error => {
                            console.log(error.message);
                            this.error="Invalid username or password";
                        });
        if(this.isUserLoggedIn){
            return true;
        }else{
            return false;
        }
    }

    isAuthenticated(){
        if(this.isUserLoggedIn){
            return true;
        }else{
            return false;
        }
    }

    logout(){
        this.isUserLoggedIn = false;
        localStorage.removeItem('userData');
    }

    autoLogin(){

        const userJson = localStorage.getItem('userData');
        const userData = userJson !== null ? JSON.parse(userJson) : false;


        if(!userData){
            this.isUserLoggedIn = false;
            return;
        }
        this.isUserLoggedIn = true;
    }

    ngOnDestroy(){
        this.subscription.unsubscribe();
    }

}