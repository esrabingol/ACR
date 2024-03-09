using ACR.Business.Abstract;
using ACR.Business.Concrete;
using ACR.DataAccess.Abstract;
using ACR.DataAccess.Concrete;
using ACR.DataAccess.Concrete.EntityFramework;
using Microsoft.EntityFrameworkCore;

namespace ASP.WEBUI
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public void ConfigureServices(IServiceCollection services)
        {
            var st = Configuration.GetConnectionString("Default");
            services.AddDbContext<ACRContext>(opts => opts.UseSqlServer(Configuration.GetConnectionString("Default"),
                option => { option.MigrationsAssembly("ACR.DataAccess"); }));

            services.AddScoped<IMachineDal, EfMachineDal>();
            services.AddScoped<IMachineService, MachineManager>();

            services.AddScoped<IRegisterDal, EfRegisterDal>();
            services.AddScoped<IRegisterService, RegisterManager>();

            services.AddScoped<IReservationDal, EfReservationDal>();
            services.AddScoped<IReservationService, ReservationManager>();

            services.AddScoped<IRoleDal, EfRoleDal>();
            services.AddScoped<IRoleService, RoleManager>();


            services.AddControllersWithViews();
            services.AddRazorPages();

			services.AddDistributedMemoryCache(); // Choose your distributed cache provider in a production environment
			//services.AddSession(options =>
			//{
			//	options.IdleTimeout = TimeSpan.FromMinutes(120); // Set session timeout as needed
			//	options.Cookie.HttpOnly = true;
			//	options.Cookie.IsEssential = true;
			//});
		}
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }
			//app.UseSession();
			app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=User}/{action=UserLogin}");

            });

		
		}
    }
}

