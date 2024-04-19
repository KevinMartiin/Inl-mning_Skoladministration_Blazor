using System.ComponentModel.DataAnnotations;

namespace Inlämning_Skoladministration
{
    public class Student
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is obligatory")]
        [TwoPartsName(ErrorMessage = "The name must contain firstname aswell as lastname")]
        [RegularExpression(@"^[a-zA-ZåäöÅÄÖ ]*$", ErrorMessage = "Special characters or numbers are not accepted.")]
        public string Name { get; set; }



        [Required(ErrorMessage = "Birthdate is obligatory")]
        [DateOfBirth(ErrorMessage = "The student must be 10 years or older")]
        public DateTime? Birthdate { get; set; }

        [Required(ErrorMessage = "E-Mail is obligatory")]
        [EmailAddress(ErrorMessage = "Invalid E-Mail")]
        public string Email { get; set; }
    }
    public class DateOfBirthAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var birthdate = (DateTime?)value;
            if (birthdate == null || birthdate > DateTime.Today.AddYears(-10))
            {
                return new ValidationResult(ErrorMessage);
            }
            return ValidationResult.Success;
        }
    }
    public class TwoPartsNameAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            string fullName = value as string;
            if (fullName != null)
            {
                string[] parts = fullName.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                if (parts.Length < 2)
                {
                    return new ValidationResult(ErrorMessage);
                }
            }
            return ValidationResult.Success;
        }
    }

}
