import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import {ProductRecord} from '../Services/ProductRecordService'
import{CustomerAlert} from '../Services/CustomerAlertService'
@Injectable()
export class PurchaseService{

  httpClient:HttpClient;
  baseUrl:string;
  constructor(httpClient:HttpClient,@Inject('apiBaseAddress')baseUrl:string){
    this.httpClient=httpClient;
    this.baseUrl=baseUrl;
    
  }

  add(user:ProductRecord){
    let observableStream=this.httpClient.post(`${this.baseUrl}/api/ProductsDatabase/products`,user, {observe:'response'});
    return observableStream;
  }
  update(user:ProductRecord,productId:string)
  {
    let observableStream=this.httpClient.put(`${this.baseUrl}/api/ProductsDatabase/products/`+productId, user, {observe:'response'});
    return observableStream;
  }
  
  getProductById(productId:string)
  {
      let observableStream=this.httpClient.get<ProductRecord>(`${this.baseUrl}/api/ProductsDatabase/products/`+productId, { responseType:'json', observe:'response'});
      return observableStream;
  }

 contactSalesperson(alert:CustomerAlert)
 {
   let observableStream=this.httpClient.post(`${this.baseUrl}/api/alert/alerts`,alert, {observe:'response'});
   return observableStream;

 } 

 onDelete(productId:string)
 {
     let observableStream=this.httpClient.delete(`${this.baseUrl}/api/ProductsDatabase/products/`+productId ,{observe:'response'});
     return observableStream;
 }
}
