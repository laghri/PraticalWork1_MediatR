using FirstAppWorkHahn.MediatR.Commands;
using FluentValidation;
using Newtonsoft.Json.Linq;

namespace FirstAppWorkHahn.Validators
{
    public class CreateEmployeValidator :AbstractValidator<CreateEmployeeCommand>
    {
        public CreateEmployeValidator() {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Please enter the name").MinimumLength(5).WithMessage("Name – at least 5 Characters");
            RuleFor(x => x.Specialite).NotEmpty().WithMessage("Please enter the Specialite").Length(3, 20).WithMessage("Specialite must have length between 3 and 20");
            RuleFor(x => x.Salaire)
           .NotEmpty().WithMessage("Salary is required")
           .GreaterThanOrEqualTo(3000).WithMessage("Salary must be at least 3000");
        }

        

       
    }
}
