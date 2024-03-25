using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConverterVoxelToBlock
{
    public interface IOpenFile
    {
        void OpenFile(string filePath, VoxelModel voxelModel);
    }
}
