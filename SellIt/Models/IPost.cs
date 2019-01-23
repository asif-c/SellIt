using System.Collections.Generic;

namespace SellIt.Models
{
    public interface IPost
    {
        Channel Channel { get; set; }
        ICollection<Comment> Comments { get; set; }
        string Content { get; set; }
        string Heading { get; set; }
        User User { get; set; }
        int Id { get; set; }
    }
}