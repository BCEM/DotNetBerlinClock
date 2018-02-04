using System;
using System.Globalization;
using BerlinClock.Implementation;
using BerlinClock.Interfaces;

namespace BerlinClock.Classes
{
    internal static class TimeParser
    {
        public static ITime Parse(string input)
        {
            if (string.IsNullOrEmpty(input))
                throw new ArgumentNullException(nameof(input));

            if (input == "24:00:00")
                return new ISO8601Time(24, 00, 00);

            if (!DateTime.TryParseExact(input, "HH:mm:ss", CultureInfo.InvariantCulture, DateTimeStyles.None, out var time))
                throw new FormatException("Provided time format is invalid. Please use HH:mm:ss time format instead.");

            return new ISO8601Time(time);
        }
    }
}
