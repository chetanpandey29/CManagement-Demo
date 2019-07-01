using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;


namespace CentralAcademy.MyModels
{
    public enum Gender
    {
        Male, Female
    }

    public class AdminLoginModel
    {
        [Display(Name="Username")]
        [Required(ErrorMessage="Username is required")]
        [StringLength(20, MinimumLength=4, ErrorMessage="Lenght should be betwwen 4 and 20 characters long")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [StringLength(50, MinimumLength = 6, ErrorMessage = "Minimum lenght should be 6 characters long")]
        public string Password { get; set; }

        [Display(Name = "Remember me")]
        public bool RememberMe { get; set; }
    }

    public class StudentModel
    {
        [Display(Name = "Scholar Number")]
        public int SRNo { get; set; }

        [Display(Name = "Fee Book Number")]
        public int? FeeBookNumber { get; set; }


        [Display(Name = "Admission Date")]
        public DateTime AdmissionDate { get; set; }


        [Display(Name = "Student Name")]
        [Required]
        [StringLength(45, MinimumLength = 3, ErrorMessage = "Length must be between 3 and 45")]
        public string StudentName { get; set; }

        public Gender Gender { get; set; }

        [Display(Name = "Date Of Birth")]
        public DateTime DateOfBirth { get; set; }


        [Display(Name = "Father's Name")]
        [StringLength(45, MinimumLength = 3, ErrorMessage = "Length must be between 3 and 45")]
        public string FatherName { get; set; }

        [StringLength(30, MinimumLength = 10, ErrorMessage = "Length must be between 10 and 30")]
        [Display(Name = "Contact No")]
        public string FatherContactNo { get; set; }

        [Display(Name = "Mother's Name")]
        [StringLength(40, MinimumLength = 3, ErrorMessage = "Length must be between 3 and 40")]
        public string MotherName { get; set; }

        [Display(Name = "Contact No")]
        [StringLength(30, MinimumLength = 10, ErrorMessage = "Length must be between 10 and 30")]
        public string MotherContactNo { get; set; }

        [Display(Name = "Class & Section")]
        public string Class { get; set; }

        [StringLength(5, MinimumLength = 1, ErrorMessage = "Only one character is allowed")]
        public string Section { get; set; }

        public string Group { get; set; }

        [Range(2001, 2018)]
        public int Session { get; set; }
        
        [StringLength(300, MinimumLength = 5, ErrorMessage = "Length must be between 5 and 300")]
        public string Address { get; set; }

        [Display(Name = "Locality")]
        public string Locality { get; set; }
        [Display(Name = "House No.")]
        public string House { get; set; }
        [Display(Name="Street")]
        public string Street { get; set; }
        [Display(Name = "City")]
        public string City { get; set; }
        [Display(Name = "Pin No")]
        public string pin { get; set; }

        [StringLength(30, MinimumLength = 3, ErrorMessage = "Length must be between 3 and 30")]
        public string Nationality { get; set; }

        [Display(Name = "Previous School")]
        [StringLength(180, MinimumLength = 3, ErrorMessage = "Length must be between 3 and 180")]
        public string PreviousSchool { get; set; }

        [Display(Name = "Initial Class")]
        [StringLength(15, MinimumLength = 1, ErrorMessage = "Length must be between 1 and 15")]
        public string InitialClass { get; set; }

        [Display(Name = "Email ID")]
        [DataType(System.ComponentModel.DataAnnotations.DataType.EmailAddress)]
        public string EmailID { get; set; }

        [Display(Name = "Document Submitted")]
        public string DocumentSubmitted { get; set; }
        [Display(Name = "Other")]
        public string OtherDoc { get; set; }
        
        public bool tc { get; set; }
        public bool bc { get; set; }
        public bool mReport { get; set; }
        public bool Photo { get; set; }
        public bool affidavit { get; set; }


        public bool Concession { get; set; }
        
        public bool Transport { get; set; }

        [Display(Name = "Name")]
        public string EmerygencyContactPerson { get; set; }

        [Display(Name = "Relation")]
        public string EmergencyRelation { get; set; }

        [Display(Name = "Contact Number")]
        public string EmergencyContactNumber { get; set; }

        [Display(Name = "Address")]
        public string EmergencyAddress { get; set; }

        public IList<Relation> Relation { get; set; }
    }

    public class StudentSearchModel
    {
        [Display(Name = "Student Name")]
        public string StudentName { get; set; }

        [Display(Name = "Class & Section")]
        public string Class { get; set; }

        public string Section { get; set; }

        public int? Session { get; set; }

        [Display(Name = "Feebook Number")]
        public int? FeebookNumber { get; set; }

        [Display(Name = "Father Name")]
        public string FatherName { get; set; }

        [Display(Name = "Date of Birth")]
        public DateTime? DateOfBirth { get; set; }

        [Display(Name = "Locality")]
        public string Locality { get; set; }

        public object SRNo { get; set; }
    }

    public class TransportDetail
    {
        [Display(Name = "Transport Type")]
        public string Type { get; set; }

        [Display(Name = "Vehicle Number")]
        [StringLength(15, MinimumLength = 2)]
        public string VehicleNumber { get; set; }

        [Display(Name = "Contact Number")]
        [StringLength(15, MinimumLength = 10)]
        public string ContactNumber { get; set; }

        [Display(Name = "Driver Name")]
        [Required]
        [StringLength(30, MinimumLength = 2)]
        public string DriverName { get; set; }
        public DateTime UpdatedOn { get; set; }
    }

