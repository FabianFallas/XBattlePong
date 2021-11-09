import { Component, OnInit } from '@angular/core';
import { ConnectionService } from 'src/app/connection.service';
import { Rules } from '../models/rules.model';

@Component({
  selector: 'app-partida',
  templateUrl: './partida.component.html',
  styleUrls: ['./partida.component.css']
})
export class PartidaComponent implements OnInit {
  eventRules = new Rules('',0,0,'',0,0,'')
  rootEventRulesGetURL:string = 'http://localhost:5000/api/Partidas/GetReglasDelEvento/'

  constructor(private service: ConnectionService) { }

  ngOnInit(): void {
  }

  confirmedToken(eventCode: any): void {
    let url = this.rootEventRulesGetURL + eventCode.toString();
    console.log(url);
    this.service.Get(url).subscribe(
      response => {
          console.log(response);
          this.eventRules =  response;
          console.log(this.eventRules);
      }
    );
  }
}
