import {Injectable} from '@angular/core'


@Injectable()
export class ProductService
{
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
}