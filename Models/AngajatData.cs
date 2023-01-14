using salon.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace Salon.Models
{
    [Table("AngajatData")]
    public class AngajatData
    {
        public IEnumerable<Angajat> Angajati { get; set; }
        public IEnumerable<Serviciu> Servicii { get; set; }
        public IEnumerable<AngajatServiciu> AngajatServicii { get; set; }
    }
}
