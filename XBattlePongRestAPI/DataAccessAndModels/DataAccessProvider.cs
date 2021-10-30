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
            return _xBattlePongDbContext.Eventos.SingleOrDefault(x => x.codigo == codigo);
        }

        public List<Eventos> GetEventosRecords()
        {
            return _xBattlePongDbContext.Eventos.ToList();
        }

        public void UpdateEventosRecord(Eventos evento)
        {
            /*
            var eventoToBeUpdated = _xBattlePongDbContext.Eventos.Find(evento.codigo);
            if (eventoToBeUpdated != null)
            {
                eventoToBeUpdated = evento;
                _xBattlePongDbContext.Eventos.Update(eventoToBeUpdated);
                _xBattlePongDbContext.SaveChanges();
                return true;
            }
            return false;
            */
            _xBattlePongDbContext.Eventos.Update(evento);
            _xBattlePongDbContext.SaveChanges();
        }
    }
}
