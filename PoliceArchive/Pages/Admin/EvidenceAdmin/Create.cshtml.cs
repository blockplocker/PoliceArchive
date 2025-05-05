using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using PoliceArchive.Data;
using PolisArkiv.Models;

namespace PoliceArchive.Pages.Admin.EvidenceAdmin
{
    public class CreateModel : PageModel
    {
        private readonly PoliceArchive.Data.PoliceArchiveContext _context;

        public CreateModel(PoliceArchive.Data.PoliceArchiveContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["ArchiveBoxID"] = new SelectList(_context.Set<ArchiveBox>(), "Id", "Name");
        ViewData["PolicemanID"] = new SelectList(_context.Policeman, "Id", "FirstName");
            return Page();
        }

        [BindProperty]
        public Evidence Evidence { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Evidence.Add(Evidence);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
