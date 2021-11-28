using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using XBattlePongRestAPI.DataAccessAndDBContext;
using XBattlePongRestAPI.Models;

namespace XBattlePongRestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CatalogoDeNavesController : ControllerBase
    {
        private readonly ICatalogoDeNavesAccessProvider _catalogoDeNavesAccessProvider;
        public CatalogoDeNavesController(ICatalogoDeNavesAccessProvider catalogoDeNavesAccessProvider)
        {
            _catalogoDeNavesAccessProvider = catalogoDeNavesAccessProvider;
        }

        // GET: api/CatalogoDeNaves
        [HttpGet]
        public IEnumerable<CatalogoDeNaves> GetCatalogoDeNaves()
        {
            return _catalogoDeNavesAccessProvider.GetCatalogoDeNavesRecords();
        }
        // GET: api/CatalogoDeNaves/GetCatalogoDeNavesByToken/{token}
        [HttpGet("GetCatalogoDeNavesByToken/{token}")]
        public ActionResult<IEnumerable<CatalogoDeNaves>> GetPartidasByToken(string token)
        {

            var catalogoDeNaves = _catalogoDeNavesAccessProvider.GetCatalogoDeNavesRecordsByToken(token);

            if (catalogoDeNaves == null)
            {
                return NotFound();
            }

            return catalogoDeNaves;
        }

        // GET: api/CatalogoDeNaves/5
        [HttpGet("{id}")]
        public ActionResult<CatalogoDeNaves> GetCatalogoDeNaves(string id)
        {
            var catalogoDeNaves = _catalogoDeNavesAccessProvider.GetCatalogoDeNavesSingleRecord(id);

            if (catalogoDeNaves == null)
            {
                return NotFound();
            }

            return catalogoDeNaves;
        }
        // PUT: api/ReglasDelEvento/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut]
        public ActionResult PutCatalogoDeNaves([FromBody] CatalogoDeNaves catalogoDeNaves)
        {
            _catalogoDeNavesAccessProvider.UpdateCatalogoDeNavesRecord(catalogoDeNaves);
            return Ok("Updated!");

        }

        // POST: api/CatalogoDeNaves
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public ActionResult<CatalogoDeNaves> PostCatalogoDeNaves([FromBody] CatalogoDeNaves catalogoDeNaves)
        {
            Guid catalogoDeNavesID = Guid.NewGuid();
            catalogoDeNaves.naveID = catalogoDeNavesID.ToString();
            _catalogoDeNavesAccessProvider.AddCatalogoDeNavesRecord(catalogoDeNaves);
            string token = _catalogoDeNavesAccessProvider.GetTokenByCodigoDeEvento(catalogoDeNaves.codigoDeEvento_fk);
            List<CatalogoDeNaves> catalogoDeNavesList = _catalogoDeNavesAccessProvider.GetCatalogoDeNavesRecordsByToken(token);

            return Ok(catalogoDeNavesList.Count);
        }

        // DELETE: api/CatalogoDeNaves/5
        [HttpDelete("{id}")]
        public ActionResult<CatalogoDeNaves> DeleteCatalogoDeNaves(string id)
        {
            bool catalogoDeNaves = _catalogoDeNavesAccessProvider.CatalogoDeNavesExists(id);
            if (!catalogoDeNaves)
            {
                return NotFound();
            }

            _catalogoDeNavesAccessProvider.DeleteCatalogoDeNavesRecord(id);

            return Ok("Successfully deleted!");
        }

    }
}

