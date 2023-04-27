namespace mauiclient.Services.Auth
{
	public class LoginResponse
	{
		public LoginError? Error { get; set; }
    }

	public enum LoginError
	{
		UserNotFound,
		PasswordIncorrect,
		CouldNotConnectToServer,
		UserNotConfirmed
	}
}

