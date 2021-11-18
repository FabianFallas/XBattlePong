using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using XBattlePongRestAPI.DataAccessAndDBContext;
using XBattlePongRestAPI.Models;
namespace XBattlePongRestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReglasDelEventoController : ControllerBase
    {
        private readonly IReglasDelEventoAccessProvider _dataAccessProvider;
        public ReglasDelEventoController(IReglasDelEventoAccessProvider dataAccessProvider)
        {
            _dataAccessProvider = dataAccessProvider;
        }

        // GET: api/ReglasDelEvento
        [HttpGet]
        public IEnumerable<ReglasDelEvento> GetReglasDelEvento()
        {
            return _dataAccessProvider.GetReglasDelEventoRecords();
        }

        // GET: api/ReglasDelEventoes/5
        [HttpGet("{id}")]
        public ActionResult<ReglasDelEvento> GetPartidas(string id)
        {
            var reglasDelEvento = _dataAccessProvider.GetReglasDelEventoSingleRecord(id);

            if (reglasDelEvento == null)
            {
                return NotFound();
            }

            return reglasDelEvento;
        }
        // PUT: api/ReglasDelEvento/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut]
        public ActionResult PutReglasDelEvento([FromBody] ReglasDelEvento reglasDelEvento)
        {
            _dataAccessProvider.UpdateReglasDelEventoRecord(reglasDelEvento);
            return Ok("Updated!");

        }

        // POST: api/ReglasDelEventoes
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public ActionResult<ReglasDelEvento> PostReglasDelEvento([FromBody] ReglasDelEvento reglasDelEvento)
        {
            Guid reglasDelEventoID = Guid.NewGuid();
            reglasDelEvento.ReglaDelEventoID = reglasDelEventoID.ToString();
            _dataAccessProvider.AddReglasDelEventoRecord(reglasDelEvento);
            return CreatedAtAction("GetReglasDelEvento", new { id = reglasDelEvento.ReglaDelEventoID }, reglasDelEvento);
        }

        // DELETE: api/ReglasDelEventoes/5
        [HttpDelete("{id}")]
        public ActionResult<ReglasDelEvento> DeleteReglasDelEvento(string id)
        {
            bool reglasDelEvento = _dataAccessProvider.ReglasDelEventoExists(id);
            if (!reglasDelEvento)
            {
                return NotFound();
            }

            _dataAccessProvider.DeleteReglasDelEventoRecord(id);

            return Ok("Successfully deleted!");
        }

    }
}
