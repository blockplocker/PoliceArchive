using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PoliceArchive.Data;
using PolisArkiv.Models;

namespace PoliceArchive.Pages.Admin.EvidenceAdmin
{
    public class DeleteModel : PageModel
    {
        private readonly PoliceArchive.Data.PoliceArchiveContext _context;

        public DeleteModel(PoliceArchive.Data.PoliceArchiveContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Evidence Evidence { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var evidence = await _context.Evidence.FirstOrDefaultAsync(m => m.Id == id);

            if (evidence == null)
            {
                return NotFound();
            }
            else
            {
                Evidence = evidence;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var evidence = await _context.Evidence.FindAsync(id);
            if (evidence != null)
            {
                Evidence = evidence;
                _context.Evidence.Remove(Evidence);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
