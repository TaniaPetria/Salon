using System.ComponentModel.DataAnnotations.Schema;

namespace salon.Models
{
    [Table("Serviciu")]
    public class Serviciu
    {
        public int ID { get; set; }
        public string Denumire { get; set; }
        public int Durata { get; set; }
        public double Pret { get; set; }
        public string? Descriere { get; set; }
        
        public ICollection<AngajatServiciu>? AngajatiServicii { get; set; }
    }
}
