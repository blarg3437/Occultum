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



        public MapLayer readDungeonMap(string fileIn)
        {
            /*
             * assuming the file is of format
             * width
             * height
             * data, data
             * data, data
             */
            river = new StreamReader(fileIn);
            int width = Convert.ToInt32(river.ReadLine());
            int height = Convert.ToInt32(river.ReadLine());
            Tile[,] data = new Tile[width, height];
            for (int y = 0; y < height; y++)
            {
                string line = river.ReadLine();
                string[] raw = line.Split(',');
                for(int i = 0; i < raw.Length; i++)// taking the length to go to from the raw versus width, should allow 0's if the data is not of perfect length
                {
                    TileType type = (TileType)Convert.ToInt32(raw[i]);
                    data[i, y] = new Tile();
                    data[i, y].tile = type;
                }
            }
            MapLayer temp = new MapLayer(width, height);
            temp.setTileMap(data);
            return temp;
        }
    }
}
