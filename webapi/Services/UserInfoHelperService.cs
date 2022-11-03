using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
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
        public Organization GetUserOrg(ClaimsPrincipal user)
        {
            string orgIdString = user.Claims.First(c => c.Type == "UserOrgId").Value;
            int orgIdInt = Int32.Parse(orgIdString);
            return _context.Organizations.First(c => c.Id == orgIdInt);
        }
    }
}