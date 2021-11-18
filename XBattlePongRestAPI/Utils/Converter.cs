using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace XBattlePongRestAPI.Utils
{
    public class Converter
    {
        public TimeSpan parseStrToTimeSpan(string timeSTR) {
            return TimeSpan.Parse(timeSTR);
        }
    }
}
