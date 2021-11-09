import { Component, OnInit } from '@angular/core';
import {MatRadioModule} from '@angular/material'
import { FormGroup, Validators, FormControl } from '@angular/forms';
import * as moment from 'moment'
import { ConnectionService } from '../../connection.service';


@Component({
  selector: 'app-evento',
  templateUrl: './evento.component.html',
  styleUrls: ['./evento.component.css']
})
export class EventoComponent implements OnInit {

  formularioevento = new FormGroup({});
  formulariopartida= new FormGroup({});

  now = new Date();
  year = this.now.getFullYear();
  month = this.now.getMonth();
  day = this.now.getDay();
  minDate = moment(new Date()).format('YYYY-MM-DD');
  maxDate = "2022-09-22"
  date = new FormControl('', [Validators.required, Validators.min(moment(new Date()).millisecond())])

  token = "";
  informacion = "";
  mensaje = "";



  constructor(private service:ConnectionService) { }

  ngOnInit(): void {
  }



  Verificar(partida:string, f_inicio:string, h_inicio:string, f_final:string, h_final:string,
            pais:string, localidad:string, codigo:string, filas:string, columnas:string, tiempo:string, nombreDeOrganizador:string): void{

      this.informacion = partida + h_inicio + f_inicio + h_final + f_final + pais + localidad +filas + columnas + tiempo;

      if(partida == "" || h_inicio == "" || f_inicio == "" || h_final == "" || f_final== ""
        || pais =="" || localidad == "" || codigo == "" || filas == "" || columnas == "" ){

          this.token = "FAVOR INGRESE LOS DATOS COMPLETOS";
      }
      else{
        this.token = "Código de evento " + Math.random().toString(15).substr(2, 6);

        let msg = '{"nombrePartida": "' + partida +  '","fechaDeInicio": "' + f_inicio + '","horaDeInicioSTR": "' + h_inicio + '","fechaDeFinalizacion": "' + f_final + '","horaDeFinalizacionSTR": "' + h_final +'","pais": "' + pais +'","localidad": "' + localidad + '","codigo": "' + codigo +'","nombreDeOrganizador": "' + nombreDeOrganizador + '"}';
        console.log(msg);

        this.service.Post(msg, 'http://localhost:5000/api/Eventos').subscribe(res=> {
        console.log(res)
        })

        let msg_2 = '{"Filas":' + filas + ',"Columnas":' + columnas + ',"TipoDeJugabilidad":"Individual'  + '","CantidadDeBarcos":' + 5 + ',"TiempoDeDisparo":' + tiempo + ',"codigoDeEvento_fk":"' + this.token + '"}';

        this.service.Post(msg_2, 'http://localhost:5000/api/ReglasDelEvento').subscribe(res=> {
        console.log(res)
        })
      }
  }
}
