using ContatoMVC.Repository;
using ContatoMVC.Repository.Interface;
using ContatoMVC.Data;
using Microsoft.EntityFrameworkCore;
using ContatoMVC.Services.Interfaces;
using ContatoMVC.Services;

namespace ContatoMVC
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            builder.Services.AddSession(options =>
            {
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
                
            });

            builder.Services.AddScoped<IContatoRepository, ContatoRepository>();
            builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            builder.Services.AddScoped<ISessaoService, SessaoService>();
            builder.Services.AddScoped<IEmailService, EmailService>();

            builder.Services.AddDbContext<ContatoContext>(
                option => option.UseSqlServer(builder.Configuration.GetConnectionString("Database"),
                assembly => assembly.MigrationsAssembly(typeof(ContatoContext).Assembly.FullName)
                ));

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseSession();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Login}/{action=Index}/{id?}");

            app.Run();
        }
    }
}