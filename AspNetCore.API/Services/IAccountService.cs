using AspNetCore.API.Dto;
using AspNetCore.Domain.Entities;

namespace AspNetCore.API.Services
{
    public interface IAccountService
    {
        string Login(LoginDto loginDto);
        Person CreateNewPassword(Person person);
    }
}