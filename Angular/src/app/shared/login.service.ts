import { HttpClient } from "@angular/common/http";
import { Injectable, OnDestroy } from "@angular/core";
import { Subscription } from "rxjs";

@Injectable({
    providedIn: 'root'
})  
export class LoginService{

    constructor(private http: HttpClient) {}

    error='';
    isUserLoggedIn = false;

    login(user: any){
        
        return this.http.post('https://localhost:44346/api/login', user);
                        
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

    

}