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
import { AddDeviceComponent } from './add-device/add-device.component';
import { UpdateDeviceComponent } from './update-device/update-device.component';
import { DeleteDeviceComponent } from './delete-device/delete-device.component';
import {ProductService} from './Services/ProductService'
import { GetProductByIdComponent } from './get-product-by-id/get-product-by-id.component';
import { GetAllProductsComponent } from './get-all-products/get-all-products.component'
@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    CustomerFormComponent,
    ChatBotComponent,
    ConfigurationComponent,
    LoginComponent,
    AddDeviceComponent,
    UpdateDeviceComponent,
    DeleteDeviceComponent,
    GetProductByIdComponent,
    GetAllProductsComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    RouterModule,FormsModule
  ],
  providers: [{provide:CustomerAlert,useClass:CustomerAlert},
    {provide:ProductService,useClass:ProductService},
    ],
  bootstrap: [AppComponent]
})
export class AppModule { }
