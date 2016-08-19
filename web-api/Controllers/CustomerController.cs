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
            var result = new List<Customer>();
            result.Add(new Customer() { Id = 1, FirstName = "Julio", LastName = "Pozo", DOB = DateTime.Parse("07/21/1972") });
            result.Add(new Customer() { Id = 2, FirstName = "Michelle", LastName = "Martin", DOB = DateTime.Parse("02/14/1973") });
            return result;
        }
    }
}