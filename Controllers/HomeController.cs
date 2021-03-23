using improve_number_3.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using improve_number_3.Models.ViewModels;

namespace improve_number_3.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        //bringing in the a varibale to hold the context object
        private MovieDataBaseContext _MovieDataBaseContext;

        public HomeController(ILogger<HomeController> logger, MovieDataBaseContext moviedatabasecontext)
        {
            _logger = logger;
            //giving a value to the context variable
            _MovieDataBaseContext = moviedatabasecontext;
        }

        public IActionResult Index()
        {
            return View();
        }
        //This will allow the user to get to the add page
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        
        //This method allows the user to add a record 
        [HttpPost]
        public IActionResult Add(MovieDataBase moviedatabase)
        {
            if (ModelState.IsValid)
            {
                _MovieDataBaseContext.Movies.Add(moviedatabase);
                _MovieDataBaseContext.SaveChanges();

                ViewBag.status = "Your Movie was added";
            }
            else
            {
                ViewBag.status = "There was an error and your Movie was not added";
            }

            return View();
        }
        
        //This method allows the user to get to the delete page
        [HttpGet]
        public IActionResult Delete()
        {
            return View(_MovieDataBaseContext.Movies);
        }

        //This allows the user to delete a record
        [HttpPost]
        public IActionResult Delete(int movieid)
        {
            MovieDataBase Movie = _MovieDataBaseContext.Movies.FirstOrDefault(m => m.MovieId == movieid);

            _MovieDataBaseContext.Remove(Movie);

            _MovieDataBaseContext.SaveChanges();

            ViewBag.status_delete = "Your Record was Deleted";
            
            return View("Index");
        }

        //Allows the user to get to the listed records
        [HttpGet]
        public IActionResult List()
        {
            return View(_MovieDataBaseContext.Movies);
        }

        //This allows the user to get to the edit page from the list page
        [HttpPost]
        public IActionResult List(int movieid)
        {
            MovieDataBase Movie = _MovieDataBaseContext.Movies.FirstOrDefault(m => m.MovieId == movieid);

            _MovieDataBaseContext.Remove(Movie);

            _MovieDataBaseContext.SaveChanges();

            return View("Edit");
        }

        [HttpGet]
        public IActionResult Edit()
        {
            return View();
        }

        //Allows users to edit records
        [HttpPost]
        public IActionResult Edit(MovieDataBase moive)
        {
            _MovieDataBaseContext.Movies.Add(moive);
            _MovieDataBaseContext.SaveChanges();

            return View("List", _MovieDataBaseContext.Movies);
        }

        //gets users to podecast page
        public IActionResult Podecast()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
