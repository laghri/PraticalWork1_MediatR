using FirstAppWorkHahn.MediatR.Commands;
using FirstAppWorkHahn.MediatR.Queries;
using FirstAppWorkHahn.Models;
using FirstAppWorkHahn.Validators;
using FluentValidation;
using FluentValidation.Results;
using MediatR;
using FluentValidation.Results;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using ValidationResult = FluentValidation.Results.ValidationResult;

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
        public async Task<IActionResult> AddEmploye(CreateEmployeeCommand CommandCreate)
        {

            try
            {
             
                return Ok(await _mediator.Send(CommandCreate));
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
          
            try 
            {
                return Ok(await _mediator.Send(new GetEmployeeByIdQuery() { Id=id} ));
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }



        }
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateEmploye(UpdateEmployesCommand UpdateCommande)
        {
            try
            {
                return Ok(await _mediator.Send(UpdateCommande));
            }
            catch( Exception ex) 
            {
                return BadRequest(ex.Message);
            }
          }
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> DeleteEmploye(DeleteEmployeCommande DeleteCommande)
        {
            try
            {
                return Ok(await _mediator.Send(DeleteCommande));
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetAllEmployes( )
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
        


