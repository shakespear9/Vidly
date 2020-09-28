using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Protocols;
using Vidly.Models;
using System.Data.Entity;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {

        private ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext();

        }


        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Customers
        public ActionResult Index()
        {
            //var customers = GetCustomers();
            // Include = change from LazyLoading to Eager Loading
            var customers = _context.Customers.Include((x)=> x.MembershipType).ToList();
            return View(customers);
            
        }

        public ActionResult Details(int id)
        {
            //var customer = GetCustomers().SingleOrDefault((x) => x.Id == id);
            var customer = _context.Customers.Include((c) => c.MembershipType).SingleOrDefault((x) => x.Id == id);
            if (customer == null) 
                return HttpNotFound();

            return View(customer);

        }




        //private IEnumerable<Customer> GetCustomers()
        //{
        //    return new List<Customer>
        //    {
        //        new Customer { Id = 1, Name = "John Smith" },
        //        new Customer { Id = 2, Name = "Mary Williams" }
        //    };
        //}
        

  
    }
}