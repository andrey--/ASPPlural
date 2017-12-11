using Microsoft.AspNetCore.Mvc;
using Start.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Start.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            var model = new Restaurant { Id = 1, Name = "Scott's Pizza Place" };
            return new ObjectResult(model);
        }
    }
}
