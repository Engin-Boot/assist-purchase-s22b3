import { Component, OnInit } from '@angular/core';
import {Router} from '@angular/router';
@Component({
  selector: 'config-comp',
  templateUrl: './configuration.component.html',
  styleUrls: ['./configuration.component.css']
})
export class ConfigurationComponent implements OnInit {

  constructor(private router:Router) { }

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

  }
  navigateGetDeviceById(){
    this.router.navigate(['/getDevice'])
  }
}
