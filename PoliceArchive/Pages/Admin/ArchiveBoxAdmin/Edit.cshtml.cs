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

namespace PoliceArchive.Pages.Admin.ArchiveBoxAdmin
{
    public class EditModel : PageModel
    {
        private readonly PoliceArchive.Data.PoliceArchiveContext _context;

        public EditModel(PoliceArchive.Data.PoliceArchiveContext context)
        {
            _context = context;
        }

        [BindProperty]
        public ArchiveBox ArchiveBox { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var archivebox =  await _context.ArchiveBox.FirstOrDefaultAsync(m => m.Id == id);
            if (archivebox == null)
            {
                return NotFound();
            }
            ArchiveBox = archivebox;
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

            _context.Attach(ArchiveBox).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ArchiveBoxExists(ArchiveBox.Id))
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

        private bool ArchiveBoxExists(int id)
        {
            return _context.ArchiveBox.Any(e => e.Id == id);
        }
    }
}
