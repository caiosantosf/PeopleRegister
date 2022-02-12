import { Component, ElementRef, EventEmitter, OnInit, Output, ViewChild } from '@angular/core';
import { PeopleService } from '../../services/people.service';

declare const bootstrap: any;

@Component({
  selector: 'app-delete-people',
  templateUrl: './delete-people.component.html',
  styleUrls: ['./delete-people.component.css']
})
export class DeletePeopleComponent implements OnInit {

  @Output("callback") callback: EventEmitter<any> = new EventEmitter()
  
  selectedId: string = ""
  selectedName: string = ""
  selectedLastName: string = ""

  constructor(
    private peopleService: PeopleService
  ) { }

  ngOnInit(): void {
  }

  deletePerson(): void {
    this.peopleService.deletePerson(this.selectedId)
      .subscribe(_ => {
        this.callback.emit()
        bootstrap.Modal.getInstance(document.getElementById('deletePeople')).hide()
      })
  }

}
