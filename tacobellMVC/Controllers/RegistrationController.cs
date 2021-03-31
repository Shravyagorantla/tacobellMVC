using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using tacobellMVC.Models;

namespace tacobellMVC.Controllers
{
    public class RegistrationController : Controller
    {
        string Baseurl = "https://localhost:44332/";
        public async Task<ActionResult> Index()
        {
            List<Registration> RegInfo = new List<Registration>();

            using (var client = new HttpClient())
            {
                //Passing service base url  
                client.BaseAddress = new Uri(Baseurl);

                client.DefaultRequestHeaders.Clear();
                //Define request data format  
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //Sending request to find web api REST service resource GetAllEmployees using HttpClient  
                HttpResponseMessage Res = await client.GetAsync("/api/Registrations");

                //Checking the response is successful or not which is sent using HttpClient  
                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api  
                    var RegResponse = Res.Content.ReadAsStringAsync().Result;

                    //Deserializing the response recieved from web api and storing into the Employee list  
                    RegInfo = JsonConvert.DeserializeObject<List<Registration>>(RegResponse);

                }
                //returning the employee list to view  
                return View(RegInfo);
            }
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Register(Registration registration)
        {
            Registration regobj = new Registration();
            using (var httpClient = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(registration), Encoding.UTF8, "application/json");

                using (var response = await httpClient.PostAsync("https://localhost:44332/api/Registrations", content))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    regobj = JsonConvert.DeserializeObject<Registration>(apiResponse);
                }
            }
            return RedirectToAction("Index");
        }



    }


}


