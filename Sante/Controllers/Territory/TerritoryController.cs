using System.Text;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Sante.Models.form;

namespace Sante.Controllers.Territory;

public class TerritoryController : Controller
{ 
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
            return "Error 500.";
        }
    }
    public async Task<IActionResult> NouveauTerrain(TerritoryForm territoryForm)
    {
        territoryForm.cin = HttpContext.Session.GetString("cin");
        Console.WriteLine("Cin "+HttpContext.Session.GetString("cin"));
        if (ModelState.IsValid)
        {
            territoryForm.cin = (string)TempData["cin"];
            territoryForm.JoinPoints();
            string JsonTerritory = JsonConvert.SerializeObject(territoryForm);
            Console.WriteLine("New territory = "+JsonTerritory);
            string url = "http://localhost:8080/Foncier-war/NouveauTerrain";
            string response = await CallApi(url, JsonTerritory);
            //return await Carte(territoryForm.cin);
        }
        return View();
    }

    public IActionResult Visualisation(string IdTerritoire)
    {
        ViewData["IdTerritoire"] = IdTerritoire;
        Console.WriteLine("ID territoire = "+ViewData["IdTerritoire"]);
        return View();
    }
}