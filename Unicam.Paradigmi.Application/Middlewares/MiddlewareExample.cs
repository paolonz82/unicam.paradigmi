using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Unicam.Paradigmi.Application.Abstractions.Services;
using Unicam.Paradigmi.Application.Services;

namespace Unicam.Paradigmi.Application.Middlewares
{
    public class MiddlewareExample
    {
        private RequestDelegate _next;
        public MiddlewareExample(RequestDelegate next
            )
        {
            _next = next;
            
        }

        public async Task Invoke(HttpContext context
            , IAziendaService aziendaService
            )
        {
            //Implementiamo il codice effettivo del nostro middleware

            //Per andare al middleware successivo dobbiamo chiamare _next.Invoke();
            //context.Response.WriteAsync("Blocco la chiamata");
            await _next.Invoke(context);
        }
    }
}
