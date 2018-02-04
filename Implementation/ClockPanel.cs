using System;
using BerlinClock.Classes;
using BerlinClock.Interfaces;

namespace BerlinClock.Implementation
{
    internal sealed class ClockPanel : IClockPanel
    {
        public TimeComponent TimeComponent { get; }

        public string PanelLampMask { get; }

        public Func<int, int> TurnOnLampsNumberResolver { get; }

        private ClockPanel(Func<int, int> turnOnLampsNumberResolver, string mask, TimeComponent timeComponent)
        {
            TurnOnLampsNumberResolver = turnOnLampsNumberResolver;
            PanelLampMask = mask;
            TimeComponent = timeComponent;
        }

        public static ClockPanel Create(Func<int, int> turnOnLampsNumberResolver, string lampMask, TimeComponent timeComponent)
        {
            if (string.IsNullOrWhiteSpace(lampMask))
                throw new ArgumentNullException(nameof(lampMask));

            if (turnOnLampsNumberResolver == null)
                throw new ArgumentNullException(nameof(turnOnLampsNumberResolver));

            return new ClockPanel(turnOnLampsNumberResolver, lampMask, timeComponent);
        }
    }
}
