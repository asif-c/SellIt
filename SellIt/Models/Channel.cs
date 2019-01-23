using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SellIt.Models
{
    public class Channel : IChannel
    {
        public int Id { get; set ; }
        [Required]
        public string Name { get; set; }
        [Required]
        public User Admin { get; set; }
        public ICollection<Post> Posts { get; set; }
    }
}