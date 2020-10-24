import { Component,Inject, OnInit } from '@angular/core';
import {Router} from '@angular/router';
import {HttpClient} from '@angular/common/http'
import { ProductRecord } from '../Services/ProductRecordService';
@Component({
  selector: 'config-comp',
  templateUrl: './configuration.component.html',
  styleUrls: ['./configuration.component.css']
})
export class ConfigurationComponent implements OnInit {
  response:any;
  baseUrl:string;
  message:string;
  htmlMessage:string;
  record:ProductRecord[];
  client:HttpClient;
  constructor(private router:Router,httpClient:HttpClient, @Inject('apiBaseAddress')baseUrl:string) { 
    this.client = httpClient;
    this.baseUrl = baseUrl;
    //this.record = record;
    this.htmlMessage ="";
  }

  ngOnInit(): void {
  }
  
  navigateAddDevice(){
    this.router.navigate(['/addDevice'])
  }
  navigateDeleteDevice()
  {
    this.router.navigate(['/deleteDevice'])
  }
  navigateUpdateDevice()
  {
    this.router.navigate(['/updateDevice'])
  }
  navigateGetAllDevices(){
    this.response = this.client.get<ProductRecord>(`${this.baseUrl}/api/ProductsDatabase/products`, { responseType:'json', observe:'response'});
    this.response.subscribe(response=>{
      
      
      this.createResponse(response.body);
      
    })
    
    
  }
 
  createResponse(body){
      this.message = JSON.stringify(body);
      this.record = JSON.parse(this.message);
      for(var record in this.record){
        for(var key in this.record[record]){
          this.htmlMessage = this.htmlMessage + key+" : "+record[key] + ", ";
        }
      }
      console.log(this.record);
      
  }

  navigateGetDeviceById(){
    this.router.navigate(['/getDevice'])
  }
}
