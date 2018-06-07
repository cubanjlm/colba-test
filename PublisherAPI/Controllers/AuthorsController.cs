using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PublisherAPI.Model;
using PublisherAPI.Repository;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PublisherAPI.Controllers
{
    [Route("api/[controller]")]
    public class AuthorsController : ControllerBase
    {
        public IAuthorRepository Repository { get; }
        public IAddressRepositry AddressRepositry { get; }

        public AuthorsController(IAuthorRepository repository, IAddressRepositry addressRepositry)
        {
            Repository = repository;
            AddressRepositry = addressRepositry;
        }
        // GET: api/<controller>
        [HttpGet]
        public Task<IEnumerable<Author>> Get()
        {
            return Repository.ListAsync();
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public Task<Author> Get(string id)
        {
            return Repository.FindAsync(id);
        }

        // POST api/<controller>
        [HttpPost]
        public IActionResult Post([FromBody]Author value)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                Repository.Save(value);
                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(500);
            }

        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public IActionResult Put(string id, [FromBody]Author value)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                Repository.UpdateAsync(id,value);
                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            try
            {
                Repository.RemoveAsync(id);
                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }
        
        [HttpGet]
        [Route("{id}/Blogs")]
        public Task<IEnumerable<BlogPost>> Blogs(string id)
        {
            return Repository.GetEntries(id);
        }


        [HttpGet]
        [Route("{id}/Addresses")]
        public Task<IEnumerable<Address>> Address(string id)
        {
            return AddressRepositry.FindByAuthor(id);
        }

    }
}
