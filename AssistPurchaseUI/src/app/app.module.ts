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
import {ProductService} from './Services/Product.service'
import { GetProductByIdComponent } from './get-product-by-id/get-product-by-id.component';
import { GetAllProductsComponent } from './get-all-products/get-all-products.component'
import { HttpClientModule } from '@angular/common/http';
import {ProductRecord} from './Services/ProductRecordService'
import {ApiLoggerService} from './Services/ApiLogger.service'
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
    RouterModule,FormsModule,HttpClientModule
  ],
  providers: [{provide:CustomerAlert,useClass:CustomerAlert},
    {provide:ProductService,useClass:ProductService},
    {provide:'logger',useClass:ApiLoggerService},
    {provide:'apiBaseAddress',useValue:"http://localhost:51964"},
    {provide:ProductRecord, useClass:ProductRecord}
    ],
  bootstrap: [AppComponent]
})
export class AppModule { }
