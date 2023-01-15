using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace salon.Models
{
    public class ProgramareModelData
    {
 
        public DateTime Date { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public int? ClientID { get; set; }
        public int? ServiciuID { get; set; }
        public int? AngajatID { get; set; }
        public int Durata { get; set; }
        public double Pret { get; set; }


    }
}
