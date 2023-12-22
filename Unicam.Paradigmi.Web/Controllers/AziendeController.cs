using Microsoft.AspNetCore.Mvc;
using Unicam.Paradigmi.Models.Entities;

namespace Unicam.Paradigmi.Web.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class AziendeController : ControllerBase
    {
        List<Azienda> aziende = new List<Azienda>();
        public AziendeController()
        {
            aziende.Add(new Azienda()
            {
                IdAzienda = 1,
                Citta = "Camerino",
                RagioneSociale = "Unicam",
                Cap = "12345"
            });
            aziende.Add(new Azienda()
            {
                IdAzienda = 2,
                Citta = "Tolentino",
                RagioneSociale = "PCSNET",
                Cap = "54321"
            });
        }

        [HttpGet]
        [Route("list")]
        public IEnumerable<Azienda> GetAziende()
        {
            return aziende;
        }

        [HttpGet]
        [Route("get/{id:int}")]
        public Azienda GetAzienda(int id)
        {
            return aziende.Where(w => w.IdAzienda == id).First();
        }

        [HttpPost]
        [Route("new")]
        public IActionResult CreateAzienda(Azienda azienda)
        {
            return Ok();
        } 

    }
}
