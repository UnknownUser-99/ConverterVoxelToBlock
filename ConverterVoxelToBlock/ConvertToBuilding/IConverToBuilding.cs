using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConverterVoxelToBlock
{
    public interface IConverToBuilding<T> where T : Block
    {
        void ConvertToBuilding(VoxelModel voxelModel, Building<T> building);
    }
}
