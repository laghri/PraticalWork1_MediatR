using FirstAppWorkHahn.Models;
using MediatR;

namespace FirstAppWorkHahn.MediatR.Commands
{
    public class UpdateEmployesCommand: IRequest<Employes>
    {
        public Employes ?employes { get; set; }
        public System.Guid Id { get; set; }
    }
}
