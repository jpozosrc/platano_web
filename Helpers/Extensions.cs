using System;

namespace Platano.Helpers
{
    public static class Extensions
    {
        public static string LastX(this String str, int characterLength)
        {
            return str.Substring(str.Length - characterLength, characterLength);
        }
    }
}