import { Component, Inject,OnInit } from '@angular/core';
import{ProductService} from '../Services/Product.service'
import {ProductRecord} from '../Services/ProductRecordService'
@Component({
  selector: 'add-comp',
  templateUrl: './add-device.component.html',
  styleUrls: ['./add-device.component.css']
})

export class AddDeviceComponent implements OnInit {
  loggerService:any;
  user:ProductRecord
  constructor(@Inject("logger") loggerService:any,private productService:ProductService, user:ProductRecord) { 
    this.loggerService=loggerService;
    this.user = user;
  }

  ProductId:string;
  ProductName:string;
  Description:string;
  ProductSpecificTraining:boolean;
  Price:number;
  SoftwareUpdateSupport:boolean
  Portability:boolean;
  Compact:boolean;
  BatterySupport:boolean;
  ThirdPartyDeviceSupport:boolean;
  SafeToFlyCertification:boolean;
  TouchScreenSupport:boolean;
  MultiPatientSupport:boolean;
  CyberSecurity:boolean;
  
  ngOnInit(): void {
  }
  
  addDevice()
  {
    this.user={ProductId:this.ProductId, ProductName:this.ProductName, Description:this.Description,ProductSpecificTraining: this.ProductSpecificTraining,
      Price:this.Price, SoftwareUpdateSupport:this.SoftwareUpdateSupport ,Portability:this.Portability,Compact:this.Compact,BatterySupport:this.BatterySupport,
      ThirdPartyDeviceSupport:this.ThirdPartyDeviceSupport,SafeToFlyCertification:this.SafeToFlyCertification,
      TouchScreenSupport:this.TouchScreenSupport,MultiPatientSupport:this.MultiPatientSupport,
      CyberSecurity:this.CyberSecurity,}

      console.log(this.user);
      let observableStream = this.productService.add(this.user);
      observableStream.subscribe(
        (data:any)=>{
          this.loggerService.write(data.message);
        },
        (error)=>{
          this.loggerService.write(error);
        },
        ()=>{
          this.loggerService.write("Request Completed");
        })
  }

  
}
