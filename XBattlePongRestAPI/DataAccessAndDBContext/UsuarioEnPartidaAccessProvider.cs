using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XBattlePongRestAPI.Models;
using XBattlePongRestAPI.Utils;

namespace XBattlePongRestAPI.DataAccessAndDBContext
{
    public class UsuarioEnPartidaAccessProvider : IUsuarioEnPartidaAccessProvider
    {
        private XBattlePongDbContext _xBattlePongDbContext;
        private Converter converter = new Converter();
        public UsuarioEnPartidaAccessProvider(XBattlePongDbContext context)
        {
            _xBattlePongDbContext = context;
        }
        public UsuarioEnPartida AddUsuarioEnPartidaRecord(UsuarioEnPartida usuarioEnPartida)
        {
            _xBattlePongDbContext.UsuarioEnPartida.Add(usuarioEnPartida);
            _xBattlePongDbContext.SaveChanges();
            return usuarioEnPartida;
        }

        public bool DeleteUsuarioEnPartidaRecord(string NombreDeUsuario)
        {
            var UsuarioEnPartidaToBeDeleted = _xBattlePongDbContext.UsuarioEnPartida.Find(NombreDeUsuario);
            if (UsuarioEnPartidaToBeDeleted != null)
            {
                _xBattlePongDbContext.UsuarioEnPartida.Remove(UsuarioEnPartidaToBeDeleted);
                _xBattlePongDbContext.SaveChanges();
                return true;
            }
            return false;
        }

        public List<UsuarioEnPartida> GetUsuarioEnPartidaRecords()
        {
            List<UsuarioEnPartida> usuarioEnPartidaList = _xBattlePongDbContext.UsuarioEnPartida.ToList();
            usuarioEnPartidaList = converter.parseFromUsuarioEnPartidaListStrAttributesToIntList(usuarioEnPartidaList);
            return usuarioEnPartidaList;
        }

        public UsuarioEnPartida GetUsuarioEnPartidaSingleRecord(string username)
        {
            UsuarioEnPartida selectedUsuarioEnPartida = _xBattlePongDbContext.UsuarioEnPartida.SingleOrDefault(x => x.NombreDeUsuario == username);
            selectedUsuarioEnPartida = converter.parseFromUsuarioEnPartidaModelStrAttributesToIntList(selectedUsuarioEnPartida);
            return selectedUsuarioEnPartida;
        }

        public string GetUsuarioEnPartidasStateByUsername(string username)
        {
            UsuarioEnPartida selectedUsuarioEnPartida = _xBattlePongDbContext.UsuarioEnPartida.SingleOrDefault(x => x.NombreDeUsuario == username);
            return selectedUsuarioEnPartida.Estado;
        }

        public void UpdateUsuarioEnPartidaRecord(UsuarioEnPartida usuarioEnPartida)
        {
            var usuarioEnPartidaSelected = _xBattlePongDbContext.UsuarioEnPartida.SingleOrDefault(u => u.partidasID_fk == usuarioEnPartida.partidasID_fk); ;
            usuarioEnPartidaSelected.PosicionamientoDeJugadasList = usuarioEnPartida.PosicionamientoDeJugadasList;
            usuarioEnPartidaSelected.PosicionamientoDeJugadas = usuarioEnPartida.PosicionamientoDeJugadas;
            _xBattlePongDbContext.UsuarioEnPartida.Update(usuarioEnPartidaSelected);
            _xBattlePongDbContext.SaveChanges();
        }

        public void UpdateUsuarioEnPartidaSTATERecord(UsuarioEnPartida usuarioEnPartida)
        {
            var usuarioEnPartidaSelected = _xBattlePongDbContext.UsuarioEnPartida.SingleOrDefault(u => u.NombreDeUsuario == usuarioEnPartida.NombreDeUsuario); ;
            string currentState = usuarioEnPartidaSelected.Estado;
            if (currentState == "StandBy")
            {
                usuarioEnPartidaSelected.Estado = "Playing";
            }
            else 
            {
                usuarioEnPartidaSelected.Estado = "StandBy";
            }
            _xBattlePongDbContext.UsuarioEnPartida.Update(usuarioEnPartidaSelected);
            _xBattlePongDbContext.SaveChanges();
        }

        public bool UsuarioEnPartidaExists(string username)
        {
            return _xBattlePongDbContext.UsuarioEnPartida.Any(up => up.NombreDeUsuario == username);
        }
    }
}
