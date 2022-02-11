import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-form-people',
  templateUrl: './form-people.component.html',
  styleUrls: ['./form-people.component.css']
})
export class FormPeopleComponent implements OnInit {

  selectedId: string = ""

  constructor() { }

  ngOnInit(): void {
  }

}
