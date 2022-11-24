using webapi.Data;
using webapi.Models;

namespace webapi.Authentication
{
    public class UserUpdateService
    {
        public ApplicationContext _context { get; set; }
        public PasswordService _passwordService { get; set; }

        public UserUpdateService(
            ApplicationContext context,
            PasswordService passwordService
        )
        {
            _context = context;
            _passwordService = passwordService;
        }

        public void UpdateUserSaved(User user, string? email, string? password, string? role){
            if(email != null && email != user.Email){
                user.Email = email;
                user.EmailIsConfirmed = false;
            }

            if(password != null){
                byte[] passwordHash = null!;
                byte[] passwordSalt = null!;
                this._passwordService.CreatePasswordHashAndSalt(password, out passwordHash, out passwordSalt);
                user.PasswordHash = passwordHash;
                user.PasswordSalt = passwordSalt;
            }

            if(role != null){
                switch(role){

                    case "crew":
                    case "Crew":
                    user.OrganizationRole = OrganizationRole.Crew;
                    break;

                    case "manager":
                    case "Manager":
                    user.OrganizationRole = OrganizationRole.Manager;
                    break;
                }
            }

            _context.SaveChanges();

            return;
        }
    }
}