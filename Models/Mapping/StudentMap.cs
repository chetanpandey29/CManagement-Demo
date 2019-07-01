using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace CAS_MVC_4.Models.Mapping
{
    public class StudentMap : EntityTypeConfiguration<Student>
    {
        public StudentMap()
        {
            // Primary Key
            this.HasKey(t => t.ScholarNumber);

            // Properties
            this.Property(t => t.ScholarNumber)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.StudentName)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.Gender)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.Class)
                .IsRequired()
                .HasMaxLength(20);

            this.Property(t => t.Section)
                .HasMaxLength(10);

            this.Property(t => t.GroupName)
                .HasMaxLength(50);

            this.Property(t => t.FatherName)
                .HasMaxLength(50);

            this.Property(t => t.FatherContactNumber)
                .HasMaxLength(35);

            this.Property(t => t.MotherName)
                .HasMaxLength(50);

            this.Property(t => t.MotherContactNumber)
                .HasMaxLength(35);

            this.Property(t => t.Address)
                .HasMaxLength(400);

            this.Property(t => t.PreviousSchool)
                .HasMaxLength(200);

            this.Property(t => t.InitialClass)
                .HasMaxLength(20);

            this.Property(t => t.EmailID)
                .HasMaxLength(50);

            this.Property(t => t.Nationality)
                .HasMaxLength(50);

            this.Property(t => t.DocumentsSubmitted)
                .HasMaxLength(200);

            this.Property(t => t.EmergencyContactPerson)
                .HasMaxLength(50);

            this.Property(t => t.EmergencyRelation)
                .HasMaxLength(50);

            this.Property(t => t.EmergencyContactNumber)
                .HasMaxLength(35);

            this.Property(t => t.EmergencyAddress)
                .HasMaxLength(400);

            // Table & Column Mappings
            this.ToTable("Student");
            this.Property(t => t.ScholarNumber).HasColumnName("ScholarNumber");
            this.Property(t => t.AdmissionDate).HasColumnName("AdmissionDate");
            this.Property(t => t.StudentName).HasColumnName("StudentName");
            this.Property(t => t.FeebookNumber).HasColumnName("FeebookNumber");
            this.Property(t => t.Gender).HasColumnName("Gender");
            this.Property(t => t.DateOfBirth).HasColumnName("DateOfBirth");
            this.Property(t => t.Class).HasColumnName("Class");
            this.Property(t => t.Section).HasColumnName("Section");
            this.Property(t => t.GroupName).HasColumnName("GroupName");
            this.Property(t => t.Session).HasColumnName("Session");
            this.Property(t => t.FatherName).HasColumnName("FatherName");
            this.Property(t => t.FatherContactNumber).HasColumnName("FatherContactNumber");
            this.Property(t => t.MotherName).HasColumnName("MotherName");
            this.Property(t => t.MotherContactNumber).HasColumnName("MotherContactNumber");
            this.Property(t => t.Address).HasColumnName("Address");
            this.Property(t => t.PreviousSchool).HasColumnName("PreviousSchool");
            this.Property(t => t.InitialClass).HasColumnName("InitialClass");
            this.Property(t => t.EmailID).HasColumnName("EmailID");
            this.Property(t => t.Nationality).HasColumnName("Nationality");
            this.Property(t => t.DocumentsSubmitted).HasColumnName("DocumentsSubmitted");
            this.Property(t => t.Transport).HasColumnName("Transport");
            this.Property(t => t.Concession).HasColumnName("Concession");
            this.Property(t => t.EmergencyContactPerson).HasColumnName("EmergencyContactPerson");
            this.Property(t => t.EmergencyRelation).HasColumnName("EmergencyRelation");
            this.Property(t => t.EmergencyContactNumber).HasColumnName("EmergencyContactNumber");
            this.Property(t => t.EmergencyAddress).HasColumnName("EmergencyAddress");
        }
    }
}
