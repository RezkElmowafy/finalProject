using Microsoft.AspNetCore.Mvc;
using final.Models;
using final.Data;

namespace final.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _dbContext;

        public HomeController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AboutUs()
        {
            return View();
        }

        public IActionResult Typography()
        {
            return View();
        }

        public IActionResult Contacts()
        {
            return View();
        }

        public IActionResult Donate()
        {
            // Retrieve the list of donors from the database
            var donorsList = _dbContext.Donors.ToList();
            return View(donorsList);
        }

        [HttpPost]
        public IActionResult AddItem(Donors model)
        {
            if (ModelState.IsValid)
            {
                // Assuming Donors is your DbSet<Donors> in AppDbContext
                _dbContext.Donors.Add(model);
                _dbContext.SaveChanges();

                // Redirect to the Donate action after adding an item
                return RedirectToAction("Donate");
            }

            // If the model is not valid, return to the Donate view with validation errors
            var donorsList = _dbContext.Donors.ToList();
            return View("Donate", donorsList);
        }
    }
}
