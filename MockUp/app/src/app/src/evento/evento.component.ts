import { Component, OnInit } from '@angular/core';
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



  Verificar(partida:string, h_inicio:string, f_inicio:string, h_final:string, f_final:string,
            pais:string, localidad:string, codigo:string, filas:string, columnas:string, tiempo:string ): void{

      this.informacion = partida + h_inicio + f_inicio + h_final + f_final + pais + localidad +filas + columnas + tiempo;

      if(partida == "" || h_inicio == "" || f_inicio == "" || h_final == "" || f_final== ""
        || pais =="" || localidad == "" || codigo == "" || filas == "" || columnas == "" ){

          this.token = "FAVOR INGRESE LOS DATOS COMPLETOS";
      }
      else{
        this.token = "Código de evento " + Math.random().toString(15).substr(2, 6);

        let msg = '{"nombrePartida": "' + partida +  '","fechaDeInicio": "' + h_inicio + '","horaDeInicioSTR": "' + f_inicio + '","fechaDeFinalizacion": "' + h_final + '","horaDeFinalizacionSTR": "' + f_final +'","pais": "' + pais +'","localidad": "' + localidad + '","codigo": "' + codigo +'","nombreDeOrganizador": "Payo"}';
        console.log(msg);

        this.service.Post(msg, 'http://localhost:5000/api/Eventos').subscribe(res=> {
        console.log(res)
        })


      }
  }
}
