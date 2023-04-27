using System.Net.Http.Json;
using mauiclient.Services.StorageService;

namespace mauiclient.Services.Auth
{
    public class LoginService : ILoginService
    {
        private readonly HttpClient _http;
        private readonly IStorageService _storage;

        public LoginService(HttpClient http, IStorageService storage)
        {
            _http = http;
            _storage = storage;
        }

        public async Task<LoginResponse> LoginAsync(LoginRequest request, CancellationToken cancellationToken)
        {
            LoginResponse r = new();

            HttpResponseMessage httpResponse = default;
            try
            {

                httpResponse = await _http.PostAsJsonAsync<LoginRequest>(App.RestApiUrl + "user/login", request);
            }
            catch (HttpRequestException e)
            {
                r.Error = LoginError.CouldNotConnectToServer;
                return r;
            }

            if (!httpResponse.IsSuccessStatusCode){
                
                LoginErrorResponse response = await httpResponse.Content.ReadFromJsonAsync<LoginErrorResponse>(cancellationToken: cancellationToken);
                r.Error = response.ResponseText switch
                {
                    "User Not Found" => LoginError.UserNotFound,
                    "Bad Credentials" => LoginError.PasswordIncorrect,
                    "User Not Confirmed" => LoginError.UserNotConfirmed,
                    _ => LoginError.CouldNotConnectToServer
                };

                return r;
            }

            await StoreLoginDetailsAsync(await httpResponse.Content.ReadFromJsonAsync<LoginDetails>(cancellationToken: cancellationToken));

            return r;
        }

        private async Task StoreLoginDetailsAsync(LoginDetails loginDetails)
        {
            await _storage.StoreTokenAsync(loginDetails.Token);
            await _storage.StoreOrganizationNameAsync(loginDetails.OrganizationName);
            await _storage.StoreOrganizationRoleAsync(loginDetails.OrganizationRole);
            await _storage.StoreUserNameAsync(loginDetails.UserName);
            await _storage.StoreNicknameAsync(loginDetails.Nickname);
        }
    }

    public record LoginErrorResponse(string ResponseText);

    public record LoginDetails(
        string Token,
        string OrganizationName,
        string OrganizationRole,
        string UserName,
        string Nickname
    );
}