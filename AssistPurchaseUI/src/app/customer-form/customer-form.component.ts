import { Component, OnInit } from '@angular/core';
import {Router} from '@angular/router'
import {CustomerAlert} from '../Services/CustomerAlertService'

@Component({
  selector: 'customerForm-comp',
  templateUrl: './customer-form.component.html',
  styleUrls: ['./customer-form.component.css']
})
export class CustomerFormComponent implements OnInit {

  alert:CustomerAlert
  constructor(private router:Router, alert:CustomerAlert) {
    this.alert = alert;
  } 
  customerName:string;
  emailId:string;
  phoneNumber:string;
  productId:string;
 
 
  ngOnInit(): void {
  }
  contactSalesPerson(){
    
    this.alert.CustomerName = this.customerName;
    this.alert.CustomerEmailId = this.emailId;
    this.alert.PhoneNumber = this.phoneNumber;
    this.alert.ProductId = this.productId;
  }

}
