import { PersonDTO } from "./personDTO"

export class ResponseListDTO{
  page!: number
  pageItems!: number
  totalItems!: number
  data!: Array<PersonDTO>
}
