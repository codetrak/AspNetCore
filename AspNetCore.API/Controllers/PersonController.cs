using AspNetCore.Data.Context;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace AspNetCore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly AppDbContext context;

        public PersonController(AppDbContext context)
        {
            this.context = context;
        }

        [HttpGet("all")]
        public IActionResult All()
        {
            var data = (from person in context.Persons
                        select person).ToList();

            return Ok(data);
        }
    }
}