using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SellIt.Models
{
    public class User
    {
        public int Id { get; set; }
        //[Required]
        public string Username { get; set; }
        //[Required]
        public string Password { get; set; }
        //[Required]
        public string Email { get; set; }
        public ICollection<Channel> SubscribedChannels { get; set; }
        public ICollection<Channel> CreatedChannels { get; set; }
        public ICollection<Post> CreatedPosts { get; set; }

        public ICollection<Comment> Comments { get; set; }
    }
}