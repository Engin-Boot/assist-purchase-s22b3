import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'add-comp',
  templateUrl: './add-device.component.html',
  styleUrls: ['./add-device.component.css']
})
export class AddDeviceComponent implements OnInit {

  constructor() { }
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
  }
}
