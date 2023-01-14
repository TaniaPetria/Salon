using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using salon.Models;

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
            var serviciuid = spec;
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


            







                return Page();

        }


       

    }
}


