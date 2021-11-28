using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XBattlePongRestAPI.Models;

namespace XBattlePongRestAPI.Utils
{
    public class Converter
    {
        public TimeSpan parseStrToTimeSpan(string timeSTR) {
            return TimeSpan.Parse(timeSTR);
        }

        public string parseListToStr(int[] posicionesList) {

            string str = string.Join(",",posicionesList.Select(item => item.ToString()).ToArray());
            return str;
        }
        public string parseCanBeEmptyListToStr(int?[] posicionesList)
        {

            string str = string.Join(",", posicionesList.Select(item => item.ToString()).ToArray());
            return str;
        }
        public UsuarioEnPartida parseFromUsuarioEnPartidaModelStrAttributesToIntList(UsuarioEnPartida selectedUsuarioEnPartida) {
            string[] posicionamientoStrArray = selectedUsuarioEnPartida.PosicionamientoBarcos.Split(',');
            string[] jugadasStrArray = selectedUsuarioEnPartida.PosicionamientoDeJugadas.Split(',');
            selectedUsuarioEnPartida.PosicionamientoBarcosList = posicionamientoStrArray.Select(int.Parse).ToArray();
            if (jugadasStrArray.Length > 1)
            {
                selectedUsuarioEnPartida.PosicionamientoDeJugadasList = jugadasStrArray.Select(int.Parse).Cast<int?>().ToArray();
            }
            return selectedUsuarioEnPartida;
        }
        public List<UsuarioEnPartida> parseFromUsuarioEnPartidaListStrAttributesToIntList(List<UsuarioEnPartida> usuarioEnPartidaList) {
            foreach (UsuarioEnPartida usuarioEnPartida in usuarioEnPartidaList)
            {
                string[] posicionamientoStrArray = usuarioEnPartida.PosicionamientoBarcos.Split(',');
                string[] jugadasStrArray = usuarioEnPartida.PosicionamientoDeJugadas.Split(',');
                usuarioEnPartida.PosicionamientoBarcosList = posicionamientoStrArray.Select(int.Parse).ToArray();
                if (jugadasStrArray.Length > 1)
                {
                    usuarioEnPartida.PosicionamientoDeJugadasList = jugadasStrArray.Select(int.Parse).Cast<int?>().ToArray();
                }

            }
            return usuarioEnPartidaList;
        }
    }
}
