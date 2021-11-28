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
  // Form for getting the event settings
  formularioevento = new FormGroup({});
  // Form for getting the event rules
  formulariopartida= new FormGroup({});
  // Form for getting the new ships
  newShipForm = new FormGroup({});

  // Attributtes for storing, validating the information obtained on the settings and rules of the event forms
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

  // This attribute should be used for displaying the amount of ships on the catalogue
  amountOfShips: number = 0;

  constructor(private service:ConnectionService) { }

  ngOnInit(): void {
  }



  /**
   * This function verfies the passed information of the settings and rules of an event and passes it to a server
   * @param partida @param f_inicio @param h_inicio @param f_final @param h_final  @param pais  @param localidad 
   * @param codigo  @param filas  @param columnas  @param tiempo @param nombreDeOrganizador 
   */
  Verificar(partida:string, f_inicio:string, h_inicio:string, f_final:string, h_final:string,
            pais:string, localidad:string, codigo:string, filas:string, columnas:string, tiempo:string, nombreDeOrganizador:string): void{

      this.informacion = partida + h_inicio + f_inicio + h_final + f_final + pais + localidad +filas + columnas + tiempo;

      if (partida == "" || h_inicio == "" || f_inicio == "" || h_final == "" || f_final== ""
        || pais =="" || localidad == "" || codigo == "" || filas == "" || columnas == "" ){

          this.token = "FAVOR INGRESE LOS DATOS COMPLETOS";
      }
      else{
        this.service.eventCode = codigo;

        // THIS MUST BE CHANGED
        let tokenRand = Math.random().toString(15).substr(2, 6);
        this.token = "Código de evento " + tokenRand;

        let msgEvento = '{"nombrePartida": "' + partida +  '","fechaDeInicio": "' + f_inicio + '","horaDeInicioSTR": "' + h_inicio + '","fechaDeFinalizacion": "' + f_final + '","horaDeFinalizacionSTR": "' + h_final +'","pais": "' + pais +'","localidad": "' + localidad + '","codigoDeEvento": "' + codigo +'","nombreDeOrganizador": "' + nombreDeOrganizador +'"}';
        this.service.Post(msgEvento, 'http://localhost:5000/api/Eventos').subscribe(res=> {
        })

        let msgEventoRules = '{"Filas":' + filas + ',"Columnas":' + columnas + ',"TipoDeJugabilidad":"Individual'  + '","CantidadDeBarcos":' + 5 + ',"TiempoDeDisparo":' + tiempo + ',"codigoDeEvento_fk":"' + codigo + '"}';
        this.service.Post(msgEventoRules, 'http://localhost:5000/api/ReglasDelEvento').subscribe(res=> {
        })
      }
  }

  /**
   * This method takes the input of the add ship form and sends the new ship to the server
   * @param length 
   * @param width 
   * @returns Undefined if the ship dimensions are not correct
   */
  addShip(length: any, width: any): void {
    if (width == 0 || length == 0) {
      alert('Por favor digite un tamaño correcto de barco')
      return
    }
    
    let msgAddShip = '{"alto:"' + Number(length) + ',"ancho:"' + Number(width) + ',"codigoDeEvento_fk":"' + this.service.eventCode + '"}'
    console.log(msgAddShip)
    this.service.Post(msgAddShip, 'http://localhost:5000/api/CatalogoDeNaves').subscribe(res=> {
      console.log(res)
    })
  }
}
