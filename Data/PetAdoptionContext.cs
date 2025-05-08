using COMP003B.SP25.FinalProject.VerissimoA.Models;
using Microsoft.EntityFrameworkCore;

namespace COMP003B.SP25.FinalProject.VerissimoA.Data
{
    public class PetAdoptionContext : DbContext
    {
        public PetAdoptionContext(DbContextOptions<PetAdoptionContext> options) : base(options)
        {
        }

        public DbSet<Animal> Animals  { get; set; }
        public DbSet<Shelter> Shelters { get; set; }
        public DbSet<Staff> Members { get; set; }
        public DbSet<Adopter> Adopters { get; set; }
        public DbSet<AdoptionRequest> AdoptionRequests { get; set; }
    }
}
