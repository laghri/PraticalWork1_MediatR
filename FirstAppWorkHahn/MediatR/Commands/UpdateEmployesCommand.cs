using FirstAppWorkHahn.Models;
using MediatR;

namespace FirstAppWorkHahn.MediatR.Commands
{
    public class UpdateEmployesCommand: IRequest<Employes>
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public double Salaire { get; set; }
        public string? Specialite { get; set; }

    }
}
