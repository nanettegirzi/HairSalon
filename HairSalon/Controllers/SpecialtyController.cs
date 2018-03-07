using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using HairSalon.Models;
using System;

namespace HairSalon.Controllers
{
    public class SpecialtiesController : Controller
    {

        [HttpGet("/specialties")]
        public ActionResult Index()
        {
            List<Specialty> allSpecialties = Specialty.GetAllSpecialties();
            return View(allSpecialties);
        }

        [HttpGet("/specialties/new")]
        public ActionResult CreateForm()
        {
            return View();
        }
        [HttpPost("/specialties")]
        public ActionResult AddStudent()
        {
            Specialty newSpecialty = new Specialty(Request.Form["specialty"]);
            newSpecialty.SaveSpecialty();
            return RedirectToAction("Index");
        }

        [HttpGet("/specialties/{specialtyid}/delete")]
        public ActionResult DeleteOne(int specialtyId)
        {
            Specialty thisSpecialty = Specialty.FindSpecialty(specialtyId);
            thisSpecialty.DeleteSpecialty();
            return RedirectToAction("index");
        }
        [HttpGet("/specialties/{id}")]
        public ActionResult SpecialtyDetails(int id)
        {
            Dictionary<string, object> model = new Dictionary<string, object>();
            Specialty selectedSpecialty = Specialty.FindSpecialty(id);
            List<Stylist> specialtyStylists = selectedSpecialty.GetStylists();
            List<Stylist> allStylists = Stylist.GetAllStylists();
            model.Add("specialty", selectedSpecialty);
            model.Add("specialtyStylists", specialtyStylists);
            model.Add("allStylists", allStylists);
            return View( model);

        }

        [HttpPost("/specialties/{specialtyId}/stylists/new")]
        public ActionResult AddStylist(int specialtyId)
        {
            Specialty specialty = Specialty.FindSpecialty(specialtyId);
            Stylist stylist = Stylist.FindStylist(Int32.Parse(Request.Form["stylist-id"]));
            specialty.AddStylist(stylist);
            return RedirectToAction("Index");
        }

        [HttpGet("/specialties/{id}/update")]
        public ActionResult UpdateSpecialtyForm(int id)
        {
            Specialty thisSpecialty = Specialty.FindSpecialty(id);
            return View("updatespecialties", thisSpecialty);
        }
        [HttpPost("/specialties/{id}/update")]
        public ActionResult UpdateSpecialty(int id)
        {
          Specialty thisSpecialty = Specialty.FindSpecialty(id);
          thisSpecialty.UpdateSpecialty(Request.Form["specialty"]);
          return RedirectToAction("Index");
        }


    }
}
