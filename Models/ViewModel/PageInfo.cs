using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace assignment_10.Models.ViewModel
{
    public class PageInfo
    {
        //This helps to organize the information that we will need inorder to set up pagination and display the right amount of contacts prer page
        public int TotalNumItems { get; set; }
        public int PerPageCount { get; set; }
        public int CurrentPage { get; set; }
        public int TotalPages => (int)Math.Ceiling((decimal)TotalNumItems / PerPageCount);
    }
}
