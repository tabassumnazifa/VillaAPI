using Microsoft.AspNetCore.Mvc;
using WebAPI_Tutorial.Models;

namespace WebAPI_Tutorial.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VillaAPIController : ControllerBase
    {
        private IEnumerable<Villa> villas = new List<Villa>
        {
            new Villa { Id = 1, Name = "Villa 1" },
            new Villa { Id = 2, Name = "Villa 2" }
        };

        [HttpGet]
        public IEnumerable<Villa> GetVillas()
        {
            return villas;
        }
    }
}
