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
    public class IndexModel : PageModel
    {
        private readonly PoliceArchive.Data.PoliceArchiveContext _context;

        public IndexModel(PoliceArchive.Data.PoliceArchiveContext context)
        {
            _context = context;
        }

        public IList<Policeman> Policeman { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Policeman = await _context.Policeman.ToListAsync();
        }
    }
}
