using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MovieAppAPI.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace MovieAppAPI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        private MovieDAL movieDAL = new MovieDAL();
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult MovieSearchResult(string keyword)
        {
            MovieModel result = movieDAL.GetMovie(keyword);
            return View(result);
        }
        public IActionResult MovieNight()
        {
            
            
            return View();
        }

        public IActionResult MovieSearch()
        {
            return View();
        }
        [HttpPost]
        public IActionResult MovieNight(string keyword1, string keyword2, string keyword3)
        {
            MovieModel result1 = movieDAL.GetMovie(keyword1);
            MovieModel result2 = movieDAL.GetMovie(keyword2);
            MovieModel result3 = movieDAL.GetMovie(keyword3);
            List<MovieModel> movieModelList = new List<MovieModel>();
            movieModelList.Add(result1);
            movieModelList.Add(result2);
            movieModelList.Add(result3);
            return View(movieModelList);
        }
     
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
