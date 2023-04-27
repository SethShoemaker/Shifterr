namespace mauiclient.Services.StorageService
{
    public interface IStorageService
    {
        Task<string> GetTokenAsync();

        Task<bool> HasTokenAsync();

        Task StoreTokenAsync(string token);

        Task DeleteTokenAsync();




        Task<string> GetOrganizationNameAsync();

        Task<bool> HasOrganizationNameAsync();

        Task StoreOrganizationNameAsync(string name);

        Task DeleteOrganizationNameAsync();




        Task<string> GetOrganizationRoleAsync();

        Task<bool> HasOrganizationRoleAsync();

        Task StoreOrganizationRoleAsync(string role);

        Task DeleteOrganizationRoleAsync();




        Task<string> GetUserNameAsync();

        Task<bool> HasUserNameAsync();

        Task StoreUserNameAsync(string username);

        Task DeleteUserNameAsync();




        Task<string> GetNicknameAsync();

        Task<bool> HasNicknameAsync();

        Task StoreNicknameAsync(string nickname);

        Task DeleteNicknameAsync();
    }
}