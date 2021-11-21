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
  code: string;
  showBoards: boolean = false;
  showGames: boolean = false;
  eventRules = new Rules('',8,8,'',0,0,'');
  rootEventRulesGetURL:string = 'http://localhost:5000/api/Partidas/GetReglasDelEvento/';
  rootGamesAvailabe: string = 'http://localhost:5000/api/Partidas/GetPartidasByToken/';
  games: Game[];

  constructor(private service: ConnectionService) { }

  ngOnInit(): void {
  }

  confirmedToken(eventCode: any): void {
    this.code = eventCode;
    let url = this.rootEventRulesGetURL + eventCode.toString();

    this.service.Get(url).subscribe(
      response => {
        // We assign the eventRules to the response to fill the information
        this.eventRules =  response;

        // We save the rules on the serive for the other components to access
        this.service.defaultRules = this.eventRules;

        // We activate the place-ships component
        this.showBoards = true;
      }
    );
  }

  searchGames(eventCode: any): void {
    this.code = eventCode;
    let url = this.rootGamesAvailabe + eventCode.toString();
    console.log(url)
    this.service.Get(url).subscribe(
      response => {
        console.log(response);

        this.games = response;

        console.log(this.games);

        this.showGames = true;
      }
    );
  }

  joinGame():void{
    this.confirmedToken(this.code);
  }

  updateTest(): void {
    this.service.defaultRules = this.eventRules;
    this.showBoards = true;
  }
}
