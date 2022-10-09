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
    public class DetailsModel : PageModel
    {
        private readonly TeamTask.Data.TeamTaskContext _context;

        public DetailsModel(TeamTask.Data.TeamTaskContext context)
        {
            _context = context;
        }

      public PageItem PageItem { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.PageItem == null)
            {
                return NotFound();
            }

            var pageitem = await _context.PageItem.FirstOrDefaultAsync(m => m.Id == id);
            if (pageitem == null)
            {
                return NotFound();
            }
            else 
            {
                PageItem = pageitem;
            }
            return Page();
        }
    }
}
