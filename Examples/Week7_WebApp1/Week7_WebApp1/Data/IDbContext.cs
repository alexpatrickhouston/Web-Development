using System.Data.Entity;
using Week6_WebApp1.Data.Entities;

namespace Week6_WebApp1.Data
{
    public interface IDbContext
    {
        DbSet<User> Users { get; set; }
        DbSet<Pet> Pets { get; set; }
    }
}
