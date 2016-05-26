using System;
using System.ComponentModel.DataAnnotations;

namespace QNA.Models
{
    /// <summary>
    /// Base class to hold user information
    /// </summary>
    public abstract class UserBase
    {
        /// <summary>
        /// User identifier
        /// </summary>
        [Key]
        public int UserId { get; set; }

        /// <summary>
        /// User name to get logged in. It must be unique for every user.
        /// </summary>
        //[System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings =false, System.ComponentModel.DataAnnotations.ErrorMessage =Constants.USERNAME_REQUIRED, ErrorMessageResourceType =typeof(MessageResource))]
        public string UserName { get; set; }

        /// <summary>
        /// User password to get logged in
        /// </summary>
        public string UserPassword { get; set; }

        /// <summary>
        /// User name to display in public
        /// </summary>
        public string DisplayName { get; set; }

        /// <summary>
        /// Date and time when user gets last logged in
        /// </summary>
        public DateTime? UserLastLoggedOn { get; set; }
    }





    /// <summary>
    /// Holds the application user information
    /// </summary>
    public class AppUser: UserBase
    {
        
    }

    /// <summary>
    /// Holds the social user information
    /// </summary>
    public class SocialUser : UserBase
    {
        /// <summary>
        /// Hold the secret key of social user
        /// </summary>
        public string SecretKey { get; set; }

    }


}
