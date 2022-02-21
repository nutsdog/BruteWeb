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

            var boards = _db.Boards.AsQueryable().AsNoTracking();

            if(!string.IsNullOrWhiteSpace(seachString))
            {
                boards = _db.Boards.Where(m => m.Title.Contains(seachString));
            }

            return View(await DisplayList<Board>.CreateListAsync(boards, page ?? 1, pageSize ?? 5));
        }

        public async Task<IActionResult> Details(int id)
        {
            var model = await _db.Boards.AsQueryable().Include(m => m.Comments).FirstOrDefaultAsync(m => m.BoardId == id);

            if(model is null)
            {
                return NotFound();
            }

            model.ViewCount++;

            _db.Boards.Update(model);
            await _db.SaveChangesAsync();

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Details(Board model, string CommentContent)
        {
            _db.Comments.Add(new Comment()
            {
                Contents = CommentContent,
                BoardForeignKey = model.BoardId
            });

            await _db.SaveChangesAsync();

            return RedirectToAction(nameof(Details), new { Id = model.BoardId });
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

            var model = await _db.Boards.FirstOrDefaultAsync(m => m.BoardId == id);

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
            if(id != model.BoardId)
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
        public async Task<IActionResult> Delete(Board model)
        {
            _db.Boards.Remove(model);
            await _db.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}
