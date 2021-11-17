using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace XBattlePongRestAPI.DataAccessAndModels
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
    }
}
