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
                ClosestColorFinder colorFinder = new ClosestColorFinder();

                foreach (var voxel in voxelModel.GetVoxels())
                {
                    Color voxelColor = voxel.color;

                    int closestBlock = colorFinder.GetClosestColor(voxelColor, blocks.Blocks);

                    building.AddBlock(new DiggerBlock
                    {
                        x = voxel.x,
                        y = voxel.y,
                        z = voxel.z,
                        blockType = closestBlock,
                        blockKind = 0
                    });
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
