using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using tacobellMVC.Models;

namespace tacobellMVC.Controllers
{
    public class NutritionController : Controller
    {
        string Baseurl = "https://localhost:44320/";
        public async Task<ActionResult> Nutrition()
        {
            List<FoodandNutrition> RegInfo = new List<FoodandNutrition>();

            using (var client = new HttpClient())
            {
                //Passing service base url  
                client.BaseAddress = new Uri(Baseurl);

                client.DefaultRequestHeaders.Clear();
                //Define request data format  
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //Sending request to find web api REST service resource GetAllEmployees using HttpClient  
                HttpResponseMessage Res = await client.GetAsync("/api/Nutritions");

                //Checking the response is successful or not which is sent using HttpClient  
                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api  
                    var RegResponse = Res.Content.ReadAsStringAsync().Result;

                    //Deserializing the response recieved from web api and storing into the Employee list  
                    RegInfo = JsonConvert.DeserializeObject<List<FoodandNutrition>>(RegResponse);

                }
                //returning the employee list to view  
                return View(RegInfo);
            }
        }
        //public IActionResult Nutrition()
        //{
        //    return View();
        //}

       // [HttpPost]
        //public async Task<IActionResult> Nutrition(Nutrition nutrition)
        //{
        //    Nutrition nobj = new Nutrition();
        //    using (var httpClient = new HttpClient())
        //    {
        //        StringContent content = new StringContent(JsonConvert.SerializeObject(nutrition), Encoding.UTF8, "application/json");

        //        using (var response = await httpClient.PostAsync("https://localhost:44320/api/Nutritions", content))
        //        {
        //            string apiResponse = await response.Content.ReadAsStringAsync();
        //            nobj = JsonConvert.DeserializeObject<Nutrition>(apiResponse);
        //        }
        //    }
        //    return RedirectToAction("Index");
        //}
            
        
    }
}


