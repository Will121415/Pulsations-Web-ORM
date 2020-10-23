using Entity;
using Microsoft.EntityFrameworkCore;
namespace DAL
{
    public class PulsationsContext: DbContext
    {
        public PulsationsContext(DbContextOptions options): base(options)
        {

        }

        public DbSet<Person> Persons { get; set; }
    }
   
     

}