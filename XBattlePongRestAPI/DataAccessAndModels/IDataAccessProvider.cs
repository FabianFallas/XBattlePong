using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace XBattlePongRestAPI.DataAccessAndModels
{
    public interface IDataAccessProvider
    {
        /*
      Description: CRUD Operations for events 
      */
        Eventos AddEventosRecord(Eventos evento);
        void UpdateEventosRecord(Eventos evento);
        bool DeleteEventosRecord(string id);
        Eventos GetEventosSingleRecord(string id);
        List<Eventos> GetEventosRecords();

        /*
        Description: CRUD Operations for partidas 
        */
        Partidas AddPartidasRecord(Partidas partidas);
        void UpdatePartidasRecord(Partidas partidas);
        bool DeletePatidasRecord(string id);
        Partidas GetPartidasSingleRecord(string id);
        List<Partidas> GetPartidasRecords();
    }
}
