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

        public static class Patients
        {
            public const string LIST = "patients";
            public const string CREATE = "patients";
            public const string READ = "patients/{id}";
            public const string READ_NAME = "patients:read";
            public const string UPDATE = "patients/{id}";
            public const string DELETE = "patients/{id}";
        }
    }
}