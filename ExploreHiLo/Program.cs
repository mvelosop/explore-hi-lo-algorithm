using Microsoft.EntityFrameworkCore;
using System;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ExploreHiLo
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var connectionString = @"Data Source=(LocalDb)\MSSQLLocalDB; Database=ExploreHiLo; Integrated Security=true;";
            var options = new DbContextOptionsBuilder<AppDbContext>().UseSqlServer(connectionString).Options;

            using (var dbContext = new AppDbContext(options))
            {
                await dbContext.Database.MigrateAsync();

                var entity = new EntityModel
                {
                    Name = "Name #1",
                    Value = 10
                };

                Console.WriteLine($"entity.Id={entity.Id} (before AddAsync)");

                await dbContext.AddAsync(entity);

                Console.WriteLine($"entity.Id={entity.Id} (after AddAsync)");

                await dbContext.SaveChangesAsync();
            }
        }
    }
}
