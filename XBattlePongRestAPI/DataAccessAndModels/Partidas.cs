using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json.Linq;
using System.Text.Json.Serialization;
namespace XBattlePongRestAPI.DataAccessAndModels
{
    [Table("Partidas")]
    public class Partidas
    {
       

        [Key]
        public string PartidasID { get; set; }
        public string codigo { get; set; }
        [NotMapped]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int[] PosicionamientoBarcosJ1List { get; set; }
        [NotMapped]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int[] PosicionamientoBarcosJ2List { get; set; }
        public string PosicionamientoBarcosJ1{ get; set; }
        public string PosicionamientoBarcosJ2{ get; set; }
        public string ReglasDelEventoID{ get; set; }
    }
}
