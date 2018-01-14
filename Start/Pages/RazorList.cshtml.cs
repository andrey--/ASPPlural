using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Start.Data;
using Start.Models;
using Start.Services;

namespace Start.Pages
{
    [Authorize]
    public class RazorListModel : PageModel
    {
    //    private readonly Start.Data.OdeToFoodDbContext _context;

    //    public RazorListModel(Start.Data.OdeToFoodDbContext context)
    //    {
    //        _context = context;
    //    }

    //    public IList<Restaurant> Restaurant { get; set; }

    //    public async Task OnGetAsync()
    //    {
    //        Restaurant = await _context.Restaurants.ToListAsync();
    //    }
    //}

    private IRestaurantData _restaurantData;

    public RazorListModel(IRestaurantData restaurantData)
    {
        _restaurantData = restaurantData;
    }

    public IList<Restaurant> Restaurant { get; set; }

    public void OnGet()
    {
        Restaurant = _restaurantData.GetAll().ToList();
    }
}
}
