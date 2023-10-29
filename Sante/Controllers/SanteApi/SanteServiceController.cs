namespace Sante.Controllers.SanteApi;

using Sante.Models.service;
using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]/[action]")]
[ApiController]
public class SanteServiceController : ControllerBase
{
    [HttpGet]
    public IActionResult Test(string cin)
    {
        Civil civil = new Civil
        {
            cin = cin
        };
        civil.GetCivilByCin();
        return Ok(civil);
    }
    [HttpPost]
    public IActionResult Post()
    {
        var data = new { message = "hello from you api post" };
        return Ok(data);
    }
}