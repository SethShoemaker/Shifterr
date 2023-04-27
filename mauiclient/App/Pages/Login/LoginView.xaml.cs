using mauiclient.Services.Auth;

namespace mauiclient.Pages.Login;

public partial class LoginView : ContentPage
{
    private readonly LoginViewModel _vm;

    public LoginView(LoginViewModel vm)
	{
		InitializeComponent();

        _vm = vm;
        BindingContext = _vm;
    }
}