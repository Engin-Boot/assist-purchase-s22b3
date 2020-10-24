import { Component,ErrorHandler,Inject, OnInit } from '@angular/core';
import {HttpClient} from '@angular/common/http'
import { ProductRecord } from '../Services/ProductRecordService';


@Component({
  selector: 'prodById-comp',
  templateUrl: './get-product-by-id.component.html',
  styleUrls: ['./get-product-by-id.component.css']
})
export class GetProductByIdComponent implements OnInit {
  response:any;
  baseUrl:string;
  message:string;
  htmlMessage:string;
  record:ProductRecord;
  client:HttpClient;
  constructor(httpClient:HttpClient, @Inject('apiBaseAddress')baseUrl:string, record:ProductRecord) {
    this.client = httpClient;
    this.baseUrl = baseUrl;
    this.record = record;
    this.htmlMessage = undefined;
  }

  ngOnInit(): void {
  }
  productId:string;
  onGet(){
    this.response = this.client.get<ProductRecord>(`${this.baseUrl}/api/ProductsDatabase/products/`+this.productId, { responseType:'json', observe:'response'});
    this.response.subscribe(response=>{
        this.createResponse(response.body);
    })
    this.checkMessage();
    
  }
   checkMessage(){
    if(this.htmlMessage === undefined){
      this.htmlMessage = "Please recheck the information given";
    }
  } 
  createResponse(body){
      if(body!=null){
        this.htmlMessage = "";
        this.message = JSON.stringify(body);
        this.record = JSON.parse(this.message);
        for(var key in this.record){
        this.htmlMessage = this.htmlMessage + key+" : "+this.record[key] + "<br>";
        }
      }
  }
  reset(){
    this.productId ="";
    this.htmlMessage = undefined;
  }
}
