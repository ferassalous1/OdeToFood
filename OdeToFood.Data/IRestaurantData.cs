using OdeToFood.Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace OdeToFood.Data
{
    public interface IRestaurantData
    {
        public IEnumerable<Restaurant> GetRestaurants();
        public IEnumerable<Restaurant> GetRestaurantByName(string name);

        public Restaurant GetRestaurantByID(int ID);
    }

    public class InMemoryRestaurantData : IRestaurantData
    {
        readonly List<Restaurant> restaurants;

        public InMemoryRestaurantData()
        {
            restaurants = new List<Restaurant>()
            {
                new Restaurant
              {
                Name = "Ihop",
                Location = "Oklahoma",
                Cusine = CusineType.American,
                Id = 1
            },
             new Restaurant
             {
                 Name = "Teds",
                 Location = "Texas",
                 Cusine = CusineType.Mexican,
                 Id = 2
             },
             new Restaurant
             {
                 Name = "Mahgony",
                 Location = "Tulsa",
                 Cusine = CusineType.American,
                 Id = 3
             }
        };


        }

        public Restaurant GetRestaurantByID(int Id)
        {
            return restaurants.FirstOrDefault(r => r.Id == Id);
        }

        public IEnumerable<Restaurant> GetRestaurantByName(string name)
        {
            return from r in restaurants
                   where string.IsNullOrEmpty(name) || r.Name.StartsWith(name)
                   select r;
        }

        public IEnumerable<Restaurant> GetRestaurants() =>
                 from r in restaurants
                 orderby r.Name
                 select r;
    }


}
