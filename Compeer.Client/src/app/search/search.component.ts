import { Component, OnInit } from '@angular/core';
import { HttpModule } from '@angular/http';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { NgForm } from '@angular/forms';
import { Router,ActivatedRoute,Params } from '@angular/router';
import { Subscription } from 'rxjs/Subscription';

@Component({
  selector: 'app-search',
  templateUrl: './search.component.html',
  styleUrls: ['./search.component.css']
})
export class SearchComponent implements OnInit {

  private term: string;
  private sub: Subscription;
  private searchResult : any;

  constructor(public http: HttpClient, public router: Router,private route: ActivatedRoute,) { }

  ngOnInit() {
    this.sub = this.route.queryParams.subscribe((params: Params) => {
      var textToSearch = params['term'];

      if( textToSearch != null ){
          this.term = textToSearch;
      }

    });
  }

}

