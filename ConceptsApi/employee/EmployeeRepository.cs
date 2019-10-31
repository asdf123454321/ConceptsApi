using ConceptsApi.employee.models;
using DataAccessLayer;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;

namespace ConceptsApi.employee
{
    public interface IEmployeeRepository
    {
        Employee createEmployee(Employee employee);
        Employee getEmployees(int EmployeeID);
        List<Employee> getEmployees();
        void updateEmployee(int EmployeeID, Employee employee);
    }

    public class EmployeeRepository : IEmployeeRepository
    {
        private IConfiguration configuration;
        private string conceptsConnectionString => configuration.GetConnectionString("concepts");

        public EmployeeRepository(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public Employee createEmployee(Employee employee)
        {
            var parameters = new { 
                employee.FirstName, 
                employee.LastName, 
                employee.Phone, 
                employee.AddressID 
            };

            return conceptsConnectionString.getObject<Employee>(parameters);
        }

        public Employee getEmployees(int EmployeeID)
        {
            var parameters = new { EmployeeID };

            return conceptsConnectionString.getObject<Employee>(parameters);
        }

        public List<Employee> getEmployees()
        {
            return conceptsConnectionString.getList<Employee>();
        }

        public void updateEmployee(int EmployeeID, Employee employee)
        {
            var parameters = new { 
                EmployeeID,
                employee.FirstName, 
                employee.LastName, 
                employee.Phone, 
                employee.AddressID 
            };

            conceptsConnectionString.execute(parameters);
        }
    }
}
