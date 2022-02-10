import { Component, AfterViewInit, ViewChild } from '@angular/core';
import { PersonDTO } from '../../models/personDTO';
import { PeopleService } from '../../services/people.service';
import { DeletePeopleComponent } from '../delete-people/delete-people.component';
import { HeaderComponent } from '../header/header.component';
import { PeopleFormComponent } from '../people-form/people-form.component';

@Component({
  selector: 'app-list-people',
  templateUrl: './list-people.component.html',
  styleUrls: ['./list-people.component.css']
})

export class ListPeopleComponent implements AfterViewInit {

  @ViewChild(HeaderComponent) headerComponent!: HeaderComponent
  @ViewChild(PeopleFormComponent) peopleFormComponent!: PeopleFormComponent
  @ViewChild(DeletePeopleComponent) deletePeopleComponent!: HeaderComponent

  page: number = 1
  data: Array<PersonDTO> = []
  selectedId: string = ""

  constructor(
    private peopleService: PeopleService
  ) { }

  ngAfterViewInit(): void {
    console.log(this.headerComponent)
    this.peopleService.getPeople(this.headerComponent.search, this.page)
      .subscribe(response => {
        this.headerComponent.total = response.totalItems
        this.data = response.data
      })
  }

  setIdForDelete(id: string): void {
    this.selectedId = id;
  }

  setIdForUpdate(id: string): void {
    this.selectedId = id;
  }
}
