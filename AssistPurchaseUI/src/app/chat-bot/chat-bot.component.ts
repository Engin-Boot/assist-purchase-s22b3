import { Component, OnInit } from '@angular/core';
import {CustomerAlert} from '../Services/CustomerAlertService'
import {CustomerFormComponent} from '../customer-form/customer-form.component'
@Component({
  selector: 'chat-comp',
  templateUrl: './chat-bot.component.html',
  styleUrls: ['./chat-bot.component.css']
})
export class ChatBotComponent implements OnInit {
  alert:CustomerAlert;
  info:CustomerFormComponent;
  constructor() {
     this.alert = new CustomerAlert();

  }

  ngOnInit(): void {
  }
  values = '';
  productId='';
  onKey(event: any) { 
    this.values = event.target.value;
  }
  setProductId(e:string)
  {
    this.productId=e;
  }
  contact(){
    this.alert.CustomerName = this.info.getCustomerName();
    this.alert.CustomerEmailId = this.info.getCustomerEmailId();
    this.alert.PhoneNumber = this.info.getPhoneNumber();
    this.alert.ProductId = this.productId;
  }
}
