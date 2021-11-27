import { ComponentFixture, TestBed } from '@angular/core/testing';
import { HttpClient } from '@angular/common/http';
import { Ship } from '../models/ship.model';
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

  // Tests
  it('should rotate', function () {
    let h = component.isHorizontal;
    component.rotate();
    expect(h).not.toBe(component.isHorizontal);
  });

  it('should not rotate', function () {
    let h = component.isHorizontal;
    component.isShipSelected = true;
    component.rotate();
    expect(h).toBe(component.isHorizontal);
  });

  it('should allow a correct horizaontal position', function () {
    component.width = 10;
    component.height = 10;

    component.selectedShip = new Ship('destroyer',3,1, 'orange');
    expect(component.isPositionCorrect(1)).toBeTrue();
  });

  it('should not allow a horizontal position because the ship is out of bounds', function () {
    component.width = 10;
    component.height = 10;

    component.selectedShip = new Ship('destroyer', 3, 1, 'orange');
    expect(component.isPositionCorrect(100)).toBeFalse();
  });

  it('should allow a correct horizontal position', function () {
    component.width = 10;
    component.height = 10;

    component.selectedShip = new Ship('destroyer',3,1, 'orange');
    component.rotate();
    expect(component.isPositionCorrect(1)).toBeTrue();
  });
});
