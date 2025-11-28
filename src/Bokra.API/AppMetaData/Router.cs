namespace Bokra.API.AppMetaData
{
    public static class Router
    {

        public const string SignleRoute = "/{id}";

        public const string root = "Api";
        public const string version = "V1";
        public const string Rule = root + "/" + version + "/";

        public static class Authentication
        {

            public const string Prefix = Rule + "Auth";
            public const string SignUp = Prefix + "/SignUp";
            public const string Login = Prefix + "/Login";
        }
    }
}
