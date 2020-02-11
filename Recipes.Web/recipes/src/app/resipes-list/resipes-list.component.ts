import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-resipes-list',
  templateUrl: './resipes-list.component.html',
  styleUrls: ['./resipes-list.component.css']
})
export class ResipesListComponent implements OnInit {

  recipes;

  constructor() { }

  ngOnInit() {
    this.recipes = [{}];
  }

}
