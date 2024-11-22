using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace APIInPIoneer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Employee2Controller : ControllerBase
    {
        private readonly SampleDataService _service;
        public Employee2Controller()
        { 
            _service = new SampleDataService();
        }
        private List<Employee> employees = new List<Employee>
        {
            new Employee{ID=1 ,EmpName="Abhi" , EmpAddress="noida"},
            new Employee{ID=2,EmpName="Prince" , EmpAddress="Gzb"},
            new Employee{ID=2,EmpName="Sourabh" , EmpAddress="Gzb"},
            new Employee{ID=2,EmpName="Mohan" , EmpAddress="New delhi"}
        };


        [HttpGet]
        public async Task<ActionResult<List<Employee>>> GetEmployees()
        {
            var employeeList = await Task.Run(() => employees);  // sql querry 
            return Ok(employees);//use the status code to determine the kind of Status U wish to return as Response. 
        }

        [HttpGet("GetEmployeeById/{id}",Name ="GetEmployeeById")]
        public async Task<ActionResult> GetEmployeeById(int id)
        {
            var employee =  employees[id];
            if (employee == null)
            {
                return NotFound("Employee not found");//return 404 not found
            }
            return Ok(employee);
        }

        [HttpPost("SaveEmployee")]
        public async Task<ActionResult> SaveEmployee(Employee emp)
        {
            employees.Add(emp);
           var exist = employees.Find((e)=>e.EmpName==emp.EmpName);
            if (exist != null)
            {
                return Conflict("user already exist"); // return 409 Resource already exist
            }
            return Ok(employees);
        }
        [HttpPost("UpdateEmployee")]
        public async Task<ActionResult> UpdateEmployee(Employee emp)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid data."); // retuurn 400
            }
            var index = employees.FindIndex((e) => e.ID == emp.ID);
            if (index != -1)
            {
                employees[index] = emp; 
            }

            return Ok(employees);
        }


        [HttpGet("Delete")]
        public async Task<ActionResult> DeleteEmp(int id)
        {
            var temp = employees.Find((e) => e.ID == id);
            if (temp==null)
            {
                return BadRequest("Employee not found");
            }
            employees.Remove(temp);
            return Ok(employees);
        }

       

        [HttpGet("data")]
        public IActionResult GetPaginatedData([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)//pageSize = number of records
        {
            if (pageNumber < 1 || pageSize < 1)
            {
                return BadRequest("PageNumber and PageSize must be greater than 0.");
            }

            var paginatedData = _service.GetPaginatedData(pageNumber, pageSize);
            return Ok(paginatedData);
        }



    }


    public class   Employee
    {
        public int ID { get; set; }
        public string EmpName { get; set; }
        public string EmpAddress { get; set; }
    }



}
