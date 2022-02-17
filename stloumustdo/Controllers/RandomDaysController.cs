using Microsoft.AspNetCore.Mvc;
using stloumustdo.Data;
using stloumustdo.POCO;

namespace stloumustdo.Controllers
{
    public class RandomDaysController : Controller
    {

        private readonly stloumustdoContext _context;

        public RandomDaysController(stloumustdoContext context)
        {
            _context = context;
        }

       
        public async Task<IActionResult> Index()
        {
            var randomDay = new RandomDay();

            var randomCafe = _context.Cafes.OrderBy(c => Guid.NewGuid()).FirstOrDefault();
            var randomRestaurant = _context.Restaurants.OrderBy(c => Guid.NewGuid()).FirstOrDefault();
            var randomOutdoor = _context.StatewideOutdoors.OrderBy(c => Guid.NewGuid()).FirstOrDefault();
            var randomAttraction = _context.LocalAttractions.OrderBy(c => Guid.NewGuid()).FirstOrDefault();
            randomDay.Cafe = randomCafe;
            randomDay.Restaurant = randomRestaurant;
            randomDay.LocalAttraction = randomAttraction;
            randomDay.StatewideOutdoors = randomOutdoor;
            

            return View(randomDay);
        }
    }
}
