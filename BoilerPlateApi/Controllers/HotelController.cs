using BoilerPlateApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace BoilerPlateApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HotelController : Controller
    {
        private readonly BoilerPlateContext _context;

        public HotelController(BoilerPlateContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery]  string id)
        {
            return Ok();
        }


    }
}
