using ConceptsApi.employee.models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ConceptsApi.employee
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        IEmployeeRepository employeeRepository;

        public EmployeesController(IEmployeeRepository employeeRepository)
        {
            this.employeeRepository = employeeRepository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Employee>> Get()
        {
            return employeeRepository.getEmployees();
        }

        [HttpGet("{id}")]
        public ActionResult<Employee> Get(int id)
        {
            return employeeRepository.getEmployees(id);
        }

        [HttpPost]
        public ActionResult<Employee> Post([FromBody] Employee value)
        {
            Employee created = employeeRepository.createEmployee(value);

            return CreatedAtAction(nameof(Get), new { id = created.EmployeeID });
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Employee value)
        {
            employeeRepository.updateEmployee(id, value);
        }
    }
}
