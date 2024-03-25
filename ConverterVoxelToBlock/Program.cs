using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConverterVoxelToBlock.ConvertToBuilding;
using ConverterVoxelToBlock.OpenFile;
using ConverterVoxelToBlock.SaveFile;

namespace ConverterVoxelToBlock
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Developed by Unknown User");
            Console.WriteLine();

            while (true)
            {
                VoxelModel voxelModel = new VoxelModel();
                Building<DiggerBlock> building = new Building<DiggerBlock>();

                OpenFile(voxelModel);

                Convert(voxelModel, building);

                SaveFile(building);

                Console.ReadKey();
            }
        }

        static void OpenFile(VoxelModel voxelModel)
        {
            Console.WriteLine("Перетащите файл в консоль:");

            string filePath;
            filePath = Console.ReadLine();
            filePath = filePath.Trim('"');

            Console.WriteLine($"Открытие файла {filePath}");

            OpenFileFactory openFactory = null;

            if (filePath.EndsWith(".json", StringComparison.OrdinalIgnoreCase))
            {
                openFactory = new OpenJsonFactory();
            }
            else
            {
                Console.WriteLine("Неподдерживаемый формат файла");
            }

            if (openFactory != null)
            {
                IOpenFile openFile = openFactory.CreateOpenFile();
                openFile.OpenFile(filePath, voxelModel);
            }
        }

        static void Convert(VoxelModel voxelModel, Building<DiggerBlock> building)
        {
            IConverToBuilding<DiggerBlock> converter = ConvertToBuildingFactory.CreateConverter<DiggerBlock>(ConvertToBuildingFactory.GameType.Digger);

            converter.ConvertToBuilding(voxelModel, building);
        }

        static void SaveFile(Building<DiggerBlock> building)
        {
            Console.WriteLine("Введите имя файла для сохранения:");

            string fileName = Console.ReadLine();
            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string filePath = Path.Combine(desktopPath, fileName + ".json");

            ISaveFile<DiggerBlock> jsonSave = SaveFileFactory.CreateSaveFile<DiggerBlock>(SaveFileFactory.FileType.json);
            jsonSave.SaveFile(building, filePath);
        }
    }
}
