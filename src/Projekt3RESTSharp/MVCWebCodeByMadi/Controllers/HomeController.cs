using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MVCWebCodeByMadi.Helper;
using MVCWebCodeByMadi.Models;

namespace MVCWebCodeByMadi.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }


        VenuesRestClient venuesRestClient = new VenuesRestClient();

        public IActionResult Venues()
        {
            List<Venues> venueList = new List<Venues>();
            venueList = venuesRestClient.GetVenues();


            return View(venueList);

        }



       

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }




    }
}

       










        
