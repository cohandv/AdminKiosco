using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.DynamicData;
using AdminKiosco.Entities;
using Microsoft.AspNet.Membership.OpenAuth;

namespace AdminKiosco.Web
{
    public static class AuthorizationConfig
    {
        private static List<aspnet_Roles> _roles;

        private static List<RoleAction> _actions;

        private static Guid _adminRoleId;

        public static void Register()
        {
            PaperEntities entities = new PaperEntities();
            _roles = entities.aspnet_Roles.ToList();
            _actions = entities.RoleAction.ToList();
            _adminRoleId = _roles.Where(r => r.LoweredRoleName.Contains("admin")).FirstOrDefault().RoleId;
        }

        public static bool Authorize(string table, string action, List<Guid> roles)
        {
            //Validate if the user have admin role
            if (roles.Where(r => r.Equals(_adminRoleId)).Count() > 0)
            {
                return true;
            }
            
            TablePermission permission = TablePermission.None;
            Enum.TryParse<TablePermission>(action, out permission);
            bool CanDelete = false, CanEdit = false, CanInsert = false;

            switch (permission)
            {
                case TablePermission.Delete:
                    CanDelete = true;
                    break;
                case TablePermission.Edit:
                    CanEdit = true;
                    break;
                case TablePermission.Insert:
                    CanInsert = true;
                    break;
            }

            foreach (Guid rol in roles)
            {
                List<RoleAction> permissionsOnTable = _actions.Where(a => a.Table.ToLowerInvariant().Equals(table.ToLowerInvariant()) &&
                                                                          a.Delete.Equals(CanDelete) &&
                                                                          a.Edit.Equals(CanEdit) &&
                                                                          a.Insert.Equals(CanInsert) &&
                                                                          a.RoleId.Equals(rol)).ToList();

            }

            return false;
        }

        public static string GetRoles(string userName)
        {
            PaperEntities entities = new PaperEntities();
            var User = entities.aspnet_Users.Where( u => u.UserName.Equals(userName)).FirstOrDefault();
            string roles = string.Empty;
            foreach (var roleId in User.aspnet_Roles.Select(r => r.RoleId).ToList())
            {
                roles += roleId + "|";
            }
            return roles;
        }
    }

    public enum TablePermission
    {
        Edit,
        Insert,
        Delete,
        None
    }
}