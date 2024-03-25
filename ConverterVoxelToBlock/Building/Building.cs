using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConverterVoxelToBlock
{
    public class Building<T> where T : Block
    {
        private List<T> blocks;

        public int sizeX;
        public int sizeY;
        public int sizeZ;
        public int totalBlocks;

        public Building()
        {
            blocks = new List<T>();
        }

        public void AddBlock(T block)
        {
            blocks.Add(block);
        }

        public List<T> GetBlocks()
        {
            return blocks;
        }
    }
}
