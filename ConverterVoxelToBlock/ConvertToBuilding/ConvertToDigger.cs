using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace ConverterVoxelToBlock.ConvertToBuilding
{
    public class ConvertToDigger : IConverToBuilding<DiggerBlock>
    {
        public void ConvertToBuilding(VoxelModel voxelModel, Building<DiggerBlock> building)
        {
            try
            {
                DiggerBlocks blocks = new DiggerBlocks();

                foreach (var voxel in voxelModel.GetVoxels())
                {
                    Color voxelColor = voxel.color;

                    DiggerBlock closestBlock = GetClosestColor(voxelColor, blocks);

                    if (closestBlock != null)
                    {
                        building.AddBlock(new DiggerBlock
                        {
                            x = voxel.x,
                            y = voxel.y,
                            z = voxel.z,
                            blockType = closestBlock.blockType,
                            blockKind = closestBlock.blockKind
                        });
                    }
                }

                Console.WriteLine("Модель преобразована в постройку");
            }
            catch(Exception ex)
            {
                Console.WriteLine($"Произошла ошибка при преобразовании в постройку: {ex.Message}");
            }
        }

        private DiggerBlock GetClosestColor(Color color, DiggerBlocks blocks)
        {
            ColorDistanceCalculator calculator = new ColorDistanceCalculator();
            int closestType = -1;
            double closestDistance = double.MaxValue;

            foreach (var kvp in blocks.Blocks)
            {
                double distance = calculator.CalculateDistance(color, kvp.Value);
                if (distance < closestDistance)
                {
                    closestType = kvp.Key;
                    closestDistance = distance;
                }
            }

            return closestType != -1 ? new DiggerBlock { blockType = closestType, blockKind = 0 } : null;
        }
    }
}
