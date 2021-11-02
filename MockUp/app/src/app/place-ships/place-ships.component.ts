import { Component, OnInit } from '@angular/core';
import { Ship } from './ship.model';

@Component({
  selector: 'app-place-ships',
  templateUrl: './place-ships.component.html',
  styleUrls: ['./place-ships.component.css']
})
export class PlaceShipsComponent implements OnInit {

// Color of the unaltered squares
baseColor: string = '';
// List used for the creating of the grid tiles or squares
squares: number[] = [];
// Width of the game grid
width: number = 0;
// Height of the game grid
height: number = 0;
// This variable is used for identifying the boundaries of the grid when placing horizontal ships
rightMostSquares: number[] = [];
// Variable used for rotating the ships on their display and when placing them in the grid
isHorizontal: boolean = true;
// Variable used to set the ships on the squares
isShipSelected: boolean = true;
// Variable for storing the info of a selected ship for putting on the grid
selectedShip: Ship = new Ship(3,'red');

constructor() {
}

ngOnInit(): void {
  // We set the main color of the squares
  this.baseColor = 'aquamarine';

  // Here we set the proportions of the grid
  this.width = 8;
  this.height = 8;

  // We calculate the right most squares of for defining boundaries
  for (let f = 1; f <= this.height; f++){
    this.rightMostSquares.push(this.width*f)
  }

  // Here we filled the list with the amount of tiles the grid will have
  for (let s = 1; s <= this.width * this.height; s++) {
    this.squares.push(s);
  }
}

// This function changes the state of isHorizontal when is called, it is called by a button
rotate(): void {
  this.isHorizontal = !this.isHorizontal;
}

// Work in progress, is called whenever a tile is clicked, should have multiple conditions depending
// on the current state of the game
clicked(e: any): void {
  // We get the id of the tile that was clicked
  let id: string = e.target.id.toString();

  console.log(id)

  // If a ship is selected and the position is correct we put it on the grid
  if (this.isShipSelected && this.isPositionCorrect(id)) {
    // We check if the placement of the ship is horizontal or vertical
    if (this.isHorizontal) {
      for (let i = 0; i < this.selectedShip.length; i++) {
          let currentId = Number(id);
          currentId += i;
          console.log(currentId)
          document.getElementById(currentId.toString())!.style.backgroundColor = this.selectedShip.color;
      }
    }
    // Code for putting a vertical ship
    else {
      // WIP
    }
  }
  if (!this.isPositionCorrect(id)) {
    alert('Posicion invalida para colocar esta nave')
  }
}

// Given a square id checks if the selected ship can be placed on that position
isPositionCorrect(id:any): boolean {

  // Horizontal checks
  if (this.isHorizontal) {

    for (let i = 0; i < this.selectedShip.length; ++i) {
      let currentId = Number(id);
      currentId += i;

      if (currentId > this.squares.length ||
        document.getElementById(currentId.toString())!.style.backgroundColor !== this.baseColor ||
        (this.rightMostSquares.includes(currentId) && i + 1 != this.selectedShip.length)) {
        return false;
      }
    }
  }
  return true;
  }
}