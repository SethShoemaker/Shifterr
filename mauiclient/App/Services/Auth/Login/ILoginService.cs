namespace mauiclient.Services.Auth
{
    public interface ILoginService
    {
        Task<LoginResponse> LoginAsync(LoginRequest request, CancellationToken cancellationToken);
    }
}