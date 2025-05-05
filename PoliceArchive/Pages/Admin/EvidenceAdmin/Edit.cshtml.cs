using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PoliceArchive.Data;
using PolisArkiv.Models;

namespace PoliceArchive.Pages.Admin.EvidenceAdmin
{
    public class EditModel : PageModel
    {
        private readonly PoliceArchive.Data.PoliceArchiveContext _context;

        public EditModel(PoliceArchive.Data.PoliceArchiveContext context)
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

            var evidence =  await _context.Evidence.FirstOrDefaultAsync(m => m.Id == id);
            if (evidence == null)
            {
                return NotFound();
            }
            Evidence = evidence;
           ViewData["ArchiveBoxID"] = new SelectList(_context.Set<ArchiveBox>(), "Id", "Id");
           ViewData["PolicemanID"] = new SelectList(_context.Policeman, "Id", "Id");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Evidence).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EvidenceExists(Evidence.Id))
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

        private bool EvidenceExists(int id)
        {
            return _context.Evidence.Any(e => e.Id == id);
        }
    }
}
