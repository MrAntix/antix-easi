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

        public static class Examinations
        {
            public const string LIST = "examinations";
            public const string CREATE = "examinations";
            public const string READ = "examinations/{id}";
            public const string READ_NAME = "examinations:read";
            public const string UPDATE = "examinations/{id}";
            public const string DELETE = "examinations/{id}";
        }
    }
}