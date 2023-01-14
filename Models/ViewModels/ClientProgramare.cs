using System.Security.Policy;
using salon.Models;

namespace Salon.Models.ViewModels
{
    public class ClientProgramare
    {
        public IEnumerable<Serviciu> Servicii { get; set; }
        public IEnumerable<Angajat> Angajati { get; set; }
    }
}
