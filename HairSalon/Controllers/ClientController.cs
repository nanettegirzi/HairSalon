using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using HairSalon.Models;
using System;

namespace HairSalon.Controllers
{
    public class ClientsController : Controller
    {

        [HttpGet("/clients")]
        public ActionResult Index()
        {
            List<Client> allClients = Client.GetAll();
            return View(allClients);
        }

        // [HttpGet("/clients/new")]
        // public ActionResult CreateForm()
        // {
        //     return View();
        // }

        [HttpPost("/clients/{id}/new")]
        public ActionResult CreateForm(int id)
        {
          int stylistId = Int32.Parse(Request.Form["stylist-id"]);
          return View(stylistId);
        }

        [HttpPost("/clients")]
        public ActionResult AddClient(int id)
        {
            Client newClient = new Client(Request.Form["client-name"],Int32.Parse(Request.Form["stylist-id"]));
            newClient.Save();
            return RedirectToAction("Index");
        }

        [HttpGet("/clients/{clientid}/delete")]
        public ActionResult DeleteOne(int clientId)
        {
            Client thisClient = Client.Find(clientId);
            thisClient.DeleteClient();
            return RedirectToAction("index");
        }
        [HttpGet("/clients/{id}")]
        public ActionResult ClientDetail(int id)
        {
            Client myClient = Client.Find(id);
            return View (myClient);
        }

        [HttpPost("/clients/{clientId}/specialties/new")]
        public ActionResult AddSpecialty(int stylistId)
        {
            Stylist stylist = Stylist.FindStylist(stylistId);
            Specialty specialty = Specialty.FindSpecialty(Int32.Parse(Request.Form["specialty-id"]));
            stylist.AddSpecialty(specialty);
            return RedirectToAction("Index");
        }

        [HttpGet("/clients/{id}/update")]
        public ActionResult UpdateClientForm(int id)
        {
            Client thisClient = Client.Find(id);
            return View(thisClient);
        }
        [HttpPost("/clients/{id}/update")]
        public ActionResult UpdateClient(int id)
        {
          Client thisClient = Client.Find(id);
          thisClient.Edit(Request.Form["new-client-name"]);
          return RedirectToAction("Index");
        }


    }
}
