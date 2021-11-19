using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using XBattlePongRestAPI.DataAccessAndDBContext;
using XBattlePongRestAPI.Models;
using XBattlePongRestAPI.Utils;

namespace XBattlePongRestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventosController : ControllerBase
    {
        private readonly IEventosAccessProvider _dataAccessProvider;
        private readonly ITokenConEventoAccessProvider _tokenConEventoAccessProvider;
        private TokenManager tokenManager = new TokenManager();
        public EventosController(IEventosAccessProvider dataAccessProvider, ITokenConEventoAccessProvider tokenConEventoAccessProvider)
        {
            _dataAccessProvider = dataAccessProvider;
            _tokenConEventoAccessProvider = tokenConEventoAccessProvider;
        }
        [HttpGet]
        public IEnumerable<Eventos> Get()
        {
            
            List<Eventos> eventosList = _dataAccessProvider.GetEventosRecords();
            foreach (Eventos evento in eventosList)
            {
                if (_tokenConEventoAccessProvider.TokenConEventoExists(evento.codigoDeEvento)) {
                    if (!tokenManager.isInEventDays(evento.fechaDeFinalizacion)) {
                        _tokenConEventoAccessProvider.DeleteTokenConEventoRecord(evento.codigoDeEvento);
                    }
                }
            }
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
            Console.WriteLine("Esto:" + JsonConvert.SerializeObject(evento));
            if (ModelState.IsValid) 
            {
                
                _dataAccessProvider.AddEventosRecord(evento);
                TokenConEvento tokenConEvento = _tokenConEventoAccessProvider.AddTokenConEventoRecord(evento.codigoDeEvento);
                return Ok(tokenConEvento);
                //return Ok(evento);
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
            _dataAccessProvider.UpdateEventosRecord(evento);
            return Ok("Updated!");
        }

    }
}
