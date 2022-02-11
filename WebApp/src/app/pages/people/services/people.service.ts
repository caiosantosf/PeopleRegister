import { Injectable } from '@angular/core';
import { environment } from '../../../../environments/environment';
import { HttpClient } from '@angular/common/http'
import { ResponseListDTO } from '../models/responseListDTO';
import { PersonDTO } from '../models/personDTO';
import { AddPersonDTO } from '../models/addPersonDTO';


@Injectable({
  providedIn: 'root'
})
export class PeopleService {
  private readonly url: string = `${environment.apiUrl}people/`

  constructor(
    private http: HttpClient
  ) { }

  public getPeople(search: string, page: number){
    const pageItems: number = environment.pageItems

    return this.http.get<ResponseListDTO>(this.url, {params: {
      page,
      pageItems,
      search
    }})
  }

  public getPerson(id: string){
    return this.http.get<PersonDTO>(`${this.url}${id}`)
  }

  public putPerson(person: PersonDTO){
    return this.http.put(`${this.url}`, person)
  }

  public deletePerson(id: string){
    return this.http.delete(`${this.url}${id}`)
  }

  public postPerson(person: AddPersonDTO){
    return this.http.post(`${this.url}`, person)
  }
}
