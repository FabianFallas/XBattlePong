using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XBattlePongRestAPI.Models;
namespace XBattlePongRestAPI.DataAccessAndDBContext
{
    public interface IPartidasAccessProvider
    {
        /*
        Description: CRUD Operations for partidas 
        */
        Partidas AddPartidasRecord(Partidas partidas);
        void UpdatePartidasRecord(Partidas partidas);
        bool DeletePatidasRecord(string id);
        Partidas GetPartidasSingleRecord(string id);
        List<Partidas> GetPartidasRecords();
        string GetReglasDelEventoIDByCodigoDeEvento(string codigoDeEvento);
        ReglasDelEvento GetReglasDelEventoByID(string id);
        bool PartidasExists(string id);
        List<Partidas> GetPartidasByToken(string token);
    }
}
