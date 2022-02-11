import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-delete-people',
  templateUrl: './delete-people.component.html',
  styleUrls: ['./delete-people.component.css']
})
export class DeletePeopleComponent implements OnInit {

  selectedId: string = ""

  constructor() { }

  ngOnInit(): void {
  }

  deletarPessoa(){

  }

}
