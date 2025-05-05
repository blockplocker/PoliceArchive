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
    public class IndexModel : PageModel
    {
        private readonly PoliceArchive.Data.PoliceArchiveContext _context;

        public IndexModel(PoliceArchive.Data.PoliceArchiveContext context)
        {
            _context = context;
        }

        public IList<Evidence> Evidence { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Evidence = await _context.Evidence
                .Include(e => e.ArchiveBox)
                .Include(e => e.Policeman).ToListAsync();
        }
    }
}
