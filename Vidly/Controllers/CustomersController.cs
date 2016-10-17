using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {
        //[Route("movies/released/{year:regex(\\d{4}):range(2012,2016)}/{month:regex(\\d{2}):range(1,12)}")] //attr route with constraints

        //[Route("movies/details/{id}")]
        public ActionResult Details(int id)
        {
            var customer = GetCustomers().SingleOrDefault(cust => cust.Id == id);

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
            var customers = GetCustomers();

            return View(customers);
        }

        private IEnumerable<Customer> GetCustomers()
        {
            return new List<Customer>
            {
                new Customer { Id = 1, Name = "George Washington", Bio = "Bacon ipsum dolor amet andouille kielbasa strip steak pig. Chicken kevin ground round bresaola pork loin. Capicola beef salami, venison tenderloin turducken tail. T-bone pastrami burgdoggen, salami swine tail ham hock spare ribs venison pork loin tri-tip short loin shank brisket boudin. Hamburger pork turducken strip steak. Ham hock corned beef fatback, shankle pig tongue turducken pancetta. Ham hock meatloaf pig jerky kevin jowl alcatra capicola pork belly sausage salami ham turkey." },
                new Customer { Id = 2, Name = "John Adams", Bio = "T-bone tri-tip sirloin, rump chuck shoulder bacon shank kevin cow shankle. Short loin prosciutto bresaola shankle ham hock jowl. Flank sausage rump kevin kielbasa, fatback spare ribs capicola boudin brisket chicken. Andouille tail prosciutto hamburger." },
                new Customer { Id = 3, Name = "Thomas Jefferson", Bio = "Bacon ipsum dolor amet andouille kielbasa strip steak pig. Chicken kevin ground round bresaola pork loin. Capicola beef salami, venison tenderloin turducken tail. T-bone pastrami burgdoggen, salami swine tail ham hock spare ribs venison pork loin tri-tip short loin shank brisket boudin. Hamburger pork turducken strip steak. Ham hock corned beef fatback, shankle pig tongue turducken pancetta. Ham hock meatloaf pig jerky kevin jowl alcatra capicola pork belly sausage salami ham turkey." }
            };
        }
    }
}