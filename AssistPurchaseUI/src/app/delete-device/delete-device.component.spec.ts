import { ComponentFixture, fakeAsync, TestBed, tick } from '@angular/core/testing';
import {HttpClientTestingModule, HttpTestingController} from '@angular/common/http/testing';
import { DeleteDeviceComponent } from './delete-device.component'
import { Type } from '@angular/core';
import { Router } from '@angular/router';
import { RouterTestingModule } from '@angular/router/testing';
import {ProductRecord} from '../Services/ProductRecordService'

describe('DeleteDeviceComponent', () => {
  let component:DeleteDeviceComponent;
  let fixture: ComponentFixture<DeleteDeviceComponent>;
  let httpMock: HttpTestingController;
  let routerSpy = {navigate: jasmine.createSpy('navigate')};

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports : [HttpClientTestingModule, RouterTestingModule],
      declarations: [ DeleteDeviceComponent ],
      providers: [
        { provide: Router, useValue: routerSpy },
        {provide: 'apiBaseAddress', useValue: "DeleteDeviceComponent"},
        {provide:ProductRecord, useClass:ProductRecord}
      ]
    }).compileComponents().then(() => {
      fixture = TestBed.createComponent(DeleteDeviceComponent);
      component = fixture.componentInstance;
      httpMock = fixture.debugElement.injector.get<HttpTestingController>(HttpTestingController as Type<HttpTestingController>);
    });
  });

  afterEach(() => {
    httpMock.verify();
  });

  it('button click should call onDelete()', fakeAsync(() => {
    spyOn(component, 'onDelete');
    let button = fixture.debugElement.nativeElement.querySelector('#delete');
    button.click();
    tick();
    expect(component.onDelete).toHaveBeenCalled();
  
  }));

  it('button click should call reset()', fakeAsync(() => {
    spyOn(component, 'reset');
    let button = fixture.debugElement.nativeElement.querySelector('#reset');
    button.click();
    tick();
    expect(component.reset).toHaveBeenCalled();
  }));
   
  it('should return failure message', () => {
    component.message = undefined;
    component.checkMessage();
    expect(component.message === "Please recheck the information given").toEqual(true);
  });

  it('should reset fields', () => {
    component.productId = "X3";
    component.reset();
    expect(component.productId === "").toEqual(true);
  });

  it('should return success message', () => {
    component.createResponse(200);
    expect(component.message === "Product deleted successfully").toEqual(true);
  });

 
});