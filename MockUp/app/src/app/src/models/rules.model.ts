export class Rules{
    constructor(
        public reglaDelEventoID : string,
        public filas: number,
        public columnas: number,
        public tipoDeJugabilidad: string,
        public cantidadDeBarcos: number,
        public tiempoDeDisparo: number,
        public codigoDeEvento_fk: string,
    ){
    }
}