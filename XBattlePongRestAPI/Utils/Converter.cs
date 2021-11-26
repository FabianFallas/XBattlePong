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
        public Partidas parseFromPartidasModelStrAttributesToIntList(Partidas selectedPartida) {
            string[] posJ1StrArray = selectedPartida.PosicionamientoBarcosJ1.Split(',');
            string[] posJ2StrArray = selectedPartida.PosicionamientoBarcosJ2.Split(',');
            selectedPartida.PosicionamientoBarcosJ1List = posJ1StrArray.Select(int.Parse).ToArray();
            if (posJ2StrArray.Length > 1)
            {
                selectedPartida.PosicionamientoBarcosJ2List = posJ2StrArray.Select(int.Parse).Cast<int?>().ToArray();
            }
            return selectedPartida;
        }
        public List<Partidas> parseFromPartidasListStrAttributesToIntList(List<Partidas> partidasList) {
            foreach (Partidas partida in partidasList)
            {
                string[] posJ1StrArray = partida.PosicionamientoBarcosJ1.Split(',');
                string[] posJ2StrArray = partida.PosicionamientoBarcosJ2.Split(',');
                partida.PosicionamientoBarcosJ1List = posJ1StrArray.Select(int.Parse).ToArray();
                if (posJ2StrArray.Length > 1)
                {
                    partida.PosicionamientoBarcosJ2List = posJ2StrArray.Select(int.Parse).Cast<int?>().ToArray();
                }

            }
            return partidasList;
        }
    }
}
