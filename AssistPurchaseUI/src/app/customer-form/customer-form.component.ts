import { Component, OnInit } from '@angular/core';
import {Router} from '@angular/router'


@Component({
  selector: 'customerForm-comp',
  templateUrl: './customer-form.component.html',
  styleUrls: ['./customer-form.component.css']
})
export class CustomerFormComponent implements OnInit {

  constructor(private router:Router) {
  } 
  customerName:string;
  customerEmailId:string;
  phoneNumber:string;
  navigate()
  {
    this.router.navigate(['/chatbot'])
  }
  getCustomerName():string{
    return this.customerName;
  }
  getCustomerEmailId():string{
    return this.customerEmailId;
  }
  getPhoneNumber():string{
    return this.phoneNumber;
  }

  ngOnInit(): void {
  }


}
