using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace salon.Models
{
    public class Programare
    {
        public int ID { get; set; }

        [Display(Name = "Data")]
        [Required(ErrorMessage = "Câmp obligatoriu")]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        [Display(Name = "Oră start")]
        [Required(ErrorMessage = "Câmp obligatoriu")]
        [DataType(DataType.Time)]
        public TimeSpan StartTime { get; set; }

        [Display(Name = "Oră finish")]
        [Required(ErrorMessage = "Câmp obligatoriu")]
        [DataType(DataType.Time)]
        public TimeSpan EndTime { get; set; }


        public int? ClientID { get; set; }
        public Client? Client { get; set; }
        public int? ServiciuID { get; set; }
        public Serviciu? Serviciu { get; set; }
        public int? AngajatID { get; set; }
        public Angajat? Angajat { get; set; }
        public int Durata { get; set; }
        public double Pret { get; set; }


    }
}
