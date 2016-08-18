using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Julio.Model;

namespace Julio.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class CustomerController : Controller
    {
        [HttpGet]
        public IList<Customer> Get()
        {
            return new List<Customer>();
        }
    }
}