import { Component, OnInit } from '@angular/core';
import {Router} from '@angular/router'
import {CustomerAlert} from '../Services/CustomerAlertService'
import {Inject} from '@angular/core'
import { HttpClient, HttpErrorResponse } from '@angular/common/http';

@Component({
  selector: 'customerForm-comp',
  templateUrl: './customer-form.component.html',
  styleUrls: ['./customer-form.component.css']
})
export class CustomerFormComponent implements OnInit {
  client:HttpClient
  alert:CustomerAlert
  baseUrl : string
  message:string;
  constructor(private router:Router, alert:CustomerAlert, httpClient:HttpClient, @Inject('apiBaseAddress')baseUrl:string) {
    this.alert = alert;
    this.client = httpClient;
    this.baseUrl = baseUrl
  } 
  customerName:string;
  emailId:string;
  phoneNumber:string;
  productId:string;
  response:any;
 
 
  ngOnInit(): void {
  }
  contactSalesPerson(){
    
    this.alert.CustomerName = this.customerName;
    this.alert.CustomerEmailId = this.emailId;
    this.alert.PhoneNumber = this.phoneNumber;
    this.alert.ProductId = this.productId;
    this.response = this.client.post(`${this.baseUrl}/api/alert/alerts`,this.alert, {observe:'response'});
    this.response.subscribe(response => {

      this.createResponse(response.status);
      
    });
    this.checkMessage();
    this.reset();
  }
  checkMessage(){
    if(this.message === undefined){
      this.message = "Please recheck the information given"
    }
  }
  createResponse(status:any){
    if(status==200){
      this.message ="Our sales person will contact you shortly. Thank you for visiting"
    }
  }
  reset(){
    this.emailId ="";
    this.customerName = "";
    this.phoneNumber ="";
  }
}
