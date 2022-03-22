using System.ComponentModel.DataAnnotations;


namespace AddressBookApplication.Models
{
    public class ContactModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(?[+. ]?([374]{3})\)?[-. ]?([0-9]{2})[-. ]?([0-9]{3})?[-. ]?([0-9]{3})$", ErrorMessage = "Not a valid phone number")]
        public string PhoneNumber { get; set; }

        [Required]
        public string FullName { get; set; }

        [Required]
        [EmailAddress]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "E-mail is not valid")]
        public string EmailAddress { get; set; }

        public string PhysicalAddress { get; set; }
    }
}