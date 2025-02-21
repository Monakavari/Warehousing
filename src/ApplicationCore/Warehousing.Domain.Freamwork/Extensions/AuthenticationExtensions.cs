using Microsoft.AspNetCore.Http;
using Warehousing.Domain.Entities;

namespace Warehousing.Domain.Freamwork.Extensions
{
    public static class AuthenticationExtensions
    {
        public static string GetUserId(this IHttpContextAccessor _httpContextAccessor)
        {
            if (_httpContextAccessor.HttpContext.Items["User"] is not null)
            {
                var user = _httpContextAccessor.HttpContext.Items["User"] as ApplicationUsers;
                if (user is not null)
                    return user.Id;
            }

            return "0";
        }

        //public static string GetUserName(this IHttpContextAccessor _httpContextAccessor)
        //{
        //    if (_httpContextAccessor.HttpContext.Items["User"] is not null)
        //    {
        //        var user = _httpContextAccessor.HttpContext.Items["User"] as ApplicationUsers;
        //        if (user is not null)
        //            return user.Email ?? user.Mobile;
        //    }

        //    return null;
        //}

        //public static string GetMobileNumber(this IHttpContextAccessor _httpContextAccessor)
        //{
        //    if (_httpContextAccessor.HttpContext.Items["User"] is not null)
        //    {
        //        var user = _httpContextAccessor.HttpContext.Items["User"] as ApplicationUsers;
        //        if (user is not null)
        //            return user.Mobile;
        //    }

        //    return null;
        //}

        public static List<int> GetRoleIds(this IHttpContextAccessor _httpContextAccessor)
        {
            List<int> roleList = new List<int>();

            if (_httpContextAccessor.HttpContext.Items["RoleId"] is not null)
            {
                var value = _httpContextAccessor.HttpContext.Items["RoleId"].ToString();
                if (!string.IsNullOrWhiteSpace(value))
                {
                    roleList = value.Split(',').Select(Int32.Parse).ToList();
                    return roleList;
                }
            }

            return roleList;
        }

        public static List<int> GetPermisionIds(this IHttpContextAccessor _httpContextAccessor)
        {
            List<int> permisionList = new List<int>();

            if (_httpContextAccessor.HttpContext.Items["PermissionId"] is not null)
            {
                var value = _httpContextAccessor.HttpContext.Items["PermissionId"].ToString();
                if (!string.IsNullOrWhiteSpace(value))
                {
                    permisionList = value.Split(',').Select(Int32.Parse).ToList();
                    return permisionList;
                }
            }

            return permisionList;
        }
    }
}
