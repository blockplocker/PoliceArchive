using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PoliceArchive.Data;
using PolisArkiv.Models;

namespace PoliceArchive.Pages.Admin.ArchiveBoxAdmin
{
    public class DetailsModel : PageModel
    {
        private readonly PoliceArchive.Data.PoliceArchiveContext _context;

        public DetailsModel(PoliceArchive.Data.PoliceArchiveContext context)
        {
            _context = context;
        }

        public ArchiveBox ArchiveBox { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var archivebox = await _context.ArchiveBox.FirstOrDefaultAsync(m => m.Id == id);
            if (archivebox == null)
            {
                return NotFound();
            }
            else
            {
                ArchiveBox = archivebox;
            }
            return Page();
        }
    }
}
