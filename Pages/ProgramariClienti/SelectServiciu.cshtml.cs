
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Salon.Data;
using salon.Models;

namespace Salon.Pages.ProgramariClienti
{
    public class SelectServiciuModel : AngajatServiciiPageModel
    {
        private readonly Salon.Data.SalonContext _context;

        public SelectServiciuModel(Salon.Data.SalonContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Angajat Angajat { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? serv,int? spec)
        {
            
            var id = spec;
            ViewData["spec"] = id;
            if (id == null || _context.Angajat == null)
            {
                return NotFound();
            }


            var angajat = await _context.Angajat.Include(b => b.AngajatiServicii).ThenInclude(b => b.Serviciu).AsNoTracking().FirstOrDefaultAsync(m => m.ID == id);

            

            if (angajat == null)
            {
                return NotFound();
            }
            PopulateAssignedServiciuData(_context, angajat);

            Angajat = angajat;
           
            //System.Diagnostics.Debug.WriteLine(Angajat2);
            //foreach (var srv in Angajat2.AngajatiServicii)
            //{
            //    System.Diagnostics.Debug.WriteLine(srv.Serviciu.Denumire);
            //}


                return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
       
    }
}
