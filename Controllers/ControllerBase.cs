using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace PlatanoWeb.Controllers
{
    public class ControllerBase : Controller
    {
        public IConfigurationSection AppSettings { get; set; }

        public ControllerBase(IConfiguration configuration)
        {
            AppSettings = configuration.GetSection("AppSettings");
        }
    }
}