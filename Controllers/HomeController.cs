using assignment_10.Models;
using assignment_10.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

        //Bringing in the context class
        private BowlingLeagueContext _BowlingLeagueContext { get; set; }

        public readonly int PerPageCount = 5;

        public HomeController(ILogger<HomeController> logger, BowlingLeagueContext bowlingLeagueContext)
        {
            _logger = logger;
            //setting the value for _BowlingLeagueContext
            _BowlingLeagueContext = bowlingLeagueContext;
        }

        //Set up the main page with list of contacts
        public IActionResult Index(int? teamid, string? teamname, int pageNum = 1)
        {
            //this will set up the data that I need to put the team name at the top of the header and body

            if (teamname == null)
            {
                ViewBag.Team = "Pick a Team!";
            }
            else
            {
                ViewBag.Team = teamname;
            }

            //This is grabing all of the data that we need
            return View(new BowlerListViewModel
            {
                Bowlers = _BowlingLeagueContext.Bowlers
                    .Where(b => b.TeamId == teamid || teamid == null)
                    .OrderBy(b => b.TeamId)
                    .Skip((pageNum - 1) * PerPageCount)
                    .Take(PerPageCount)
                    .ToList()
                ,
                PageInfo = new PageInfo
                {
                    CurrentPage = pageNum,
                    PerPageCount = PerPageCount,
                    TotalNumItems = (teamid == null ? _BowlingLeagueContext.Bowlers.Count() :
                        _BowlingLeagueContext.Bowlers.Where(b => b.TeamId == teamid).Count())
                }
                ,
                TeamName = teamname
            });
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
