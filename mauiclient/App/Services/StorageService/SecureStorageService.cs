using static Microsoft.Maui.Storage.SecureStorage;

namespace mauiclient.Services.StorageService
{
    public class SecureStorageService : IStorageService
    {
        private string TokenLocation = "SHIFTERR_AUTH_TOKEN";

        public Task<string> GetTokenAsync() => Default.GetAsync(TokenLocation);

        public async Task<bool> HasTokenAsync() => await Default.GetAsync(TokenLocation) != null;

        public Task StoreTokenAsync(string token) => Default.SetAsync(TokenLocation, token);

        public Task DeleteTokenAsync()
        {
            Default.Remove(TokenLocation);
            return Task.CompletedTask;
        }



        private string OrganizationNameLocation = "SHIFTERR_ORGANIZATION_NAME";

        public Task<string> GetOrganizationNameAsync() => Default.GetAsync(OrganizationNameLocation);

        public async Task<bool> HasOrganizationNameAsync() => await Default.GetAsync(OrganizationNameLocation) != null;

        public Task StoreOrganizationNameAsync(string name) => Default.SetAsync(OrganizationNameLocation, name);

        public Task DeleteOrganizationNameAsync()
        {
            Default.Remove(OrganizationNameLocation);
            return Task.CompletedTask;
        }



        private string OrganizationRoleLocation = "SHIFTERR_ORGANIZATION_ROLE";

        public Task<string> GetOrganizationRoleAsync() => Default.GetAsync(OrganizationRoleLocation);

        public async Task<bool> HasOrganizationRoleAsync() => await Default.GetAsync(OrganizationRoleLocation) != null;

        public Task StoreOrganizationRoleAsync(string role) => Default.SetAsync(OrganizationRoleLocation, role);

        public Task DeleteOrganizationRoleAsync()
        {
            Default.Remove(OrganizationRoleLocation);
            return Task.CompletedTask;
        }



        private string UserNameLocation = "SHIFTERR_USERNAME";

        public Task<string> GetUserNameAsync() => Default.GetAsync(UserNameLocation);

        public async Task<bool> HasUserNameAsync() => await Default.GetAsync(UserNameLocation) != null;

        public Task StoreUserNameAsync(string username) => Default.SetAsync(UserNameLocation, username);

        public Task DeleteUserNameAsync()
        {
            Default.Remove(UserNameLocation);
            return Task.CompletedTask;
        }



        private string NicknameLocation = "SHIFTERR_NICKNAME";

        public Task<string> GetNicknameAsync() => Default.GetAsync(NicknameLocation);

        public async Task<bool> HasNicknameAsync() => await Default.GetAsync(NicknameLocation) != null;

        public Task StoreNicknameAsync(string nickname) => Default.SetAsync(NicknameLocation, nickname);

        public Task DeleteNicknameAsync()
        {
            Default.Remove(NicknameLocation);
            return Task.CompletedTask;
        }
    }
}