using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using mauiclient.Pages.Dashboard;
using mauiclient.Services.Auth;

namespace mauiclient.Pages.Login
{
	public partial class LoginViewModel : ObservableObject
	{
        private readonly ILoginService _loginService;
        private readonly DashboardView _dashboard;

        public LoginViewModel(ILoginService loginService, DashboardView dashboard)
		{
            _loginService = loginService;
            _dashboard = dashboard;
        }

        [ObservableProperty]
        string generalFeedback;

        [ObservableProperty]
        string username;

        [ObservableProperty]
        string usernameFeedback;

        [ObservableProperty]
        string password;

        [ObservableProperty]
        string passwordFeedback;

        [RelayCommand]
        async Task SubmitFormAsync()
        {
            LoginRequest request = new(Username, Password);
            LoginResponse response = await _loginService.LoginAsync(request, default);

            switch (response.Error)
            {
                case LoginError.UserNotFound:
                    Username = "";
                    Password = "";
                    UsernameFeedback = "user not found";
                    break;
                case LoginError.PasswordIncorrect:
                    Password = "";
                    UsernameFeedback = "password incorrect";
                    break;
                case LoginError.UserNotConfirmed:
                    Password = "";
                    UsernameFeedback = "user not confirmed";
                    break;
                case LoginError.CouldNotConnectToServer:
                    GeneralFeedback = "could not connect to server";
                    break;
                case null:
                    App.Current.MainPage = _dashboard;
                    break;
            }
        }
    }
}

