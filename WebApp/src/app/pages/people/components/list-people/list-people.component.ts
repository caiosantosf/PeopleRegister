import { Component, AfterViewInit, ViewChild } from '@angular/core';
import { PersonDTO } from '../../models/personDTO';
import { PeopleService } from '../../services/people.service';
import { DeletePeopleComponent } from '../delete-people/delete-people.component';
import { HeaderComponent } from '../../../../shared/components/header/header.component';
import { FormPeopleComponent } from '../form-people/form-people.component';
import { environment } from '../../../../../environments/environment';

@Component({
  selector: 'app-list-people',
  templateUrl: './list-people.component.html',
  styleUrls: ['./list-people.component.css']
})

export class ListPeopleComponent implements AfterViewInit {

  @ViewChild(HeaderComponent) headerComponent!: HeaderComponent
  @ViewChild(FormPeopleComponent) peopleFormComponent!: FormPeopleComponent
  @ViewChild(DeletePeopleComponent) deletePeopleComponent!: DeletePeopleComponent

  page: number = 1
  data: Array<PersonDTO> = []
  lastPage: number = 1;

  constructor(
    private peopleService: PeopleService
  ) { }

  ngAfterViewInit(): void {
    this.getPeople()
  }

  getPeople() {
    this.peopleService.getPeople(this.headerComponent.search, this.page)
      .subscribe(response => {
        this.headerComponent.total = response.totalItems
        this.data = response.data
        this.lastPage = Math.ceil(response.totalItems / environment.pageItems)
      })

    this.handleNavEnabled()
  }

  handleNavEnabled() {

  }

  setIdForDelete(id: string): void {
    this.peopleFormComponent.selectedId = id
  }

  setIdForUpdate(id: string): void {
    this.deletePeopleComponent.selectedId = id
  }

  navFirst() {
    this.page = 1
    this.getPeople()
  }

  navPrevious() {
    this.page--
    this.getPeople()
  }

  navNext() {
    this.page++
    this.getPeople();
  }

  navLast() {
    this.page = this.lastPage;
    this.getPeople();
  }
}
