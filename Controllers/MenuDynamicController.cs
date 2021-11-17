using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using APIConsume.DAO;
using APIConsume.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace APIConsume.Controllers
{
    public class MenuDynamicController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
