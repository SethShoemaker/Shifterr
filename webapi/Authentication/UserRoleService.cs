using webapi.Models;

namespace webapi.Authentication
{
    public class UserRoleService
    {
        public OrganizationRole GetRoleFromString(string RoleString){

            OrganizationRole RoleEnum = OrganizationRole.Undefined;
            switch(RoleString){

                case "crew":
                case "Crew":
                    RoleEnum = OrganizationRole.Crew;
                break;


                case "manager":
                case "Manager":
                    RoleEnum = OrganizationRole.Manager;
                break;

                case "administrator":
                case "Administrator":
                case "admin":
                case "Admin":
                    RoleEnum = OrganizationRole.Administrator;
                break;
            }

            return RoleEnum;
        }
    }
}