using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Domain;
using Microsoft.AspNetCore.Identity;

namespace API.Persistence
{
    public class Seed
    {
        public static async Task SeedData(DataContext context, UserManager<AppUser> userManager)
        {
            if(!userManager.Users.Any())
            {
                var users = new List<AppUser>
                {
                    new AppUser
                    {
                        DisplayName = "mahbub",
                        UserName = "mahbb",
                        Email = "mahbub@gmail.com",
                    },

                    new AppUser
                    {
                        DisplayName = "tonni",
                        UserName = "tonni",
                        Email = "tonni@gmail.com",
                    },
                    new AppUser
                    {
                        DisplayName = "tonmoy",
                        UserName = "tonmoy",
                        Email = "tonmoy@gmail.com",
                    }
                };

                foreach (var i in users)
                {
                    await userManager.CreateAsync(i, "M1m@mmmm");
                }
            }

            if(!context.Activities.Any())
            {
                var activities = new List<Activity>
                {
                    new Activity
                    {
                        Title = "Past",
                        Date = DateTime.Now.AddMonths(-2),
                        Description = "Activity 2 month ago",
                        Category = "drinks",
                        City = "London",
                        Venue = "Pub",
                    },
                     new Activity
                    {
                        Title = "Past",
                        Date = DateTime.Now.AddMonths(-6),
                        Description = "Activity 6 month ago",
                        Category = "drinks",
                        City = "London",
                        Venue = "Pub",
                    },
                     new Activity
                    {
                        Title = "future",
                        Date = DateTime.Now.AddMonths(2),
                        Description = "Activity 2 month in future",
                        Category = "drinks",
                        City = "London",
                        Venue = "Pub",
                    },
                     new Activity
                    {
                        Title = "Future",
                        Date = DateTime.Now.AddMonths(8),
                        Description = "Activity 8 month in future",
                        Category = "drinks",
                        City = "London",
                        Venue = "gulshan",
                    }
                };

                context.Activities.AddRange(activities);
                context.SaveChanges();
            }
        }
        
    }
}