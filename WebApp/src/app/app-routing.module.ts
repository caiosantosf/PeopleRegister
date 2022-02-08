import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ListPeopleComponent } from './pages/people/components/list-people/list-people.component';

const routes: Routes = [
  {
    path: '',
    component: ListPeopleComponent
  },
  {
    path: '**',
    redirectTo: ''
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
