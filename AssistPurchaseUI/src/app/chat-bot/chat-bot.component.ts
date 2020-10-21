import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'chat-comp',
  templateUrl: './chat-bot.component.html',
  styleUrls: ['./chat-bot.component.css']
})
export class ChatBotComponent implements OnInit {

  constructor() { }

  ngOnInit(): void {
  }
  values = '';
  productId='';
  onKey(event: any) { 
    this.values = event.target.value;
    console.log(this.values);
}
contact(e:string)
{
this.productId=e;
console.log(e);
}
}
