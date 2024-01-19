using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Unicam.Paradigmi.Application.Abstractions.Services;
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
        
        
        [HttpGet]
        [Route("list")]
        public IEnumerable<Azienda> GetAziende()
        {
            return null;
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
        public IActionResult CreateAzienda(CreateAziendaRequest request)
        {
            /*var validator = new CreateAziendaRequestValidator();
            validator.Validate(request);*/
            var azienda = request.ToEntity();
            _aziendaService.AddAzienda(azienda);

            var response = new CreateAziendaResponse();
            response.Azienda = new Application.Models.Dtos.AziendaDto(azienda);
            return Ok(response);
        } 

    }
}
