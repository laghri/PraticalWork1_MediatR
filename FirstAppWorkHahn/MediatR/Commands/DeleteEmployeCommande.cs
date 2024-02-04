using FirstAppWorkHahn.Models;
using MediatR;

namespace FirstAppWorkHahn.MediatR.Commands
{
    public class DeleteEmployeCommande: IRequest<Employes>
    {
        public System.Guid Id { get; set; }
    }
}
