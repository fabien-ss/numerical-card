
    using System.Web.Http.Cors;
    using Microsoft.EntityFrameworkCore.Metadata.Internal;

    namespace Sante.Controllers.ApiService;

    using Sante.Models.service;
    using Microsoft.AspNetCore.Mvc;
    using Newtonsoft.Json;

    [Route("api/[controller]/[action]")]
    [ApiController]
    [EnableCors("localhost:4200", "*", "*")]
    public class SanteService : ControllerBase
    {

        [HttpGet]
        public async Task<IActionResult> Test(string cin)
        {
            Civil civil = new Civil
            {
                cin = cin
            };
            
            civil.GetCivilByCin();
            string apiUrl = "http://localhost:8080/Banque-war/MyServletBanque?cin="+cin;
            string apiResponse = await CallApi(apiUrl);
            string json = apiResponse;
            //civil.json = json;
            civil.listeBanques =  JsonConvert.DeserializeObject<List<Banque>>(json);
            
            string apiUrl2 = "http://localhost:8080/Banque-war/MyServlet?cin="+cin;
            string apiResponse2 = await CallApi(apiUrl2);
            string json2 = apiResponse2;
            //civil.json = json;
            civil.listeTerritories = JsonConvert.DeserializeObject<List<Territory>>(json2);
            //Vie["Civil"] = civil;
            return Ok(civil);
        }

        [HttpPost]
        public IActionResult Post()
        {
            var data = new { message = "hello from your api post" };
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