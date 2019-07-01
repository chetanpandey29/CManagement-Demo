using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace CAS_MVC_4.Models.Mapping
{
    public class StudentRelationMap : EntityTypeConfiguration<StudentRelation>
    {
        public StudentRelationMap()
        {
            // Primary Key
            this.HasKey(t => new { t.Scholar1, t.Scholar2, t.UpdatedOn });

            // Properties
            this.Property(t => t.Scholar1)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.Scholar2)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Table & Column Mappings
            this.ToTable("StudentRelation");
            this.Property(t => t.Scholar1).HasColumnName("Scholar1");
            this.Property(t => t.Scholar2).HasColumnName("Scholar2");
            this.Property(t => t.UpdatedOn).HasColumnName("UpdatedOn");
        }
    }
}
