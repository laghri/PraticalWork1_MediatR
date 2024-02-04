using FirstAppWorkHahn.MediatR.Queries;
using FirstAppWorkHahn.Models;
using FirstAppWorkHahn.Repositores;
using MediatR;

namespace FirstAppWorkHahn.MediatR.Handlers
{
    public class GetEmployeeByIdHandler : IRequestHandler<GetEmployeeByIdQuery, Employes>
    {
        private readonly IGenericRepository<Employes> _employesRepository;
       public  GetEmployeeByIdHandler(IGenericRepository<Employes> employesRepository)
        {
            _employesRepository = employesRepository;
        }

        public async Task<Employes> Handle(GetEmployeeByIdQuery request, CancellationToken cancellationToken)
        {
            return await _employesRepository.GetById(request.Id);
        }
    }
}
