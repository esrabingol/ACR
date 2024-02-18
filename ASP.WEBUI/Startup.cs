
using ACR.Business.Abstract;
using ACR.Business.Concrete;
using ACR.DataAccess.Abstract;
using ACR.DataAccess.Concrete.EntityFramework;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace ASP.WEBUI
{
	public class Startup
	{
		public void ConfigureServices(IServiceCollection services)
		{
			//services.AddScoped<IRegisterDal, EfRegisterDal>();
			//services.AddScoped<IRegisterService, RegisterManager>();

			// Servis konfigürasyonları burada yapılır.
			services.AddControllersWithViews();
			// Diğer servis eklemeleri yapılabilir.
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

			app.UseHttpsRedirection();
			app.UseStaticFiles();

			app.UseRouting();
			app.UseAuthorization();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllerRoute(
					name: "default",
					pattern: "{controller=Operator}/{action=Index}");
			});
		}
	}
}

