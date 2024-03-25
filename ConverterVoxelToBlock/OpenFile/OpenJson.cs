using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using Newtonsoft.Json.Linq;

namespace ConverterVoxelToBlock
{
    public class OpenJson : IOpenFile
    {
        public void OpenFile(string filePath, VoxelModel voxelModel)
        {
            try
            {
                string jsonContent = File.ReadAllText(filePath);
                JObject jsonObj = JObject.Parse(jsonContent);

                JArray voxelsArray = (JArray)jsonObj["voxels"];

                foreach (JObject voxelObj in voxelsArray)
                {
                    int x = (int)voxelObj["x"];
                    int y = (int)voxelObj["y"];
                    int z = (int)voxelObj["z"];

                    int red = (int)voxelObj["red"];
                    int green = (int)voxelObj["green"];
                    int blue = (int)voxelObj["blue"];

                    Color color = Color.FromArgb(red, green, blue);

                    voxelModel.AddVoxel(new Voxel { x = x, y = y, z = z, color = color });
                }

                Console.WriteLine("Данные из файла JSON получены");
            }
            catch(Exception ex)
            {
                Console.WriteLine($"Произошла ошибка при получении данных: {ex.Message}");
            }
        }
    }
}
