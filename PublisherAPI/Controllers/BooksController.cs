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
    public class BooksController : Controller
    {
        public IBookRepository Repository { get; }

        public BooksController(IBookRepository repository)
        {
            Repository = repository;
        }
        // GET: api/Books
        [HttpGet]
        public Task<IEnumerable<Book>> Get()
        {
            return Repository.ListAsync();
        }

        // GET: api/Books/5
        [HttpGet("{id}")]
        public Task<Book> Get(string id)
        {
            return Repository.FindAsync(id);
        }


        // POST: api/Books
        [HttpPost]
        public IActionResult Post([FromBody]Book value)
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

        // PUT: api/Books/5
        [HttpPut("{id}")]
        public IActionResult Put(string id, [FromBody]Book value)
        {
            if (!ModelState.IsValid || string.IsNullOrEmpty(id))
            {
                return BadRequest(ModelState);
            }
            try
            {
                Repository.UpdateAsync(id, value);
                return Ok();
            }
            catch (Exception)
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
                Repository.RemoveAsync(id);
                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

    }
}
