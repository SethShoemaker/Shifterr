using mauiclient.Pages.Login;
using mauiclient.Pages.Dashboard.Shifts;
using mauiclient.Pages.Dashboard.Calendar;
using mauiclient.Pages.Dashboard;
using mauiclient.Services.Auth;
using mauiclient.Services.StorageService;
using mauiclient.Services.Auth.Logout;
using mauiclient.Services.Dashboard.Shifts.GetShifts;

namespace mauiclient
{
	public static class ServiceConfiguration
	{
		public static void ConfigureServices(this IServiceCollection services)
		{
                        //Pages
                        services.AddSingleton<LoginView>();
                        services.AddSingleton<LoginViewModel>();

                        services.AddSingleton<DashboardView>();

                        services.AddSingleton<ShiftsViewModel>();
                        services.AddSingleton<ShiftsView>();

                        services.AddSingleton<CalendarViewModel>();
                        services.AddSingleton<CalendarView>();

                        //Services
                        services.AddSingleton<HttpClient>();

                        services.AddSingleton<ILoginService, LoginService>();
                        services.AddSingleton<ILogoutService, LogoutService>();
                        services.AddSingleton<IStorageService, InMemoryStorageService>();
                        services.AddSingleton<IGetShiftsService, GetShiftsService>();
        }
	}
}