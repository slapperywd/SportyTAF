namespace Sporty.Tests.API.Constants
{
    public class Endpoints
    {
        public class Auth
        {
            public const string Login = "Login";
            public const string Register = "Register";
        }

        public class Categories
        {
            public const string GetCategories = "GetCategories";
        }

        public class Events
        {
            public const string GetEvents = "GetEvents";
            public const string GetEvent = "GetEvent";
            public const string CreateEvent = "CreateEvent";
            public const string UpdateEvent = "UpdateEvent";
            public const string JoinEvent = "JoinEvent";
            public const string LeaveEvent = "LeaveEvent";
        }

        public class Health
        {
            public const string Ping = "Ping";
        }

        public class Places
        {
            public const string GetPlaces = "GetPlaces";
        }

        public class Users
        {
            public const string UpdateUser = "UpdateUser";
        }
    }
}
