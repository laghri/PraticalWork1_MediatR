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
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> AddEmploye(Employes employes)
        {
            
            var employesCommand = new CreateEmployeeCommand() { employes = employes };
            try
            {
             
                return Ok(await _mediator.Send(employesCommand));
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
           
        }
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> GetEmployeById(Guid id)
        {
            var employeQuery = new GetEmployeeByIdQuery() { Id = id };
         
            try 
            {
                return Ok(await _mediator.Send(employeQuery));
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }



        }
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateEmploye( Employes employes)
        {
            var EmployeCommande = new UpdateEmployesCommand() { employes = employes };

          
            try
            {
                return Ok(await _mediator.Send(EmployeCommande));
            }
            catch( Exception ex) 
            {
                return BadRequest(ex.Message);
            }





        }
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> DeleteEmploye(Guid id)
        {
            var EmployeCommande = new DeleteEmployeCommande() { Id = id };
            
            try
            {
                return Ok(await _mediator.Send(EmployeCommande));
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetAllEmployes()
        {
            
            try
            {
                return Ok(await _mediator.Send(new GetAllEmployesQuery() { }));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
       
            }
    }
}
        


