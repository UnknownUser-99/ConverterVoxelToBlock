using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConverterVoxelToBlock
{
    public abstract class Block
    {
        public int x { get; set; }
        public int y { get; set; }
        public int z { get; set; }
    }
}
