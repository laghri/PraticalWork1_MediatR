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
    public class DeleteEmployeHandler:IRequestHandler<DeleteEmployeCommande,Employes>
    {
        private readonly IGenericRepository<Employes> _employesRepository;
        public DeleteEmployeHandler(IGenericRepository<Employes> employesRepository)
        {
            _employesRepository = employesRepository ?? throw new ArgumentNullException(nameof(employesRepository)); ;
        }


         async Task<Employes> IRequestHandler<DeleteEmployeCommande, Employes>.Handle(DeleteEmployeCommande request, CancellationToken cancellationToken)
        {
            var ExistingEmploye = await _employesRepository.GetById(request.Id);
            if (ExistingEmploye != null)

                await _employesRepository.Delete(request.Id);
            return ExistingEmploye;
        }
    }
}

