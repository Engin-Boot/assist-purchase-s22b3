import { Component, OnInit } from '@angular/core';
import {Router} from '@angular/router'
import {CustomerAlert} from '../Services/CustomerAlertService'
import {Inject} from '@angular/core'
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'customerForm-comp',
  templateUrl: './customer-form.component.html',
  styleUrls: ['./customer-form.component.css']
})
export class CustomerFormComponent implements OnInit {
  client:HttpClient
  alert:CustomerAlert
  baseUrl : string
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
    console.log(this.alert);
    this.response = this.client.post(`${this.baseUrl}/api/alert/alerts`,this.alert, {observe:'response'});
    this.response.subscribe(response => {
    
      console.log(response.status);
    
    });
    
  }

}
