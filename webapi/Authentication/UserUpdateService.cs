using webapi.Data;
using webapi.Models;

namespace webapi.Authentication
{
    public class UserUpdateService
    {
        private readonly ApplicationContext _context;
        private readonly PasswordService _passwordService;
        private readonly UserRoleService _userRoleService;
        public UserUpdateService(
            ApplicationContext Context,
            PasswordService PasswordService,
            UserRoleService UserRoleService
        )
        {
            _context = Context;
            _passwordService = PasswordService;
            _userRoleService = UserRoleService;
        }

        public bool UpdateUserSaved(User User, string? Email, string? Password, string? Role){
            if(Email != null && Email != User.Email){
                User.Email = Email;
                User.EmailIsConfirmed = false;
            }

            if(Password != null){
                byte[] passwordHash = null!;
                byte[] passwordSalt = null!;
                this._passwordService.CreatePasswordHashAndSalt(Password, out passwordHash, out passwordSalt);
                User.PasswordHash = passwordHash;
                User.PasswordSalt = passwordSalt;
            }

            if(Role != null){
                OrganizationRole RoleEnum = this._userRoleService.GetRoleFromString(Role);
                if(RoleEnum == OrganizationRole.Administrator || RoleEnum == OrganizationRole.Undefined) return false;
                User.OrganizationRole = RoleEnum;
            }

            _context.SaveChanges();

            return true;
        }
    }
}