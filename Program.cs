namespace BymmashTZ
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            
            builder.Services.AddControllers();  // добавляем поддержку контроллеров
            builder.Services.AddControllersWithViews();// и представления

            var app = builder.Build();
           
            app.UseStaticFiles(); // добавляем поддержку статических файлов

            // устанавливаем сопоставление маршрутов с контроллерами
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}");

            

            app.Run();
            
        }
    }
}