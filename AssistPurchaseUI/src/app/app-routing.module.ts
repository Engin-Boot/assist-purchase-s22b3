import { importType } from '@angular/compiler/src/output/output_ast';
import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import {HomeComponent} from './home/home.component'
import {CustomerFormComponent} from './customer-form/customer-form.component'
import {ConfigurationComponent} from './configuration/configuration.component'
import {ChatBotComponent} from './chat-bot/chat-bot.component'

const routes: Routes = [
  {path:"", redirectTo:'home', pathMatch: 'full'},
  {path:'home', component:HomeComponent},
  {path:'customerinfo', component:CustomerFormComponent},
  {path:'config',component:ConfigurationComponent},
  {path:'chatbot',component:ChatBotComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
