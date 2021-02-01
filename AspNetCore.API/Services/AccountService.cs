using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using AspNetCore.API.Auth;
using AspNetCore.API.Dto;
using AspNetCore.Domain.Entities;
using AspNetCore.Infrastructure.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace AspNetCore.API.Services
{
    public class AccountService : IAccountService
    {
        private readonly IConfiguration configuration;
        private readonly IRepository<Person> personRepository;

        public AccountService(IConfiguration configuration, IRepository<Person> personRepository)
        {
            this.configuration = configuration;
            this.personRepository = personRepository;
        }
        private string CreateToken(LoginDto loginDto)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, loginDto.EntityID.ToString()),
                new Claim(ClaimTypes.Name, loginDto.Username),
                new Claim(ClaimTypes.Role, loginDto.RoleName)
            };

            SymmetricSecurityKey key = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(configuration.GetSection("AppSettings:Token").Value)
                );

            SigningCredentials signingCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);
            SecurityTokenDescriptor securityTokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddMinutes(1),
                SigningCredentials = signingCredentials
            };

            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            SecurityToken securityToken = tokenHandler.CreateToken(securityTokenDescriptor);

            return tokenHandler.WriteToken(securityToken);
        }

        private LoginDto GetUserAccountLogin(LoginDto loginDto)
        {
           return personRepository.Find(x => x.Email.EmailAddress == loginDto.Username || x.Phone.PhoneNumber == loginDto.Username)
                        .Select(x => new LoginDto
                        {
                            EntityID = x.EntityID,
                            PasswordHash = x.AccountLogin.PasswordHash,
                            PasswordSalt = x.AccountLogin.PasswordSalt,
                            Username = x.Email.EmailAddress,
                            RoleStatusID = x.AccountLogin.AccountRole.RoleStatusID,
                            RoleName = x.AccountLogin.AccountRole.AccountRoleType.RoleName

                        }).FirstOrDefault();
        }

        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));

                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != passwordHash[i])
                    {
                        return false;
                    }
                }

                return true;
            }
        }

        public string Login(LoginDto loginDto)
        {
            var login = GetUserAccountLogin(loginDto);

            if (login.RoleStatusID >= 400)
            {
                return null;
            }
            else
            {
                if (login == null)
                {
                    return null;
                }
                else if (!VerifyPasswordHash(loginDto.Password, login.PasswordHash, login.PasswordSalt))
                {
                    return null;
                }
                else
                {
                    return CreateToken(login);
                }
            }

        }

        public Person CreateNewPassword(Person person)
        {
            CreatePasswordHash(person.AccountLogin.Password, out byte[] passwordHash, out byte[] passwordSalt);

            person.AccountLogin = new AccountLogin
            {
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt
            };

            // If user already has account then do not change Roles.
            if(person.EntityID == 0)
            {
                person.AccountLogin.AccountRole = new AccountRole
                {
                    RoleStatusID = (int)RoleStatus.Pending,
                    RoleTypeID = (int)Role.Restricted
                };
            }

            return person;
        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            }
        }
    }
}