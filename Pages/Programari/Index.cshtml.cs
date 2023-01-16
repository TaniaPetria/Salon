using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Salon.Data;
using salon.Models;
using Microsoft.AspNetCore.Authorization;
using System.Data;

namespace Salon.Pages.Programari
{
    [Authorize(Roles = "Admin")]
    public class IndexModel : PageModel
    {
        private readonly Salon.Data.SalonContext _context;

        public IndexModel(Salon.Data.SalonContext context)
        {
            _context = context;
        }

        public IList<Programare> Programare { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Programare != null)
            {
                Programare = await _context.Programare.Include(p => p.Angajat).Include(p => p.Client).Include(p => p.Serviciu).OrderBy(p => p.Angajat.Nume).ThenBy(p => p.Date)
                .ThenBy(p => p.StartTime)
                .ToListAsync();

               // Programare = await _context.Programare.Include(p => p.Angajat).Include(p => p.Client).Include(p => p.Serviciu).OrderBy(p => p.Angajat.Nume).ThenBy(p => p.Date).ThenBy(p => p.Angajat.Nume)
               //.ThenBy(p => p.StartTime)
               //.ToListAsync();
            }
        }
    }
}
