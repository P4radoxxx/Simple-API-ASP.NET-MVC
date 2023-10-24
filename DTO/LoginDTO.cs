using System.ComponentModel.DataAnnotations;

namespace WebAPITest.DTO
{



    //Login DTO model
    public class LoginDTO
    {
        /// <summary>
        /// The user's email address.
        /// </summary>  
        [Required]
        [RegularExpression("^[\\w\\.-]+@[\\w\\.-]+\\.\\w+$\r\n")]
        public string Email { get; set; }



        /// <summary>
        /// The user's password.
        /// </summary>
        [Required]
        [RegularExpression("^(?=.*[A-Z])(?=.*[a-z])(?=.*\\d)(?=.*[\\W_]).{8,}$\r\n", ErrorMessage = "Format de l'emal invalide.")]
        public string Password { get; set; }


    }
}
