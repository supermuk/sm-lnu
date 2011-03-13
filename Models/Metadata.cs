using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using CMT.Attributes;

namespace CMT.Models
{
    [MetadataType(typeof(Metadata))]
    public partial class ChangePasswordModel
    {
        private sealed class Metadata
        {
            [Required]
            [DataType(DataType.Password)]
            [DisplayName("Current password")]
            public string OldPassword { get; set; }

            [Required]
            [ValidatePasswordLength]
            [DataType(DataType.Password)]
            [DisplayName("New password")]
            public string NewPassword { get; set; }

            [Required]
            [DataType(DataType.Password)]
            [DisplayName("Confirm new password")]
            public string ConfirmPassword { get; set; }
        }
    }

    public partial class LogOnModel
    {
        private sealed class Metadata
        {
            [Required]
            [DisplayName("User name")]
            public string UserName { get; set; }

            [Required]
            [DataType(DataType.Password)]
            [DisplayName("Password")]
            public string Password { get; set; }

            [DisplayName("Remember me?")]
            public bool RememberMe { get; set; }
        }
    }

    [MetadataType(typeof(Metadata))]
    [PropertiesMustMatch("Password", "ConfirmPassword", ErrorMessage = "The password and confirmation password do not match.")]
    public partial class RegisterModel
    {
        private sealed class Metadata
        {
            [Required]
            [DisplayName("User name")]
            public string UserName { get; set; }

            [Required]
            [DataType(DataType.EmailAddress)]
            [DisplayName("Email address")]
            public string Email { get; set; }

            [Required]
            [ValidatePasswordLength]
            [DataType(DataType.Password)]
            [DisplayName("Password")]
            public string Password { get; set; }

            [Required]
            [DataType(DataType.Password)]
            [DisplayName("Confirm password")]
            public string ConfirmPassword { get; set; }
        }
    }

    [MetadataType(typeof(Metadata))]
    public partial class Champ
    {
        private sealed class Metadata
        {
            [ScaffoldColumn(false)]
            public int Id { get; set; }

            [Required]
            [DisplayName("Championship Name")]
            public string Name { get; set; }

            [ScaffoldColumn(false)]
            public DateTime Created { get; set; }

            [ScaffoldColumn(false)]
            public DateTime Finished { get; set; }

            [ScaffoldColumn(false)]
            public int CreatedBy { get; set; }

            [ScaffoldColumn(false)]
            public bool Deleted { get; set; }
        }        
    }
}