import { Component, OnInit } from '@angular/core';
import { AuthService } from '../shared/auth.service';
import { Router } from '@angular/router'

@Component({
  selector: 'app-admin',
  templateUrl: './admin.component.html',
  styleUrls: ['./admin.component.css']
})
export class AdminComponent implements OnInit {

  loggedusername: string;

  constructor(private authService: AuthService, private router: Router) { }

  ngOnInit(): void {

    this.loggedusername = localStorage.getItem("username");
  }

  //logout

  logout() {

    this.authService.LogOut();

    this.router.navigateByUrl('login');


}
}
