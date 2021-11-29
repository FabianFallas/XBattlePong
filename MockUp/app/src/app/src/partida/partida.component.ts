import { Component, OnInit } from '@angular/core';
import { ConnectionService } from 'src/app/connection.service';
import { Game } from '../models/game.model';
import { Rules } from '../models/rules.model';

@Component({
  selector: 'app-partida',
  templateUrl: './partida.component.html',
  styleUrls: ['./partida.component.css']
})
export class PartidaComponent implements OnInit {
  // This attributes display different html components
  showBoards: boolean = false;
  showGames: boolean = false;

  // This attributes store recieved information
  eventRules: Rules = new Rules('',0,0,'',0,0,'');
  games: Game[] = [];

  // Root URLs to which we make requests
  rootEventRulesGetURL: string = 'http://localhost:5000/api/ReglasDelEvento/GetReglasDelEventoByToken/';
  rootGamesAvailabe: string = 'http://localhost:5000/api/Partidas/GetPartidasByToken/';


  constructor(private service: ConnectionService) { }

  ngOnInit(): void {
  }

  /**
   * This method recieves a event id and makes a GET request for rules to the server, the rules are stored on an attribute
   * @param eventID
   */
  getRules(eventID: any): void {
    this.service.eventID = eventID;

    let url = this.rootEventRulesGetURL + eventID.toString();
    this.service.Get(url).subscribe(
      response => {
        console.log(response)
        // We assign the eventRules to the response to fill the information
        this.eventRules =  response;
        console.log(this.eventRules)
        // We save the rules on the service for the other components to access
        this.service.eventRules = this.eventRules;
        console.log(this.service.eventRules)

        // We activate the place-ships component
        this.showBoards = true;
      }
    );
  }

  /**
   * This method recieves a event id and makes a GET request for available game to the server, the games are stored on an attribute
   * @param eventID
   */
  searchGames(eventID: any): void {
    this.service.eventID = eventID;

    let url = this.rootGamesAvailabe + eventID.toString();
    this.service.Get(url).subscribe(
      response => {
        // We fill the games list with the available games in that event
        this.games = response;

        // We show the list of available games
        this.showGames = true;
      }
    );
  }

  /**
   * This method the game ID that was selected to join and stores it on the service and gets the rules of the event
   * @param gameID
   */
  chooseGame(gameID: any):void{
    this.service.gameID = gameID;
    this.service.isCreator = false;
    this.service.username = 'Jugador 2'
    this.service.enemyUsername = 'Jugador 1'

    this.getRules(this.service.eventID);
  }
}

