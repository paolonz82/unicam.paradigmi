using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Runtime.InteropServices;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Unicam.Paradigmi.Application.Abstractions.Services;
using Unicam.Paradigmi.Application.Models.Requests;

namespace Unicam.Paradigmi.Application.Services
{
    public class TokenService : ITokenService
    {
        //Pacchetti nuget necessari  System.IdentityModel.Tokens.Jwt
        public  string CreateToken(CreateTokenRequest request)
        {
            //STEP 1 : Verificare esattezza della coppia username/password
            //TODO : Effettuare la verifica
            //STEP 2 : Se username/password corrette creo il token con le claims necessarie
            //TODO : Prendere i parametri dalla configurazione
            //TODO : Prendere le claims dal database
            string issuer = "https://paradigmi.unicam.it";
          
            List<Claim> claims = new List<Claim>();
            claims.Add(new Claim("Nome", "Federico"));
            claims.Add(new Claim("Cognome", "Paoloni"));
            string key = "Unicam.ParadigmiChiave1234567890123";
            var securityKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(key)
                );
            var credentials = new SigningCredentials(securityKey
                , SecurityAlgorithms.HmacSha256);

            var securityToken = new JwtSecurityToken(issuer
                , null
                , claims
                , expires: DateTime.Now.AddMinutes(30)
                , signingCredentials : credentials
                );

            var token = new JwtSecurityTokenHandler().WriteToken(securityToken);
            //STEP 3 : Restituisco il token
            return token;
        }
    }
}
