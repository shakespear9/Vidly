﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {
        // GET: Customers
        public ActionResult Index()
        {
            return View();
        }

        [Route("")]
        public ActionResult GetCustomers()
        {

        }

        //public ActionResult GetCustomer()
        //{
            
        //}
    }
}