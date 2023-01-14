
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
    public class SelectAngajatModel : AngajatServiciiPageModel
    {
        private readonly Salon.Data.SalonContext _context;

        public SelectAngajatModel(Salon.Data.SalonContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Serviciu Serviciu { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? serv, int? spec)
        {
            var id = serv;
            ViewData["serv"] = id;
            if (id == null || _context.Serviciu == null)
            {
                return NotFound();
            }


            var serviciu = await _context.Serviciu.Include(b => b.AngajatiServicii).ThenInclude(b => b.Angajat).AsNoTracking().FirstOrDefaultAsync(m => m.ID == id);

             


            if (serviciu == null)
            {
                return NotFound();
            }
            //PopulateAssignedServiciuData(_context, angajat);

            Serviciu = serviciu;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(int? id, string[] selectedServicii)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            if (id == null) { return NotFound(); }



            var angajatToUpdate = await _context.Angajat
                    .Include(i => i.AngajatiServicii)
                    .ThenInclude(i => i.Serviciu)
                .FirstOrDefaultAsync(s => s.ID == id);

            if (angajatToUpdate == null)
            { return NotFound(); }
            if (await TryUpdateModelAsync<Angajat>(angajatToUpdate, "Angajat", i => i.Nume, i => i.Avatar))
            {
                UpdateAngajatServicii(_context, selectedServicii, angajatToUpdate);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }

            UpdateAngajatServicii(_context, selectedServicii, angajatToUpdate);
            PopulateAssignedServiciuData(_context, angajatToUpdate);
            return Page();


        }

        private bool AngajatExists(int id)
        {
            return _context.Angajat.Any(e => e.ID == id);
        }
    }
}
