using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        // GET: Movies/Random
        public ActionResult Random()
        {
            var movie = new Movie() { Name = "Shrek!" };
            //return View(movie); //return a View
            //return Content("hello world!"); //return the content, similar to Laravel's return $request->all();
            //return HttpNotFound(); //return 404
            //return new EmptyResult(); //return empty page
            return RedirectToAction("Index", "Home", new { page = 1, sortBy = "name" } ); //specify <ActionName, Controller, [{args to pass as URL query string}]> to redirect to
        }
    }
}