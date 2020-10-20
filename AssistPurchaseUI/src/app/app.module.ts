import { NgModule } from '@angular/core';
import {HomeComponent} from './home/home.component'
import {BrowserModule} from '@angular/platform-browser';
import { HeaderComponent } from './header/header.component'



@NgModule({
    declarations:[ HeaderComponent,HomeComponent],
    bootstrap:[HeaderComponent],
    imports:[BrowserModule],
   /*  exports:[HomeComponent],
   providers:[
      {provide:'logger',useC,lass:ApiLoggerService},
      {provide:'apiBaseAddress',useValue:"http://localhost:8003"}
    ]*/
  })

export class AppModule{

}