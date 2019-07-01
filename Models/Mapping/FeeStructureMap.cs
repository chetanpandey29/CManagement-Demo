using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace CAS_MVC_4.Models.Mapping
{
    public class FeeStructureMap : EntityTypeConfiguration<FeeStructure>
    {
        public FeeStructureMap()
        {
            // Primary Key
            this.HasKey(t => t.GroupId);

            // Properties
            // Table & Column Mappings
            this.ToTable("FeeStructure");
            this.Property(t => t.GroupId).HasColumnName("GroupId");
            this.Property(t => t.TuitionFee).HasColumnName("TuitionFee");
            this.Property(t => t.ActivityFee).HasColumnName("ActivityFee");
            this.Property(t => t.DevelopmentFee).HasColumnName("DevelopmentFee");
            this.Property(t => t.ConveyanceFee).HasColumnName("ConveyanceFee");
            this.Property(t => t.AdmissionFee).HasColumnName("AdmissionFee");
        }
    }
}
