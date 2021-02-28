import { Injectable } from "@angular/core";

@Injectable({
    providedIn: 'root'
})  
export class LoginService{

    user= {username:'kunal', password:'123'} ;
    error='';
    isUserLoggedIn = false;

    login(username: string, password: string){
        if(this.user.username == username && this.user.password == password){
            localStorage.setItem('userData', JSON.stringify(this.user));
            this.isUserLoggedIn = true;
            return true;
        }else{
            this.error='Incorrect username or password';
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

}