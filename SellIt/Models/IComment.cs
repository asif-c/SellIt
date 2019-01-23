using System.Collections.Generic;

namespace SellIt.Models
{
    public interface IComment
    {
        IEnumerable<Comment> Children { get; set; }
        string Content { get; set; }
        int Id { get; set; }
        Comment Parent { get; set; }
        User User { get; set; }
    }
}