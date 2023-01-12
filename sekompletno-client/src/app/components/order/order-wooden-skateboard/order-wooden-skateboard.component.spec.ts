import { ComponentFixture, TestBed } from '@angular/core/testing';

import { OrderWoodenSkateboardComponent } from './order-wooden-skateboard.component';

describe('OrderWoodenSkateboardComponent', () => {
  let component: OrderWoodenSkateboardComponent;
  let fixture: ComponentFixture<OrderWoodenSkateboardComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ OrderWoodenSkateboardComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(OrderWoodenSkateboardComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
