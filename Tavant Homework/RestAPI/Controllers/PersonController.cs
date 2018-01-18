using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Homework.Console.Classes;
using Microsoft.AspNetCore.Mvc;

namespace Homework.API.Controllers
{
    [Produces("application/json")]
    [Route("records")]
    public class PersonController : Controller
    {

        private People _people = new People();

        // POST: /records
        [HttpPost]
        public StatusCodeResult Post([FromBody] string value)
        {
            if (string.IsNullOrWhiteSpace(value) || _people.Add(value) != "") return StatusCode(400);
            return StatusCode(200);
        }

        [HttpGet]
        [Route("name")]
        public List<Person> Name()
        {
            return _people.GetPeopleByName();
        }

        [HttpGet]
        [Route("birthdate")]
        public List<Person> Birthdate()
        {
            return _people.GetPeopleByBirthdate();
        }

        [HttpGet]
        [Route("gender")]
        public List<Person> Gender()
        {
            return _people.GetPeopleByGender();
        }   
    }
}
