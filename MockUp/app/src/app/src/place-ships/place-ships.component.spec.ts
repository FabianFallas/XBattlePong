import { ComponentFixture, TestBed } from '@angular/core/testing';

import { Ship } from '../models/ship.model';
import { PlaceShipsComponent } from './place-ships.component';

// Http testing module and mocking controller
import { HttpClientTestingModule, HttpTestingController } from '@angular/common/http/testing';

// Other imports

import { HttpClient, HttpErrorResponse } from '@angular/common/http';

describe('PlaceShipsComponent', () => {
  let component: PlaceShipsComponent;
  let fixture: ComponentFixture<PlaceShipsComponent>;
  let httpClient: HttpClient;
  let httpTestingController: HttpTestingController;

  beforeEach(async () => {
    TestBed.configureTestingModule({
      imports: [ HttpClientTestingModule ],
      declarations: [ PlaceShipsComponent ]
    }).compileComponents();;

    // Inject the http service and test controller for each test
    httpClient = TestBed.get(HttpClient);
    httpTestingController = TestBed.get(HttpTestingController);
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
    component.width = 2;
    component.height = 2;

    component.selectedShip = new Ship('destroyer', 3, 1, 'orange');
    expect(component.isPositionCorrect(1)).toBeFalse();
  });

  it('should allow a correct horizontal position', function () {
    component.width = 10;
    component.height = 10;

    component.selectedShip = new Ship('destroyer',3,1, 'orange');
    component.rotate();
    expect(component.isPositionCorrect(1)).toBeTrue();
  });
});
