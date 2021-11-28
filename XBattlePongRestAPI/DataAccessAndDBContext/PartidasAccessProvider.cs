using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XBattlePongRestAPI.Models;
using XBattlePongRestAPI.Utils;

namespace XBattlePongRestAPI.DataAccessAndDBContext
{
    public class PartidasAccessProvider: IPartidasAccessProvider
    {
        private XBattlePongDbContext _xBattlePongDbContext;
        private Converter converter = new Converter();
        public PartidasAccessProvider(XBattlePongDbContext context)
        {
            _xBattlePongDbContext = context;
        }
        public Partidas AddPartidasRecord(Partidas partidas)
        {
            _xBattlePongDbContext.Partidas.Add(partidas);
            _xBattlePongDbContext.SaveChanges();
            return partidas;
        }

        public void UpdatePartidasRecord(Partidas partidas)
        {
            var partidasToBeUpdated = _xBattlePongDbContext.Partidas.Find(partidas.PartidasID);
            _xBattlePongDbContext.Partidas.Update(partidasToBeUpdated);
            _xBattlePongDbContext.SaveChanges();
        }

        public bool DeletePatidasRecord(string id)
        {
            var partidasToBeDeleted = _xBattlePongDbContext.Partidas.Find(id);
            if (partidasToBeDeleted != null)
            {
                _xBattlePongDbContext.Partidas.Remove(partidasToBeDeleted);
                _xBattlePongDbContext.SaveChanges();
                return true;
            }
            return false;
        }

        public Partidas GetPartidasSingleRecord(string id)
        {
            Partidas selectedPartida = _xBattlePongDbContext.Partidas.SingleOrDefault(x => x.PartidasID == id);
            return selectedPartida;
        }

        public List<Partidas> GetPartidasRecords()
        {
            List<Partidas> partidasList = _xBattlePongDbContext.Partidas.ToList();
            return partidasList;
        }
        public bool PartidasExists(string id)
        {
            return _xBattlePongDbContext.Partidas.Any(e => e.PartidasID == id);
        }
        public string GetReglasDelEventoIDByToken(string token)
        {
            string codigoDeEvento = GetCodigoDeEventoByToken(token);
            return _xBattlePongDbContext.ReglasDelEvento.Where(
                cod => cod.codigoDeEvento_fk == codigoDeEvento
                ).Select(
                regID => regID.ReglaDelEventoID
                ).SingleOrDefault(); 
        }
        public string GetReglasDelEventoIDByCodigoDeEvento(string codigoDeEvento)
        {
           
            return _xBattlePongDbContext.ReglasDelEvento.Where(
                cod => cod.codigoDeEvento_fk == codigoDeEvento
                ).Select(
                regID => regID.ReglaDelEventoID
                ).SingleOrDefault();
        }
        public ReglasDelEvento GetReglasDelEventoByID(string id)
        {
            return _xBattlePongDbContext.ReglasDelEvento.Find(id);
        }
        public List<Partidas> GetPartidasByToken(string token)
        {
            TokenConEvento tokenConEvento = _xBattlePongDbContext.TokenConEvento.Find(token);
            string reglasDelEventoID = GetReglasDelEventoIDByToken(token);
            List<Partidas> partidasWithCodigoDeEventoList = _xBattlePongDbContext.Partidas.Where(
                p => p.ReglaDelEventoID_fk == reglasDelEventoID).ToList();
            return partidasWithCodigoDeEventoList;
        }

        public string GetCodigoDeEventoByToken(string token)
        {
            string codigoDeEvento = _xBattlePongDbContext.TokenConEvento.Where(t => t.token == token).Select(cod => cod.codigoDeEvento_fk).SingleOrDefault();
            return codigoDeEvento;
        }
    }
}
