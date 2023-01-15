using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Salon.Data;
using salon.Models;
using Microsoft.EntityFrameworkCore;

namespace Salon.Pages.ProgramariClienti
{
    public class SalvareModel : PageModel
    {
        private readonly Salon.Data.SalonContext _context;
        
        public Angajat Angajat { get; set; } = default!;
       
        public Serviciu Serviciu { get; set; } = default!;
        [BindProperty]
        public Programare Programare { get; set; } = default!;

        
        private static ProgramareModelData _data;

        public SalvareModel(Salon.Data.SalonContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> OnGetAsync(int spec, int serv, string day, TimeSpan time)
        {

            var angajatid = spec;
            var serviciuid = serv;
            var oraprogramare = time;
            DateTime ziprogramare = DateTime.ParseExact(day, "ddMMyyyy", System.Globalization.CultureInfo.InvariantCulture);
            ViewData["spec"] = angajatid;
            ViewData["serv"] = serviciuid;
            ViewData["oraprogramare"] = oraprogramare;
            ViewData["ziprogramare"] = day;

            if (angajatid == null || serviciuid == null || oraprogramare == null || day == null)
            {
                return NotFound();
            }

            var angajat = await _context.Angajat.FirstAsync(m => m.ID == angajatid);
            var serviciu = await _context.Serviciu.FirstOrDefaultAsync(m => m.ID == serviciuid);

            _data = new ProgramareModelData
            {
                Pret = serviciu.Pret,
                StartTime = oraprogramare,
                EndTime = oraprogramare + TimeSpan.FromMinutes(serviciu.Durata),
                ServiciuID = serviciuid,
                AngajatID = angajatid,
                Date = ziprogramare,
                Durata = serviciu.Durata,
                ClientID = 1,

            };
            
            
            Angajat = angajat;
            Serviciu = serviciu;
            


            return Page();
        }

        
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            //if (!ModelState.IsValid)
            //  {
            //      return Page();
            //  }
            Programare = new Programare
            {
                Pret = _data.Pret,
                StartTime = _data.StartTime,
                EndTime = _data.EndTime,
                ServiciuID = _data.ServiciuID,
                AngajatID = _data.AngajatID,
                Date = _data.Date,
                Durata = _data.Durata,
                ClientID = 1,

            };
            _context.Programare.Add(Programare);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
