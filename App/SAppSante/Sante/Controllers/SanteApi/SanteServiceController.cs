using Json;
using Microsoft.AspNetCore.Mvc;
using Sante.Models.service;
using Newtonsoft.Json;

namespace Sante.Controllers.SanteApi;

[Route("api/[controller]/[action]")]
[ApiController]
public class SanteServiceController : ControllerBase
{
    [HttpGet]
    public string Test()
    {
        const string cin = "000000000003";
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