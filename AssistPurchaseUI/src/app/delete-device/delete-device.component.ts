import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'delete-comp',
  templateUrl: './delete-device.component.html',
  styleUrls: ['./delete-device.component.css']
})
export class DeleteDeviceComponent implements OnInit {

  constructor() { }
  productId:string;
  ngOnInit(): void {
  }
  onDelete()
  {
    console.log(this.productId);
  }
}
