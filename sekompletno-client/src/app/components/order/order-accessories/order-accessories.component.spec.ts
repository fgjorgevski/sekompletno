import { ComponentFixture, TestBed } from '@angular/core/testing';

import { OrderAccessoriesComponent } from './order-accessories.component';

describe('OrderAccessoriesComponent', () => {
  let component: OrderAccessoriesComponent;
  let fixture: ComponentFixture<OrderAccessoriesComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ OrderAccessoriesComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(OrderAccessoriesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
