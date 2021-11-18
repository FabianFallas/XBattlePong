using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using XBattlePongRestAPI.DataAccessAndDBContext;
using XBattlePongRestAPI.Models;

namespace XBattlePongRestAPI.Utils
{
    public class TokenManager
    {
        public string RandomString(int length)
        {
            const string valid = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
            StringBuilder res = new StringBuilder();
            using (RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider())
            {
                byte[] uintBuffer = new byte[sizeof(uint)];

                while (length-- > 0)
                {
                    rng.GetBytes(uintBuffer);
                    uint num = BitConverter.ToUInt32(uintBuffer, 0);
                    res.Append(valid[(int)(num % (uint)valid.Length)]);
                }
            }

            return res.ToString();
        }

        public bool isInEventDays(DateTime deadline) {
            DateTime now = DateTime.Now;
            if (DateTime.Compare(now,deadline) > 0)
            {
                   return false;
            }
            return true;
        }
    }
}
