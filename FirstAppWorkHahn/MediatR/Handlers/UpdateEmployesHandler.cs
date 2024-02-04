using FirstAppWorkHahn.MediatR.Commands;
using FirstAppWorkHahn.Models;
using FirstAppWorkHahn.Repositores;
using MediatR;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace FirstAppWorkHahn.MediatR.Handlers
{
    public class UpdateEmployesHandler:IRequestHandler<UpdateEmployesCommand,Employes>
    {
        private readonly IGenericRepository<Employes> _employesRepository;
        public UpdateEmployesHandler(IGenericRepository<Employes> employesRepository)
        {
            _employesRepository = employesRepository;
        }
        public async Task Handle(UpdateEmployesCommand command, CancellationToken cancellationToken)
        {
            
            
        }

         async Task<Employes> IRequestHandler<UpdateEmployesCommand, Employes>.Handle(UpdateEmployesCommand command, CancellationToken cancellationToken)
        {
             await _employesRepository.Update(command.Id, command.employes);
            return command.employes;
        }
    }
}
