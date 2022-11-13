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

        public Organization GetUserOrg(ClaimsPrincipal User)
        {
            string OrgIdString = User.Claims.First(c => c.Type == "UserOrgId").Value;
            int OrgIdInt = Int32.Parse(OrgIdString);
            return _context.Organizations.First(c => c.Id == OrgIdInt);
        }

        public string GetUserOrgNameFromModel(User user)
        {
            Organization userOrg = _context.Organizations.Where(o => o.Id == user.OrganizationId).First();
            return userOrg.Name;
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