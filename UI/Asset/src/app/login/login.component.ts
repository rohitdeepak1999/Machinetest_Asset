import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthService } from '../shared/auth.service';
import { Login } from '../shared/login';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  loginForm!: FormGroup;
  
  isSubmitted = false;
  loginUser: Login = new Login;
  error = '';
 // jwtResponse:any=new JwtResponce();
  constructor(private formbuilder: FormBuilder,
    private router: Router,public authService:AuthService
  ) { }

  ngOnInit(): void {
    this.loginForm = this.formbuilder.group(
      {
        Username: ['', [Validators.required, Validators.minLength(3)]],
        Password: ['', [Validators.required]],
      }
    );
  }


  //get controls

  get formControls() {
    return this.loginForm.controls;
  }

  //login verify credentials

  LoginCredentials() {

    //console.log(this.loginForm.value);
    this.isSubmitted = true;

    // invalid

    if (this.loginForm.invalid)
      return;



    //valid
    if (this.loginForm.valid) {

//calling method from Authservice 
      //calling token generation api

      this.authService.getTokenByPassword(this.loginForm.value).subscribe
      (data=>
        {
          console.log(data);
         
          localStorage.setItem("token",data.token);// adding token to the local storage
          sessionStorage.setItem("token",data.token);
          //check the role
          if(data.UserType=='admin')
              {
                //logged as admin
                console.log("admin");

                localStorage.setItem("username",data.UserName);
                
             
                sessionStorage.setItem("username",data.UserName);
                
              localStorage.setItem("Access_Role","1");
              //based on role redirect out application
                this.router.navigateByUrl("/admin");
              }
              else if(data.UserType==="productmanager"){
                console.log("manager")
                localStorage.setItem("username",data.UserName);
                sessionStorage.setItem("username",data.UserName);
                localStorage.setItem("Access_Role","2");
                //based on role redirect out application
                this.router.navigateByUrl("/manager");
              }
              else if(data.RoleId===3){
                console.log("user");
                localStorage.setItem("username",data.UserName);
                sessionStorage.setItem("username",data.UserName);
                localStorage.setItem("Access_Role",data.RoleId.toString());
                //based on role redirect out application
                this.router.navigateByUrl("/user");
              }
              else{
                this.error="Sorry .. invalid authorization"
              }
            },
            
        error=>
        {
          this.error="invalid"
        }
        )
    }
  }
 
}