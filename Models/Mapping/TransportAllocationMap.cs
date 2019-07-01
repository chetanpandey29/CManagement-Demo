using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace CAS_MVC_4.Models.Mapping
{
    public class TransportAllocationMap : EntityTypeConfiguration<TransportAllocation>
    {
        public TransportAllocationMap()
        {
            // Primary Key
            this.HasKey(t => new { t.ScholarNumber, t.Type, t.StartDate });

            // Properties
            this.Property(t => t.ScholarNumber)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.Type)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.SourceLocation)
                .HasMaxLength(100);

            // Table & Column Mappings
            this.ToTable("TransportAllocation");
            this.Property(t => t.ScholarNumber).HasColumnName("ScholarNumber");
            this.Property(t => t.Type).HasColumnName("Type");
            this.Property(t => t.SourceLocation).HasColumnName("SourceLocation");
            this.Property(t => t.StartDate).HasColumnName("StartDate");
            this.Property(t => t.LeftDate).HasColumnName("LeftDate");

            // Relationships
            this.HasRequired(t => t.Student)
                .WithMany(t => t.TransportAllocations)
                .HasForeignKey(d => d.ScholarNumber);

        }
    }
}
