using Microsoft.AspNetCore.Mvc;
using SellIt.Models;
using SellIt.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SellIt.Controllers
{
    public class SellIt : Controller
    {
        public HardCodedData Data { get; }

        public SellIt(HardCodedData data)
        {
            Data = data;
        }


        public ViewResult Index()
        {
            return View(Data.Posts);
        }

        public ViewResult Post() => View();
    }
}
