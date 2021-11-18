﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XBattlePongRestAPI.Models;
using XBattlePongRestAPI.Utils;

namespace XBattlePongRestAPI.DataAccessAndDBContext
{
    public class TokenConEventoAccessProvider : ITokenConEventoAccessProvider
    {
        private XBattlePongDbContext _xBattlePongDbContext;
        private TokenConEvento tokenConEvento = new TokenConEvento();
        TokenManager tokenManager = new TokenManager();
        public TokenConEventoAccessProvider(XBattlePongDbContext context)
        {
            _xBattlePongDbContext = context;
        }
        public TokenConEvento AddTokenConEventoRecord(string codigoDeEvento)
        {
           
            tokenConEvento.token = tokenManager.RandomString(6);
            tokenConEvento.codigoDeEvento_fk = codigoDeEvento;
            _xBattlePongDbContext.TokenConEvento.Add(tokenConEvento);
            _xBattlePongDbContext.SaveChanges();
            return tokenConEvento;
        }
        public bool TokenConEventoExists(string codigoDeEvento)
        {
            return _xBattlePongDbContext.TokenConEvento.Any(t => t.codigoDeEvento_fk == codigoDeEvento);
        }
        public bool DeleteTokenConEventoRecord(string codigoDeEvento)
        {
            var tokenConEventoToBeDeleted = _xBattlePongDbContext.TokenConEvento.SingleOrDefault(t => t.codigoDeEvento_fk == codigoDeEvento);
            if (tokenConEventoToBeDeleted != null)
            {
                _xBattlePongDbContext.TokenConEvento.Remove(tokenConEventoToBeDeleted);
                _xBattlePongDbContext.SaveChanges();
                return true;
            }
            return false;
        }

        public List<TokenConEvento> GetTokenConEventoRecords()
        {
            return _xBattlePongDbContext.TokenConEvento.ToList(); ;
        }

        public TokenConEvento GetTokenConEventoSingleRecord(string codigoDeEvento)
        {
            TokenConEvento selectedTokenConEvento = _xBattlePongDbContext.TokenConEvento.SingleOrDefault(x => x.codigoDeEvento_fk == codigoDeEvento);
            return selectedTokenConEvento;
        }
    }
}
