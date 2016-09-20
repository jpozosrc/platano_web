using System;
using Microsoft.AspNetCore.Mvc;
using PlatanoWeb.Model;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Text;
using System.Net.Http;
using Newtonsoft.Json;

namespace PlatanoWeb.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        
        [HttpPost]
        public async Task<IActionResult> Index(AutomationCommand cmd)
        {
            cmd.TimeStamp = DateTime.Now;
            cmd.UserName = "jpozo";
            cmd.CommandText = "GARAGE-DOOR";
            cmd.CommandArgs = "ACTION=OPEN";
            
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:8079");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            
                var json = JsonConvert.SerializeObject(cmd);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await client.PostAsync("/api/automationcommand", content);
            
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsStringAsync();
                }
            }
            
            return View();
        } 

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:8079");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var uri = String.Format("/api/automationcommand/{0}", id.ToString());
                var response = await client.DeleteAsync(uri);
                Console.Out.WriteLine(uri);
            }

            return RedirectToAction("ViewQueue");
        }

        [HttpGet]
        public async Task<IActionResult> ViewQueue()
        {
            AutomationCommand[] cmds = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:8079");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            
                var response = await client.GetAsync("/api/automationcommand");
            
                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    cmds = JsonConvert.DeserializeObject<AutomationCommand[]>(json);
                }
            }

            return View(cmds);
        }

        public IActionResult Error()
        {
            return View();
        }   
    }
}