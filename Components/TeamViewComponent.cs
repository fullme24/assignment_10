using Microsoft.AspNetCore.Mvc;
using assignment_10.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace assignment_10.Components
{
    //This code sets up the infmoration from teams that I need inorder to make the view component in a bit
    public class TeamViewComponent : ViewComponent
    {
        private BowlingLeagueContext _context;
        private IOrderedQueryable<long?> teamId;

        public TeamViewComponent(BowlingLeagueContext bowler)
        {
            _context = bowler;
        }

        public IViewComponentResult Invoke()
        {
            return View(_context.Teams
                .Distinct()
                .OrderBy(b => b)
            );
        }
    }
}
