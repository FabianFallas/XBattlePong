using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace XBattlePongRestAPI.Models
{
    [Table("TokenConEvento")]
    public class TokenConEvento
    {
        [Key]
        public string token { get; set; }
        public string codigoDeEvento_fk { get; set; }
    }
}
