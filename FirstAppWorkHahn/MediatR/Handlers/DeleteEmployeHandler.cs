using FirstAppWorkHahn.MediatR.Commands;
using FirstAppWorkHahn.MediatR.Queries;
using FirstAppWorkHahn.Models;
using FirstAppWorkHahn.Repositores;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol.Core.Types;

namespace FirstAppWorkHahn.MediatR.Handlers
{
    public class DeleteEmployeHandler:IRequestHandler<DeleteEmployeCommande,Guid>
    {
        private readonly IGenericRepository<Employes> _employesRepository;
        public DeleteEmployeHandler(IGenericRepository<Employes> employesRepository)
        {
            _employesRepository = employesRepository ?? throw new ArgumentNullException(nameof(employesRepository)); ;
        }


         async Task<Guid> IRequestHandler<DeleteEmployeCommande, Guid>.Handle(DeleteEmployeCommande request, CancellationToken cancellationToken)
        {
            var ExistingEmploye = await _employesRepository.GetById(request.Id);
            if (ExistingEmploye == null)
              return default;
            await _employesRepository.Delete(request.Id);
            return ExistingEmploye.Id;
        }
    }
}

