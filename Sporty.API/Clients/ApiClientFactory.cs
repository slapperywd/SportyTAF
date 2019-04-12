using System;
using Sporty.API.Models;

namespace Sporty.API.Clients
{
    public class ApiClientFactory
    {
        public static T GetClient<T>() => (T)Activator.CreateInstance(typeof(T));

        public static T GetClient<T>(User user) => (T)Activator.CreateInstance(typeof(T), user);
    }
}
