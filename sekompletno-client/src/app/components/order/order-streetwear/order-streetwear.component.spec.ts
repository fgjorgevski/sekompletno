import { ComponentFixture, TestBed } from '@angular/core/testing';

import { OrderStreetwearComponent } from './order-streetwear.component';

describe('OrderStreetwearComponent', () => {
  let component: OrderStreetwearComponent;
  let fixture: ComponentFixture<OrderStreetwearComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ OrderStreetwearComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(OrderStreetwearComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
