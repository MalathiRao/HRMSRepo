using HRMS.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRMS.Web.Controllers
{
    public class ClientController : Controller
    {

        static List<Client> Clientdata = new List<Client>()
        {
                new Client { ClientId = 1, ClientName="Nstarx",Address="hyd",Website="https:tutorial",PrimaryContactPersonName="smith",PrimaryContactPersonEmail="smith@gmail.com",SecondaryContactPersonName="josh",SecondaryContactPersonEmail="josh@gmail.com"},
                new Client { ClientId = 2, ClientName="TCS",Address="hyd",Website="https:tutorial",PrimaryContactPersonName="john",PrimaryContactPersonEmail="john@gmail.com",SecondaryContactPersonName="smith",SecondaryContactPersonEmail="smith@gmail.com"},
                new Client { ClientId = 3, ClientName="Infosys",Address="Banglore",Website="https:tutorial",PrimaryContactPersonName="amy",PrimaryContactPersonEmail="amy@gmail.com",SecondaryContactPersonName="Alex",SecondaryContactPersonEmail="Alex@gmail.com"},
                new Client { ClientId = 4, ClientName="Accenture",Address="chennai",Website="https:tutorial",PrimaryContactPersonName="christaine",PrimaryContactPersonEmail="christane@gmail.com",SecondaryContactPersonName="johhny",SecondaryContactPersonEmail="johhny@gmail.com"},
            };
        public IActionResult Index()
        {
            return View(Clientdata);
        }
        public IActionResult Index1()
        {
            return View(Clientdata);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Client cli)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View("Create", cli);
                }
                Clientdata.Add(cli);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        [HttpGet]
        public ActionResult Details(int ClientId)
        {
            Client per = Clientdata.Find(obj => obj.ClientId == ClientId);
            
            return View(per);
        }
       
        [HttpGet]
        public async Task<IActionResult> Edit(int? ClientId)
        {
            ViewBag.PageName = ClientId == null ? "Create " : "Edit ";

            ViewBag.IsEdit = ClientId == null ? false : true;
            if (ClientId == null)
            {
                return View();
            }
            else
            {
                Client per = Clientdata.Find(emp => emp.ClientId == ClientId);
                return View(per);
            }            
        }
        [HttpPost]
        public IActionResult Edit(int ClientId, [Bind("ClientName,Address,Website,PrimaryContactPersonName,PrimaryContactPersonEmail,SecondaryContactPersonName,SecondaryContactPersonEmail")] Client values)
        {
            bool IsdataExist = false;
            Client obj = new Client();
            Client clientvalues =  Clientdata.FirstOrDefault(emp => emp.ClientId == ClientId);

            if (clientvalues != null)
            {
                IsdataExist = true;
            }
            else
            {
                obj = new Client();
                obj.ClientId = values.ClientId;
                obj.ClientName = values.ClientName;
                obj.Website = values.Website;
                obj.Address = values.Address;
                obj.PrimaryContactPersonName = values.PrimaryContactPersonName;
                obj.PrimaryContactPersonEmail = values.PrimaryContactPersonEmail;
                obj.SecondaryContactPersonName = values.SecondaryContactPersonName;
                obj.SecondaryContactPersonEmail = values.SecondaryContactPersonEmail;
            }

            if (ModelState.IsValid)
            {                
                if (IsdataExist)
                {
                   // Clientdata[clientvalues.ClientId] = clientvalues;                 
                    clientvalues.ClientName = values.ClientName;
                    clientvalues.Website = values.Website;
                    clientvalues.Address = values.Address;
                    clientvalues.PrimaryContactPersonName = values.PrimaryContactPersonName;
                    clientvalues.PrimaryContactPersonEmail = values.PrimaryContactPersonEmail;
                    clientvalues.SecondaryContactPersonName = values.SecondaryContactPersonName;
                    clientvalues.SecondaryContactPersonEmail = values.SecondaryContactPersonEmail;
                }
                else
                {
                    Clientdata.Add(obj);
                }
                return RedirectToAction(nameof(Index),Clientdata);                
            }
            return View(Clientdata);
        }

    }
}
