import { Injectable } from "@angular/core";

@Injectable({
    providedIn: 'root'
})  
export class LoginService{

    users= {username:'kunal.bathija', password:'123456'} ;
    error='';
    isUserLoggedIn = false;

    login(username: string, password: string){
        if(this.users.username == username && this.users.password == password){
            this.isUserLoggedIn = true;
            return true;
        }else{
            this.error='Incorrect username or password';
            return false;
        }
    }

}