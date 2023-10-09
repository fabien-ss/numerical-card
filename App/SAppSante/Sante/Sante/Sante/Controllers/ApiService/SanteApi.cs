using Newtonsoft.Json;

namespace Sante.Controllers.ApiService;

using Sante.Models.service;
using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]/[action]")]
[ApiController]
public class SanteServiceController : ControllerBase
{
    [HttpGet]
    public string Test(string cin)
    {
        Civil civil = new Civil
        {
            cin = cin
        };
        civil.GetCivilByCin();
        string json = JsonConvert.SerializeObject(civil);
        return json;
    }
    [HttpPost]
    public IActionResult Post()
    {
        var data = new { message = "hello from you api post" };
        return Ok(data);
    }
}