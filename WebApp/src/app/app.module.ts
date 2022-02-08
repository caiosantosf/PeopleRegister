import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HeaderComponent } from './pages/people/components/header/header.component';
import { ListPeopleComponent } from './pages/people/components/list-people/list-people.component'
import { PeopleFormComponent } from './pages/people/components/people-form/people-form.component';
import { DeletePeopleComponent } from './pages/people/components/delete-people/delete-people.component'

@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent,
    ListPeopleComponent,
    PeopleFormComponent,
    DeletePeopleComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
