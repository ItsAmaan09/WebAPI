using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Tutorial_5.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly ILogger<EmployeeController> _logger;
        private EmployeeManager _employeeManager;
        public EmployeeController(ILogger<EmployeeController> logger)
        {
            _logger = logger;
            this._employeeManager = new EmployeeManager();
        }

        [HttpPost]
        [Route("Get")]
        public IActionResult Get()
        {
            try
            {
                return Ok(this._employeeManager.GetEmployees());
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex, "Exception occurs while adding employee data.");
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("Get/{Id}")]
        public IActionResult GetEmployeeById(int Id)
        {
            try
            {
                return Ok(this._employeeManager.GetEmployeeById(Id));
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex, "Exception occurs while adding employee data.");
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("Add")]
        public IActionResult AddEmployee(Employee employee)
        {
            try
            {
                this._employeeManager.AddEmployee(employee);
                return Ok(employee);
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex, "Exception occurs while adding employee data.");
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("Update")]
        public IActionResult UpdateEmployee(Employee employee)
        {
            try
            {
                this._employeeManager.UpdateEmployee(employee);
                return Ok(employee);
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex, "Exception occurs while update employee data.");
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("Delete")]
        public IActionResult DeleteEmployee(Employee employee)
        {
            try
            {
                this._employeeManager.DeleteEmployee(employee);
                return Ok("Delete Successfully");
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex, "Exception occurs while delete employee data");
                return BadRequest(ex.Message);
            }
        }
    }
}