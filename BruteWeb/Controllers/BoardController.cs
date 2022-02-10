using BruteWeb.DataAccess;
using BruteWeb.Models;
using BruteWeb.Utillity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BruteWeb.Controllers
{
    public class BoardController : Controller
    {
        private readonly ApplicationDbContext _db;

        public BoardController(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<IActionResult> Index(int? page)
        {

            return View(await DisplayList<Board>.CreateListAsync(_db.Boards.AsNoTracking(), page ?? 1, 3));
        }

        public IActionResult Details(int id)
        {
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Board obj)
        {
            if(!ModelState.IsValid)
            {
                return View();
            }

            await _db.Boards.AddAsync(obj);
            await _db.SaveChangesAsync();

            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public IActionResult Edit(int id)
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public IActionResult Delete(int id)
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
