import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'prodById-comp',
  templateUrl: './get-product-by-id.component.html',
  styleUrls: ['./get-product-by-id.component.css']
})
export class GetProductByIdComponent implements OnInit {

  constructor() { }

  ngOnInit(): void {
  }
  productId:string;
  onGet(){
      console.log(this.productId);
  }
}
