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
    public class UsuarioEnPartidaController : ControllerBase
    {
        private readonly IUsuarioEnPartidaAccessProvider _usuarioEnPartidaAccessProvider;
        private Converter converter = new Converter();
        public UsuarioEnPartidaController(IUsuarioEnPartidaAccessProvider usuarioEnPartidaAccessProvider)
        {
            _usuarioEnPartidaAccessProvider = usuarioEnPartidaAccessProvider;
        }

        // GET: api/UsuarioEnPartida
        [HttpGet]
        public IEnumerable<UsuarioEnPartida> GetUsuarioEnPartida()
        {
            return _usuarioEnPartidaAccessProvider.GetUsuarioEnPartidaRecords();
        }

        /*
        // GET: api/UsuarioEnPartida/GetUsuarioEnPartidaByUsername/{username}
        [HttpGet("GetUsuarioEnPartidaByUsername/{username}")]
        public ActionResult<IEnumerable<UsuarioEnPartida>> GetUsuarioEnPartidaByUsername(string username)
        {

            var usuarioEnPartida = _usuarioEnPartidaAccessProvider.GetCatalogoDeNavesRecordsByToken(token);

            if (catalogoDeNaves == null)
            {
                return NotFound();
            }

            return catalogoDeNaves;
        }
        */

        // GET: api/UsuarioEnPartida/5
        [HttpGet("{username}")]
        public ActionResult<UsuarioEnPartida> GetUsuarioEnPartidaBy(string username)
        {
            var usuarioEnPartida = _usuarioEnPartidaAccessProvider.GetUsuarioEnPartidaSingleRecord(username);

            if (usuarioEnPartida == null)
            {
                return NotFound();
            }

            return usuarioEnPartida;
        }
        // GET: api/CatalogoDeNaves/GetCatalogoDeNavesByToken/{token}
        [HttpGet("GetUserEnPartidaStateByUsername/{username}")]
        public ActionResult<string> GetUserEnPartidaStateByUsername(string username)
        {

            var usuarioEnPartidaState = _usuarioEnPartidaAccessProvider.GetUsuarioEnPartidasStateByUsername(username);

            if (usuarioEnPartidaState == null)
            {
                return NotFound();
            }

            return usuarioEnPartidaState;
        }
        // PUT: api/UsuarioEnPartida
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut]
        public ActionResult PutUsuarioEnPartida([FromBody] UsuarioEnPartida usuarioEnPartida)
        {
            usuarioEnPartida.PosicionamientoDeJugadas = converter.parseCanBeEmptyListToStr(usuarioEnPartida.PosicionamientoDeJugadasList);
            _usuarioEnPartidaAccessProvider.UpdateUsuarioEnPartidaRecord(usuarioEnPartida);
            return Ok("Updated!");

        }
        // PUT: api/UsuarioEnPartida/ChangeState
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("ChangeState")]
        public ActionResult PutUsuarioEnPartidaState([FromBody] UsuarioEnPartida usuarioEnPartida)
        {
            _usuarioEnPartidaAccessProvider.UpdateUsuarioEnPartidaSTATERecord(usuarioEnPartida);
            return Ok(true);

        }

        // POST: api/UsuarioEnPartida
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public ActionResult<UsuarioEnPartida> PostUsuarioEnPartida([FromBody] UsuarioEnPartida usuarioEnPartida)
        {
            usuarioEnPartida.PosicionamientoBarcos = converter.parseListToStr(usuarioEnPartida.PosicionamientoBarcosList);
            usuarioEnPartida.PosicionamientoDeJugadas = "";
            usuarioEnPartida.Estado = "StandBy";
            _usuarioEnPartidaAccessProvider.AddUsuarioEnPartidaRecord(usuarioEnPartida);
            return CreatedAtAction("GetUsuarioEnPartida", new { id = usuarioEnPartida.NombreDeUsuario }, usuarioEnPartida);
        }

        // DELETE: api/UsuarioEnPartida/5
        [HttpDelete("{id}")]
        public ActionResult<UsuarioEnPartida> DeleteUsuarioEnPartida(string id)
        {
            bool usuarioEnPartida = _usuarioEnPartidaAccessProvider.UsuarioEnPartidaExists(id);
            if (!usuarioEnPartida)
            {
                return NotFound();
            }

            _usuarioEnPartidaAccessProvider.DeleteUsuarioEnPartidaRecord(id);

            return Ok("Successfully deleted!");
        }
    }
}
