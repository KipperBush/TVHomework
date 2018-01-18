using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestAPI.Models;

namespace RestAPI.Controllers
{
    [Produces("application/json")]
    [Route("records")]
    public class PersonController : Controller
    {

        private List<Person> People = new List<Person>();

        // POST: api/Person
        [HttpPost]
        public void Post([FromBody]Person value)
        {

        }


        // GET: records
        [HttpGet]
        public IEnumerable<string> Get()
        {

            return new string[] { "value1", "value2" };

        }

        // GET: api/Person/5
        [HttpGet("{gender}", Name = "Get")]
        public List<Person> Get()
        {
            var peoplByGender = People.OrderBy(x => x.Gender).ToList();
            return peoplByGender;
        }

        // GET: api/Person/5
        [HttpGet("{birthdate}", Name = "Get")]
        public List<Person> Get()
        {
            var person = new Person(id, "Last", "Gender", "Color", "5/5/2017");
            var peoplByGender = People.OrderBy(x => x.Gender).ToList();
            return peoplByGender;
        }

        // GET: api/Person/5
        [HttpGet("{name}", Name = "Get")]
        public List<Person> Get()
        {
            var peoplByGender = People.OrderByDescending(x => x.LastName).ToList();
            return peoplByGender;
        }

    }
}
