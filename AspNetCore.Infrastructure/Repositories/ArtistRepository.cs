using AspNetCore.Data.Context;
using AspNetCore.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AspNetCore.Infrastructure.Repositories
{
    public class ArtistRepository : Repository<Artist>
    {
        public ArtistRepository(AppDbContext context) : base(context)
        {
        }

        public override IEnumerable<Artist> ReadAll()
        {
            return context.Artists.Include(d => d.ArtistDescription).DefaultIfEmpty();
        }

    }
}
