import { Component, OnInit } from '@angular/core';
import { ConnectionService } from 'src/app/connection.service';
import { Rules } from '../models/rules.model';

@Component({
  selector: 'app-partida',
  templateUrl: './partida.component.html',
  styleUrls: ['./partida.component.css']
})
export class PartidaComponent implements OnInit {
  showBoards: boolean = false;
  eventRules = new Rules('',8,8,'',0,0,'')
  rootEventRulesGetURL:string = 'http://localhost:5000/api/Partidas/GetReglasDelEvento/'

  constructor(private service: ConnectionService) { }

  ngOnInit(): void {
  }

  confirmedToken(eventCode: any): void {
    let url = this.rootEventRulesGetURL + eventCode.toString();
    console.log(url);
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

  updateTest(): void {
    this.service.defaultRules = this.eventRules;
    this.showBoards = true;
  }
}
