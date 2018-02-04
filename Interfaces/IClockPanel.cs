using System;
using BerlinClock.Classes;

namespace BerlinClock.Interfaces
{
    /// <summary>
    /// Clock panel of a Berlin Clock
    /// </summary>
    public interface IClockPanel
    {
        /// <summary>
        /// Time component which will be used to display on panel
        /// </summary>
        TimeComponent TimeComponent { get; }

        /// <summary>
        /// Lamp mask where each symbol is a color of a turned on lamp
        /// </summary>
        string PanelLampMask { get; }

        /// <summary>
        /// Function to resolve actual number of lamps which are turned on
        /// </summary>
        Func<int, int> TurnOnLampsNumberResolver { get; }
    }
}
