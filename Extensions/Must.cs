using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZeroTwoTwelve.Extensions
{
    public static class Must
    {
        public static T NotBeNull<T>(T value, string name = "") where T : class
        {
            if (value == null)
                throw new ArgumentNullException(name);
            return value;
        }

        public static void BeInRange(int value, int min, int length, string name = "")
        {
            int max = min + length;
            if (value < min || value > max)
                throw new ArgumentOutOfRangeException(name, string.Format("Must be in range {0} to {1}", min, max));
        }

    }
}
