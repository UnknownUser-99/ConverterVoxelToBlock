using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConverterVoxelToBlock
{
    public class VoxelModel
    {
        private List<Voxel> voxels;

        public VoxelModel()
        {
            voxels = new List<Voxel>();
        }

        public void AddVoxel(Voxel voxel)
        {
            voxels.Add(voxel);
        }

        public List<Voxel> GetVoxels()
        {
            return voxels;
        }
    }
}
