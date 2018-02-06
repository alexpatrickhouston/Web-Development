using System.Data.Entity;
using Week5_WebApp1.Data.Entities;

namespace Week5_WebApp1.Data
{
    public interface IDbContext
    {
        DbSet<User> Users { get; set; }
        DbSet<Pet> Pets { get; set; }
    }
}
