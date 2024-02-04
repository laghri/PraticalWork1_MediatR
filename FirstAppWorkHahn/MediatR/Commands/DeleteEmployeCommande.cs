using FirstAppWorkHahn.Models;
using MediatR;

namespace FirstAppWorkHahn.MediatR.Commands
{
    public class DeleteEmployeCommande: IRequest<Guid>
    {
        public System.Guid Id { get; set; }
    }
}
