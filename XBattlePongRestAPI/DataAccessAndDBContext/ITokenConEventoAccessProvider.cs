using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XBattlePongRestAPI.Models;
namespace XBattlePongRestAPI.DataAccessAndDBContext
{
    public interface ITokenConEventoAccessProvider
    {
        /*
    Description: CRUD Operations for eventos con token
    */
        public TokenConEvento AddTokenConEventoRecord(string codigoDeEvento);
        bool DeleteTokenConEventoRecord(string codigoDeEvento);
        TokenConEvento GetTokenConEventoSingleRecord(string id);
        List<TokenConEvento> GetTokenConEventoRecords();
        public bool TokenConEventoExists(string codigoDeEvento);
        
    }
}
