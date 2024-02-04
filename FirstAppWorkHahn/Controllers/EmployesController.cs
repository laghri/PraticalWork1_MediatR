using FirstAppWorkHahn.MediatR.Commands;
using FirstAppWorkHahn.MediatR.Queries;
using FirstAppWorkHahn.Models;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FirstAppWorkHahn.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployesController : ControllerBase
    {
        private readonly IMediator _mediator;
        public EmployesController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost]
        public async Task<IActionResult> AddEmploye(Employes employes)
        {
            var employesCommand = new CreateEmployeeCommand() { employes = employes };
            var empl = await _mediator.Send(employesCommand);
            return Ok(empl);
        }
        [HttpGet("{id}")]

        public async Task<ActionResult> GetEmployeById(Guid id)
        {
            var employeQuery = new GetEmployeeByIdQuery() { Id = id };
            var Employe = await _mediator.Send(employeQuery);
            if (Employe != null)
            {
                return Ok(Employe);
            }
            else
            {
                return NotFound();
            }



        }
        [HttpPut]
        public async Task<IActionResult> UpdateEmploye(Guid id, Employes employes)
        {
            var EmployeCommande = new UpdateEmployesCommand() { Id = id, employes = employes };

            var Employe = await _mediator.Send(EmployeCommande);
            if (Employe != null)
            {
                return Ok(Employe);
            }
            else
            {
                return BadRequest();
            }





        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmploye(Guid id)
        {
            var EmployeCommande = new DeleteEmployeCommande() { Id = id };
            var Employe = await _mediator.Send(EmployeCommande);
            if (Employe != null)
            {
                return Ok("Delete seccussufly");
            }
            else
            {
                return BadRequest("SomeThingWrong");
            }
        }
        [HttpGet]
        public async Task<IActionResult> GetAllEmployes()
        {
            var EmployeQuery = new GetAllEmployesQuery() { };
            List<Employes> Employes = await _mediator.Send(EmployeQuery);
            return Ok(Employes);
            }
    }
}
        


