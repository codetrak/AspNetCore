using AspNetCore.API.Dto;
using AspNetCore.API.Services;
using AspNetCore.API.Services.ControllerHelpers;
using AspNetCore.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountControllerHelper controllerHelper;
        private readonly IAccountService accountService;

        public AccountController(IAccountControllerHelper controllerHelper, IAccountService accountService)
        {
            this.controllerHelper = controllerHelper;
            this.accountService = accountService;
        }


        [HttpGet("all")]
        public IActionResult GetAll()
        {
            return Ok(controllerHelper.GetAll());
        }

        [HttpGet("id/{id}")]
        public IActionResult GetById(int id)
        {
            return Ok(controllerHelper.GetById(id));
        }

        [HttpPost("create")]
        public IActionResult Create(Person person)
        {

            var result = controllerHelper.Create(person);

            if (!result.Success)
            {
                return StatusCode(StatusCodes.Status400BadRequest, result.Message);
            }
            else
            {
                return StatusCode(StatusCodes.Status200OK, result);
            }
        }

        [HttpPatch("update")]
        public IActionResult Update(Person person)
        {
            return Ok(controllerHelper.UpdatePerson(person));
        }

        [HttpPatch("update/password")]
        public IActionResult UpdatePassword(Person person)
        {
            return Ok(controllerHelper.UpdatePassword(person));
        }

        [HttpPost("login")]
        public IActionResult Login(LoginDto loginDto)
        {
            var token = accountService.Login(loginDto);
            return Ok(token);
        }

    }
}
