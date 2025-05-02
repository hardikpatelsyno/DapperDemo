
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonLayer.Models
{
    public class ServiceRequestModel
    {    

        public int Id { get; set; }
        [StringLength(100, MinimumLength = 1, ErrorMessage = "Min Length 1")]
        [RegularExpression("^[a-zA-Z0-9]*$", ErrorMessage = "Only Alphabets and Numbers allowed")]
        public string FirstName { get; set; }
        [StringLength(100, MinimumLength = 1, ErrorMessage = "Min Length 1")]
        [RegularExpression("^[a-zA-Z0-9]*$", ErrorMessage = "Only Alphabets and Numbers allowed")]
        public string LastName { get; set; }
        [RegularExpression("^(?!0+$)(\\+\\d{1,3}[- ]?)?(?!0+$)\\d{10,15}$", ErrorMessage = "Please enter valid Mobile Number")]
        public string MobileNumber { get; set; }

        [Required(ErrorMessage = "Please enter the birth date.")]
        [DataType(DataType.Date)]
        [Display(Name = "Birth Date")]
        [MinimumAge(18, ErrorMessage = "Age must be greater than 18.")]
        public DateTime BirthDate { get; set; }
     
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public int EnquiryType { get; set; }
        public string? Comments { get; set; }

        public string FullName => $"{FirstName} {LastName}";


    }
}
