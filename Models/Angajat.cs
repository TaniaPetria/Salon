using System.ComponentModel.DataAnnotations.Schema;

namespace salon.Models
{
    [Table("Angajat")]
    public class Angajat
    {
        public int ID { get; set; }
        public string Nume { get; set; }
        public string Avatar { get; set; }
        public string Email { get; set; }
        public ICollection<AngajatServiciu>? AngajatiServicii { get; set; }

    }
}
