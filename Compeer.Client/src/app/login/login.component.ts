import { Component, OnInit } from '@angular/core';
import { AuthService } from '../_services/auth.service';
import { NgForm } from '@angular/forms';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent{

  private headerText:string = 'Entrar'

  constructor(public authService : AuthService){}

  onSubmit(authDetails: NgForm)
  {
    this.authService.logIn(authDetails);
  }

}
