using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using ConverterVoxelToBlock.ColorConvert;

namespace ConverterVoxelToBlock.ConvertToBuilding
{
    public class ConvertToDigger : IConverToBuilding<DiggerBlock>
    {
        public void ConvertToBuilding(VoxelModel voxelModel, Building<DiggerBlock> building)
        {
            try
            {
                DiggerBlocks blocks = new DiggerBlocks();
                ClosestColorFinder<DiggerBlock> colorFinder = new ClosestColorFinder<DiggerBlock>();

                foreach (var voxel in voxelModel.GetVoxels())
                {
                    Color voxelColor = voxel.color;

                    DiggerBlock closestBlock = colorFinder.GetClosestColor(voxelColor, blocks.Blocks);

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
    }
}
