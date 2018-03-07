using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using HairSalon.Models;
using System;

namespace HairSalon.Controllers
{
    public class StylistsController : Controller
    {

        [HttpGet("/stylists")]
        public ActionResult Index()
        {
            List<Stylist> allStylists= Stylist.GetAllStylists();
            return View(allStylists);
        }

        [HttpGet("/stylists/new")]
        public ActionResult CreateForm()
        {
            return View();
        }
        [HttpPost("/stylists")]
        public ActionResult Create()
        {
            Stylist newStylist = new Stylist(Request.Form["stylist-name"], Request.Form["stylist-rate"]);
            newStylist.SaveStylist();
            return RedirectToAction("Index");
        }

        [HttpGet("/stylists/{id}")]
        public ActionResult StylistDetail(int id)
        {
            Dictionary<string, object> model = new Dictionary<string, object>();
            Stylist selectedStylist = Stylist.FindStylist(id);
            List<Specialty> stylistSpecialties = selectedStylist.GetSpecialties();
            List<Specialty> allSpecialties = Specialty.GetAllSpecialties();
            model.Add("stylist", selectedStylist);
            model.Add("stylistSpecialties", stylistSpecialties);
            model.Add("allSpecialties", allSpecialties);
            return View(model);
        }

        [HttpPost("/stylists/{stylistId}/specialties/new")]
        public ActionResult AddSpecialty(int stylistId)
        {
            Stylist stylist = Stylist.FindStylist(stylistId);
            Specialty specialty = Specialty.FindSpecialty(Int32.Parse(Request.Form["specialty-id"]));
            stylist.AddSpecialty(specialty);
            return RedirectToAction("Index");
        }

        [HttpGet("/stylists/{stylistId}/update")]
        public ActionResult UpdateForm(int stylistId)
        {
            Stylist thisStylist = Stylist.FindStylist(stylistId);
            return View("update", thisStylist);
        }

        [HttpPost("/stylists/{stylistId}/update")]
        public ActionResult Update(int stylistId)
        {
            Stylist thisStylist = Stylist.FindStylist(stylistId);
            thisStylist.UpdateStylist(Request.Form["new-stylist-name"], (Request.Form["new-stylist-rate"]));
            return RedirectToAction("Index");
        }

        [HttpGet("/stylists/{stylistid}/delete")]
        public ActionResult DeleteOne(int stylistId)
        {
            Stylist thisStylist = Stylist.FindStylist(stylistId);
            thisStylist.DeleteStylist();
            return RedirectToAction("index");
        }
    }
}
