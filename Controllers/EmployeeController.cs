using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Http;
using System.Net.Http.Formatting;
using ConsumeWEBAPIINMVC.Models;

namespace ConsumeWEBAPIINMVC.Controllers
{
    public class EmployeeController : Controller
    {
        //Inorder to communicate with WEB API we need HttpClient class
        HttpClient httpClient = new HttpClient();

        // GET: Employee
        public ActionResult Index()
        {
            //Specify the url of the web api
            var url = "http://localhost:60597/api/Employee";

            //Read the url and its return type is HttpResponseMessage
            HttpResponseMessage responseObj = httpClient.GetAsync(url).Result;

            //read the content using ReadAsAsync() and convert to appropriate model type
            List<Employee> employee = responseObj.Content.ReadAsAsync<List<Employee>>().Result;

            return View(employee);
        }

        public ActionResult Details(int id)
        {
            var url = "http://localhost:60597/api/Employee/" + id;

            HttpResponseMessage responseObj = httpClient.GetAsync(url).Result;

            Employee employee = responseObj.Content.ReadAsAsync<Employee>().Result;

            return View(employee);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Employee employee)
        {
            var url = "http://localhost:60597/api/Employee/";

            HttpResponseMessage responseObj = httpClient.PostAsJsonAsync(url, employee).Result;

            var res = responseObj.Content.ReadAsAsync<string>().Result;

            ViewBag.Response = res;

            return View();
        }

        public ActionResult Edit(int id)
        {
            var url = "http://localhost:60597/api/Employee/" + id;

            HttpResponseMessage responseObj = httpClient.GetAsync(url).Result;

            Employee employee = responseObj.Content.ReadAsAsync<Employee>().Result;

            return View(employee);
        }

        [HttpPost]
        public ActionResult Edit(Employee emp)
        {
            var url = "http://localhost:60597/api/Employee/" + emp.Eno;

            HttpResponseMessage responseObj = httpClient.PutAsJsonAsync(url, emp).Result;

            var response = responseObj.Content.ReadAsAsync<string>().Result;

            ViewBag.Response = response;

            return View();
        }

        public ActionResult Delete(int id)
        {
            var url = "http://localhost:60597/api/Employee/" + id;

            HttpResponseMessage responseObj = httpClient.GetAsync(url).Result;

            Employee employee = responseObj.Content.ReadAsAsync<Employee>().Result;

            return View(employee);
        }

        [HttpDelete]
        public ActionResult Delete(Employee emp)
        {
            var url = "http://localhost:60597/api/Employee/";

            HttpResponseMessage responseObj = httpClient.DeleteAsync(url).Result;

            ViewBag.Response = responseObj.Content.ReadAsAsync<string>().Result;

            return View();
        }
    }
}