using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConverterVoxelToBlock.SaveFile
{
    public interface ISaveFile<T> where T : Block
    {
        void SaveFile(Building<T> building, string filePath);
    }
}
