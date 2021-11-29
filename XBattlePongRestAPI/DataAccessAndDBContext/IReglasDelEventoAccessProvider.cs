using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XBattlePongRestAPI.Models;
namespace XBattlePongRestAPI.DataAccessAndDBContext
{
    public interface IReglasDelEventoAccessProvider
    {
        /*
        Description: CRUD Operations for Reglas del Evento 
        */
        ReglasDelEvento AddReglasDelEventoRecord(ReglasDelEvento reglasDelEvento);
        void UpdateReglasDelEventoRecord(ReglasDelEvento reglasDelEvento);
        bool DeleteReglasDelEventoRecord(string id);
        ReglasDelEvento GetReglasDelEventoSingleRecord(string id);
        List<ReglasDelEvento> GetReglasDelEventoRecords();
        ReglasDelEvento GetReglasDelEventoRecordsByToken(string token);
        bool ReglasDelEventoExists(string id);
    }
}
