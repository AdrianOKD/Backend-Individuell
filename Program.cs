using Microsoft.EntityFrameworkCore;

namespace ovningD29;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddDbContext<AppDbContext>(options =>
            options.UseNpgsql(
                "Host=localhost;Port=5432;Database=minireddit;Username=postgres;Password=password"
            )
        );

        builder.Services.AddControllers();

        var app = builder.Build();

        app.MapControllers();

        app.Run();
    }
}
//Lägg till environment variabel för localHost Strängen.
