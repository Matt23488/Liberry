﻿using Liberry.Lib.DAL;
using Liberry.Lib.DTO;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Liberry.Lib.BLL
{
    public class TokenManager
    {
        private static readonly string _password = ConfigurationManager.AppSettings["password"];

        public TokenResponse GetToken(string password, string ipAddress)
        {
            var response = new TokenResponse();

            if (password != _password)
            {
                response.Valid = false;
            }
            else
            {
                response.Valid = true;
                response.Token = GenerateToken(ipAddress);
            }

            return response;
        }

        public bool ValidateToken(string token, string ipAddress)
        {
            using (var context = new LiberryContext())
            {
                var existingEntry = context.Tokens.FirstOrDefault(obj => obj.TokenValue == token && obj.IpAddress == ipAddress);
                
                return existingEntry != null && existingEntry.Expires > DateTime.Now;
            }
        }

        private string GenerateToken(string ipAddress)
        {
            const int numGuids = 2;
            var guidLength = Guid.Empty.ToByteArray().Length;

            var bytes = new byte[numGuids * guidLength];
            for (int i = 0; i < numGuids; i++)
            {
                Guid.NewGuid().ToByteArray().CopyTo(bytes, i * guidLength);
            }

            var tokenValue = Convert.ToBase64String(bytes);
            
            using (var context = new LiberryContext())
            {
                var nextId = 0;
                if (context.Tokens.Any())
                {
                    nextId = context.Tokens.Max(obj => obj.TokenId) + 1;
                }

                context.Tokens.Add(new Token
                {
                    TokenId = nextId,
                    TokenValue = tokenValue,
                    IpAddress = ipAddress,
                    Expires = DateTime.Now.AddMinutes(5) // TODO: Change to a higher number. Or better, make it configurable.
                });
            }

            return tokenValue;
        }
    }
}
