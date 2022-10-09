using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using TeamTask.Data;
using TeamTask.Models;

namespace TeamTask.Pages.MyPages
{
    public class CreateModel : PageModel
    {
        private readonly TeamTask.Data.TeamTaskContext _context;

        public CreateModel(TeamTask.Data.TeamTaskContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public PageItem PageItem { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.PageItem.Add(PageItem);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
