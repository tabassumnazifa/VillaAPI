using Microsoft.AspNetCore.Mvc;
using WebAPI_Tutorial.Models;

namespace WebAPI_Tutorial.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VillaAPIController : ControllerBase
    {
        private static List<Villa> villas = new List<Villa>
        {
            new Villa { Id = 1, Name = "Villa 1" },
            new Villa { Id = 2, Name = "Villa 2" }
        };

        [HttpGet]
        public IEnumerable<Villa> GetVillas()
        {
            return villas;
        }

        [HttpPost]
        public IActionResult CreateVilla(Villa villa)
        {
            villa.Id = villas.Count + 1;
            villas.Add(villa);
            return Ok(villa);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteVilla(int id)
        {
            var villa = villas.FirstOrDefault(v => v.Id == id);
            if (villa == null) return NotFound();

            villas.Remove(villa);
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateVilla(int id, Villa updatedVilla)
        {
            var villa = villas.FirstOrDefault(v => v.Id == id);
            if (villa == null) return NotFound();

            villa.Name = updatedVilla.Name;
            return Ok(villa);
        }
    }
}