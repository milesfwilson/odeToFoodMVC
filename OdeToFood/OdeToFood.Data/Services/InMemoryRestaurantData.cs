using OdeToFood.Data.Models;
using System.Collections.Generic;
using System.Linq;

namespace OdeToFood.Data.Services
{
    public class InMemoryRestaurantData : IRestaurantData
    {

        List<Restaurant> restaurants;
        public InMemoryRestaurantData()
        {
            restaurants = new List<Restaurant>()
            {
                new Restaurant { Id = 1, Name = "Messenger Pizza", Cuisine = CuisineType.Italian},
                new Restaurant { Id = 2, Name = "Muffy's", Cuisine = CuisineType.French},
                new Restaurant { Id = 3, Name = "Taj Mahal", Cuisine = CuisineType.Indian}
            };
        }

        public Restaurant Get(int id)
        {
            return restaurants.FirstOrDefault(restaurant => restaurant.Id == id);
        }

        public IEnumerable<Restaurant> GetAll()
        {
            return restaurants.OrderBy(restaurant => restaurant.Name);
        }

       public void Add(Restaurant restaurant)
        {
            restaurant.Id = restaurants.Max(r => r.Id) + 1;
            restaurants.Add(restaurant);
        }

        public void Update(Restaurant restaurant)
        {
            var existing = Get(restaurant.Id);
            if(existing != null)
            {
                existing.Name = restaurant.Name;
                existing.Cuisine = restaurant.Cuisine;
            }
        }
        public void Delete(int id)
        {
            var existing = Get(id);
            if(existing != null)
            {
                restaurants.Remove(existing);
            }
        }
    }
}
