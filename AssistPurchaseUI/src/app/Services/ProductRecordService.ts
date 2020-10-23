import {Injectable} from '@angular/core'


@Injectable()
export class ProductRecord
{
    ProductId:string;
  ProductName:string;
  Description:string;
  ProductSpecificTraining:boolean;
  Price:number;
  SoftwareUpdateSupport:boolean;
  Portability:boolean;
  Compact:boolean;
  BatterySupport:boolean;
  ThirdPartyDeviceSupport:boolean;
  SafeToFlyCertification:boolean;
  TouchScreenSupport:boolean;
  MultiPatientSupport:boolean;
  CyberSecurity:boolean;
}
