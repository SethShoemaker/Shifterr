using System;
namespace mauiclient.Services.StorageService
{
	public class InMemoryStorageService : IStorageService
	{
        private string Token { get; set; }

        public Task<string> GetTokenAsync() => Task.FromResult(Token);

        public Task<bool> HasTokenAsync() => Task.FromResult(Token != null);

        public Task StoreTokenAsync(string token)
        {
            Token = token;
            return Task.CompletedTask;
        }

        public Task DeleteTokenAsync()
        {
            Token = null;
            return Task.CompletedTask;
        }



        private string OrganizationName { get; set; }

        public Task<string> GetOrganizationNameAsync() => Task.FromResult(OrganizationName);

        public Task<bool> HasOrganizationNameAsync() => Task.FromResult(OrganizationName != null);

        public Task StoreOrganizationNameAsync(string name)
        {
            OrganizationName = name;
            return Task.CompletedTask;
        }

        public Task DeleteOrganizationNameAsync()
        {
            OrganizationName = null;
            return Task.CompletedTask;
        }



        private string OrganizationRole { get; set; }

        public Task<string> GetOrganizationRoleAsync() => Task.FromResult(OrganizationRole);

        public Task<bool> HasOrganizationRoleAsync() => Task.FromResult(OrganizationRole != null);

        public Task StoreOrganizationRoleAsync(string role)
        {
            OrganizationRole = role;
            return Task.CompletedTask;
        }

        public Task DeleteOrganizationRoleAsync()
        {
            OrganizationRole = null;
            return Task.CompletedTask;
        }



        private string UserName { get; set; }

        public Task<string> GetUserNameAsync() => Task.FromResult(UserName);

        public Task<bool> HasUserNameAsync() => Task.FromResult(UserName != null);

        public Task StoreUserNameAsync(string username)
        {
            UserName = username;
            return Task.CompletedTask;
        }

        public Task DeleteUserNameAsync()
        {
            UserName = null;
            return Task.CompletedTask;
        }



        private string Nickname { get; set; }

        public Task<string> GetNicknameAsync() => Task.FromResult(Nickname);

        public Task<bool> HasNicknameAsync() => Task.FromResult(Nickname != null);

        public Task StoreNicknameAsync(string nickname)
        {
            Nickname = nickname;
            return Task.CompletedTask;
        }

        public Task DeleteNicknameAsync()
        {
            Nickname = null;
            return Task.CompletedTask;
        }
    }
}

