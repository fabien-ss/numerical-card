using System.Diagnostics;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Sante.Models;
using Sante.Models.form;
using Sante.Models.service;

namespace Sante.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }
    [HttpGet]
    public async Task<IActionResult> YourActionMethod()
    {
        string apiUrl = "http://localhost:8080/Banque-war/ApiService"; // Replace with your actual API U
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
            throw new Exception("500 server is down.");
        }
    }

    static async Task<string> CallApi(string url, string jsonObject)
    {
        using (HttpClient client = new HttpClient())
        {
            StringContent content = new StringContent(jsonObject, Encoding.UTF8, "application/json");
            HttpResponseMessage responseMessage = await client.PostAsync(url, content);
            if (responseMessage.IsSuccessStatusCode)
            {
                return await responseMessage.Content.ReadAsStringAsync();
            }
            throw new Exception("500 server is down.");
        }
    }
    public async Task<IActionResult> Carte(String cin)
    {
        if (cin == null) cin = "000000000001";
        TempData["cin"] = cin;
        HttpContext.Session.SetString("cin", cin);
        Civil civil = new Civil
        {
            cin = cin
        };
        civil.GetCivilByCin();
        string apiUrl = "http://localhost:8080/Banque-war/MyServletBanque?cin="+cin;
        string apiResponse = await CallApi(apiUrl);
        civil.listeBanques =  JsonConvert.DeserializeObject<List<Sante.Models.service.Banque>>(apiResponse);
        string apiUrl2 = "http://localhost:8080/Banque-war/MyServlet?cin="+cin;
        string apiResponse2 = await CallApi(apiUrl2);
        string json2 = apiResponse2;
        Console.WriteLine("Territoire "+json2);
        //civil.json = json;
        civil.listeTerritories = JsonConvert.DeserializeObject<List<Models.service.Territory>>(json2);
        ViewData["civil"] = civil;
        return View();
    }
    public IActionResult Index()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }

}