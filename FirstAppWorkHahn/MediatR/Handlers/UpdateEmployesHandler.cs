using FirstAppWorkHahn.MediatR.Commands;
using FirstAppWorkHahn.Models;
using FirstAppWorkHahn.Repositores;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.InteropServices;
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
   

         async Task<Employes> IRequestHandler<UpdateEmployesCommand, Employes>.Handle(UpdateEmployesCommand command, CancellationToken cancellationToken)
        {
            var Em = new Employes();
            Em.Id = command.Id;
            Em.Name= command.Name;
            Em.Salaire = command.Salaire;
            Em.Specialite= command.Specialite;
            await _employesRepository.Update(Em); ;
              return Em;
        }
    }
}
