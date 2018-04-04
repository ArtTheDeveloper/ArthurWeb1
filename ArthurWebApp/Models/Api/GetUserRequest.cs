using System.ComponentModel.DataAnnotations;

namespace ArthurWebApp.Models
{
    public class GetUserRequest
    {
        [Required]
        public string Username { get; set; }
    }
}