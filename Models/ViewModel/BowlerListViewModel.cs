using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace assignment_10.Models.ViewModel
{
    public class BowlerListViewModel
    {
        //This is the bundle of information that we will need to render all the information needed by the user
        public IEnumerable<Bowlers> Bowlers { get; set; }
        public PageInfo PageInfo { get; set; }
        public string TeamName { get; set; }
    }
}
