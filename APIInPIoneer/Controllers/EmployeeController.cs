using Microsoft.AspNetCore.Mvc;

namespace APIInPIoneer.Controllers
{
    public class EmployeeController : Controller
    {
        private static List<Employee> employees = new List<Employee>
        {
            new Employee{ ID = 123, EmpName ="Abhishek", EmpAddress="pata nhi" },
            new Employee{ ID = 124, EmpName ="Tushar", EmpAddress="Noida" },
            new Employee{ ID = 125, EmpName ="Tarun", EmpAddress="New Delhi" }
        };

        [HttpGet("ListOfEmployees")]
        public async Task<ActionResult<List<Employee>>> GetEmployees()
        {
            return Ok(employees);//use the status code to determine the kind of Status U wish to return as Response. 
        }
    }
}



class Employee
{
    public int ID { get; set; }
    public string EmpName { get; set; }
    public string EmpAddress { get; set; }
}
