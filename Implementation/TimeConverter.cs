using BerlinClock.Classes;
using BerlinClock.Implementation;
using BerlinClock.Interfaces;

// ReSharper disable once CheckNamespace
namespace BerlinClock
{
    public class TimeConverter : ITimeConverter
    {
        public string convertTime(string aTime)
        {
            var time = TimeParser.Parse(aTime);
            var clockPanels = BerlinClockConstructor.Construct();
            var outputBuilder = new OutputBuilder(offSign: 'O');

            return outputBuilder.BuildOutput(clockPanels, time);
        }
    }
}
