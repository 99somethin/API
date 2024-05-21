using ApiStudy.Data;
using ApiStudy.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiStudy.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly AppDbContext appDbContext;

        public UserController(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        [HttpGet]

        public async Task<ActionResult<List<User>>> Get() => Ok(await appDbContext.Users.ToListAsync());

        [HttpPost]

        public async Task<ActionResult<User>> Add(User user)
        {
            if (user != null)
            {
                var result = appDbContext.Users.Add(user).Entity;

                await appDbContext.SaveChangesAsync();

                return Ok(result);
            }
            return BadRequest("Invalid Request");
        }

        [HttpGet ("{email}/{password}")]

        public async Task<ActionResult<User>> Login(string email,string password )
        {
            if(email != null || password != null)
            {
                var user = await appDbContext.Users.Where(x => x.Email!.ToLower().Equals(email.ToLower()) && x.Password == password).FirstOrDefaultAsync();

                return user != null ? Ok(user) : NotFound("User not found");
                
            }
            return BadRequest("Invalid Request");
        }

    }
}
