import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HeaderComponent } from './shared/components/header/header.component';
import { ListPeopleComponent } from './pages/people/components/list-people/list-people.component'
import { FormPeopleComponent } from './pages/people/components/form-people/form-people.component';
import { DeletePeopleComponent } from './pages/people/components/delete-people/delete-people.component'
import { HttpClientModule } from '@angular/common/http';


@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent,
    ListPeopleComponent,
    FormPeopleComponent,
    DeletePeopleComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
