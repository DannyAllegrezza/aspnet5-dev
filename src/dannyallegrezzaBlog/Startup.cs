using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Hosting;
using Microsoft.Data.Entity;
using Microsoft.Extensions.DependencyInjection;

namespace dannyallegrezzaBlog
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            // Use AddTransient to create brand new instance of the BlogDataContext everytime a component requests one.
            // Use AddSingleton to create 1 instance for the lifetime of the app
            // Use AddScoped so that we create one instance for every web request. Cleans up once the request is over.
            services.AddScoped<dannyallegrezzaBlog.Models.BlogDataContext>();
            services.AddScoped<dannyallegrezzaBlog.Models.Identity.ApplicationUser>();
            services.AddTransient<dannyallegrezzaBlog.Models.FormattingService>();

            string identityConnectionString =
                "Server=(LocalDb)\\MSSQLLocalDb;Database=AspNetBlog_Identity";

            // Defines the connection string for the datacontext
            services.AddEntityFramework().
                    AddSqlServer().
                    AddDbContext<Models.Identity.IdentityDataContext>(dbConfig =>
                    dbConfig.UseSqlServer(identityConnectionString));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app)
        {

            /*
            var config = new Configuration();
            // Environment Variables 
            config.AddEnvironmentVariables();
            config.AddIniFile("config.ini");

            if (config.Get("debug") == "True")
            {
                // Debug Error/Exception Handling Diagnostics
                app.UseDeveloperExceptionPage(); // Shows the Developer Error Page - really helpful
                app.UseRuntimeInfoPage(); // Accessed via "/RunTimeInfo" ex: "http://localhost:50079/RunTimeInfo". Shows all packages installed, assembly version, etc.
            }         

            // Production Debug/Error Handling Diagnostics
            app.UseExceptionHandler("/Home/Error"); // Custom error handler. Go to /Home Controller and "Error" action. 
            */


            //var context = app.ApplicationServices.GetService<Models.BlogDataContext>();
            //context.Database.EnsureDeleted();
            //System.Threading.Thread.Sleep(2000);
            //context.Database.EnsureCreated();

            app.UseIdentity(); // Registers the Identity Service middleware so 
            app.UseDeveloperExceptionPage(); // Shows the Developer Error Page - really helpful
            app.UseRuntimeInfoPage(); // Accessed via "/RunTimeInfo" ex: "http://localhost:50079/RunTimeInfo". Shows all packages installed, assembly version, etc.

            // Call to use the MVC middleware app - and defines the default routes ex: admin/user/1 -> Admin controller, User action, id of 1
            app.UseMvc(routes => 
                routes.MapRoute("Default",
                    "{controller=Home}/{action=Index}/{id?}"));

            app.UseFileServer();

        }

        // Entry point for the application.
        public static void Main(string[] args) => WebApplication.Run<Startup>(args);
    }
}
