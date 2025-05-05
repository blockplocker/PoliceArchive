using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PoliceArchive.Data;
using PolisArkiv.Models;

namespace PoliceArchive.Pages.Admin.PolicemanAdmin
{
    public class DeleteModel : PageModel
    {
        private readonly PoliceArchive.Data.PoliceArchiveContext _context;

        public DeleteModel(PoliceArchive.Data.PoliceArchiveContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Policeman Policeman { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var policeman = await _context.Policeman.FirstOrDefaultAsync(m => m.Id == id);

            if (policeman == null)
            {
                return NotFound();
            }
            else
            {
                Policeman = policeman;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var policeman = await _context.Policeman.FindAsync(id);
            if (policeman != null)
            {
                Policeman = policeman;
                _context.Policeman.Remove(Policeman);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
