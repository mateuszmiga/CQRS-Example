using CQRS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS.Infrastructure
{
    public class Repository
    {
        private readonly Context context;

        public Repository(Context context)
        {
            this.context = context;
        }

        public async Task<User> Get(int id)
        {
            var result = await context.Users.FirstOrDefaultAsync(x => x.Id == id);
            return result;
        }

        public async Task Create(string userLogin)
        {
            await context.Users.AddAsync(new User { Login = userLogin });
            await context.SaveChangesAsync();
        }
    }
}
