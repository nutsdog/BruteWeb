using BruteWeb.DataAccess;
using BruteWeb.Models;
using BruteWeb.Utillity;
using BruteWeb.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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

        public async Task<IActionResult> Index(int? pageSize, int? page, string? seachString)
        {
            ViewData["seachString"] = seachString;

            var boards = _db.Boards.AsQueryable();

            if(!string.IsNullOrWhiteSpace(seachString))
            {
                boards = _db.Boards.Where(m => m.Title.Contains(seachString));
            }

            return View(await DisplayList<Board>.CreateListAsync(boards.AsNoTracking(), page ?? 1, pageSize ?? 5));
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
