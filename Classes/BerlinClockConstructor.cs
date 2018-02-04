using System.Collections.Generic;
using BerlinClock.Implementation;
using BerlinClock.Interfaces;

namespace BerlinClock.Classes
{
    internal static class BerlinClockConstructor
    {
        /// <summary>
        /// Construct Berlin clock with 5 panels
        /// </summary>
        /// <returns>Berlin clock panels</returns>
        public static List<IClockPanel> Construct()
        {
            var clockPanels = new List<IClockPanel>(5);

            // Head lamp
            clockPanels.Add(ClockPanel.Create(_ => _ % 2 == 0 ? 1 : 0, "Y", TimeComponent.Second));

            // First Hour Row
            clockPanels.Add(ClockPanel.Create(_ => (_ - _ % 5) / 5, "RRRR", TimeComponent.Hour));

            // Second Hour Row
            clockPanels.Add(ClockPanel.Create(_ => _ % 5, "RRRR", TimeComponent.Hour));

            // First Minute Row
            clockPanels.Add(ClockPanel.Create(_ => (_ - _ % 5) / 5, "YYRYYRYYRYY", TimeComponent.Minute));

            // Second Minute Row
            clockPanels.Add(ClockPanel.Create(_ => _ % 5, "YYYY", TimeComponent.Minute));

            return clockPanels;
        }
    }
}
