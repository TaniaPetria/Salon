using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using salon.Models;
using Salon.Models;

namespace Salon.Pages.ProgramariClienti
{
    public class SelectProgramareModel : PageModel
    {
        private readonly Salon.Data.SalonContext _context;

        

        public SelectProgramareModel(Salon.Data.SalonContext context)
        {
            _context = context;
        }
        [BindProperty]
        public Angajat Angajat { get; set; } = default!;
        [BindProperty]
        public Serviciu Serviciu { get; set; } = default!;
        public List<Tuple<DateTime, TimeSpan, TimeSpan>> IntervaleLibere { get; set; }


        public async Task<IActionResult> OnGetAsync(int? serv, int? spec)
        {
            var angajatid = spec;
            var serviciuid = serv;
            ViewData["spec"] = angajatid;
            ViewData["serv"] = serviciuid;


            if (angajatid == null || serviciuid == null)
            {
                return NotFound();
            }

            var angajat = await _context.Angajat.FirstOrDefaultAsync(m => m.ID == angajatid);
            var serviciu = await _context.Serviciu.FirstOrDefaultAsync(m => m.ID == serviciuid);

            Angajat = angajat;
            Serviciu = serviciu;

            List<Tuple<DateTime, TimeSpan, TimeSpan>> intervaleLibere = new List<Tuple<DateTime, TimeSpan, TimeSpan>>();
            DateTime dataCurenta = DateTime.Today;
            TimeSpan oraInceput = new TimeSpan(8, 0, 0);
            TimeSpan oraSfarsit = new TimeSpan(16, 0, 0);

            for (int i = 0; i < 21; i++)
            {
                DateTime data = dataCurenta.AddDays(i);
                TimeSpan oraCurenta = oraInceput;

                while (oraCurenta < oraSfarsit)
                {
                    bool esteOcupat = _context.Programare
                        .Any(p => p.Date == data &&
                        (p.StartTime <= oraCurenta && p.EndTime > oraCurenta));

                    if (!esteOcupat)
                    {
                        intervaleLibere.Add(new Tuple<DateTime, TimeSpan, TimeSpan>(data, oraCurenta, oraCurenta.Add(TimeSpan.FromMinutes(30))));
                    }
                    oraCurenta = oraCurenta.Add(TimeSpan.FromMinutes(30));
                }
            }

            IntervaleLibere = intervaleLibere;






            return Page();

        }


       

    }
}


