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

namespace PoliceArchive.Pages.Admin.PolicemanAdmin
{
    public class EditModel : PageModel
    {
        private readonly PoliceArchive.Data.PoliceArchiveContext _context;

        public EditModel(PoliceArchive.Data.PoliceArchiveContext context)
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

            var policeman =  await _context.Policeman.FirstOrDefaultAsync(m => m.Id == id);
            if (policeman == null)
            {
                return NotFound();
            }
            Policeman = policeman;
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

            _context.Attach(Policeman).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PolicemanExists(Policeman.Id))
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

        private bool PolicemanExists(int id)
        {
            return _context.Policeman.Any(e => e.Id == id);
        }
    }
}
