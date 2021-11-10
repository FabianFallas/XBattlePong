import { Component, OnInit } from '@angular/core';
import { Subscription } from 'rxjs';
import { ConnectionService } from 'src/app/connection.service';
import { Rules } from '../models/rules.model';
import { Ship } from '../models/ship.model';

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
// List of the positions of were the ships are located
squaresOccupied: number[] = [];
// Width of the game grid
width: number = 0;
// Height of the game grid
height: number = 0;
// This variable is used for identifying the boundaries of the grid when placing horizontal ships
rightMostSquares: number[] = [];
// Variable used for rotating the ships on their display and when placing them in the grid
isHorizontal: boolean = true;
// Variable used to set the ships on the squares
isShipSelected: boolean = false;
// List for storing the available ships
ships: Ship[] = [];
// Variable for storing the info of a selected ship for putting on the grid
selectedShip: Ship = new Ship('',0,'');

constructor(private service: ConnectionService) {
}

ngOnInit(): void {
  // We set the main color of the squares
  this.baseColor = 'aquamarine';

  // We set the proportions of the grid based on the rules
  this.width = this.service.defaultRules.filas;
  this.height = this.service.defaultRules.columnas;

  // We filled the available ships list with the ships
  this.ships.push(new Ship('destroyer',3,'orange'))
  this.ships.push(new Ship('submarine',4,'blue'))
  this.ships.push(new Ship('battleship',5,'red'))

  // We calculate the right most squares of the grid, used for defining boundaries
  for (let f = 1; f <= this.height; f++){
    this.rightMostSquares.push(this.width*f)
  }

  // We filled the square list with the amount of tiles the grid will have
  for (let s = 1; s <= this.width * this.height; s++) {
    this.squares.push(s);
  }
}

/**
 * This method changes the state of the isHorizontal variable when is called,
 * it is called by a button and if a ship is being selected the change cannot be made
 */
rotate(): void {
  if (!this.isShipSelected) {
    this.isHorizontal = !this.isHorizontal;
  }
}

/**
 * This method is called when a ship is clicked, indicates the system that a specific ship is being selected
 * @param s event of the mouse click on the ship
 */
shipClicked(s: any): void {
  // We get the id of the clicked ship
  let id = s.target.id.toString();

  // We inform that a ship was selected
  this.isShipSelected = true;

  // We search in the list of ships for the selected ship
  for (let i = 0; i < this.ships.length; i++) {
    if (this.ships[i].name == id) {
      this.selectedShip = this.ships[i];
    }
  }
  console.log(this.selectedShip)
}

/**
 * This method is called whenever a tile is clicked, is used for placing the ships on the grid
 * @param e event of the mouse click on the square
 */
squareClicked(e: any): void {
  // We get the id of the tile that was clicked
  let id: string = e.target.id.toString();

  // If a ship is selected and the position is correct we put it on the grid
  if (this.isShipSelected && this.isPositionCorrect(id)) {
    // We check if the placement of the ship is horizontal or vertical
    if (this.isHorizontal) {

      for (let i = 0; i < this.selectedShip.length; i++) {
        let currentId = Number(id);
        currentId += i;

        // We save the occupied position to a list and change the color of the square to the one of the ship
        this.squaresOccupied.push(currentId);
        document.getElementById(currentId.toString())!.style.backgroundColor = this.selectedShip.color;
      }
    }
    // Code for putting a vertical ship
    else {
      // TO DO
    }
    this.isShipSelected = false;
  }
  else {
    if (this.isShipSelected) {
      alert('Posicion invalida para colocar esta nave')
    }
  }
}

/**
 * This method checks if the selected ship can be placed on that position
 * If the position of the ship goes against the rules the method returns false, if not returns true
 * @param id of the square to be checked
 */
isPositionCorrect(id: any): boolean {
  // Horizontal positioning
  if (this.isHorizontal) {

    // We visit the squares connected from the starting position
    for (let i = 0; i < this.selectedShip.length; ++i) {
      let currentId = Number(id);
      currentId += i;

      // Checks
      if (currentId > this.squares.length ||
        document.getElementById(currentId.toString())!.style.backgroundColor !== this.baseColor ||
        (this.rightMostSquares.includes(currentId) && i + 1 != this.selectedShip.length)) {
        return false;
      }
    }
  }
  // Vertical positioning
  else {
    // TO DO
  }
  return true;
  }
}