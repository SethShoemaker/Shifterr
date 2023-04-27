namespace mauiclient.Services.Auth
{
	public record LoginRequest
	(
		string UserName,
		string Password
	);
}

