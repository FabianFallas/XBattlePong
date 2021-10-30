using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using XBattlePongRestAPI.DataAccessAndModels;

namespace XBattlePongRestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventosController : ControllerBase
    {
        private readonly IDataAccessProvider _dataAccessProvider;
        public EventosController(IDataAccessProvider dataAccessProvider)
        {
            _dataAccessProvider = dataAccessProvider;
        }
        [HttpGet]
        public IEnumerable<Eventos> Get()
        {
            return _dataAccessProvider.GetEventosRecords();
        }
        [HttpGet("{codigo}")]
        public Eventos GetByCodigo(string codigo)
        {
            return _dataAccessProvider.GetEventosSingleRecord(codigo);
        }
        [HttpPost]
        public IActionResult CreateEvento([FromBody] Eventos evento)
        {
            if (ModelState.IsValid) 
            {
                evento.horaDeInicio = TimeSpan.Parse(evento.horaDeInicioSTR);
                evento.horaDeFinalizacion = TimeSpan.Parse(evento.horaDeFinalizacionSTR);
                _dataAccessProvider.AddEventosRecord(evento);
                return Ok(evento);
            }
            return BadRequest("Bad information or format were introduced");
        }
        [HttpDelete("{codigo}")]
        public IActionResult DeleteEvento(string codigo) 
        {
            bool action = _dataAccessProvider.DeleteEventosRecord(codigo);
            if (action) 
            {
                return Ok("Deleted!");    
            }
            return NotFound($"Evento con codigo: {codigo} no fue encontrado");
        }
        [HttpPut]
        public IActionResult UpdateEvento([FromBody] Eventos evento)
        {
            evento.horaDeInicio = TimeSpan.Parse(evento.horaDeInicioSTR);
            evento.horaDeFinalizacion = TimeSpan.Parse(evento.horaDeFinalizacionSTR);
            _dataAccessProvider.UpdateEventosRecord(evento);
            return Ok("Updated!");
        }

    }
}
