import { ComponentFixture, TestBed } from '@angular/core/testing';

import { OrderSkateboardComponent } from './order-skateboard.component';

describe('OrderSkateboardComponent', () => {
  let component: OrderSkateboardComponent;
  let fixture: ComponentFixture<OrderSkateboardComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ OrderSkateboardComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(OrderSkateboardComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
