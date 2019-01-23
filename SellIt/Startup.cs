using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SellIt.Data;
using SellIt.Models;
using SellIt.Services;

namespace SellIt
{
    public class Startup
    {
        public IList<Channel> Channels { get; set; }
        public IList<User> Users { get; set; }
        public IList<Post> Posts { get; set; }
        public IConfiguration Config { get; set; }

        public Startup(IConfiguration config)
        {
            Config = config;
            SeedData();

        }

        public void ConfigureServices(IServiceCollection services)
        {

            services.AddMvc().SetCompatibilityVersion(Microsoft.AspNetCore.Mvc.CompatibilityVersion.Version_2_2);

            //services.AddDbContext<SellItContext>(options =>
            //    options.UseSqlServer(Config.GetConnectionString("SQLServer")));

            services.AddScoped<IPost, Post>()
                    .AddScoped<IChannel, Channel>()
                    .AddScoped<HardCodedData>(x => new HardCodedData
                    {
                        Channels = Channels,
                        Posts = Posts,
                        Users = Users
                    });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHsts();
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseMvc(routes =>
            {
                routes.MapRoute(name: "default",
                    template: "{action}/{id?}",
                    defaults: new { Controller = "SellIt" });
            });
        }

        private void SeedData()
        {
            if(this.Channels is null)
            {
                this.Channels = new List<Channel>
                {
                    new Channel {
                        Name = "Home",
                        Admin = new User { Username = "Jane_doe" }
                    },
                    new Channel {
                        Name = "ION9000",
                        Admin = new User { Username = "AllAboard"}
                    },
                    new Channel {
                        Name = "ION8000",
                        Admin = new User { Username = "triton"}
                    },
                    new Channel {
                        Name = "ION7400",
                        Admin = new User { Username = "ios_isOkay"}
                    },
                    new Channel {
                        Name = "ION7x50",
                        Admin = new User { Username = "top_secret"}
                    },
                    new Channel {
                        Name = "PME",
                        Admin = new User { Username = "007"}
                    },
                    new Channel {
                        Name = "PSE(SCADA)",
                        Admin = new User { Username = "pme_isAwesome"}
                    },
                };
            }

            if(this.Users is null)
            {
                this.Users = new List<User>
                {
                    new User { Username = "John_Doe" },
                    new User { Username = "Jack_hammer" },
                    new User { Username = "triton" },
                    new User { Username = "xoxox" },
                    new User { Username = "craves" },
                    new User { Username = "dontWorryBoutMe" },
                };
            }

            if (this.Posts is null)
            {
                this.Posts = new List<Post>
                {
                    new Post
                    {
                        User = this.Users[0],
                        Heading = "How does the ION 9000 stack up against the ION 8650?",
                        Channel = this.Channels.FirstOrDefault(x => x.Name.Contains("ION9000")),
                        Rating = new Rating { Upvotes = 50, Downvotes = 0 }
                    },
                    new Post
                    {
                        User = this.Users[1],
                        Heading = "What is the leadtime of ION 9000 in Australia and Asia Pacific?",
                        Channel = this.Channels.FirstOrDefault(x => x.Name.Contains("ION9000")),
                        Rating = new Rating { Upvotes = 1, Downvotes = 0 }
                    },
                    new Post
                    {
                        User = this.Users[2],
                        Heading = "Who is the local distributor of ION 9000 in Scotland?",
                        Channel = this.Channels.FirstOrDefault(x => x.Name.Contains("ION9000")),
                        Rating = new Rating { Upvotes = 100, Downvotes = 20 }
                    },
                    new Post
                    {
                        User = this.Users[0],
                        Heading = "Resons to upgrade to ION8000?",
                        Channel = this.Channels.FirstOrDefault(x => x.Name.Contains("ION8")),
                        Rating = new Rating { Upvotes = 3456, Downvotes = 2100 }
                    },
                    new Post
                    {
                        User = this.Users[4],
                        Heading = "How to respond to Is PME right for me?",
                        Channel = this.Channels.FirstOrDefault(x => x.Name.Contains("PME")),
                        Rating = new Rating { Upvotes = 0, Downvotes = 1 }
                    },
                    new Post
                    {
                        User = this.Users[5],
                        Heading = "The Awesomeness of PSE (SCADA)",
                        Channel = this.Channels.FirstOrDefault(x => x.Name.Contains("SCADA")),
                        Rating = new Rating { Upvotes = 9, Downvotes = 10 }
                    },
                    new Post
                    {
                        User = this.Users[0],
                        Heading = "How does the ION 9000 stack up against the ION 8650?",
                        Channel = this.Channels.FirstOrDefault(x => x.Name.Contains("ION9000")),
                        Rating = new Rating { Upvotes = 130, Downvotes = 4 }
                    },
                };
            }

            //IList<Comment> GenerateRandomComments(Post parentPost, Comment parentComment, int maxNestedLevel, int currentLevel = 1)
            //{
            //    var rand = new Random((int)DateTime.UtcNow.Ticks);
            //    var numberOfComments = rand.Next(5);
            //    var comments = new List<Comment>(numberOfComments);

            //    for (int i = 0; i < numberOfComments; i++)
            //    {
            //        comments.Add(new Comment
            //        {
            //            Content = $"Comment {i}",
            //            ParentPost = parentPost,
            //            Parent = parentComment,
            //            Children = GenerateRandomComments(parentPost, )
            //        })
            //    }
            //}

        }
    }
}
