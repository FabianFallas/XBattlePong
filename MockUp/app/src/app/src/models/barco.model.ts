export class Barco {
    constructor(
      public naveID: string,
      public alto: number,
      public ancho: number,
      public color: string,
      public codigoDeEvento_fk: string
    )  
  {}
}