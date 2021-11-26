using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace XBattlePongRestAPI.Models
{
    public class CatalogoDeNaves
    {
        [Key]
        public string naveID { get; set; }
        public int alto { get; set; }
        public int ancho { get; set; }

        public string color { get; set; }

        public string codigoDeEvento_fk { get; set; }
    }
}
