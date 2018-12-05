import { Component, OnInit } from '@angular/core';
import { HttpModule } from '@angular/http';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';

@Component({
  selector: 'app-search-bar',
  templateUrl: './search-bar.component.html',
  styleUrls: ['./search-bar.component.css']
})
export class SearchBarComponent implements OnInit {

  constructor(public http: HttpClient, public router: Router) { }

  ngOnInit() {
  }

  doSearch(searchDetails: NgForm)
  {
    var textToSearch = searchDetails.value;
    if( textToSearch['TextSearch'] != null ){
      this.router.navigateByUrl("/search?term="+textToSearch['TextSearch']);
    }   
  }

}
