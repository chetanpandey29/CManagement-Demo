using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace CAS_MVC_4.Models.Mapping
{
    public class AdminLoginMap : EntityTypeConfiguration<AdminLogin>
    {
        public AdminLoginMap()
        {
            // Primary Key
            this.HasKey(t => new { t.Username, t.Password, t.UpdatedOn });

            // Properties
            this.Property(t => t.Username)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.Password)
                .IsRequired()
                .HasMaxLength(300);

            this.Property(t => t.Email)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("AdminLogin");
            this.Property(t => t.Username).HasColumnName("Username");
            this.Property(t => t.Password).HasColumnName("Password");
            this.Property(t => t.Email).HasColumnName("Email");
            this.Property(t => t.UpdatedOn).HasColumnName("UpdatedOn");
        }
    }
}
