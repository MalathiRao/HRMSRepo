using HRMS.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using System.Net.Http.Headers;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Authorization;

namespace HRMS.Web.Controllers
{
    [Authorize]
    public class ProfileSettingsController : Controller
    {        
        public ActionResult Index1()
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:55577");
                MediaTypeWithQualityHeaderValue contentType = new MediaTypeWithQualityHeaderValue("application/json");
                client.DefaultRequestHeaders.Accept.Add(contentType);
                HttpResponseMessage response = client.GetAsync("/Employees").Result;
                string stringData = response.Content.ReadAsStringAsync().Result;
                List<Employee> data = JsonConvert.DeserializeObject<List<Employee>>(stringData);
                var employee = data.Where(m => m.EmailID == "Ramakrishna.reddi@nstarxinc.com").FirstOrDefault();
                return View(employee);
            }
        }

        public ActionResult Index()
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:55577");
                MediaTypeWithQualityHeaderValue contentType = new MediaTypeWithQualityHeaderValue("application/json");
                client.DefaultRequestHeaders.Accept.Add(contentType);
                HttpResponseMessage response = client.GetAsync("/Employees").Result;
                string stringData = response.Content.ReadAsStringAsync().Result;
                List<Employee> data = JsonConvert.DeserializeObject<List<Employee>>(stringData);
                var employee = data.Where(m => m.EmailID == "Ramakrishna.reddi@nstarxinc.com").FirstOrDefault();
                List<ContactDetails> data1 = JsonConvert.DeserializeObject<List<ContactDetails>>(stringData);
                var contact = data1.Where(m => m.EmpID == employee.EmpID).FirstOrDefault();
                EmployeeContact employeeContact = new EmployeeContact();
                employeeContact.Contactdetails = contact;
                employeeContact.Employeedetails = employee;
                return View(employeeContact);
            }
        }
    }
}
