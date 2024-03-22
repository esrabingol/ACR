﻿using ACR.Business.Abstract;
using ACR.Business.Concrete;
using ACR.DataAccess.Abstract;
using ACR.DataAccess.Concrete;
using ACR.DataAccess.Concrete.EntityFramework;
using ACR.Entity.Concrete;
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

			services.AddIdentity<User, Role>(options =>
			{
				options.Password.RequireDigit = false;
				options.Password.RequiredLength = 6;
				options.Password.RequireUppercase = false;
				options.Password.RequireLowercase = false;
				options.Password.RequireNonAlphanumeric = false;


				options.User.RequireUniqueEmail = true;

			})
				.AddEntityFrameworkStores<ACRContext>();

			services.AddSession();
			services.AddDistributedMemoryCache();
			services.AddScoped<IMachineDal, EfMachineDal>();
			services.AddScoped<IMachineService, MachineManager>();

			services.AddScoped<IRegisterDal, EfRegisterDal>();
			services.AddScoped<IRegisterService, RegisterManager>();

			services.AddScoped<IReservationDal, EfReservationDal>();
			services.AddScoped<IReservationService, ReservationManager>();

			services.AddScoped<IRoleDal, EfRoleDal>();
			services.AddScoped<IRoleService, RoleManager>();

			//services.ConfigureApplicationCookie(options =>
			//{
			//	options.LoginPath = new PathString("/User/UserLogin");

			//	options.AccessDeniedPath = new PathString("/AccessDenied");

			//	options.Cookie = new CookieBuilder
			//	{
			//		Name = "AspNetIdentity",
			//		HttpOnly = false,
			//		SecurePolicy = CookieSecurePolicy.SameAsRequest,
			//		SameSite = SameSiteMode.Lax

			//	};
			//	options.SlidingExpiration = true;

			//	options.ExpireTimeSpan = TimeSpan.FromMinutes(20);
			//});

			services.AddControllersWithViews();
			services.AddRazorPages();

			services.AddDistributedMemoryCache(); // Choose your distributed cache provider in a production environment
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
			app.UseSession();
			app.UseStaticFiles();
			app.UseRouting();
			app.UseAuthentication();
			app.UseAuthorization();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllerRoute(
					name: "default",
					pattern: "{controller=Home}/{action=Index}");

			});

			app.UseHttpsRedirection();

		}
	}
}

