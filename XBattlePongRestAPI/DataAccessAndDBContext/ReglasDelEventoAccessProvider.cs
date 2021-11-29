using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XBattlePongRestAPI.Models;
namespace XBattlePongRestAPI.DataAccessAndDBContext
{
    public class ReglasDelEventoAccessProvider: IReglasDelEventoAccessProvider
    {
        private XBattlePongDbContext _xBattlePongDbContext;
        public ReglasDelEventoAccessProvider(XBattlePongDbContext context)
        {
            _xBattlePongDbContext = context;
        }
        public ReglasDelEvento AddReglasDelEventoRecord(ReglasDelEvento reglasDelEvento)
        {
            Console.WriteLine("Reglas: " + JsonConvert.SerializeObject(reglasDelEvento));
            _xBattlePongDbContext.ReglasDelEvento.Add(reglasDelEvento);
            _xBattlePongDbContext.SaveChanges();
            return reglasDelEvento;
        }

        public bool DeleteReglasDelEventoRecord(string codigo)
        {
            var reglasDelEventoToBeDeleted = _xBattlePongDbContext.ReglasDelEvento.Find(codigo);
            if (reglasDelEventoToBeDeleted != null)
            {
                _xBattlePongDbContext.ReglasDelEvento.Remove(reglasDelEventoToBeDeleted);
                _xBattlePongDbContext.SaveChanges();
                return true;
            }
            return false;
        }

        public ReglasDelEvento GetReglasDelEventoSingleRecord(string id)
        {
            ReglasDelEvento selectedReglasDelEvento = _xBattlePongDbContext.ReglasDelEvento.SingleOrDefault(x => x.ReglaDelEventoID == id);
            return selectedReglasDelEvento;
        }

        public List<ReglasDelEvento> GetReglasDelEventoRecords()
        {
            List<ReglasDelEvento> reglasDelEventoList = _xBattlePongDbContext.ReglasDelEvento.ToList();
            return reglasDelEventoList;
        }

        public void UpdateReglasDelEventoRecord(ReglasDelEvento reglasDelEvento)
        {
            _xBattlePongDbContext.ReglasDelEvento.Update(reglasDelEvento);
            _xBattlePongDbContext.SaveChanges();
        }
        public bool ReglasDelEventoExists(string id)
        {
            return _xBattlePongDbContext.ReglasDelEvento.Any(e => e.ReglaDelEventoID == id);
        }

        public ReglasDelEvento GetReglasDelEventoRecordsByToken(string token)
        {
            string codigoDeEvento = _xBattlePongDbContext.TokenConEvento.Where(t => t.token == token).Select(c => c.codigoDeEvento_fk).SingleOrDefault();
            ReglasDelEvento reglasDelEventoWithTokenList = _xBattlePongDbContext.ReglasDelEvento.Where(
                r => r.codigoDeEvento_fk == codigoDeEvento).SingleOrDefault();
            return reglasDelEventoWithTokenList;
        }
    }
}
