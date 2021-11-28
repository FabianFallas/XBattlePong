using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XBattlePongRestAPI.Models;
using XBattlePongRestAPI.Utils;
namespace XBattlePongRestAPI.DataAccessAndDBContext
{
    public class EventosAccessProvider : IEventosAccessProvider
    {
        private XBattlePongDbContext _xBattlePongDbContext;
        private Converter converter = new Converter();
        public EventosAccessProvider(XBattlePongDbContext context)
        {
            _xBattlePongDbContext = context;
        }
        public Eventos AddEventosRecord(Eventos evento)
        {
            
            evento.horaDeInicio = converter.parseStrToTimeSpan(evento.horaDeInicioSTR);
            evento.horaDeFinalizacion = converter.parseStrToTimeSpan(evento.horaDeFinalizacionSTR);
            Console.WriteLine("Evento: " + JsonConvert.SerializeObject(evento));
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
            foreach (Eventos evento in eventsList)
            {
                evento.horaDeInicioSTR = evento.horaDeInicio.ToString();
                evento.horaDeFinalizacionSTR = evento.horaDeFinalizacion.ToString();
            }
            return eventsList;
        }

        public void UpdateEventosRecord(Eventos evento)
        {
            evento.horaDeInicio = converter.parseStrToTimeSpan(evento.horaDeInicioSTR);
            evento.horaDeFinalizacion = converter.parseStrToTimeSpan(evento.horaDeFinalizacionSTR);
            _xBattlePongDbContext.Eventos.Update(evento);
            _xBattlePongDbContext.SaveChanges();
        }
    }
}
