import { ComponentFixture, fakeAsync, TestBed, tick } from '@angular/core/testing';
import {HttpClientTestingModule, HttpTestingController} from '@angular/common/http/testing';
import { GetProductByIdComponent } from './get-product-by-id.component'
import { Type } from '@angular/core';
import { Router } from '@angular/router';
import { RouterTestingModule } from '@angular/router/testing';
import {ProductRecord} from '../Services/ProductRecordService'

describe('GetProductByIdComponent', () => {
  let component:GetProductByIdComponent;
  let fixture: ComponentFixture<GetProductByIdComponent>;
  let httpMock: HttpTestingController;
  let routerSpy = {navigate: jasmine.createSpy('navigate')};

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports : [HttpClientTestingModule, RouterTestingModule],
      declarations: [ GetProductByIdComponent ],
      providers: [
        { provide: Router, useValue: routerSpy },
        {provide: 'apiBaseAddress', useValue: "GetProductByIdComponent"},
        {provide:ProductRecord, useClass:ProductRecord}
      ]
    }).compileComponents().then(() => {
      fixture = TestBed.createComponent(GetProductByIdComponent);
      component = fixture.componentInstance;
      httpMock = fixture.debugElement.injector.get<HttpTestingController>(HttpTestingController as Type<HttpTestingController>);
    });
  });

  afterEach(() => {
    httpMock.verify();
  });

  it('button click should call onDelete()', fakeAsync(() => {
    spyOn(component, 'onGet');
    let button = fixture.debugElement.nativeElement.querySelector('#get');
    button.click();
    tick();
    expect(component.onGet).toHaveBeenCalled();
  
  }));

  it('button click should call reset()', fakeAsync(() => {
    spyOn(component, 'reset');
    let button = fixture.debugElement.nativeElement.querySelector('#reset');
    button.click();
    tick();
    expect(component.reset).toHaveBeenCalled();
  }));
   
  

  it('should reset fields', () => {
    component.productId = "X3";
    component.reset();
    expect(component.productId === "").toEqual(true);
  });

 
});