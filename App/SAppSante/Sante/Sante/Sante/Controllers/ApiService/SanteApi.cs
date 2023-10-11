
using System.Text.Json.Nodes;
using Newtonsoft.Json;

namespace Sante.Controllers.ApiService;

using Sante.Models.service;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

[Route("api/[controller]/[action]")]
[ApiController]
public class SanteServiceController : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> Test(string cin)
    {
        Civil civil = new Civil
        {
            cin = cin
        };
        civil.GetCivilByCin();
        string apiUrl = "http://localhost:8080/Banque-war/ApiService";
        string apiResponse = await CallApi(apiUrl);
        string json = apiResponse;
        civil.listeBanques =  JsonConvert.DeserializeObject<List<Banque>>(json);
        return Ok(civil);
    }
    [HttpPost]
    public IActionResult Post()
    {
        var data = new { message = "hello from you api post" };
        return Ok(data);
    }

    [HttpGet]
    public async Task<IActionResult> YourActionMethod()
    {
        string apiUrl = "http://localhost:8080/Banque-war/ApiService"; // Replace with your actual API URL
    
        try
        {
            string apiResponse = await CallApi(apiUrl);
            return Ok(apiResponse);
        }
        catch (Exception ex)
        {
            return Problem(("Tsia"));
        }
    }
 
    static async Task<string> CallApi(string apiUrl)
    {
        using (HttpClient client = new HttpClient())
        {
            HttpResponseMessage response = await client.GetAsync(apiUrl);

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsStringAsync();
            }

            return "Non";
        }
    }
}