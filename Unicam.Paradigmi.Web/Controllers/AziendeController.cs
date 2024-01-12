using Microsoft.AspNetCore.Mvc;
using Unicam.Paradigmi.Application.Abstractions.Services;
using Unicam.Paradigmi.Application.Models.Requests;
using Unicam.Paradigmi.Application.Services;
using Unicam.Paradigmi.Models.Entities;

namespace Unicam.Paradigmi.Web.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
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
            var azienda = request.ToEntity();
            _aziendaService.AddAzienda(azienda);
            return Ok();
        } 

    }
}
