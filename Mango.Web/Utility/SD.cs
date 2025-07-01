namespace Mango.Web.Utility
{
    public class SD
    {
        public const string RoleAdmin = "ROLE_ADMIN";
        public const string RoleCustomer = "ROLE_CUSTOMER";

        public enum ApiType
        {
            GET,
            POST,
            PUT,
            DELETE
        }

        public static string AuthBaseAddress { get; set; }
    }
}
