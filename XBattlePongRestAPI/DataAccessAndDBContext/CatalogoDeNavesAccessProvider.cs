using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XBattlePongRestAPI.Models;

namespace XBattlePongRestAPI.DataAccessAndDBContext
{
    public class CatalogoDeNavesAccessProvider : ICatalogoDeNavesAccessProvider
    {
        private XBattlePongDbContext _xBattlePongDbContext;
        public CatalogoDeNavesAccessProvider(XBattlePongDbContext context)
        {
            _xBattlePongDbContext = context;
        }
        public CatalogoDeNaves AddCatalogoDeNavesRecord(CatalogoDeNaves catalogoDeNaves)
        {
            var random = new Random();
            var color = String.Format("#{0:X6}", random.Next(0x1000000));
            catalogoDeNaves.color = color;
            _xBattlePongDbContext.CatalogoDeNaves.Add(catalogoDeNaves);
            _xBattlePongDbContext.SaveChanges();
            return catalogoDeNaves;
        }

        public bool CatalogoDeNavesExists(string id)
        {
            return _xBattlePongDbContext.CatalogoDeNaves.Any(c => c.naveID == id);
        }

        public bool DeleteCatalogoDeNavesRecord(string id)
        {
            var catalogoDeNavesToBeDeleted = _xBattlePongDbContext.CatalogoDeNaves.Find(id);
            if (catalogoDeNavesToBeDeleted != null)
            {
                _xBattlePongDbContext.CatalogoDeNaves.Remove(catalogoDeNavesToBeDeleted);
                _xBattlePongDbContext.SaveChanges();
                return true;
            }
            return false;
        }

        public List<CatalogoDeNaves> GetCatalogoDeNavesRecords()
        {
            List<CatalogoDeNaves> catalogoDeNavesList = _xBattlePongDbContext.CatalogoDeNaves.ToList();
            return catalogoDeNavesList;
        }

        public CatalogoDeNaves GetCatalogoDeNavesSingleRecord(string id)
        {
            CatalogoDeNaves selectedCatalagoDeNaves = _xBattlePongDbContext.CatalogoDeNaves.SingleOrDefault(x => x.naveID == id);
            return selectedCatalagoDeNaves;
        }

        public void UpdateCatalogoDeNavesRecord(CatalogoDeNaves catalogoDeNaves)
        {
            _xBattlePongDbContext.CatalogoDeNaves.Update(catalogoDeNaves);
            _xBattlePongDbContext.SaveChanges();
        }
    }
}
