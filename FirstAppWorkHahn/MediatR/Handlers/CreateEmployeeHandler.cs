using FirstAppWorkHahn.Data;
using FirstAppWorkHahn.MediatR.Commands;
using FirstAppWorkHahn.Models;
using FirstAppWorkHahn.Repositores;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FirstAppWorkHahn.MediatR.Handlers
{

    public class CreateEmployeeHandler : IRequestHandler<CreateEmployeeCommand, Employes    >
    {
        private readonly IGenericRepository<Employes> _employesRepository; 
        public CreateEmployeeHandler(IGenericRepository<Employes> employesRepository)
        {
            _employesRepository = employesRepository;
        }
        public async Task<Employes> Handle(CreateEmployeeCommand command,CancellationToken cancellationToken)
        {
                   return  await _employesRepository.Add(command.employes);
        }




    }
}
