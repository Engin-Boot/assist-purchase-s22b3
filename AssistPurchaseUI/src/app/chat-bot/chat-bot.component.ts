import { Component, OnInit } from '@angular/core';
import {CustomerAlert} from '../Services/CustomerAlertService'
import {CustomerFormComponent} from '../customer-form/customer-form.component'
import {Router} from '@angular/router'
@Component({
  selector: 'chat-comp',
  templateUrl: './chat-bot.component.html',
  styleUrls: ['./chat-bot.component.css']
})
export class ChatBotComponent implements OnInit {
  alert:CustomerAlert;
  info:CustomerFormComponent;
  constructor(private router:Router) {
     this.alert = new CustomerAlert();

  }
  navigate()
  {
    this.router.navigate(['/customerinfo'])
  } 
  ngOnInit(): void {
  }
  values = '';
  onKey(event: any) { 
    this.values = event.target.value;
  }
  
  
}
