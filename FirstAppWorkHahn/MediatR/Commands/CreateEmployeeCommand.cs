using FirstAppWorkHahn.Models;
using MediatR;

namespace FirstAppWorkHahn.MediatR.Commands
{
   public class CreateEmployeeCommand : IRequest<Employes>
    {
        public Employes employes { get; set; }
    }
}
