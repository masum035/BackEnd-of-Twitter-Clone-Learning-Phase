

namespace TweeterBackend.Contracts.v1
{
    public static class ApiRoutes
    {
        public const string RootUrl = "api";
        public const string VersionUrl = "v1";
        public const string Base = RootUrl + "/" + VersionUrl;

        public static class Posts
        {
            public const string GetAll = Base + "/post";

        }

    }
}
