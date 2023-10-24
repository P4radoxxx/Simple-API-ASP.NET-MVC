using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace WebAPITest.Modeles
{
    public class Users
    {
        [JsonIgnore]
        //Handled by DB
        public int UserID        { get; set; }
        [Required]
        private string Lastname  { get; set; }
        [Required]
        public  string FirstName { get; set; }
        [Required]
        [RegularExpression("^[\\w\\.-]+@[\\w\\.-]+\\.\\w+$\r\n")]
        private string Email     { get; set; }

        // 1 Upper case char, 1 lower case char, 1 digit, 1 special char & at least 8 chars total.
        [Required]
        [RegularExpression("^(?=.*[A-Z])(?=.*[a-z])(?=.*\\d)(?=.*[\\W_]).{8,}$\r\n")]
        private string Password  { get; set; }
        private string Token     { get; set; }


        // Xposed props start here
        public string lastName
        {
            get => Lastname;
            set => Lastname = value;
        }

        public string email
        {
            get => Email;
            set => Email = value;
        }


        // Obj is no plain text no matter what, so grab, hash and send to DB to build a user check later.
        public string password
        {
            get => Password;
            set => Password = value;
        }

        public string token
        {
            get => Token;
            set => Token = value;
        }



    }
}
