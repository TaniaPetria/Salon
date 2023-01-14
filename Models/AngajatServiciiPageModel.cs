using Microsoft.AspNetCore.Mvc.RazorPages;
using Salon.Data;

namespace salon.Models
{
 
        public class AngajatServiciiPageModel : PageModel
        {
            public List<AssignedServiciiData> AssignedServiciuDataList;
            public void PopulateAssignedServiciuData(SalonContext context, Angajat angajat)
            {
                var allServicii = context.Serviciu;
                var angajatServicii = new HashSet<int>(angajat.AngajatiServicii.Select(c => c.ServiciuID)); 

                AssignedServiciuDataList = new List<AssignedServiciiData>();

                foreach (var cat in allServicii) 
                    {
                        AssignedServiciuDataList.Add(new AssignedServiciiData 
                            {
                                ServiciuID = cat.ID,
                                Name = cat.Denumire,
                                Descriere=cat.Descriere,
                                Pret=cat.Pret,
                                Durata=cat.Durata,
                                Assigned = angajatServicii.Contains(cat.ID)
                            }
                                                    );
                    }
             }
            public void UpdateAngajatServicii(SalonContext context, string[] selectedServicii, Angajat angajatToUpdate)
                {
                    if (selectedServicii == null) { angajatToUpdate.AngajatiServicii = new List<AngajatServiciu>(); return; }
                    var selectedCategoriesHS = new HashSet<string>(selectedServicii);
                    var angajatServicii = new HashSet<int>(angajatToUpdate.AngajatiServicii.Select(c => c.Serviciu.ID)); foreach (var cat in context.Serviciu)
                    {
                        if (selectedCategoriesHS.Contains(cat.ID.ToString())) { if (!angajatServicii.Contains(cat.ID)) { angajatToUpdate.AngajatiServicii.Add(new AngajatServiciu { AngajatID = angajatToUpdate.ID, ServiciuID = cat.ID }); } }
                        else
                        {
                            if (angajatServicii.Contains(cat.ID))
                            {
                        AngajatServiciu courseToRemove = angajatToUpdate.AngajatiServicii
                    .SingleOrDefault(i => i.ServiciuID == cat.ID); context.Remove(courseToRemove);
                            }
                        }
                    }
                }
            
        }
}
