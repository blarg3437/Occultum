
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Occult.Dungeon.MapStuff
{
    class MapGenerator
    {
        static Random rand;
        static MapLayer constructionsite;
        public static MapLayer generatenewMap(int width, int height)
        {
            rand = new Random();
            //generate a map based on the size
            constructionsite = new MapLayer(width, height);
            Tile[,] groundZero = generateBlankMap(width, height);
            //define the rectangles(rooms)
            int numberofrooms = rand.Next(3, 30);//this defines how many rooms to attempt to create
            List<Room> createdrooms = new List<Room>();
            for (int i = 0; i < numberofrooms; i++)
            {
                int x = rand.Next(width);
                int y = rand.Next(height);

                int wide = rand.Next(2, width / 2);
                int high = rand.Next(2, height / 2);

                Room currentroom = new Room(x, y, wide, high);

                //this loops over all the other rooms, to prevent room intersection: disable for room interesection
                if(x + wide < width)
                {
                    if(y+high<height)
                    {
                        createdrooms.Add(currentroom);
                    }
                }
            
               
            }
            //now our list of rooms is filled out! Time to add them and connect them

            Room lastroom = createdrooms.ElementAt(0);
            foreach (Room item in createdrooms)
            {
                Tile[,] roomsData = item.generateRoom();
                for (int y = 0; y < item.height; y++)
                {
                    for (int x = 0; x < item.width; x++)
                    {
                        groundZero[x+item.startX, y+item.startY] = roomsData[x, y];
                    }
                }
                lastroom = item;
            }
            //path between them
            //generate random loot? (maybe in the rectangle definition
            //generate the border
            constructionsite.setTileMap(groundZero);
            return constructionsite;
        }
        public static MapLayer generateRandomSizedMap(int bound)
        {
            return generatenewMap(rand.Next(bound), rand.Next(bound));
        }

        private static Tile[,] generateBlankMap(int width, int height, Tile.tiletype type = Tile.tiletype.middle)
        {
            Tile[,] temp = new Tile[width, height];
            for(int i =0; i < height; i++)
            {
                for(int j = 0; j < width; j++)
                {
                    Tile tile = new Tile();
                    tile.tile = type;
                    temp[j, i] = tile;
                }
            }
            return temp;
           
        }

        ~MapGenerator()
        {

        }
    }
}
