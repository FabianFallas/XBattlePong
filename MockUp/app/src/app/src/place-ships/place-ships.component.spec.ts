import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PlaceShipsComponent } from './place-ships.component';

describe('PlaceShipsComponent', () => {
  let component: PlaceShipsComponent;
  let fixture: ComponentFixture<PlaceShipsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PlaceShipsComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(PlaceShipsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
