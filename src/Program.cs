using pr4.src;

namespace pr4
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Configuration.AddJsonFile("books.json");
            builder.Configuration.AddJsonFile("users.json");
            var app = builder.Build();

            app.Map("/Library", () => "Hello!");
            app.Map("/Library/Books", () => builder.Configuration.GetSection("Books").Get<List<Book>>());
            app.Map("/user/{id:int:range(1, 5)}", (int id) => builder.Configuration.GetSection("Users").Get<List<User>>()?.First(user => user.Id.Equals(id)));
            app.Map("/user", () => "Users Page");

            app.Run();
        }
    }
}