using FirstAppWorkHahn.Models;
using MediatR;

namespace FirstAppWorkHahn.MediatR.Queries
{
    public class GetAllEmployesQuery:IRequest<List<Employes>>
    {

    }
}
