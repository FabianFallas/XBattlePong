using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace XBattlePongRestAPI.Models
{
    [Table("Eventos")]
    public class Eventos
    {

        [NotMapped]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string horaDeInicioSTR { get; set; }
        [NotMapped]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string horaDeFinalizacionSTR { get; set; }
        public string nombrePartida { get; set; }
        public DateTime fechaDeInicio { get; set; }
        public TimeSpan horaDeInicio { get; set; }
        public DateTime fechaDeFinalizacion { get; set; }
        public TimeSpan horaDeFinalizacion { get; set; }
        public string pais { get; set; }
        public string localidad { get; set;}
        [Key]
        public string codigoDeEvento { get; set;}
        public string nombreDeOrganizador { get; set; }
    }
}