    public class TransportAllocation
    {
        [Display(Name = "Scholar Number")]
        public int ScholarNumber { get; set; }

        [Display(Name = "Transport Type")]
        public string Type { get; set; }
        
        [Required]
        [Display(Name = "Source Location")]
        public string SourceLocation { get; set; }

        [Display(Name = "Start Date")]
        [Required]
        [DataType( System.ComponentModel.DataAnnotations.DataType.Date)]
        public DateTime StartDate { get; set; }

        [Display(Name = "Left Date")]
        public DateTime? LeftDate { get; set; }
    }

    public class TransportSearch
    {
        [Display(Name="Scholar Number")]
        public int? ScholarNumber { get; set; }

        [Display(Name = "Transport Number")]
        public string TransportType { get; set; }
        
        [Display(Name = "Source Location")]
        public string SourceLocation { get; set; }

        [Display(Name = "Show only Current")]
        public bool ShowCurrent { get; set; }
    }

    public class FeeStructure
    {
        [Display(Name = "Class Group")]
        public byte GroupID { get; set; }

        [Display(Name = "Tuition Fee")]
        [Required]
        [Range(0, short.MaxValue, ErrorMessage = "Invalid Value")]
        public decimal TuitionFee { get; set; }

        [Display(Name = "Activity Fee")]
        [Required]
        [Range(0, short.MaxValue, ErrorMessage = "Invalid Value")]
        public decimal ActivityFee { get; set; }

        [Display(Name = "Development Fee")]
        [Required]
        [Range(0, short.MaxValue, ErrorMessage = "Invalid Value")]
        public decimal DevelopmentFee { get; set; }

        [Display(Name = "Conveyance Fee")]
        [Required]
        [Range(0, short.MaxValue, ErrorMessage = "Invalid Value")]
        public decimal ConveyanceFee { get; set; }

        [Display(Name = "Admission Fee")]
        [Required]
        [Range(0, short.MaxValue, ErrorMessage = "Invalid Value")]
        public decimal AdmissionFee { get; set; }
    }

    public class FeeDepositModel
    {
        [Display(Name = "Scholar Number")]
        public int ScholarNumber { get; set; }

        [Display(Name = "Fee Book No")]
        public int FeeBookNo { get; set; }

        [Display(Name = "Fee Group")]
        public string FeeGroup { get; set; }

        [Display(Name="From Instalment")]
        public int FromInstallment { get; set; }

        [Display(Name="To Instalment")]
        public int ToInstallment { get; set; }

        [Display(Name = "Tuition Fee")]
        [Range(0, short.MaxValue, ErrorMessage = "Invalid Amount.")]
        public decimal TuitionFee { get; set; }

        [Display(Name = "Admission Fee")]
        [Range(0, short.MaxValue, ErrorMessage = "Invalid Amount.")]
        public decimal AdmissionFee { get; set; }

        [Display(Name = "Activity Fee")]
        [Range(0, short.MaxValue, ErrorMessage = "Invalid Amount.")]
        public decimal ActivityFee { get; set; }

        [Display(Name = "Development Fee")]
        [Range(0, short.MaxValue, ErrorMessage = "Invalid Amount.")]
        public decimal DevelopmentFee { get; set; }

        [Display(Name = "Conveyance Fee")]
        [Range(0, short.MaxValue, ErrorMessage = "Invalid Amount.")]
        public decimal ConveyanceFee { get; set; }

        [Display(Name = "Concession")]
        [Range(0, short.MaxValue, ErrorMessage = "Invalid Amount.")]
        public decimal Concession { get; set; }

        [Display(Name = "Late Fee")]
        [Range(0, short.MaxValue, ErrorMessage = "Invalid Amount.")]
        public decimal LateFee { get; set; }
    }


    public class BankResource
    {
        [Display(Name = "S.No.")]
        public int SNo { get; set; }
        [Display(Name = "Date")]
        public DateTime Date { get; set; }
        [Display(Name = "Instalment No")]
        public string InstalmentNo { get; set; }
        [Display(Name = "S.R. No.")]
        public int SRNo { get; set; }
        [Display(Name = "Fee Book Number")]
        public int FeeBookNumber { get; set; }
        [Display(Name = "Name")]
        public string Name { get; set; }
        [Display(Name = "Class")]
        public string Class { get; set; }
        [Display(Name = "Section")]
        public string Section { get; set; }
        [Display(Name = "Conveyance fee")]
        public decimal  ConveyanceFee { get; set; }
        [Display(Name = "Tuition Fee")]
        public decimal TuitionFee { get; set; }
        [Display(Name = "Activity Fee")]
        public decimal ActivityFee { get; set; }
        [Display(Name = "Development Fee")]
        public decimal Development { get; set; }
        [Display(Name = "Late Fee")]
        public decimal LateFee { get; set; }
        [Display(Name = "Total Fee")]
        public decimal TotalFee { get; set; }
        [Display(Name = "Mode Of Payment")]
        public string Mode { get; set; }
    }

    public class Relation
    {                                   
        public int ScholarNumber { get; set; }
        public string Name { get; set; }
        public string RelationName { get; set; }
        public string Class { get; set; }
        public string Section { get; set; }
    }

    public class DailyFeeCollectionModel
    {
        [Display(Name = "Start Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime startDate { get; set; }

        [Display(Name = "End Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime endDate { get; set; }
    }

}