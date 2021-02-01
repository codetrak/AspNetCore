using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using AspNetCore.Data.Context;
using AspNetCore.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace AspNetCore.Infrastructure.Repositories
{
    public class PersonRepository : Repository<Person>
    {
        public PersonRepository(AppDbContext context) : base(context)
        { }

        public override IEnumerable<Person> ReadAll()
        {
            return context.Persons
            .Include(l => l.Location)
            .Include(e => e.Email)
            .Include(p => p.Phone)
            .ToList();
        }

        public override Person Read(int id)
        {
            return context.Persons
            .Include(l => l.Location)
            .Include(e => e.Email)
            .Include(p => p.Phone)
            .FirstOrDefault();
        }

        public override IEnumerable<Person> Find(Expression<Func<Person, bool>> predicate)
        {
            return context.Persons
            .Include(e => e.Email)
            .Include(p => p.Phone)
            .Include(a => a.AccountLogin)
            .ThenInclude(r => r.AccountRole)
            .ThenInclude(a => a.AccountRoleType).Where(predicate);
        }

        public override Person Create(Person entity)
        {
            return base.Create(entity);
        }
    }
}