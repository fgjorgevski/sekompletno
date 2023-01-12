import { ComponentFixture, TestBed } from '@angular/core/testing';

import { OrderAluminiumSkateboardComponent } from './order-aluminium-skateboard.component';

describe('OrderAluminiumSkateboardComponent', () => {
  let component: OrderAluminiumSkateboardComponent;
  let fixture: ComponentFixture<OrderAluminiumSkateboardComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ OrderAluminiumSkateboardComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(OrderAluminiumSkateboardComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
