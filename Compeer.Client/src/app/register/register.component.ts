import { Component, OnInit } from '@angular/core';
import { HttpModule } from '@angular/http';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {

  responseMessage:string;

  constructor(public http: HttpClient, public router: Router) { }

  ngOnInit() {
  }

  onSubmit(registerForm: NgForm){
    
    let user = registerForm.value;

    this.http.post("http://localhost:5000/api/Register/Create", user, {
      headers: new HttpHeaders({
        "Content-Type": "application/json"
      }),
      responseType: 'text'
    }).subscribe(response => {
      this.responseMessage = "Usuário Cadastrado com Sucesso! " + response;
      //this.router.navigate(["/register"]);
    }, err => {
      this.responseMessage = "Erro ao cadastrar usuário : " + err.statusText;
    });

  }

}
