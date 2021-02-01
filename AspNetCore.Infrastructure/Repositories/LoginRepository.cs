using AspNetCore.Data.Context;
using AspNetCore.Domain.Entities;

namespace AspNetCore.Infrastructure.Repositories
{
    public class LoginRepository : Repository<AccountLogin>
    {
        public LoginRepository(AppDbContext context) : base(context)
        {
        }
    }
}