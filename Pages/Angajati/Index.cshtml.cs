using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Salon.Data;
using salon.Models;
using Salon.Models;
using System.Net;

namespace Salon.Pages.Angajati
{
    public class IndexModel : PageModel
    {
        private readonly Salon.Data.SalonContext _context;

        public IndexModel(Salon.Data.SalonContext context)
        {
            _context = context;
        }

        public IList<Angajat> Angajat { get;set; }
        public AngajatData AngajatD { get; set; }
        public int AngajatID { get; set; }
        public int ServiciuID { get; set; }

        public async Task OnGetAsync(int? id, int? ServiciuID)
        {
            AngajatD = new AngajatData();
            AngajatD.Angajati = await _context.Angajat
                .Include(b => b.AngajatiServicii)
                    .ThenInclude(b => b.Serviciu)
                    .AsNoTracking()
                    .OrderBy(b => b.Nume)
                    .ToListAsync();
            if (id != null)
            {
                AngajatID = id.Value;
                Angajat angajat = AngajatD.Angajati
                    .Where(i => i.ID == id.Value).Single();
                AngajatD.Servicii = angajat.AngajatiServicii.Select(s => s.Serviciu);

            }
        }
    }
}
