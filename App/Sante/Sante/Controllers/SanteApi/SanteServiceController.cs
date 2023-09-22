using Microsoft.AspNetCore.Mvc;

namespace Sante.Controllers.SanteApi
{
    [Route("api/[controller]")]
    [ApiController]
    public class SanteServiceController : ControllerBase
    {

        [HttpGet]
        public IActionResult Index()
        {
            var data = new { message = "hello from you api" };
            return Ok(data);
        }

        [HttpPost]
        public IActionResult Post()
        {
            var data = new { message = "hello from you api post" };
            return Ok(data);
        }
    }
}