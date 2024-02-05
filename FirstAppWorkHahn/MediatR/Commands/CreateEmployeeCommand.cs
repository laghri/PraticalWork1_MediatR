using FirstAppWorkHahn.Models;
using MediatR;

namespace FirstAppWorkHahn.MediatR.Commands
{
   public class CreateEmployeeCommand : IRequest<Employes>
    {
        
        public string? Name { get; set; }
        public double Salaire { get; set; }
        public string? Specialite { get; set; }
    }
}
