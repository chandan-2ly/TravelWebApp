using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Travel.Core.BusinessModels
{
    /// <summary>
    /// This API is used to handle login requests.
    /// </summary>
    public class AuthenticateRequest
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

        /// <summary>
        /// Token
        /// </summary>
        public string Token { get; set; }
    }

}
