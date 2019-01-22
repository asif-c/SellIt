using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SellIt.Controllers
{
    public class SellIt : Controller
    {
        public ViewResult Index() => View();

        public ViewResult Post() => View();
    }
}
