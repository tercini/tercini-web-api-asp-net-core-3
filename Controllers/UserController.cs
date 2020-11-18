using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using testeef.Data;
using testeef.Models;

namespace testeef.Controllers
{    
    [ApiController]
    [Route("v1/users")]
    public class UserController: ControllerBase
    {
        [HttpGet]
        [Route("")]
        public async Task<ActionResult<List<User>>> Get ([FromServices] DataContext context)
        {
            var users = await context.Users.ToListAsync();
            return users;
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<ActionResult<User>> GetById ([FromServices] DataContext context, int id)
        {
            var user = await context.Users
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == id);
            return user;
        }

        [HttpPost()]
        [Route("")]
        public async Task<ActionResult<User>> Login ([FromServices] DataContext context, string usuario, string senha)
        {
            var user = await context.Users            
            .AsNoTracking()      
            .Where(x => x.Usuario == usuario && x.Senha == senha)
            .FirstOrDefaultAsync();
            return user;
        }

        [HttpPost]
        [Route("")]
        public async Task<ActionResult<User>> Post(
            [FromServices] DataContext context,
            [FromBody] User model)
        {
            if(ModelState.IsValid)
            {
                context.Users.Add(model);
                await context.SaveChangesAsync();
                return model;
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

    }
}