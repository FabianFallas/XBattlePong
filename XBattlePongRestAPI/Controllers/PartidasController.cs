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
    public class PartidasController : ControllerBase
    {
        private readonly XBattlePongDbContext _context;

        public PartidasController(XBattlePongDbContext context)
        {
            _context = context;
        }

        // GET: api/Partidas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Partidas>>> GetPartidas()
        {
            return await _context.Partidas.ToListAsync();
        }

        // GET: api/Partidas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Partidas>> GetPartidas(string id)
        {
            var partidas = await _context.Partidas.FindAsync(id);

            if (partidas == null)
            {
                return NotFound();
            }

            return partidas;
        }

        // PUT: api/Partidas/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPartidas(string id, Partidas partidas)
        {
            if (id != partidas.PartidasID)
            {
                return BadRequest();
            }

            _context.Entry(partidas).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PartidasExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Partidas
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Partidas>> PostPartidas([FromBody]Partidas partidas)
        {
            Guid partidaID = Guid.NewGuid();
            Guid reglasDelEventoID = Guid.NewGuid();
            partidas.PartidasID = partidaID.ToString();
            partidas.ReglasDelEventoID = reglasDelEventoID.ToString();

            partidas.PosicionamientoBarcosJ1 = string.Join(",", partidas.PosicionamientoBarcosJ1List.Select(item => item.ToString()).ToArray());
            partidas.PosicionamientoBarcosJ2 = string.Join(",", partidas.PosicionamientoBarcosJ2List.Select(item => item.ToString()).ToArray());
            _context.Partidas.Add(partidas);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (PartidasExists(partidas.PartidasID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetPartidas", new { id = partidas.PartidasID }, partidas);
        }

        // DELETE: api/Partidas/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Partidas>> DeletePartidas(string id)
        {
            var partidas = await _context.Partidas.FindAsync(id);
            if (partidas == null)
            {
                return NotFound();
            }

            _context.Partidas.Remove(partidas);
            await _context.SaveChangesAsync();

            return partidas;
        }

        private bool PartidasExists(string id)
        {
            return _context.Partidas.Any(e => e.PartidasID == id);
        }
    }
}
