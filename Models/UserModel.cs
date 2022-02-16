using System.ComponentModel.DataAnnotations;

namespace DanielsCodingChallenge.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
        public int Score { get; set; }
    }
}
