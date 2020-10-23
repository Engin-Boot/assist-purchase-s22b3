import {Injectable,Inject} from '@angular/core'
import { HttpClient, HttpHeaders } from '@angular/common/http';
import {ProductRecord} from '../Services/ProductRecordService'

//const options={headers:new HttpHeaders({'Access-Control-Allow-Origin':'http://localhost:51964', 'Access-Control-Allow-Credentials':'true', 'Access-Control-Allow-Methods':'POST'})}
@Injectable()
export class ProductService
{ 
    httpClient:HttpClient;
    baseUrl:string;
    
    constructor(httpClient:HttpClient,@Inject('apiBaseAddress')baseUrl:string){
      this.httpClient = httpClient;
      this.baseUrl = baseUrl;
    }
    add(user:ProductRecord)
    {
      let observableStream = this.httpClient.post(`${this.baseUrl}/api/ProductsDatabase/products`,user);
      return observableStream;
    }
}