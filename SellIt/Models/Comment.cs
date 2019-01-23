using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SellIt.Models
{
    public class Comment : IComment
    {
        public int Id { get; set; }
        [Required]
        public User User { get; set; }
        [Required]
        public string Content { get; set; }
        public Comment Parent { get; set; }
        public ICollection<Comment> Children { get; set; }
        public Post ParentPost { get; set; }
    }
}