using System;
using BerlinClock.Interfaces;

namespace BerlinClock.Implementation
{
    // ReSharper disable once InconsistentNaming
    public class ISO8601Time : ITime
    {
        private readonly int hour;

        private readonly int minute;

        private readonly int second;

        public ISO8601Time(DateTime dateTime)
        {
            hour = dateTime.Hour;
            minute = dateTime.Minute;
            second = dateTime.Second;
        }

        public ISO8601Time(int hour, int minute, int second)
        {
            if (hour < 0 || hour > 24)
                throw new ArgumentException($"Hour value \"{hour}\" is out of range: 00..24.", nameof(hour));

            if (minute < 0 || minute > 59)
                throw new ArgumentException($"Minute value \"{minute}\" is out of range: 00..59.", nameof(minute));

            // 60 is only used to denote an added leap second
            if (second < 0 || second > 60)
                throw new ArgumentException($"Second value \"{second}\" is out of range: 00..60.", nameof(second));

            this.hour = hour;
            this.minute = minute;
            this.second = second;
        }

        int ITime.Hour => hour;

        int ITime.Minute => minute;

        int ITime.Second => second;
    }
}
