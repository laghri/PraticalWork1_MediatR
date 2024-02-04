using FirstAppWorkHahn.Models;
using MediatR;

namespace FirstAppWorkHahn.MediatR.Queries
{
    public class GetEmployeeByIdQuery : IRequest<Employes>
    {
        public System.Guid Id { get; set; }
    }
}
