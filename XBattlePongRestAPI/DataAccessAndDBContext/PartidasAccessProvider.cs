using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XBattlePongRestAPI.Models;
namespace XBattlePongRestAPI.DataAccessAndDBContext
{
    public class PartidasAccessProvider: IPartidasAccessProvider
    {
        private XBattlePongDbContext _xBattlePongDbContext;
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
            _xBattlePongDbContext.Partidas.Update(partidas);
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
            string[] posJ1StrArray = selectedPartida.PosicionamientoBarcosJ1.Split(',');
            string[] posJ2StrArray = selectedPartida.PosicionamientoBarcosJ2.Split(',');
            selectedPartida.PosicionamientoBarcosJ1List = posJ1StrArray.Select(int.Parse).ToArray();
            if (posJ2StrArray.Length > 1)
            {
                selectedPartida.PosicionamientoBarcosJ2List = posJ2StrArray.Select(int.Parse).Cast<int?>().ToArray();
            }
            return selectedPartida;
        }

        public List<Partidas> GetPartidasRecords()
        {
            List<Partidas> partidasList = _xBattlePongDbContext.Partidas.ToList();
            foreach (Partidas partida in partidasList)
            {
                string[] posJ1StrArray = partida.PosicionamientoBarcosJ1.Split(',');
                string[] posJ2StrArray = partida.PosicionamientoBarcosJ2.Split(',');
                partida.PosicionamientoBarcosJ1List = posJ1StrArray.Select(int.Parse).ToArray();
                if (posJ2StrArray.Length > 1)
                {
                    partida.PosicionamientoBarcosJ2List = posJ2StrArray.Select(int.Parse).Cast<int?>().ToArray();
                }
    
            }
            return partidasList;
        }
        public bool PartidasExists(string id)
        {
            return _xBattlePongDbContext.Partidas.Any(e => e.PartidasID == id);
        }
        public string GetReglasDelEventoIDByToken(string token)
        {
            string codigoDeEvento = _xBattlePongDbContext.TokenConEvento.Where(t => t.token == token).Select(cod => cod.codigoDeEvento_fk).SingleOrDefault();
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
    }
}
