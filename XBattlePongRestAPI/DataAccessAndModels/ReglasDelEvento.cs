using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace XBattlePongRestAPI.DataAccessAndModels
{
    public class ReglasDelEvento
    {
        [Key]
        public string ReglaDelEventoID { get; set; }
        public int Filas { get; set; }
        public int Columnas { get; set; }
        public string TipoDeJugabilidad { get; set; }
        public int CantidadDeBarcos { get; set; }
        public int TiempoDeDisparo { get; set; }



    }
}
