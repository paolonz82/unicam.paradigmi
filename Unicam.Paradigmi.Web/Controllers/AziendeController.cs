using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Unicam.Paradigmi.Application.Abstractions.Services;
using Unicam.Paradigmi.Application.Factories;
using Unicam.Paradigmi.Application.Models.Requests;
using Unicam.Paradigmi.Application.Models.Responses;
using Unicam.Paradigmi.Application.Services;
using Unicam.Paradigmi.Application.Validators;
using Unicam.Paradigmi.Models.Entities;

namespace Unicam.Paradigmi.Web.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class AziendeController : ControllerBase
    {
        private readonly IAziendaService _aziendaService;
        public AziendeController(IAziendaService aziendaService)
        {
            _aziendaService = aziendaService;
        }
        
        
        [HttpPost]
        [Route("list")]
        public IActionResult GetAziende(GetAziendeRequest request)
        {
            // TODO : Validazione della richiesta
            int totalNum = 0;
            var aziende = _aziendaService.GetAziende(request.PageNumber * request.PageSize, request.PageSize, request.Name, out totalNum);

            var response = new GetAziendeResponse();
            var pageFounded = (totalNum / (decimal)request.PageSize);
            response.NumeroPagine = (int)Math.Ceiling(pageFounded);
            response.Aziende = aziende.Select(s =>
            new Application.Models.Dtos.AziendaDto(s)).ToList();


            return Ok(ResponseFactory
              .WithSuccess(response)
              );
        }

        [HttpGet]
        [Route("get/{id:int}")]
        public Azienda GetAzienda(int id)
        {
            //return aziende.Where(w => w.IdAzienda == id).First();
            return null;
        }

        [HttpPost]
        [Route("new")]
        public async Task<IActionResult> CreateAzienda(CreateAziendaRequest request)
        {
            var claimsIdentity = this.User.Identity as ClaimsIdentity;
            string idUtente = claimsIdentity.Claims
                .Where(w => w.Type == "id_utente").First().Value;
            /*var validator = new CreateAziendaRequestValidator();
            validator.Validate(request);*/
            var azienda = request.ToEntity();
            await _aziendaService.AddAziendaAsync(azienda);

            var response = new CreateAziendaResponse();
            response.Azienda = new Application.Models.Dtos.AziendaDto(azienda);
            return Ok(ResponseFactory 
                .WithSuccess(response)
                );
        } 

    }
}
