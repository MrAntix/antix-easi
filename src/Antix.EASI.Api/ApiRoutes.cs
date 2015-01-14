namespace Antix.EASI.Api
{
    public static class ApiRoutes
    {
        public const string ROOT = "api";

        public static class Clinicians
        {
            public const string CREATE = "clinicians";
            public const string READ = "clinicians/{id}/read";
            public const string UPDATE = "clinicians/{id}/update";
            public const string LOOKUP = "clinicians/lookup";
        }
    }
}