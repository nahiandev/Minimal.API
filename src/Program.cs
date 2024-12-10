namespace Minimal.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            var app = builder.Build();

            app.MapGet("/", () =>
            {
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
                    PreviousTechStack = new string[] { "C#", "SQL", "Azure" },

                };
            }).WithName("EmployeeRecord");

            app.Run();
        }
    }
}
