using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XBattlePongRestAPI.Models;

namespace XBattlePongRestAPI.DataAccessAndDBContext
{
    public interface ICatalogoDeNavesAccessProvider
    {
        /*
       Description: CRUD Operations for Catalogo de Naves
       */
        CatalogoDeNaves AddCatalogoDeNavesRecord(CatalogoDeNaves catalogoDeNaves);
        void UpdateCatalogoDeNavesRecord(CatalogoDeNaves catalogoDeNaves);
        bool DeleteCatalogoDeNavesRecord(string id);
        CatalogoDeNaves GetCatalogoDeNavesSingleRecord(string id);
        List<CatalogoDeNaves> GetCatalogoDeNavesRecords();
        bool CatalogoDeNavesExists(string id);
    }
}
