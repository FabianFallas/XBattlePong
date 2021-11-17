using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace XBattlePongRestAPI.DataAccessAndModels
{
    public interface IReglasDelEventoAccessProvider
    {
        /*
        Description: CRUD Operations for events 
        */
        ReglasDelEvento AddReglasDelEventoRecord(ReglasDelEvento reglasDelEvento);
        void UpdateReglasDelEventoRecord(ReglasDelEvento reglasDelEvento);
        bool DeleteReglasDelEventoRecord(string id);
        ReglasDelEvento GetReglasDelEventoSingleRecord(string id);
        List<ReglasDelEvento> GetReglasDelEventoRecords();
        bool ReglasDelEventoExists(string id);
    }
}
