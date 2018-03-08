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

        // [HttpGet("/stylists/new")]
        // public ActionResult CreateNewStylistForm()
        // {
        //     return View();
        // }

        // [HttpPost("/stylists")]
        // public ActionResult CreateNewStylist()
        // {
        //     Stylist newStylist = new Stylist(Request.Form["new-stylist"]);
        //     newStylist.SaveStylist();
        //     List<Stylist> allStylists = Stylist.GetAllStylists();
        //     return View("Index", allStylists);
        // }
        //
        // [HttpGet("/stylists/details/{id}")]
        // public ActionResult StylistDetails(int id)
        // {
        //     Dictionary<string, object> model = new Dictionary<string, object>();
        //     Stylist selectedStylist = Stylist.FindStylist(id);
        //     List<Client> stylistClients = selectedStylist.GetClients();
        //     model.Add("stylist", selectedStylist);
        //     model.Add("clients", stylistClients);
        //     return View("StylistDetails", model);
        // }
        //
        // [HttpPost("/stylists/details")]
        // public ActionResult PostStylistDetails()
        // {
        //     Client newClient = new Client (Request.Form["new-client"], Int32.Parse(Request.Form["stylist-id"]));
        //     newClient.Save();
        //     return RedirectToAction("StylistDetails", new {id = newClient.GetStylistId()});
        // }
        //
        // [HttpPost("/stylists/delete")]
        // public ActionResult DeleteAllStylists()
        // {
        //   Stylist.DeleteAllStylists();
        //   return View();
        // }
        //
        // [HttpGet("/clients/new/{clientid}")]
        // public ActionResult CreateNewClientForm(int clientid)
        // {
        //     return View(clientid);
        // }
        //
        // [HttpGet("/clients/{id}")]
        // public ActionResult ClientDetails(int id)
        // {
        //     Client client = Client.Find(id);
        //     return View(client);
        // }
        //
        // [HttpPost("/clients")]
        // public ActionResult CreateNewClient()
        // {
        //   Client newClient = new Client (Request.Form["new-client"]);
        //   newClient.Save();
        //   List<Client> allClients = Client.GetAll();
        //   return View("Index", allClients);
        // }
        //
        // // [HttpGet("/clients/{id}/update")]
        // // public ActionResult UpdateClientForm(int id)
        // // {
        // //   Client thisClient = Client.Find(id);
        // //     return View(thisClient);
        // // }
        // // [HttpPost("/clients/{id}/update")]
        // // public ActionResult UpdateClient(int id)
        // // {
        // //     Client thisClient = Client.Find(id);
        // //     thisClient.Edit(Request.Form["newname"]);
        // //     return RedirectToAction("Index");
        // // }
        //
        // [HttpPost("/clients/delete")]
        // public ActionResult DeleteClients()
        // {
        //   Client.DeleteAll();
        //   return View();
        // }
    }
}
