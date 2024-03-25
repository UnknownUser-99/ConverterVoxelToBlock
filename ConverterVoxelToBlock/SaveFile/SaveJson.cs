using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ConverterVoxelToBlock.SaveFile
{
    public class SaveJson<T> : ISaveFile<T> where T : Block
    {
        public void SaveFile(Building<T> building, string filePath)
        {
            try
            {
                string json = JsonConvert.SerializeObject(building.GetBlocks(), Formatting.Indented);
                File.WriteAllText(filePath, json);

                Console.WriteLine("Файл JSON сохранён");
            }
            catch(Exception ex)
            {
                Console.WriteLine($"Произошла ошибка при сохранении файла JSON: {ex.Message}");
            }
        }
    }
}
