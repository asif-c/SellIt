using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SellIt.Models;
using SellIt.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SellIt.Controllers
{
    public class SellIt : Controller
    {
        public HardCodedData Data { get; }

        public SellIt(HardCodedData data)
        {
            Data = data;
        }


        public ViewResult Index(HardCodedData data, string channelName)
        {
            if(string.IsNullOrWhiteSpace(channelName))
            {
                var newData = JsonConvert.DeserializeObject<HardCodedData>(JsonConvert.SerializeObject(data));
                newData.Channels = data.Channels ?? this.Data.Channels;
                newData.Posts = data.Posts ?? this.Data.Posts;
                newData.Users = data.Users ?? this.Data.Users;
                return View(newData);
            }
            else if (channelName.Equals("Home", StringComparison.InvariantCultureIgnoreCase))
            {
                var newData = JsonConvert.DeserializeObject<HardCodedData>(JsonConvert.SerializeObject(data));
                newData.Channels = data.Channels ?? this.Data.Channels;
                newData.Posts = data.Posts ?? this.Data.Posts;
                newData.Users = data.Users ?? this.Data.Users;
                return View(newData);
            }
            else
            {
                var newData = JsonConvert.DeserializeObject<HardCodedData>(JsonConvert.SerializeObject(data));
                newData.Posts = this.Data.Posts.Where(x => x.Channel.Name.Contains(channelName, StringComparison.InvariantCultureIgnoreCase)).ToList();
                return View(newData);
            }

        }

        public ViewResult Post() => View();
    }
}
