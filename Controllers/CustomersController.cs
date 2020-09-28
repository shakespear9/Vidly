using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Protocols;
using Vidly.Models;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {
        // GET: Customers
        public ActionResult Index()
        {
            var customers = GetCustomers();
            return View(customers);
            
        }

        public ActionResult Details(int id)
        {
            var customer = GetCustomers().SingleOrDefault((x) => x.Id == id);
            if (customer == null) 
                return HttpNotFound();

            return View(customer);


            //return customer == null ? HttpNotFound() : View(customer);
            //return customer == null ? HttpNotFound() : View(Customer);
        }

        private IEnumerable<Customer> GetCustomers()
        {
            return new List<Customer>
            {
                new Customer { Id = 1, Name = "John Smith" },
                new Customer { Id = 2, Name = "Mary Williams" }
            };
        }
        

        //public ActionResult GetCustomer()
        //{
            
        //}
    }
}