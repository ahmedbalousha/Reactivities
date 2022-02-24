using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;

namespace Persistence
{
    public class Seed
    {
        public static async Task SeedData(DataContext context)
        {
            
            if (!context.Activities.Any())
            {
                var activities = new List<Activity>
                {
                    new Activity
                    {
                        Titel = "Past Activity 1",
                        Date = DateTime.Now.AddMonths(-2),
                        Discription = "Activity 2 months ago",
                        Category = "Drinks",
                        City = "London",
                        Venue = "Pub",
                    },
                    new Activity
                    {
                        Titel = "Past Activity 2",
                        Date = DateTime.Now.AddMonths(-1),
                        Discription = "Activity 1 month ago",
                        Category = "Culture",
                        City = "Paris",
                        Venue = "The Louvre",
                        
                    },
                    new Activity
                    {
                        Titel = "Future Activity 1",
                        Date = DateTime.Now.AddMonths(1),
                        Discription = "Activity 1 month in future",
                        Category = "Music",
                        City = "London",
                        Venue = "Wembly Stadium",
                    },
                        
                    new Activity
                    {
                        Titel = "Future Activity 2",
                        Date = DateTime.Now.AddMonths(2),
                        Discription = "Activity 2 months in future",
                        Category = "Food",
                        City = "London",
                        Venue = "Jamies Italian",
                        
                    },
                    new Activity
                    {
                        Titel = "Future Activity 3",
                        Date = DateTime.Now.AddMonths(3),
                        Discription = "Activity 3 months in future",
                        Category = "Drinks",
                        City = "London",
                        Venue = "Pub",
                       
                    },
                    new Activity
                    {
                        Titel = "Future Activity 4",
                        Date = DateTime.Now.AddMonths(4),
                        Discription = "Activity 4 months in future",
                        Category = "Culture",
                        City = "London",
                        Venue = "British Museum",
                        
                    },
                    new Activity
                    {
                        Titel = "Future Activity 5",
                        Date = DateTime.Now.AddMonths(5),
                        Discription = "Activity 5 months in future",
                        Category = "Drinks",
                        City = "London",
                        Venue = "Punch and Judy",
                        
                    },
                    new Activity
                    {
                        Titel = "Future Activity 6",
                        Date = DateTime.Now.AddMonths(6),
                        Discription = "Activity 6 months in future",
                        Category = "Music",
                        City = "London",
                        Venue = "O2 Arena",
                        
                    },
                    new Activity
                    {
                        Titel = "Future Activity 7",
                        Date = DateTime.Now.AddMonths(7),
                        Discription = "Activity 7 months in future",
                        Category = "Travel",
                        City = "Berlin",
                        Venue = "All",
                    },
                    new Activity
                    {
                        Titel = "Future Activity 8",
                        Date = DateTime.Now.AddMonths(8),
                        Discription = "Activity 8 months in future",
                        Category = "Drinks",
                        City = "London",
                        Venue = "Pub",
                        
                    }
                };

                await context.Activities.AddRangeAsync(activities);
                await context.SaveChangesAsync();
            }
        }
    }
}