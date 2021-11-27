import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';
import { environment } from 'src/environments/environment';
import { Login } from './login';
import { Observable } from 'rxjs';
@Injectable({
  providedIn: 'root'
})


  export class AuthService {
    constructor(private httpClient:HttpClient,private router:Router) { }
  
  
    // api call for token generation  with username and password
    getTokenByPassword(login:Login):Observable<any>{
  
      console.log("Token generation")
      
     return this.httpClient.get(environment.apiUrl+"api/login/"+login.Username+"/"+login.Password);
  
    }
  
  
    // clear all localstorage and session adata while logout
    public LogOut()
    {
      
      localStorage.clear();
      sessionStorage.clear()
    }
  
  
  }