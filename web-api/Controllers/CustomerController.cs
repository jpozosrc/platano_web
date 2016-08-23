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
            result.Add(new Customer() { Id = 1, FirstName = "John", LastName = "Doe", DOB = DateTime.Parse("03/28/1979") });
            result.Add(new Customer() { Id = 2, FirstName = "Jane", LastName = "Doe", DOB = DateTime.Parse("04/16/1979") });
            return result;
        }
    }
}
