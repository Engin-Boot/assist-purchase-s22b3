import { NgModule } from '@angular/core';
import {HomeComponent} from './home/home.component'
import {BrowserModule} from '@angular/platform-browser'

@NgModule({
    declarations:[HomeComponent],
    bootstrap:[HomeComponent],
    imports:[BrowserModule],
    /*exports:[GreeterComponent],
    providers:[
      {provide:'logger',useClass:ApiLoggerService},
      {provide:'apiBaseAddress',useValue:"http://localhost:8003"}
    ]*/
  })

export class AppModule{

}