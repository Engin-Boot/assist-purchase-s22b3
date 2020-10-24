import { Component,Inject, OnInit } from '@angular/core';
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
    this.htmlMessage ="";
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
    this.reset();
    
  }
  checkMessage(){
    if(this.htmlMessage === ""){
      this.htmlMessage = "Please recheck the information given"
    }
    return;
  }
  createResponse(body){
      this.message = JSON.stringify(body);
      this.record = JSON.parse(this.message);
      for(var key in this.record){
        this.htmlMessage = this.htmlMessage + key+" : "+this.record[key] + ", ";
      }
      console.log(this.htmlMessage);
      
  }
  reset(){
    this.productId ="";
  }
}
