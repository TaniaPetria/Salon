namespace salon.Models
{
    public class AssignedServiciiData
    {
        public int ServiciuID { get; set; }
        public string Name { get; set; }
        public int Durata { get; set; }
        public double Pret { get; set; }
        public string? Descriere { get; set; }
        public bool Assigned { get; set; }
    }
}
