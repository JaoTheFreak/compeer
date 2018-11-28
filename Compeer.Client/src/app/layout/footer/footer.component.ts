import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-footer',
  templateUrl: './footer.component.html',
  styleUrls: ['./footer.component.css']
})
export class FooterComponent implements OnInit {

  private footerText:string = 'Compeer App. Projeto Faculdade Bagozzi. Arthur K. Neto, João A. Martins, Luis Fernando, Maycon Lesko'

  constructor() { }

  ngOnInit() {
  }

}
