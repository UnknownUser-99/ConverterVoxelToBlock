using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConverterVoxelToBlock.ConvertToBuilding
{
    public class ConvertToBuildingFactory
    {
        public enum GameType
        {
            Digger
        }

        public static IConverToBuilding<T> CreateConverter<T>(GameType gameType) where T : Block
        {
            switch (gameType)
            {
                case GameType.Digger:
                    return new ConvertToDigger() as IConverToBuilding<T>;
                default:
                    throw new ArgumentException("Неподдерживаемый тип игры", nameof(gameType));
            }
        }
    }
}
