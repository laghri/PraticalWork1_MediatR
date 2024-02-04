using System.ComponentModel.DataAnnotations;

namespace FirstAppWorkHahn.Models
{
    public class Employes
    {
        [Key]
        public Guid Id { get; set; }
        public string ?Name { get; set; }
        public double Salaire { get; set; }
        public string ?Specialite { get; set; }
    }
}
