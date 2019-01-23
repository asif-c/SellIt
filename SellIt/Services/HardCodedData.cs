using SellIt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SellIt.Services
{
    public class HardCodedData
    {
        public IList<User> Users { get; set; }
        public IList<Post> Posts { get; set; }
        public IList<Channel> Channels { get; set; }
    }
}
