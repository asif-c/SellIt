using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SellIt.Models
{
    public class Post : IPost
    {
        public int Id { get ; set ; }
        //[Required]
        public User User { get; set; }
        //[Required]
        public string Heading { get; set; }
        public string Content { get; set; }
        public ICollection<Comment> Comments { get; set; }
        [Required]
        public Channel Channel { get; set; }
        public Rating Rating { get; set; }
    }
}
