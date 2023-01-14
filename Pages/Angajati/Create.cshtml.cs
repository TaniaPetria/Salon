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

namespace Salon.Pages.Angajati
{
    public class CreateModel : AngajatServiciiPageModel
    {
        private readonly Salon.Data.SalonContext _context;

        public CreateModel(Salon.Data.SalonContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            var angajat = new Angajat();
            angajat.AngajatiServicii = new List<AngajatServiciu>();
            PopulateAssignedServiciuData(_context, angajat);



            return Page();
        }

        [BindProperty]
        public Angajat Angajat { get; set; }


        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync(string[] selectedServicii)
        {

            var newAngajat = new Angajat();
            if (selectedServicii != null)
            {
                newAngajat.AngajatiServicii = new List<AngajatServiciu>();
                foreach (var cat in selectedServicii)
                {
                    var catToAdd = new AngajatServiciu
                    {
                        ServiciuID = int.Parse(cat)
                    };
                    newAngajat.AngajatiServicii.Add(catToAdd);
                }
            }
            Angajat.AngajatiServicii = newAngajat.AngajatiServicii;
            _context.Angajat.Add(Angajat);
            await _context.SaveChangesAsync();
            return RedirectToPage("./Index");
        
        PopulateAssignedServiciuData(_context, newAngajat); 
        return Page();


        }
        ////////////////////
        
        
    }
}
