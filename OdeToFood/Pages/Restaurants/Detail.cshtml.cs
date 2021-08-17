using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OdeToFood.Core;
using OdeToFood.Data;

namespace OdeToFood.Pages.Restaurants
{
    public class DetailModel : PageModel
    {
        private readonly IRestaurantData rd;

        public Restaurant Restaurant { get; set; }

        public DetailModel(IRestaurantData rd)
        {
            this.rd = rd;
        }
        public void OnGet(int restaurantID)
        {
            Restaurant =  rd.GetRestaurantById(restaurantID);
        }
    }
}
