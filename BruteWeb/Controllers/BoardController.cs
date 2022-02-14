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

        public async Task<IActionResult> Index(int? pageSize, int? page, string? seachString, IFormCollection form)
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

        public async Task<IActionResult> Edit(int id)
        {
            if(id <= 0)
            {
                return RedirectToAction(nameof(Index));
            }

            var model = await _db.Boards.FirstOrDefaultAsync(m => m.Number == id);

            if(model == null)
            {
                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, Board model)
        {
            if(id != model.Number)
            {
                return RedirectToAction(nameof(Index));
            }

            _db.Boards.Update(model);
            await _db.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
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
