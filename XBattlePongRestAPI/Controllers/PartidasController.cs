using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using XBattlePongRestAPI.DataAccessAndDBContext;
using XBattlePongRestAPI.Models;
using XBattlePongRestAPI.Utils;

namespace XBattlePongRestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PartidasController : ControllerBase
    {
        private readonly IPartidasAccessProvider _dataAccessProvider;
        
        public PartidasController(IPartidasAccessProvider dataAccessProvider)
        {
            _dataAccessProvider = dataAccessProvider;
        }

        // GET: api/Partidas
        [HttpGet]
        public IEnumerable<Partidas> GetPartidas()
        {
            return  _dataAccessProvider.GetPartidasRecords();
        }

        // GET: api/Partidas/5
        [HttpGet("{id}")]
        public ActionResult<Partidas>  GetPartidas(string id)
        {
            var partidas = _dataAccessProvider.GetPartidasSingleRecord(id);

            if (partidas == null)
            {
                return NotFound();
            }

            return partidas;
        }

        // GET: api/Partidas/GetReglasDelEvento/{codigoDeEvento}
        [HttpGet("GetReglasDelEvento/{codigoDeEvento}")]
        public ActionResult<ReglasDelEvento> GetReglasDelEvento(string codigoDeEvento)
        {
            string reglasDelEventoID = _dataAccessProvider.GetReglasDelEventoIDByCodigoDeEvento(codigoDeEvento);
            var reglas = _dataAccessProvider.GetReglasDelEventoByID(reglasDelEventoID);

            if (reglas == null)
            {
                return NotFound();
            }

            return reglas;
        }
        // GET: api/Partidas/GetPartidasByToken/{token}
        [HttpGet("GetPartidasByToken/{token}")]
        public ActionResult<IEnumerable<Partidas>> GetPartidasByToken(string token)
        {
            
            var partidas = _dataAccessProvider.GetPartidasByToken(token);

            if (partidas == null)
            {
                return NotFound();
            }

            return partidas;
        }
        // PUT: api/Partidas/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut]
        public ActionResult PutPartidas([FromBody]Partidas partidas)
        {
            
            //partidas.PosicionamientoBarcosJ2 = converter.parseCanBeEmptyListToStr(partidas.PosicionamientoBarcosJ2List); 
            _dataAccessProvider.UpdatePartidasRecord(partidas);
             return Ok("Updated!");
        }

        // POST: api/Partidas
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public ActionResult<Partidas> PostPartidas([FromBody]Partidas partidas)
        {
            Guid partidaID = Guid.NewGuid();
     
            partidas.PartidasID = partidaID.ToString();
            string codigoDeEvento = _dataAccessProvider.GetCodigoDeEventoByToken(partidas.token);
            partidas.ReglaDelEventoID_fk = _dataAccessProvider.GetReglasDelEventoIDByCodigoDeEvento(codigoDeEvento);

            //partidas.PosicionamientoBarcosJ1 = string.Join(",", partidas.PosicionamientoBarcosJ1List.Select(item => item.ToString()).ToArray());
            //partidas.PosicionamientoBarcosJ2 = string.Join(",", partidas.PosicionamientoBarcosJ2List.Select(item => item.ToString()).ToArray());
            
            //ToPassToOtherController
            //partidas.PosicionamientoBarcosJ1 = converter.parseListToStr(partidas.PosicionamientoBarcosJ1List);
            //partidas.PosicionamientoBarcosJ2 = "";
            _dataAccessProvider.AddPartidasRecord(partidas);
            return CreatedAtAction("GetPartidas", new { id = partidas.PartidasID }, partidas);
        }

        // DELETE: api/Partidas/5
        [HttpDelete("{id}")]
        public ActionResult<Partidas> DeletePartidas(string id)
        {
            bool partidas = _dataAccessProvider.PartidasExists(id);
            if (!partidas)
            {
                return NotFound();
            }

            _dataAccessProvider.DeletePatidasRecord(id);

            return Ok("Successfully deleted!");
        }

       
    }
}
