using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace APIConsume.Controllers
{
    public class DetailDosenController : Controller
    {
        public IActionResult Index(string idDosen="0")
        {
            return View();
        }
    }
}