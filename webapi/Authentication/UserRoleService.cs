using webapi.Models;

namespace webapi.Authentication
{
    public class UserRoleService
    {
        public OrganizationRole GetRoleFromString(string roleString){

            OrganizationRole roleEnum = OrganizationRole.Undefined;
            switch(roleString){

                case "crew":
                case "Crew":
                    roleEnum = OrganizationRole.Crew;
                break;


                case "manager":
                case "Manager":
                    roleEnum = OrganizationRole.Manager;
                break;

                case "administrator":
                case "Administrator":
                case "admin":
                case "Admin":
                    roleEnum = OrganizationRole.Administrator;
                break;
            }

            return roleEnum;
        }
    }
}