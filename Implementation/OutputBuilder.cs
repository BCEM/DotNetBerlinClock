using System;
using System.Collections.Generic;
using System.Text;
using BerlinClock.Classes;
using BerlinClock.Interfaces;

namespace BerlinClock.Implementation
{
    internal sealed class OutputBuilder : IOutputBuilder
    {
        public OutputBuilder(char offSign) => this.offSign = offSign;

        private readonly char offSign;

        public string BuildOutput(List<IClockPanel> panels, ITime time)
        {
            var stringBuilder = new StringBuilder(panels.Count);
            for (var i = 0; i < panels.Count; i++)
            {
                var panel = panels[i];
                string panelOutput;
                switch (panel.TimeComponent)
                {
                    case TimeComponent.Hour:
                        panelOutput = BuildForPanel(panel, time.Hour);
                        break;
                    case TimeComponent.Minute:
                        panelOutput = BuildForPanel(panel, time.Minute);
                        break;
                    case TimeComponent.Second:
                        panelOutput = BuildForPanel(panel, time.Second);
                        break;
                    default:
                        throw new NotSupportedException($"Time component \"{panel.TimeComponent}\" is not supported");
                }

                if (i == panels.Count - 1)
                    stringBuilder.Append(panelOutput);
                else
                    stringBuilder.AppendLine(panelOutput);
            }

            return stringBuilder.ToString();
        }

        private string BuildForPanel(IClockPanel panel, int value)
        {
            var numberOfTurnedOnLamps = panel.TurnOnLampsNumberResolver(value);
            var totalLamps = panel.PanelLampMask.Length;
            if (totalLamps < numberOfTurnedOnLamps)
                throw new ArgumentException("Number of turned on lamps is greater than available on panel");

            var output = new StringBuilder(totalLamps);

            for (var i = 0; i < numberOfTurnedOnLamps; i++)
                output.Append(panel.PanelLampMask[i]);

            for (var i = 0; i < totalLamps - numberOfTurnedOnLamps; i++)
                output.Append(offSign);

            return output.ToString();
        }
    }
}
