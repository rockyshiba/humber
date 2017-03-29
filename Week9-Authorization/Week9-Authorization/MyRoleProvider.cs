using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using Week9_Authorization.Models;

namespace Week9_Authorization
{
    public class MyRoleProvider : RoleProvider
    {
        public override string ApplicationName
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override void CreateRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            throw new NotImplementedException();
        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new NotImplementedException();
        }

        public override string[] GetAllRoles()
        {
            throw new NotImplementedException();
        }

        public override string[] GetRolesForUser(string username)
        {
            //throw new NotImplementedException(); //This method will be implemented so comment out the original return value
            SecretHQContext db = new SecretHQContext(); //We will need the check the database for user roles so make sure to provide using {projectname}.Models at the top of this class

            string roleResult = db.Users.Where(u => u.Username == username).FirstOrDefault().Role;
            //Remember that Role is a column in the table, therefore property of the row that is being pulled from the database. 
            //"Role" can be replaced with whatever name you named the column containing values that determine who can access what

            //When the application is checking for roles, it will be the value from the column and that value will be compared against the values you define in the controllers
            string[] results = { roleResult };
            return results;
            //results will contain string(s) that will be compared. In this case, if a user's role returns admin and the controller or its actions allow admin, then the action will complete its code. Otherwise it will go back to the controller/action defined in Web.Config.
        }

        public override string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool IsUserInRole(string username, string roleName)
        {
            throw new NotImplementedException();
        }

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override bool RoleExists(string roleName)
        {
            throw new NotImplementedException();
        }
    }
}