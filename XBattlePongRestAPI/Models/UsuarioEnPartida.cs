using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json.Linq;
using System.Text.Json.Serialization;

namespace XBattlePongRestAPI.Models
{
    [Table("UsuarioEnPartida")]
    public class UsuarioEnPartida
    {
        [Key]
        public string NombreDeUsuario { get; set; }
        [NotMapped]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int[] PosicionamientoBarcosList { get; set; }
        [NotMapped]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int?[] PosicionamientoDeJugadasList { get; set; }
        public string PosicionamientoBarcos { get; set; }
        public string PosicionamientoDeJugadas { get; set; }
        public string partidasID_fk { get; set; }
        public string Estado { get; set; }

    }
} 
