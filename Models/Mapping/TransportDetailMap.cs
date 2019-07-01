using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace CAS_MVC_4.Models.Mapping
{
    public class TransportDetailMap : EntityTypeConfiguration<TransportDetail>
    {
        public TransportDetailMap()
        {
            // Primary Key
            this.HasKey(t => new { t.Type, t.UpdatedOn });

            // Properties
            this.Property(t => t.Type)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.VehicleNumber)
                .HasMaxLength(20);

            this.Property(t => t.DriverName)
                .HasMaxLength(50);

            this.Property(t => t.ContactNumber)
                .HasMaxLength(15);

            // Table & Column Mappings
            this.ToTable("TransportDetail");
            this.Property(t => t.Type).HasColumnName("Type");
            this.Property(t => t.VehicleNumber).HasColumnName("VehicleNumber");
            this.Property(t => t.DriverName).HasColumnName("DriverName");
            this.Property(t => t.ContactNumber).HasColumnName("ContactNumber");
            this.Property(t => t.UpdatedOn).HasColumnName("UpdatedOn");
        }
    }
}
