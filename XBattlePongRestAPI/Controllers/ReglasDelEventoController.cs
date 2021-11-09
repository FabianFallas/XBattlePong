using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using XBattlePongRestAPI.DataAccessAndModels;

namespace XBattlePongRestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReglasDelEventoController : ControllerBase
    {
        private readonly XBattlePongDbContext _context;

        public ReglasDelEventoController(XBattlePongDbContext context)
        {
            _context = context;
        }

        // GET: api/ReglasDelEvento
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ReglasDelEvento>>> GetReglasDelEventos()
        {
            return await _context.ReglasDelEvento.ToListAsync();
        }

        // GET: api/ReglasDelEventoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ReglasDelEvento>> GetReglasDelEvento(string id)
        {
            var reglasDelEvento = await _context.ReglasDelEvento.FindAsync(id);

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
        public async Task<IActionResult> PutReglasDelEvento([FromBody] ReglasDelEvento reglasDelEvento)
        {
           
            _context.Entry(reglasDelEvento).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
                return Ok("Updated!");
            }
            catch (DbUpdateConcurrencyException)
            {
               throw;
            
            }

        }

        // POST: api/ReglasDelEventoes
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<ReglasDelEvento>> PostReglasDelEvento([FromBody] ReglasDelEvento reglasDelEvento)
        {
            Guid reglasDelEventoID = Guid.NewGuid();
            reglasDelEvento.ReglaDelEventoID = reglasDelEventoID.ToString();
            _context.ReglasDelEvento.Add(reglasDelEvento);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ReglasDelEventoExists(reglasDelEvento.ReglaDelEventoID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetReglasDelEvento", new { id = reglasDelEvento.ReglaDelEventoID }, reglasDelEvento);
        }

        // DELETE: api/ReglasDelEventoes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ReglasDelEvento>> DeleteReglasDelEvento(string id)
        {
            var reglasDelEvento = await _context.ReglasDelEvento.FindAsync(id);
            if (reglasDelEvento == null)
            {
                return NotFound();
            }

            _context.ReglasDelEvento.Remove(reglasDelEvento);
            await _context.SaveChangesAsync();

            return reglasDelEvento;
        }

        private bool ReglasDelEventoExists(string id)
        {
            return _context.ReglasDelEvento.Any(e => e.ReglaDelEventoID == id);
        }
    }
}
