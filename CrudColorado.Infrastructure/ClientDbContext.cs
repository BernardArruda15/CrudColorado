using CrudColorado.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudColorado.Infrastructure
{
    public class ClientDbContext : DbContext
    {
        public ClientDbContext(DbContextOptions<ClientDbContext> options) 
            : base(options)
        {

        }

        public DbSet<Client> Clients { get; set; }

        public static implicit operator ClientDbContext(ClientRepository v)
        {
            throw new NotImplementedException();
        }
    }
}
