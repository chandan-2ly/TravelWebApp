using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Travel.Core.BusinessModels
{
    public class RegisterUser
    {
        /// <summary>
        /// Email
        /// </summary>
        [Required(ErrorMessage = "Please Enter Email ID")]
        [RegularExpression(@"^([a-zA-Z0-9_.-])+@(([a-zA-Z0-9-])+.)+([a-zA-Z0-9]{2,4})+$", ErrorMessage = "Please enter a valid Email Address")]
        public string Email { get; set; }

        /// <summary>
        /// Password
        /// </summary>
        [Required(ErrorMessage = "Please enter Password")]
        public string Password { get; set; }
        [JsonIgnore]
        public string Salt { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        [JsonIgnore]
        public int Role { get; set; }
    }
}
