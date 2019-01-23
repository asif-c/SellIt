using SellIt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SellIt.Services
{
    public class HardCodedData
    {
        public ICollection<User> Users { get; set; }
        public ICollection<Post> Posts { get; set; }
        public ICollection<Channel> Channels { get; set; }
    }
}
