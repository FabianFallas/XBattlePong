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
    [Table("Partidas")]
    public class Partidas
    {
       

        [Key]
        public string PartidasID { get; set; }
        [NotMapped]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string token { get; set; }
        public string ReglaDelEventoID_fk{ get; set; }
    }
}
