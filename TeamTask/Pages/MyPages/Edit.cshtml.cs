using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TeamTask.Data;
using TeamTask.Models;

namespace TeamTask.Pages.MyPages
{
    public class EditModel : PageModel
    {
        private readonly TeamTask.Data.TeamTaskContext _context;

        public EditModel(TeamTask.Data.TeamTaskContext context)
        {
            _context = context;
        }

        [BindProperty]
        public PageItem PageItem { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.PageItem == null)
            {
                return NotFound();
            }

            var pageitem =  await _context.PageItem.FirstOrDefaultAsync(m => m.Id == id);
            if (pageitem == null)
            {
                return NotFound();
            }
            PageItem = pageitem;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(PageItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PageItemExists(PageItem.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool PageItemExists(int id)
        {
          return _context.PageItem.Any(e => e.Id == id);
        }
    }
}
