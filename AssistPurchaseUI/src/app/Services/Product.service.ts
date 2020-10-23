import {Injectable,Inject} from '@angular/core'
import { HttpClient } from '@angular/common/http';

@Injectable()
export class ProductService
{ httpClient:HttpClient;
    baseUrl:string;
    constructor(httpClient:HttpClient,@Inject('apiBaseAddress')baseUrl:string){
      this.httpClient=httpClient;
      this.baseUrl=baseUrl;
    }
    add(user)
    {
    let observableStream=this.httpClient.post(`${this.baseUrl}/api/ProductsDatabase/products`,user);
    return observableStream;
    }
}