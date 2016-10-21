using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;

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

        public ActionResult New()
        {
            return View();
        }

        #region
        //[Route("movies/released/{year:regex(\\d{4}):range(2012,2016)}/{month:regex(\\d{2}):range(1,12)}")] //attr route with constraints

        //[Route("movies/details/{id}")] 
        #endregion
        public ActionResult Details(int id)
        {
            #region
            //SingleOrDefault -- Returns the only element of a sequence that satisfies a specified condition or a default value if no such element exists; this method throws an exception if more than one element satisfies the condition.
            //get customer by calling GetCustomers, which returns a List of customers
            //"filter" that result of GetCustomers and obtain the Customer type object whose Id equals the id param
            //var customer = GetCustomers().SingleOrDefault(cust => cust.Id == id);

            /******************
            //Alternate version A, using an explicitly stated param type in the lambda expression:
            var customer = GetCustomers().SingleOrDefault((Customer cust) => cust.Id == id);
            ******************/

            /******************
            //Alternal version B, using a delegate anonymous function;
            var customer = GetCustomers().SingleOrDefault(delegate(Customer cust)
            {
                return cust.Id == id;
            });
            ******************/ 
            #endregion

            var customer = _context.Customers.Include(c => c.MembershipType).SingleOrDefault(c => c.Id == id); //get customer from database

            if (customer == null)
            {
                return HttpNotFound();
            } else
            {
                return View(customer);
            }

        }

        // GET: Customers
        public ActionResult Index()
        {
            //var customers = GetCustomers();
            var customers = _context.Customers.Include(c => c.MembershipType).ToList(); //get customers from table

            return View(customers);
        }

        #region Hard-coded data
        //private IEnumerable<Customer> GetCustomers()
        //{
        //    return new List<Customer>
        //    {
        //        new Customer { Id = 1, Name = "George Washington" },
        //        new Customer { Id = 2, Name = "John Adams" },
        //        new Customer { Id = 3, Name = "Thomas Jefferson" }
        //    };
        //} 
        #endregion
    }
}