import { Component, OnInit } from '@angular/core';
import { HttpModule } from '@angular/http';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent{

  responseMessage:string;

  constructor(public http: HttpClient, public router: Router){}

  onSubmit(authDetails: NgForm)
  {

    let user = authDetails.value;
    console.log("Tentativa de Login para usuário '"+user+"'");

    this.http.post("https://localhost:5001/api/auth/login", user, {
      headers: new HttpHeaders({
        "Content-Type": "application/json",
        "Access-Control-Allow-Methods":"GET, POST, PUTs"
      })
    }).subscribe(response => {
      this.storeToken(response);
    }, err => {
      this.responseMessage = "Erro ao cadastrar usuário : " + err.statusText;
    });
    
  }

  storeToken(token)
  {
    if( token.accessToken != null && token.accessToken !== 'undefined' )
    {
      this.responseMessage = "Access Token armazenado com sucesso. " + token.accessToken;
      localStorage.setItem("COMPEER_TOKEN", token.tokenType + " " + token.accessToken);
      console.log("Token Armazenado : " + token.accessToken);
      this.router.navigate(['/']);
    }
  }

}
