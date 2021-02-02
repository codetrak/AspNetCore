using AspNetCore.API.Dto;
using AspNetCore.Domain.Entities;
using AspNetCore.Infrastructure.Repositories;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace AspNetCore.API.Controllers
{
    [EnableCors("AllowAnyOrigin")]
    [ApiController]
    [Route("api/[controller]")]
    public class CatalogController : ControllerBase
    {
        private readonly IRepository<Catalog> repository;

        public CatalogController(IRepository<Catalog> repository)
        {
            this.repository = repository;
        }

        [HttpGet("All")]
        public IActionResult All()
        {
            return Ok(repository.ReadAll());
        }

        [HttpPost("create"), DisableRequestSizeLimit]
        public IActionResult Create([FromForm] UploadResourceDto dto)
        {

            var upload = GetUpload(dto);

            Catalog catalog = new Catalog
            {
                Name = dto.CatalogName,
                ArtistID = dto.ArtistID,
                CatalogTypeID = dto.CatalogTypeID
            };

            catalog.CatalogDescription = new CatalogDescription
            {
                Description = dto.Description
            };

            catalog.CatalogArtwork = new CatalogArtwork
            {
                ArtWork = upload.DataFile,
                OriginalName = upload.Name,
                AssignedName = upload.AssignedName,
                Extension = upload.Extension
            };

            repository.Create(catalog);
            repository.SaveChanges();
            
            return Ok();
        }

        private UploadResourceDto GetUpload(UploadResourceDto dto)
        {
            try
            {

                var fileFullName = dto.UploadedFile.FileName;

                dto.Name = fileFullName.Substring(0, fileFullName.LastIndexOf("."));
                dto.Extension = $".{fileFullName.Substring(fileFullName.LastIndexOf('.') + 1)}";
                dto.AssignedName = String.Concat(Convert.ToString(Guid.NewGuid()), dto.Extension);

                using (var target = new MemoryStream())
                {
                    dto.UploadedFile.CopyTo(target);
                    dto.DataFile = target.ToArray();
                }

            }
            catch (Exception ex)
            {
                dto.ErrorMessage = ex.Message;
            }

            return dto;
        }
    }
}
