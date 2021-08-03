using System.ComponentModel.Design.Serialization;
using Movies.Domain.Entities;
using Movies.Domain.ValueObjects;
using Movies.Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;
using System.Linq;
using System.Threading.Tasks;

namespace Movies.Infrastructure.Persistence
{
    public static class ApplicationDbContextSeed
    {
        public static async Task SeedDefaultUserAsync(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            var administratorRole = new IdentityRole("Administrator");

            if (roleManager.Roles.All(r => r.Name != administratorRole.Name))
            {
                await roleManager.CreateAsync(administratorRole);
            }

            var administrator = new ApplicationUser { UserName = "administrator@localhost", Email = "administrator@localhost" };

            if (userManager.Users.All(u => u.UserName != administrator.UserName))
            {
                await userManager.CreateAsync(administrator, "Administrator1!");
                await userManager.AddToRolesAsync(administrator, new [] { administratorRole.Name });
            }
        }

        public static async Task SeedSampleDataAsync(ApplicationDbContext context)
        {
            // Seed, if necessary
            if (!context.TodoLists.Any())
            {
                context.TodoLists.Add(new TodoList
                {
                    Title = "Shopping",
                    Colour = Colour.Blue,
                    Items =
                    {
                        new TodoItem { Title = "Apples", Done = true },
                        new TodoItem { Title = "Milk", Done = true },
                        new TodoItem { Title = "Bread", Done = true },
                        new TodoItem { Title = "Toilet paper" },
                        new TodoItem { Title = "Pasta" },
                        new TodoItem { Title = "Tissues" },
                        new TodoItem { Title = "Tuna" },
                        new TodoItem { Title = "Water" }
                    }
                });

                await context.SaveChangesAsync();
            }

            if(!context.Movies.Any())
            {
                context.Movies.Add(new Movie
                {
                    Film = "Zack and Miri Make a Porno",
                    Genre = "Romance",
                    LeadStudio = "The Weinstein Company",
                    AudienceScore = 70,
                    Profitability = "1.747541667",
                    RottenTomatoes = 64,
                    WorldwideGross = "$41.94",
                    Year = 2008,
                    Comments =
                    {
                        new Comment { User = "George Guzman", TextComment = "This Film is Terrible"},
                        new Comment { User = "Mark Guzman", TextComment = "This Film is sad"}
                    }
                });

                context.Movies.Add(new Movie
                {
                    Film = "Zack and Miri Make a Porno",
                    Genre = "Romance",
                    LeadStudio = "The Weinstein Company",
                    AudienceScore = 70,
                    Profitability = "1.747541667",
                    RottenTomatoes = 64,
                    WorldwideGross = "$41.94",
                    Year = 2008,
                    Comments =
                    {
                        new Comment { User = "George Guzman", TextComment =  "This Film is Great"},
                        new Comment { User = "Mark Guzman", TextComment = "This Film is Good"}
                    }
                });

                context.Movies.Add(new Movie
                {
                    Film = "Youth in Revolt",
                    Genre = "Comedy",
                    LeadStudio = "The Weinstein Company",
                    AudienceScore = 52,
                    Profitability = "1.09",
                    RottenTomatoes = 68,
                    WorldwideGross = "$19.62",
                    Year = 2010,
                    Comments =
                    {
                        new Comment { User = "George Guzman", TextComment = "This Film is Great"},
                        new Comment { User = "Mark Guzman", TextComment = "This Film is Good"}
                    }
                });

                context.Movies.Add(new Movie
                {
                    Film = "You Will Meet a Tall Dark Stranger",
                    Genre = "Comedy",
                    LeadStudio = "Independent",
                    AudienceScore = 35,
                    Profitability = "1.211818182",
                    RottenTomatoes = 46,
                    WorldwideGross = "$26.66",
                    Year = 2010,
                    Comments =
                    {
                        new Comment { User = "George Guzman", TextComment =  "This Film is Great"},
                        new Comment { User = "Mark Guzman", TextComment = "This Film is Good"}
                    }
                });

                await context.SaveChangesAsync();
            }
        }
    }
}
