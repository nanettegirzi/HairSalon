using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using HairSalon.Models;
using System;

namespace HairSalonApp.Ccsontrollers
{
    public class CategoriesController : Controller
    {

        [HttpGet("/")]
        public ActionResult Index()
        {
            List<Stylist> allStylists = Stylist.GetAllStylists();
            return View(allStylists);
        }

        [HttpGet("/stylists/new")]
        public ActionResult CreateNewStylistForm()
        {
            return View();
        }

        [HttpPost("/stylists")]
        public ActionResult CreateNewStylist()
        {
            Stylist newStylist = new Stylist(Request.Form["new-stylist"]);
            newStylist.SaveStylist();
            List<Stylist> allStylists = Stylist.GetAllStylists();
            return View("Index", allStylists);
        }
    }
}
