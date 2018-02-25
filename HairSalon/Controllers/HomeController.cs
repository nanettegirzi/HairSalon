using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using HairSalon.Models;
using System;

namespace HairSalon.Controllers
{
    public class HomeController : Controller
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

        [HttpGet("/stylists/details/{id}")]
        public ActionResult StylistDetails(int id)
        {
            Dictionary<string, object> model = new Dictionary<string, object>();
            Stylist selectedStylist = Stylist.FindStylist(id);
            List<Client> stylistClients = selectedStylist.GetClients();
            model.Add("stylist", selectedStylist);
            model.Add("clients", stylistClients);
            return View("StylistDetails", model);
        }

        [HttpPost("/stylists/details")]
        public ActionResult PostStylistDetails()
        {
            Client newClient = new Client (Request.Form["new-client"], Int32.Parse(Request.Form["stylist-id"]));
            newClient.Save();
            return RedirectToAction("StylistDetails", new {id = newClient.GetStylistId()});
        }

        [HttpPost("/stylists/delete")]
        public ActionResult DeleteAllStylists()
        {
          Stylist.DeleteAllStylists();
          return View();
        }
    }
}
