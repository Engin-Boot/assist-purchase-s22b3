import { Component, OnInit } from '@angular/core';
import {Router} from '@angular/router'
import {CustomerAlert} from '../Services/CustomerAlertService'

@Component({
  selector: 'customerForm-comp',
  templateUrl: './customer-form.component.html',
  styleUrls: ['./customer-form.component.css']
})
export class CustomerFormComponent implements OnInit {

  constructor(private router:Router) {
    let alert=new CustomerAlert();

   }
  
navigate()
{

this.router.navigate(['/chatbot'])
}
GetCustomerInfo()
{
  
}
  ngOnInit(): void {
  }


}
