using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Salon.Data;
using salon.Models;

namespace Salon.Pages.ProgramariClienti
{
    public class CreateModel : PageModel
    {
        private readonly Salon.Data.SalonContext _context;

        public CreateModel(Salon.Data.SalonContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["AngajatID"] = new SelectList(_context.Angajat, "ID", "ID");
        ViewData["ClientID"] = new SelectList(_context.Client, "ID", "ID");
        ViewData["ServiciuID"] = new SelectList(_context.Serviciu, "ID", "ID");
            return Page();
        }

        [BindProperty]
        public Programare Programare { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          //if (!ModelState.IsValid)
          //  {
          //      return Page();
          //  }

            _context.Programare.Add(Programare);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
