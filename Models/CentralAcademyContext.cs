using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using CAS_MVC_4.Models.Mapping;

namespace CAS_MVC_4.Models
{
    public partial class CentralAcademyContext : DbContext
    {
        static CentralAcademyContext()
        {
            Database.SetInitializer<CentralAcademyContext>(null);
        }

        public CentralAcademyContext()
            : base("Data Source=DEll-Pc;Initial Catalog=CentralAcademy;Integrated Security=True;MultipleActiveResultSets=True")
        {
        }

        public DbSet<AdminLogin> AdminLogins { get; set; }
        public DbSet<BankResource> BankResources { get; set; }
        public DbSet<FeeStructure> FeeStructures { get; set; }
        public DbSet<FeeTransaction> FeeTransactions { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<StudentRelation> StudentRelations { get; set; }
        public DbSet<sysdiagram> sysdiagrams { get; set; }
        public DbSet<TransportAllocation> TransportAllocations { get; set; }
        public DbSet<TransportDetail> TransportDetails { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new AdminLoginMap());
            modelBuilder.Configurations.Add(new BankResourceMap());
            modelBuilder.Configurations.Add(new FeeStructureMap());
            modelBuilder.Configurations.Add(new FeeTransactionMap());
            modelBuilder.Configurations.Add(new StudentMap());
            modelBuilder.Configurations.Add(new StudentRelationMap());
            modelBuilder.Configurations.Add(new sysdiagramMap());
            modelBuilder.Configurations.Add(new TransportAllocationMap());
            modelBuilder.Configurations.Add(new TransportDetailMap());
        }
    }
}
