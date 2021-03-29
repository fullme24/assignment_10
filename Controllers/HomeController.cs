using assignment_10.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace assignment_10.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly BowlingLeagueContext _BowlingLeagueContext;

        public HomeController(ILogger<HomeController> logger, BowlingLeagueContext bowlingLeagueContext)
        {
            _logger = logger;
            _BowlingLeagueContext = bowlingLeagueContext;
        }

        public IActionResult Index()
        {
            return View(_BowlingLeagueContext.Bowlers.ToList());
        }

        public IActionResult List()
        {
            return View(_BowlingLeagueContext.Bowlers.ToList());
        }

        //This is for errors, we really have not done anything with this all semester, though.
        //So I am moving it down a couple lines to have a metaphorical, and literal, separation
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
