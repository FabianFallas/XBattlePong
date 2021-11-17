using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace XBattlePongRestAPI.DataAccessAndModels
{
    public interface IEventosAccessProvider
    {
        /*
     Description: CRUD Operations for events 
     */
        Eventos AddEventosRecord(Eventos evento);
        void UpdateEventosRecord(Eventos evento);
        bool DeleteEventosRecord(string id);
        Eventos GetEventosSingleRecord(string id);
        List<Eventos> GetEventosRecords();
    }
}
