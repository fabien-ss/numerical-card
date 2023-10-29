using System.Text;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Sante.Models.service;

namespace Sante.Controllers.Banque;

public class BanqueController : Controller
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
    public async Task<IActionResult> Transaction()
    {
        List<Devise> devises = new List<Devise>();
        string apiurl = "http://localhost:8080/Foncier-war/getDevise";
        string apiResponse = await CallApi(apiurl);
        string json = apiResponse;
        devises = JsonConvert.DeserializeObject<List<Devise>>(json);
        ViewData["devises"] = devises;
        return View();
    }

    public async Task<IActionResult> DoTransaction()
    {
        double montant = double.Parse(HttpContext.Request.Form["montant"]);
        int idDevise = int.Parse(HttpContext.Request.Form["idDevise"]);
        string cin1 = HttpContext.Request.Form["cin1"];
        string cin2 = HttpContext.Request.Form["cin2"];
        string idBanque = HttpContext.Request.Form["idBanque"];
        Console.WriteLine(idBanque + " idbanque");
        string url = "?montant=" + montant + "&idDevise=" + idDevise + "&cin1=" + cin1 + "&cin2=" + cin2 + "&idBanque="+idBanque;
        string urlstring = "http://localhost:8080/Banque-war/Transcation" + url;
        Console.WriteLine(urlstring);
        Console.WriteLine(urlstring);
        string response = await CallApi(urlstring);
        Console.WriteLine(response);
        ViewData["message"] = response;
        return View();
    }
   
}

