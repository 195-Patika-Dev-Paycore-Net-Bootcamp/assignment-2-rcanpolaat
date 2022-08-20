using FluentValidation.Results;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace StaffApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StaffController : ControllerBase
    {
        private static List<Staff> StaffList = new List<Staff>() //list named StaffList has been created.
        {
            new Staff // new object added to the list
            {
                 Id = 1,
                 Name = "Rabia",
                 LastName = "Canpolat",
                 DateOfBirth = new DateTime(1998, 8, 3),
                 Email = "rcanpolaat@gmail.com",
                 PhoneNumber = 5656565456,
                 Salary = 8500
            },

            new Staff // new object added to the list
            {
                Id = 2,
                Name = "Ömer",
                LastName = "Canpolat",
                DateOfBirth = new DateTime(2002, 1, 1),
                Email = "ocapolat@gmail.com",
                PhoneNumber = 5656385456,
                Salary = 6500
            }
        };

        [HttpGet] //fetched the list with the get method
        public List<Staff> GetStaff()
        {
            var stafflist = StaffList.OrderBy(x => x.Id).ToList<Staff>();
            return StaffList;
        }

        [HttpGet("{id}")] //information about the requested id has been fetched
        public Staff GetById(int id)
        {
            var staff = StaffList.Where(staff => staff.Id == id).SingleOrDefault();
            return staff;

        }

        [HttpPost] //post method is used to add a new element
        public IActionResult AddStaff([FromBody] Staff newStaff)
        {
            StaffValidator staffvalidation = new StaffValidator();
            ValidationResult result = staffvalidation.Validate(newStaff); //submits the new element for validation
            if (result.IsValid) //checks the correctness of the added element in validation
            {
                StaffList.Add(newStaff); //add to the list if they comply with the conditions in the validation
                return Ok(newStaff);
            }
            else
            {
                foreach (var item in result.Errors)
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);

                return BadRequest(ModelState);
            }
        }

        [HttpPut] //Existing element details can be changed with put method
        public IActionResult UpdateStaff(int id, [FromBody] Staff updatedStaff)
        {
            var staff = StaffList.SingleOrDefault(x => x.Id == id);

            if (staff is null)
                return BadRequest();

            //just for the part we change to change, for the rest to stay the same
            staff.Name = updatedStaff.Name != default ? updatedStaff.Name : staff.Name;
            staff.LastName = updatedStaff.LastName != default ? updatedStaff.LastName : staff.LastName ;
            staff.DateOfBirth = updatedStaff.DateOfBirth != default ? updatedStaff.DateOfBirth : staff.DateOfBirth;
            staff.Email = updatedStaff.Email != default ? updatedStaff.Email : staff.Email;
            staff.PhoneNumber = updatedStaff.PhoneNumber != default ? updatedStaff.PhoneNumber : staff.PhoneNumber;
            staff.Salary = updatedStaff.Salary != default ? updatedStaff.Salary : staff.Salary;

            return Ok();
        }

        [HttpDelete("{id}")] //Delete method is used to delete the element with id
        public IActionResult DeleteStaff(int id)
        {
            var staff = StaffList.SingleOrDefault(x => x.Id == id);

            if (staff is null)
                return BadRequest();
            StaffList.Remove(staff);
            return Ok();
        }

    }
}