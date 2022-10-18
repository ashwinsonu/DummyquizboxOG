using Microsoft.AspNetCore.Mvc;
using MVC_Assign.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace MVC_Assign.Controllers
{
    public class MenuController : Controller
    {
        //string Baseurl = "https://localhost:44391/";
        static readonly log4net.ILog _log4net = log4net.LogManager.GetLogger(typeof(MenuController));
        public async Task<ActionResult> Chaat()
        {
            _log4net.Info("Chaat method called ");
            List<Chaat> Info = new List<Chaat>();

            using (var client = new HttpClient())
            {
                //Passing service base url  
               // client.BaseAddress = new Uri(Baseurl);

                client.DefaultRequestHeaders.Clear();
                //Define request data format  
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //Sending request to find web api REST service resource GetAllEmployees using HttpClient  
                HttpResponseMessage Res = await client.GetAsync("https://localhost:44391/api/Menu");

                //Checking the response is successful or not which is sent using HttpClient  
                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api   
                    var Response = Res.Content.ReadAsStringAsync().Result;

                    //Deserializing the response recieved from web api and storing into the Employee list  
                    Info = JsonConvert.DeserializeObject<List<Chaat>>(Response);

                }
                //returning the employee list to view  
                return View(Info);
            }
        }

        public async Task<ActionResult> Drinks()
        {
            _log4net.Info("Drinks method called ");
            List<Drink> Info = new List<Drink>();

            using (var client = new HttpClient())
            {
                //Passing service base url  
                // client.BaseAddress = new Uri(Baseurl);

                client.DefaultRequestHeaders.Clear();
                //Define request data format  
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //Sending request to find web api REST service resource GetAllEmployees using HttpClient  
                HttpResponseMessage Res = await client.GetAsync("https://localhost:44391/api/Menu/drinks");

                //Checking the response is successful or not which is sent using HttpClient  
                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api   
                    var Response = Res.Content.ReadAsStringAsync().Result;

                    //Deserializing the response recieved from web api and storing into the Employee list  
                    Info = JsonConvert.DeserializeObject<List<Drink>>(Response);
                }
                //returning the employee list to view  
                return View(Info);
            }
        }

       


    }
}
