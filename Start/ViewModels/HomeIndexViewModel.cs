using Start.Models;
using System.Collections.Generic;

namespace Start.ViewModels
{
    public class HomeIndexViewModel
    {
        public IEnumerable<Restaurant> Restaurants{ get; set; }
        public string CurrentMessage { get; set; }
    }
}
