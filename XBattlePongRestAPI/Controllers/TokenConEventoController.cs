using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using XBattlePongRestAPI.DataAccessAndDBContext;
using XBattlePongRestAPI.Models;
using XBattlePongRestAPI.Utils;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace XBattlePongRestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenConEventoController : ControllerBase
    {
        private readonly ITokenConEventoAccessProvider _tokenConEventoAccessProvider;
        private TokenManager tokenManager = new TokenManager();

        public TokenConEventoController(ITokenConEventoAccessProvider tokenConEventoAccessProvider)
        {
            _tokenConEventoAccessProvider = tokenConEventoAccessProvider;
        }
        // GET: api/<TokenConEventoController>
        [HttpGet]
        public IEnumerable<TokenConEvento> Get()
        {
            return _tokenConEventoAccessProvider.GetTokenConEventoRecords();
        }

        // GET api/<TokenConEventoController>/5
        [HttpGet("{id}")]
        public ActionResult<TokenConEvento> Get(string token)
        {
            var tokenConEvento = _tokenConEventoAccessProvider.GetTokenConEventoSingleRecord(token);

            if (tokenConEvento == null)
            {
                return NotFound();
            }

            return tokenConEvento;
        }

        // POST api/<TokenConEventoController>
        [HttpPost]
        public ActionResult<TokenConEvento> Post([FromBody] TokenConEvento tokenConEvento)
        {
            tokenConEvento.token = tokenManager.RandomString(6);
            _tokenConEventoAccessProvider.AddTokenConEventoRecord(tokenConEvento);
            return CreatedAtAction("Get", new { token = tokenConEvento.token }, tokenConEvento);
        }

        // PUT api/<TokenConEventoController>
        [HttpPut]
        public void Put([FromBody] TokenConEvento tokenConEvento)
        {

        }

        // DELETE api/<TokenConEventoController>/5
        [HttpDelete("{codigoDeEvento}")]
        public IActionResult Delete(string codigoDeEvento)
        {
            bool action = _tokenConEventoAccessProvider.DeleteTokenConEventoRecord(codigoDeEvento);
            if (action)
            {
                return Ok("Deleted!");
            }
            return NotFound($"Evento con codigo: {codigoDeEvento} no fue encontrado");

        }
    }
}
