import { Injectable } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';
import { HttpClient, HttpHeaders } from '@angular/common/http';


@Injectable()
export class AuthService {

  private tokenName: string = 'COMPEER_TOKEN';
  public invalidLogin: boolean = true;

  constructor(public http: HttpClient, public router: Router) { }

  public isAuthenticated(): boolean {
    const token = localStorage.getItem(this.tokenName);
    //this.invalidLogin = token != null;
    //return this.invalidLogin;
    return token != null;
  }

  public logIn(userDetails: NgForm) {
    let user = userDetails.value;
    this.http.post("http://localhost:5000/api/account/login", user, {
      headers: new HttpHeaders({
        "Content-Type": "application/json"
      }),
      responseType: 'text'
    }).subscribe(response => {
      console.log(response);
      let token = response.toString();
      localStorage.setItem(this.tokenName, token);
      this.router.navigate(["/"]);
    }, err => {
      this.invalidLogin = true;
      console.log("Error on login as received : ");
    });
  }
  public logOut() {
    localStorage.removeItem(this.tokenName);
    this.router.navigate(["/login"]);
  }

}