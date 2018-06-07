using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PublisherAPI.Model;
using PublisherAPI.Repository;

namespace PublisherAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class AddressController : ControllerBase
    {
        public IAddressRepositry Repo { get; }

        public AddressController(IAddressRepositry repositry)
        {
            Repo = repositry;
        }
        // GET: api/Address
        [HttpGet]
        public Task<IEnumerable<Address>> Get()
        {
            return Repo.ListAsync();
        }

        // GET: api/Address/5
        [HttpGet("{id}")]
        public Task<Address> Get(string id)
        {
            return Repo.FindAsync(id);
        }
        
        // POST: api/Address
        [HttpPost]
        public IActionResult Post([FromBody]Address value)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                Repo.Save(value);
                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }
        
        // PUT: api/Address/5
        [HttpPut("{id}")]
        public IActionResult Put(string id, [FromBody]Address value)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                Repo.UpdateAsync(id, value);
                return Ok();
            }
            catch (Exception e)
            {
                return StatusCode(500);
            }
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            try
            {
                Repo.RemoveAsync(id);
                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }
    }
}
