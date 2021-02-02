using AspNetCore.Data.Context;
using AspNetCore.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNetCore.Infrastructure.Repositories
{
    public class CatalogRepository : Repository<Catalog>
    {
        public CatalogRepository(AppDbContext context) : base(context)
        {
        }

        public override IEnumerable<Catalog> ReadAll()
        {
            return context.Catalogs
                .Include(d => d.CatalogDescription)
                .Include(a => a.CatalogArtwork).DefaultIfEmpty().ToList();
        }
    }
}
