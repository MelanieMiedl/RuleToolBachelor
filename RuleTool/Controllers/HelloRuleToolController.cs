using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace RuleTool.Controllers
{
    public class HelloRuleToolController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}