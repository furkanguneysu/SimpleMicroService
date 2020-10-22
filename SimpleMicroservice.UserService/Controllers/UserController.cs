using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SimpleMicroservice.UserService.Database;
using SimpleMicroservice.UserService.Database.Entities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SimpleMicroservice.UserService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        DatabaseContext dbContext;
        public UserController()
        {
            dbContext = new DatabaseContext();
        } 
        // GET: api/<UserController>
        [HttpGet]
        public IEnumerable<User> Get()
        {
            return dbContext.Users.ToList();
        }

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
             
            var userFound = dbContext.Users.Find(id);
            if(userFound != null)
            {
                return StatusCode(StatusCodes.Status200OK, userFound);
            }
            else
            {
                return StatusCode(StatusCodes.Status404NotFound);
            }
            
        }

        // POST api/<UserController>
        [HttpPost]
        public IActionResult Post([FromBody] User user)
        {
            try
            {
                dbContext.Users.Add(user);
                dbContext.SaveChanges();
                return StatusCode(StatusCodes.Status201Created,user);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,ex);
            }
            
        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var userToRemove = dbContext.Users.Find(id);
                dbContext.Users.Remove(userToRemove);
                dbContext.SaveChanges();
                return StatusCode(StatusCodes.Status200OK);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
            
        }
    }
}
