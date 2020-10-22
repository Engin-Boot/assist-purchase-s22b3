import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import {RouterModule} from '@angular/router'
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HomeComponent } from './home/home.component';
import { CustomerFormComponent } from './customer-form/customer-form.component';
import { ChatBotComponent } from './chat-bot/chat-bot.component';
import { ConfigurationComponent } from './configuration/configuration.component';
import {FormsModule} from '@angular/forms';
import { LoginComponent } from './login/login.component'
import {CustomerAlert} from './Services/CustomerAlertService'
@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    CustomerFormComponent,
    ChatBotComponent,
    ConfigurationComponent,
    LoginComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    RouterModule,FormsModule
  ],
  providers: [{provide:CustomerAlert,useClass:CustomerAlert}],
  bootstrap: [AppComponent]
})
export class AppModule { }
