import { Component, OnInit } from '@angular/core';
import { Subscription } from 'rxjs';
import { ConnectionService } from 'src/app/connection.service';
import { Barco } from '../models/barco.model';
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
  // Color of the enemy squares
  enemyBaseColor: string = '';
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
  barcos: Barco[] = [];
  // Variable for storing the info of a selected ship for putting on the grid
  selectedShip: Ship = new Ship('',0,0,'');
  // Amount of ships placed
  placedShipsAmount: number = 0;

  constructor(public service: ConnectionService) {
  }

  ngOnInit(): void {
    // We set the main color of the squares
    this.baseColor = 'aquamarine';
    this.enemyBaseColor = '#008060'

    // We set the proportions of the grid based on the rules
    this.width = this.service.eventRules.filas;
    this.height = this.service.eventRules.columnas;


    // GET of the ships
    this.service.Get('http://localhost:5000/api/CatalogoDeNaves/GetCatalogoDeNavesByToken/' + this.service.eventID).subscribe(
      res => {
        console.log(res)
        this.barcos = res;
            // If the server sends ships we get data from them and adapted them to our model
        if (this.barcos.length > 0){
          this.service.eventCode = this.barcos[0].codigoDeEvento_fk

          for (let i = 0; i < this.barcos.length; i++){
            this.ships.push(new Ship(this.barcos[i].naveID,this.barcos[i].alto,this.barcos[i].ancho,this.barcos[i].color))
          }
        }
        console.log(this.ships);
      }
    )


    // We manually filled the available ships list with the ships
    /*
    this.ships.push(new Ship('destroyer',3,2,'orange'))
    this.ships.push(new Ship('submarine',2,1,'blue'))
    this.ships.push(new Ship('battleship',1,3,'red'))
    */

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
    } else {
      alert('No se pueden rotar las naves si ya se tiene una seleccionada');
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
  }

  /**
   * This method is called whenever a tile is clicked, is used for placing the ships on the grid
   * @param e event of the mouse click on the square
   */
  squareClicked(e: any): void {
    // We get the id of the tile that was clicked
    let id: string = e.target.id.toString();

    // If a ship is selected, the position is correct and it can be placed we put it on the grid
    if (this.isShipSelected) {
      if (this.placedShipsAmount < this.service.eventRules.cantidadDeBarcos) {
        if (this.squaresOccupied.length + (this.selectedShip.length * this.selectedShip.width) <= this.squares.length / 2) {
          if (this.isPositionCorrect(id)) {

            // Horizontal placement
            if (this.isHorizontal) {
              for (let i = 0; i < this.selectedShip.width; i++) {
                let currentId = Number(id) + i * this.width;
                for (let j = 0; j < this.selectedShip.length; j++) {
                  this.squaresOccupied.push(currentId);
                  document.getElementById(currentId.toString())!.style.backgroundColor = this.selectedShip.color;
                  currentId++;
                }
              }
              this.placedShipsAmount++;
            }
            // Vertical placement
            else {
              for (let i = 0; i < this.selectedShip.width; i++) {
                let currentId = Number(id) + i;
                for (let j = 0; j < this.selectedShip.length; j++) {
                  this.squaresOccupied.push(currentId);
                  document.getElementById(currentId.toString())!.style.backgroundColor = this.selectedShip.color;
                  currentId += this.width;
                }
              }
              this.placedShipsAmount++
            }
            this.isShipSelected = false;
          } else {
              alert('Posicion invalida para colocar esta nave')
            }
        } else {
            alert('Esta naves es muy grande para colocar')
            this.isShipSelected = false;
          }
      } else {
        alert('Ya no se pueden colocar mas aves')
        }
    } else {
      alert('No se ha seleccionado ninguna nave para colocar')
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

      // Width of the ship
      for (let i = 0; i < this.selectedShip.width; i++) {
        let currentId = Number(id) + i * this.width;

        // Length of the ship
        for (let j = 0; j < this.selectedShip.length; ++j) {
          // Checks
          if (currentId > this.squares.length ||
            document.getElementById(currentId.toString())!.style.backgroundColor !== this.baseColor ||
            (this.rightMostSquares.includes(currentId) && j + 1 != this.selectedShip.length)) {
            return false;
          }
          currentId ++;
        }
      }
    }

    // Vertical positioning
    else {

      // Width of the ship
      for (let i = 0; i < this.selectedShip.width; i++) {
        let currentId = Number(id) + i;

        // Length of the ship
        for (let j = 0; j < this.selectedShip.length; ++j) {
          // Checks
          if (currentId > this.squares.length ||
            document.getElementById(currentId.toString())!.style.backgroundColor !== this.baseColor) {
            return false;
          }
          currentId += this.width;
        }
      }
    }
    return true;
  }

  /**
   * This method creates a game, if the current payer is a creator, and joins the player to the game if they have placed the correct amount of ships
   */
  createGame(): void {
    if (this.placedShipsAmount == this.service.eventRules.cantidadDeBarcos) {
      if (this.service.isCreator) {
        this.service.Post(this.service.eventID,'http://localhost:5000/api/Partidas').subscribe(
          res => {
            console.log(res)
            this.service.gameID = res;
            this.createPlayerOnGame('Jugador1');
          }
        )
      } else {
        this.createPlayerOnGame('Jugador2')
      }
    }
    else {
      alert('Aun no se puede crear la partida, faltan barcos de colocar')
    }
  }

  /**
   * This method joins a given player to the current game
   * @param player
   */
  createPlayerOnGame(player: string): void {
    let msgAddPlayer = '{"NombreDeUsuario":"' + player +'","PosicionamientoBarcosList":['+ this.squaresOccupied + '],"partidasID_fk":"' + this.service.gameID + '"}'
    this.service.Post(msgAddPlayer,'http://localhost:5000/api/UsuarioEnPartida')
  }
}
