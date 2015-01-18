namespace Antix.EASI.Api
{
    public static class ApiRoutes
    {
        public const string ROOT = "api";

        public static class Clinicians
        {
            public const string LIST = "clinicians";
            public const string CREATE = "clinicians";
            public const string READ = "clinicians/{id}";
            public const string READ_NAME = "clinicians:read";
            public const string UPDATE = "clinicians/{id}";
            public const string DELETE = "clinicians/{id}";
        }
    }
}