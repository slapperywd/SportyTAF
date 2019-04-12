
using System;
using System.Linq;

namespace Sporty.Core.Utils
{
    public class DataGenerator
    {
        const string chars = "abcdefghijklmnopqrstuvwxyz";

        public static string GenerateString(int length)
        {
            var random = new Random((int)DateTime.Now.Ticks);

            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        public static string GenerateEmail(string domain = "sporty.com", int length = 12)
        {
            return string.Concat(GenerateString(length), "@", domain);
        }
    }
}
