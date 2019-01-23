using System.Collections.Generic;

namespace SellIt.Models
{
    public interface IChannel
    {
        int Id { get; set; }
        User Admin { get; set; }
        string Name { get; set; }
        ICollection<Post> Posts { get; set; }
    }
}