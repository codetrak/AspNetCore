using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AspNetCore.API.Auth;
using AspNetCore.API.Dto;
using AspNetCore.API.Services;
using AspNetCore.Domain.Entities;
using AspNetCore.Infrastructure.Repositories;

namespace AspNetCore.API.Services.ControllerHelpers
{
    public class AccountControllerHelper : IAccountControllerHelper
    {
        private readonly IRepository<Person> personRepository;
        private readonly IAccountService accountService;

        public AccountControllerHelper(IRepository<Person> personRepository, IAccountService accountService)
        {
            this.personRepository = personRepository;
            this.accountService = accountService;
        }

        private PersonDto MapPersonResponse(Person person)
        {
            // If the user has no phone then default to a new object otherwise we get an exception.
            person.Phone ??= new Phone();
            person.Email ??= new Email();

            return new PersonDto
            {
                EntityID = person.EntityID,
                FirstName = person.FirstName,
                MiddleName = person.MiddleName,
                LastName = person.LastName,
                Country = person.Location.Country,
                City = person.Location.City,
                SubCity = person.Location.SubCity,
                County = person.Location.County,
                EmailAddress = person.Email.EmailAddress,
                PhoneNumber = person.Phone.PhoneNumber
            };
        }

        private Person MapPersonUpdateRequest(Person person)
        {
            person.Email = new Email { EntityID = person.EntityID, EmailAddress = person.Email.EmailAddress };
            person.Phone = new Phone { EntityID = person.EntityID, PhoneNumber = person.Phone.PhoneNumber };
            person.Location = new Location { EntityID = person.EntityID, City = person.Location.City, Country = person.Location.Country };

            return person;
        }

        private bool IsMatchPassword(Person person)
        {
            return (String.Compare(person.AccountLogin.Password, person.AccountLogin.PasswordConfirm) == 0);
        }

        public ServiceResponse<PersonDto> Create(Person person)
        {
            ServiceResponse<PersonDto> serviceResponse = new ServiceResponse<PersonDto>();

            if (IsMatchPassword(person))
            {

                accountService.CreateNewPassword(person);
                personRepository.Create(person);
                personRepository.SaveChanges();

                serviceResponse.Data = MapPersonResponse(person);

                return serviceResponse;
            }
            else
            {
                serviceResponse.Success = false;
                serviceResponse.Message = "Password does not match";

                return serviceResponse;
            }

        }

        public ServiceResponse<PersonDto> UpdatePerson(Person person)
        {
            ServiceResponse<PersonDto> serviceResponse = new ServiceResponse<PersonDto>();

            personRepository.Update(MapPersonUpdateRequest(person));
            personRepository.SaveChanges();

            serviceResponse.Data = MapPersonResponse(personRepository.Read(person.EntityID));

            return serviceResponse;

        }

        public ServiceResponse<int> UpdatePassword(Person person)
        {
            ServiceResponse<int> serviceResponse = new ServiceResponse<int>();

            if (IsMatchPassword(person))
            {
               var newPassword = accountService.CreateNewPassword(person);

                person.AccountLogin = new AccountLogin
                {
                    EntityID = person.EntityID,
                    PasswordHash = newPassword.AccountLogin.PasswordHash,
                    PasswordSalt = newPassword.AccountLogin.PasswordSalt
                };

                personRepository.Update(person);
                personRepository.SaveChanges();
                serviceResponse.Data = person.EntityID;

                return serviceResponse;
            }
            else
            {
                serviceResponse.Success = false;
                serviceResponse.Message = "Password does not match";

                return serviceResponse;
            }
        }

        public ServiceResponse<IEnumerable<PersonDto>> GetAll()
        {

            ServiceResponse<IEnumerable<PersonDto>> serviceResponse = new ServiceResponse<IEnumerable<PersonDto>>();
            serviceResponse.Data = personRepository.ReadAll().Select(person => MapPersonResponse(person));

            return serviceResponse;
        }

        public ServiceResponse<PersonDto> GetById(int id)
        {
            ServiceResponse<PersonDto> serviceResponse = new ServiceResponse<PersonDto>();
            serviceResponse.Data = MapPersonResponse(personRepository.Read(id));

            return serviceResponse;
        }
    }
}