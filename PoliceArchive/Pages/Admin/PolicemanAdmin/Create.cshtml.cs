using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using PoliceArchive.Data;
using PolisArkiv.Models;

namespace PoliceArchive.Pages.Admin.PolicemanAdmin
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
            return Page();
        }

        [BindProperty]
        public Policeman Policeman { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Policeman.Add(Policeman);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
