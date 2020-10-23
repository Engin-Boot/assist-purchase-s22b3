import { Component, Inject,OnInit } from '@angular/core';
import{ProductService} from '../Services/Product.service'
@Component({
  selector: 'add-comp',
  templateUrl: './add-device.component.html',
  styleUrls: ['./add-device.component.css']
})

export class AddDeviceComponent implements OnInit {
  loggerService:any;
  constructor(@Inject("logger") loggerService:any,private productService:ProductService) { 
    this.loggerService=loggerService;
  }

  ProductId:string;
  Description:string;
  ProductSpecificTraining:boolean;
  Price:Float32Array;
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
    let user={ProductId:this.ProductId, Description:this.Description,ProductSpecificTraining:this.ProductSpecificTraining
      ,Price:this.Price,Portability:this.Portability,Compact:this.Compact,BatterySupport:this.BatterySupport,
      ThirdPartyDeviceSupport:this.ThirdPartyDeviceSupport,SafeToFlyCertification:this.ThirdPartyDeviceSupport,
      TouchScreenSupport:this.TouchScreenSupport,MultiPatientSupport:this.MultiPatientSupport,
      CyberSecurity:this.MultiPatientSupport}
      let observableStream=this.productService.add(user);
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
