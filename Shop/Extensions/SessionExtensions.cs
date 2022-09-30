namespace Shop.Extensions
{
    public static class SessionExtensions
    {
        public static readonly string UserNameKey = "userName";
        public static readonly string UserIdKey = "user";
        public static readonly string UserAdminKey = "admin";
        public static bool IsUserAdmin(this ISession session) => session.GetString(UserAdminKey) == true.ToString();
        public static bool IsUserLogined(this ISession session) => session.TryGetValue(UserIdKey, out _);
        public static string? GetUserName(this ISession session) => session.GetString(UserNameKey);
    }
}
