import { Component, OnInit } from '@angular/core';
import { HttpModule } from '@angular/http';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { NgForm } from '@angular/forms';
import { Router,ActivatedRoute,Params } from '@angular/router';

@Component({
  selector: 'app-search',
  templateUrl: './search.component.html',
  styleUrls: ['./search.component.css']
})
export class SearchComponent implements OnInit {

  private term: string;
  private searchResult : any;
  private searchResultCound : number;

  constructor(public http: HttpClient, public router: Router,private route: ActivatedRoute,) { }

  ngOnInit() {

    this.searchResultCound = 0;

    this.route.queryParams.subscribe((params: Params) => {
      
      if( params['term'] != null && params['term'] != '' )
      {

        let textToSearch = params['term'];
        let token = localStorage.getItem("COMPEER_TOKEN");

        if( textToSearch != null ){
            this.term = textToSearch;
            let searchBody = 
            {
              "TextSearch":this.term
            }

            this.http.post("https://localhost:5001/api/search/friends", searchBody, {
        headers: new HttpHeaders({
          "Content-Type": "application/json",
          "Authorization":token
        })
          }).subscribe(response => {
            console.log(response);
            this.searchResult = response['results'];
            this.searchResultCound = Object.keys(this.searchResult).length;
          }, err => {
            this.searchResult == null;
            this.searchResultCound = Object.keys(this.searchResult).length;
          });

        }

      }

    });
  }

}

