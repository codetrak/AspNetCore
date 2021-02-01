using AspNetCore.API.Dto;
using AspNetCore.Domain.Entities;
using System.Collections.Generic;

namespace AspNetCore.API.Services.ControllerHelpers
{
    public interface IAccountControllerHelper
    {
        ServiceResponse<IEnumerable<PersonDto>> GetAll();
        ServiceResponse<PersonDto> GetById(int id);
        ServiceResponse<PersonDto> Create(Person person);
        ServiceResponse<PersonDto> UpdatePerson(Person person);
        ServiceResponse<int> UpdatePassword(Person person);

    }
}