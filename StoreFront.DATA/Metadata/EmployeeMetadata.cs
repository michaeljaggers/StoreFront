using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreFront.DATA
{
    public class EmployeeMetadata
    {
        [ScaffoldColumn(false)]
        [Display(Name = "Employee ID")]
        public int EmployeeID { get; set; }

        [Required]
        [Display(Name = "First Name")]
        [StringLength(30, ErrorMessage = "Maximum length is 30 characters.")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        [StringLength(30, ErrorMessage = "Maximum length is 30 characters.")]
        public string LastName { get; set; }

        [DisplayFormat(DataFormatString = "{0:c2}")]
        public Nullable<decimal> Wage { get; set; }

        [Display(Name = "Hire Date")]
        public Nullable<System.DateTime> HireDate { get; set; }

        [Display(Name = "Date of Birth")]
        public Nullable<System.DateTime> DOB { get; set; }

        [Display(Name = "Street Address")]
        [StringLength(60, ErrorMessage = "Maximum length is 60 characters.")]
        public string Address { get; set; }

        [StringLength(20, ErrorMessage = "Maximum length is 20 characters.")]
        public string City { get; set; }

        [StringLength(15, ErrorMessage = "Maximum length is 15 characters.")]
        public string State { get; set; }

        [Display(Name = "Zip Code")]
        [StringLength(10, ErrorMessage = "Maximum length is 10 characters.")]
        public string Zip { get; set; }

        [StringLength(15, ErrorMessage = "Maximum length is 15 characters.")]
        public string Country { get; set; }

        [EmailAddress]
        [StringLength(30, ErrorMessage = "Maximum length is 30 characters.")]
        public string Email { get; set; }

        [StringLength(24, ErrorMessage = "Maximum length is 24 characters.")]
        public string Phone { get; set; }
    }

    [MetadataType(typeof(EmployeeMetadata))]
    public partial class Employee { }
}
