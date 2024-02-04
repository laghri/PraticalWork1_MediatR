using FirstAppWorkHahn.MediatR.Queries;
using FirstAppWorkHahn.Models;
using FirstAppWorkHahn.Repositores;
using MediatR;
using NuGet.Protocol.Core.Types;

namespace FirstAppWorkHahn.MediatR.Handlers
{
    public class GetAllEmployesHandles : IRequestHandler<GetAllEmployesQuery, List<Employes>>
    {
            
        private readonly IGenericRepository<Employes> _employesRepository;
        public GetAllEmployesHandles(IGenericRepository<Employes> employesRepository)
        {
            _employesRepository = employesRepository;
        }


        public async Task<List<Employes>> Handle(GetAllEmployesQuery request, CancellationToken cancellationToken)
        {

         return (List<Employes>)await _employesRepository.GetAll();
        }

      
    }
}
