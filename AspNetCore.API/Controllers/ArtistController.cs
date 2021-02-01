using AspNetCore.API.Services;
using AspNetCore.Domain.Entities;
using AspNetCore.Infrastructure.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArtistController : ControllerBase
    {
        private readonly IRepository<Artist> repository;

        public ArtistController(IRepository<Artist> repository)
        {
            this.repository = repository;
        }

        [HttpPost("create")]
        public IActionResult Create(Artist artist)
        {
            ServiceResponse<Artist> serviceResponse = new ServiceResponse<Artist>();

            serviceResponse.Data = repository.Create(artist);
            repository.SaveChanges();

            return Ok(serviceResponse);
        }

        [HttpGet("all")]
        public IActionResult All()
        {
            ServiceResponse<IEnumerable<Artist>> serviceResponse = new ServiceResponse<IEnumerable<Artist>>();
            serviceResponse.Data = repository.ReadAll();

            return Ok(serviceResponse);
        }

        [HttpGet("id/{id}")]
        public IActionResult GetById(int id)
        {
            ServiceResponse<Artist> serviceResponse = new ServiceResponse<Artist>();
            serviceResponse.Data = repository.Read(id);

            return Ok(serviceResponse);
        }

        [HttpPatch("update")]
        public IActionResult Update(Artist artist)
        {
            ServiceResponse<Artist> serviceResponse = new ServiceResponse<Artist>();

            if (artist.ArtistDescription != null)
            {
                artist.ArtistDescription = new ArtistDescription
                {
                    Description = artist.ArtistDescription.Description
                };
            }

            serviceResponse.Data = repository.Update(artist);
            repository.SaveChanges();

            return Ok(serviceResponse);
        }
    }
}
