using DapperMvcApp.Models;
using DapperMvcApp.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace DapperMvcApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUserRepository repo;

        public HomeController(IUserRepository _repository)
        {
            repo = _repository;
        }
        public IActionResult Index()
        {
            return View(repo.GetUsers());
        }

        public IActionResult Details(int id)
        {
            User user = repo.Get(id);
            if (user != null)
                return View(user);
            return NotFound();
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(User user)
        {
            repo.Create(user);
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            User user = repo.Get(id);
            if (user != null)
                return View(user);
            return NotFound();
        }

        [HttpPost]
        public IActionResult Edit(User user)
        {
            repo.Update(user);
            return RedirectToAction("Index");
        }

        [HttpGet]
        [ActionName("Delete")]
        public IActionResult ConfirmDelete(int id)
        {
            User user = repo.Get(id);
            if (user != null)
                return View(user);
            return NotFound();
        }
        [HttpPost]
        public IActionResult Delete(int id)
        {
            repo.Delete(id);
            return RedirectToAction("Index");
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
