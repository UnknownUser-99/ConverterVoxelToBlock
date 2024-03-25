using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConverterVoxelToBlock.SaveFile
{
    public class SaveFileFactory
    {
        public enum FileType
        {
            json,
            xml,
            txt
        }

        public static ISaveFile<T> CreateSaveFile<T>(FileType fileType) where T : Block
        {
            switch (fileType)
            {
                case FileType.json:
                    return new SaveJson<T>();
                default:
                    throw new ArgumentException("Неподдерживаемый формат файла", nameof(fileType));
            }
        }
    }
}
