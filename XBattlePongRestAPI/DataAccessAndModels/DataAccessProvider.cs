using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace XBattlePongRestAPI.DataAccessAndModels
{
    public class DataAccessProvider : IDataAccessProvider
    {
        private XBattlePongDbContext _xBattlePongDbContext;
        public DataAccessProvider(XBattlePongDbContext context) 
        {
            _xBattlePongDbContext = context;   
        } 
        public Eventos AddEventosRecord(Eventos evento)
        {
            _xBattlePongDbContext.Eventos.Add(evento);
            _xBattlePongDbContext.SaveChanges();
            return evento;
        }

        public bool DeleteEventosRecord(string codigo)
        {
            var eventoToBeDeleted = _xBattlePongDbContext.Eventos.Find(codigo);
            if (eventoToBeDeleted != null) 
            {
                _xBattlePongDbContext.Eventos.Remove(eventoToBeDeleted);
                _xBattlePongDbContext.SaveChanges();
                return true;
            }
            return false;
        }

        public Eventos GetEventosSingleRecord(string codigo)
        {
            Eventos selectedEvent = _xBattlePongDbContext.Eventos.SingleOrDefault(x => x.codigoDeEvento == codigo);
            selectedEvent.horaDeInicioSTR = selectedEvent.horaDeInicio.ToString();
            selectedEvent.horaDeFinalizacionSTR = selectedEvent.horaDeFinalizacion.ToString();
            return selectedEvent;
        }

        public List<Eventos> GetEventosRecords()
        {
            List<Eventos> eventsList = _xBattlePongDbContext.Eventos.ToList();
            foreach (Eventos evento in eventsList) {
                evento.horaDeInicioSTR = evento.horaDeInicio.ToString();
                evento.horaDeFinalizacionSTR = evento.horaDeFinalizacion.ToString();
            }
            return eventsList;
        }

        public void UpdateEventosRecord(Eventos evento)
        {
            _xBattlePongDbContext.Eventos.Update(evento);
            _xBattlePongDbContext.SaveChanges();
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
            selectedPartida.PosicionamientoBarcosJ2List = posJ2StrArray.Select(int.Parse).ToArray();
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
                partida.PosicionamientoBarcosJ2List = posJ2StrArray.Select(int.Parse).ToArray();
            }
            return partidasList;
        }

        public string GetReglasDelEventoIDByCodigoDeEvento(string codigoDeEvento)
        {
            return _xBattlePongDbContext.ReglasDelEvento.Where(
                cod => cod.codigoDeEvento_fk == codigoDeEvento
                ).Select(
                regID => regID.ReglaDelEventoID
                ).SingleOrDefault(); ;
        }
        public bool PartidasExists(string id)
        {
            return _xBattlePongDbContext.Partidas.Any(e => e.PartidasID == id);
        }

        public ReglasDelEvento GetReglasDelEventoByID(string id)
        {
            return _xBattlePongDbContext.ReglasDelEvento.Find(id);
        }
    }
}
