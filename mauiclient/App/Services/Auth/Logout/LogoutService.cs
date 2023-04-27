using mauiclient.Services.StorageService;

namespace mauiclient.Services.Auth.Logout
{
    public class LogoutService : ILogoutService
    {
        private readonly IStorageService _storage;

        public LogoutService(IStorageService storage)
        {
            _storage = storage;
        }

        public async Task LogoutAsync()
        {
            await _storage.DeleteTokenAsync();
            await _storage.DeleteOrganizationNameAsync();
            await _storage.DeleteOrganizationRoleAsync();
            await _storage.DeleteUserNameAsync();
            await _storage.DeleteNicknameAsync();
        }
    }
}