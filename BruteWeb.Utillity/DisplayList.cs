using BruteWeb.Models;
using Microsoft.EntityFrameworkCore;

namespace BruteWeb.Utillity
{
    public class DisplayList<T> : List<T> where T : class
    {
        public int PageIndex { get; private set; }
        public int TotalPages { get; private set; }

        public DisplayList(List<T> items, int count, int pageIndex, int pageSize)
        {
            AddRange(items);

            PageIndex = pageIndex;
            TotalPages = (int)Math.Ceiling(count / (double)pageSize);
        }

        public bool HasPreviousPage => PageIndex > 1;
        public bool HasNextPage => PageIndex < TotalPages;

        public static async Task<DisplayList<T>> CreateListAsync(IQueryable<T> sources, int pageIndex, int pageSize)
        {
            var count = await sources.CountAsync();
            var items = await sources.OrderByDescending(m => m)
                .Skip((pageIndex - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return new DisplayList<T>(items, count, pageIndex, pageSize);
        }
    }
}