using System.Security.Claims;

namespace InventoryService.Application.Services.Data.Helper
{
    public static class CurrentUserExtension
    {
        public static Guid Id(this ClaimsPrincipal principal)
        {
            var value = principal.FindFirst("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier");
            return value == null ? Guid.Empty : Guid.Parse(principal.FindFirst("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier").Value);
        }

        public static string Email(this ClaimsPrincipal principal)
        {
            var value = principal.FindFirst("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress");
            return value!=null ? string.Empty : principal.FindFirst("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress").Value;
        }

        public static string GivenName(this ClaimsPrincipal principal)
        {
            var value = principal.FindFirst("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/givenname");
            return value!=null ? string.Empty : principal.FindFirst("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/givenname").Value;
        }

        public static string Surname(this ClaimsPrincipal principal)
        {
            var value = principal.FindFirst("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/surname");
            return value!=null ? string.Empty : principal.FindFirst("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/surname").Value;
        }

        public static string FullName(this ClaimsPrincipal principal)
        {
            string result = string.Empty;
            var text = principal.FindFirst("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/givenname").Value;
            var text2 = principal.FindFirst("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/surname").Value;
            if (text != null && text2 != null)
            {
                result = text + " " + text2;
            }

            return result;
        }
    }
}