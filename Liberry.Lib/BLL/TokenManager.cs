using Liberry.Lib.DAL;
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
                var token = GenerateToken(ipAddress);
                response.Valid = true;
                response.Token = token.TokenValue;
                response.Expires = token.Expires;
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

        private Token GenerateToken(string ipAddress)
        {
            const int numGuids = 2;
            var guidLength = Guid.Empty.ToByteArray().Length;

            var bytes = new byte[numGuids * guidLength];
            for (int i = 0; i < numGuids; i++)
            {
                Guid.NewGuid().ToByteArray().CopyTo(bytes, i * guidLength);
            }

            var tokenValue = Convert.ToBase64String(bytes);
            var token = default(Token);
            
            using (var context = new LiberryContext())
            {
                // Remove old tokens assigned to this IP Address
                var existingTokens = context.Tokens.Where(obj => obj.IpAddress == ipAddress);
                context.Tokens.RemoveRange(existingTokens);

                var nextId = 0;
                if (context.Tokens.Any())
                {
                    nextId = context.Tokens.Max(obj => obj.TokenId) + 1;
                }

                token = new Token
                {
                    TokenId = nextId,
                    TokenValue = tokenValue,
                    IpAddress = ipAddress,
                    Expires = DateTime.Now.AddMinutes(5) // TODO: Change to a higher number. Or better, make it configurable.
                };

                context.Tokens.Add(token);
                context.SaveChanges();
            }

            return token;
        }
    }
}
