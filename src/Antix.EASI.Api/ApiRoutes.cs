namespace Antix.EASI.Api
{
    public static class ApiRoutes
    {
        public const string ROOT = "api";

        public static class Examiners
        {
            public const string LIST = "examiners";
            public const string CREATE = "examiners";
            public const string READ = "examiners/{id}";
            public const string READ_NAME = "examiners:read";
            public const string UPDATE = "examiners/{id}";
            public const string DELETE = "examiners/{id}";
        }
    }
}