using Occult.Dungeon.MapStuff;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Occult.Util
{
    class FileLoader
    {
        StreamReader river;

        private static FileLoader instance;
        public static FileLoader Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new FileLoader();
                }
                return instance;
            }
        }



        public DungeonMap readDungeonMap(string fileIn)
        {
            river = new StreamReader(fileIn);
            //DungeonMap temp = new DungeonMap();
        }
    }
}
