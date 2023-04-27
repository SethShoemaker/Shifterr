using mauiclient.Pages.Dashboard;
using mauiclient.Pages.Login;

namespace mauiclient;

public partial class App : Application
{
    public LoginView Login { get; }

    public DashboardView DashboardView { get; }

    public App(IServiceProvider serviceProvider)
    {
        InitializeComponent();

        // when the app constructor is the first place for views to be instantiated, views are able to use global resource dictionary
        Login = serviceProvider.GetService<LoginView>();
        DashboardView = serviceProvider.GetService<DashboardView>();

        MainPage = Login;
    }

    public const string RestApiUrl = "http://localhost:5137/api/";
}