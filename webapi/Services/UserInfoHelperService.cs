using System.Security.Claims;
using webapi.Data;
using webapi.Models;

namespace webapi.Services
{
    public class UserInfoHelperService
    {
        public ApplicationContext _context { get; }
        public UserInfoHelperService(ApplicationContext Context)
        {
            _context = Context;
        }

        public void GetUserOrgNameAndRole(
            User user, 
            out string userOrgName,
            out string userRole
        )
        {
            userOrgName = _context.Organizations.Where(o => o.Id == user.OrganizationId).First().Name;
            userRole = user.OrganizationRole.ToString();
        }

        public Organization GetUserOrg(ClaimsPrincipal User)
        {
            int UserOrgId = this.GetUserOrgId(User);
            return _context.Organizations.Where(o => o.Id == UserOrgId).First();
        }

        public int GetUserOrgId(ClaimsPrincipal User)
        {
            return Int32.Parse(User.Claims.First(c => c.Type == "UserOrgId").Value);
        }

        public int GetUserId (ClaimsPrincipal User)
        {
            string UserIdString = User.Claims.First(c => c.Type == ClaimTypes.NameIdentifier).Value;
            return Int32.Parse(UserIdString);
        }
    }
}