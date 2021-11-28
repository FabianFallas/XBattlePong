using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XBattlePongRestAPI.Models;

namespace XBattlePongRestAPI.DataAccessAndDBContext
{
    public interface IUsuarioEnPartidaAccessProvider
    {
        /*
        Description: CRUD Operations for Usuario En Partida 
        */
        UsuarioEnPartida AddUsuarioEnPartidaRecord(UsuarioEnPartida usuarioEnPartida);
        void UpdateUsuarioEnPartidaRecord(UsuarioEnPartida usuarioEnPartida);
        void UpdateUsuarioEnPartidaSTATERecord(UsuarioEnPartida usuarioEnPartida);
        bool DeleteUsuarioEnPartidaRecord(string id);
        UsuarioEnPartida GetUsuarioEnPartidaSingleRecord(string id);
        string GetUsuarioEnPartidasStateByUsername(string username);
        List<UsuarioEnPartida> GetUsuarioEnPartidaRecords();
        bool UsuarioEnPartidaExists(string id);
    }
}
