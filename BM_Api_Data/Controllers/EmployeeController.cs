using BM_Api_Data.Repository;
using BM_Models;
using BM_Models.Validator;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BM_Api_Data.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeRepository employeeRepository;

        public EmployeeController(IEmployeeRepository _employeeRepository)
        {
            employeeRepository = _employeeRepository;
        }
        [HttpGet]
        public async Task<ActionResult> GetEmployees()
        {
            try
            {
                return Ok(await employeeRepository.GetEmployees());
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }

        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Employee>> GetEmployee(string id)
        {
            try
            {
                var result = await employeeRepository.GetEmployee(id);

                if (result == null) return NotFound();

                return result;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Employee>> GetEmployee(int id)
        {
            try
            {
                var result = await employeeRepository.GetEmployee(id);

                if (result == null) return NotFound();

                return result;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }


        [HttpPost]
        public async Task<ActionResult<Employee>>      CreateEmployee([FromBody] Employee employee)
        {
            try
            {
                if (employee == null) {
                return BadRequest();
                }
            
               

                EmployeeValidator employeeValidator = new EmployeeValidator();

                var result = employeeValidator.Validate(employee);

                if(result.IsValid)
                {
                    //var alreadyUseID = await employeeRepository.GetEmployee(employee.EmployeeID);

                    var alreadyUseNo = await employeeRepository.GetEmployee(employee.EmployeeNumber);
                    //if (alreadyUseID != null)
                    //{
                    //    return BadRequest(error: new { error = "ID Error" });

                    //}
                    //else 
                    if (alreadyUseNo != null)
                    {
                        return BadRequest(error: new { error = "Number Already Taken" });
                    }
                    else
                    {
                        if ((employee.EmployeeID == "" || employee.EmployeeID == null))
                        {
                            employee.EmployeeID = Guid.NewGuid().ToString();
                        }
                        var createdEmployee = await employeeRepository.AddEmployee(employee);


                        return CreatedAtAction(nameof(GetEmployee),
                            new { id = createdEmployee.EmployeeID }, createdEmployee);
                    }
                   

                   

                }
                else
                {
                   return  BadRequest(result.Errors);
                }

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error creating new employee record");
            }
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult<Employee>> DeleteEmployee(string id)
        {
            try
            {
                var employeeToDelete = await employeeRepository.GetEmployee(id);

                if (employeeToDelete == null)
                {
                    return NotFound($"Employee with Id = {id} not found");
                }

                var result = await employeeRepository.DeleteEmployee(id);

                employeeToDelete = await employeeRepository.GetEmployee(id);

                if (employeeToDelete == null)
                {
                return Ok("Deletion Succesful");

                }
                else
                {
                    return StatusCode(StatusCodes.Status500InternalServerError,
                  "Error deleting data");
                }

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error deleting data");
            }
        }


        [HttpPut]
        public async Task<ActionResult<Employee>> UpdateEmployee(Employee employee)
        {
            try
            {
                var employeeToUpdate = await employeeRepository.GetEmployee(employee.EmployeeID);

                if (employeeToUpdate == null)
                {
                    return NotFound($"Employee with Code = {employee.EmployeeNumber} not found");
                }

                return await employeeRepository.UpdateEmployee(employee);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error updating data");
            }
        }

    }
}
