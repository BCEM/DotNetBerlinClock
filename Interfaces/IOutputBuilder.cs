using System.Collections.Generic;

namespace BerlinClock.Interfaces
{
    /// <summary>
    /// Output builder used to provide output in desirable format
    /// </summary>
    public interface IOutputBuilder
    {
        /// <summary>
        /// Builds output string
        /// </summary>
        /// <param name="panels">Clock panels to display</param>
        /// <param name="time">Time value to display</param>
        /// <returns></returns>
        string BuildOutput(List<IClockPanel> panels, ITime time);
    }
}
