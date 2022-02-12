using BruteWeb.Models;
using BruteWeb.Utillity;
using Microsoft.AspNetCore.Mvc.Rendering;

#nullable disable

namespace BruteWeb.ViewModels
{
    public class BoardIndexViewModel
    {
        public IEnumerable<SelectListItem> SelectListItems { get; set; }

        public DisplayList<Board> DisplayItems { get; set; }
    }
}
