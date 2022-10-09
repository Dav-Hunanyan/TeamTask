using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TeamTask.Data;
using TeamTask.Models;

namespace TeamTask.Pages.MyPages
{
    public class IndexModel : PageModel
    {
        private readonly TeamTask.Data.TeamTaskContext _context;

        public IndexModel(TeamTask.Data.TeamTaskContext context)
        {
            _context = context;
        }

        public IList<PageItem> PageItem { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.PageItem != null)
            {
                PageItem = await _context.PageItem.ToListAsync();
            }
        }
    }
}
