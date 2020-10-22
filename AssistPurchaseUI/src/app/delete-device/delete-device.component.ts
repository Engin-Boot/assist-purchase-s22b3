import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'delete-comp',
  templateUrl: './delete-device.component.html',
  styleUrls: ['./delete-device.component.css']
})
export class DeleteDeviceComponent implements OnInit {

  constructor() { }
ProductId:string;
  ngOnInit(): void {
  }
onDelete()
{
  return this.ProductId;
}
}
