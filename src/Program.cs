using System;

namespace Minimal.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            var app = builder.Build();

            app.MapGet("/", (HttpContext context) =>
            {
                Console.WriteLine($"Request received at {context.Request.Path}");

                return new
                {
                    Name = "Alex",
                    EmployeeId = Guid.NewGuid(),
                    Salary = 10000,
                    Department = "IT",
                    DateOfJoining = DateTime.Now,
                    IsManager = false,
                    Address = new
                    {
                        Street = "123 Main St",
                        City = "Anytown",
                        State = "CA",
                        Zip = "12345"
                    },
                    TechnologyStack = new List<string> { "C#", "SQL", "Azure" },

                };
            }).WithName("EmployeeRecord");


            app.MapGet("/google", async (HttpContext context) => 
            {
                Console.WriteLine($"Request received at {context.Request.Path}");

                const string url = @"https://google.com";

                using HttpClient client = new();

                HttpResponseMessage response = await client.GetAsync(url);

                var success = response.EnsureSuccessStatusCode();

                Console.WriteLine(success);

                string html = await response.Content.ReadAsStringAsync();

                response.Dispose();

                return new
                {
                    html,
                    success.StatusCode,
                    
                };

            }).WithName("Google");


            

            app.Run();
        }
    }
}
