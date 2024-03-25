using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace ConverterVoxelToBlock.ColorConvert
{
    public class ClosestColorFinder<T> where T : Block
    {
        public T GetClosestColor(Color color, Dictionary<int, Color> blockColors)
        {
            ColorDistanceCalculator calculator = new ColorDistanceCalculator();

            int closestType = -1;
            double closestDistance = double.MaxValue;

            foreach (var kvp in blockColors)
            {
                double distance = calculator.CalculateDistance(color, kvp.Value);
                if (distance < closestDistance)
                {
                    closestType = kvp.Key;
                    closestDistance = distance;
                }
            }

            return closestType != -1 ? Activator.CreateInstance<T>() : null;
        }
    }
}
