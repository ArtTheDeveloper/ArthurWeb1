using System.Collections.Generic;

namespace ArthurWebApp.Models
{
    public class UserViewModel
    {
        public string Username { get; set; }

        public string Location { get; set; }

        public string AvatarUrl { get; set; }

        public IEnumerable<UserRepoViewModel> Repos { get; set; }
    }
}