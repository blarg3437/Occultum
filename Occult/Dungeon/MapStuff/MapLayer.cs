using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Occult.Dungeon.MapStuff
{
    class MapLayer
    {
        private Tile[,] tileMap;
        public int width{get; private set;}
        public int height { get; private set; }
        public Tuple<int, int> spawnLocation;
        Random rand;

        List<Room> rooms;
        private int numberOfRooms;

        //might want to add information about rooms and stuff in here, that way I can generate the map
        public MapLayer(int sizeX, int sizeY)
        {
            tileMap = new Tile[sizeX, sizeY];//idk if I will keep this here
            width = sizeX;
            height = sizeY;
            rooms = new List<Room>();
        }
        public void setTileMap(Tile[,] arr) { tileMap = arr; }
        public Tile getTileAt(int x, int y)
        {
           if(isInBounds(x, y))
            {                  
                return tileMap[x, y];               
            }
            return null;
        }      
        public void changeTileType(int x, int y, TileType type)
        {
           if(isInBounds(x, y))
            {
                tileMap[x, y].tile = type;
            }
        }
        public void toString()
        {
            StreamWriter river = new StreamWriter(@"C:\Users\Nicholas\Pictures\MyPixArt\out.txt");
            
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    river.Write((int)tileMap[j, i].tile+",");
                }
                river.WriteLine();
            }
            river.Close();
        }
        //map generation section ----------------------------
        #region Mapgen
        public void generatenewMap(int roomAttempts = 30)
        {
            rand = new Random();
            //generate a map based on the size
            
            Tile[,] groundZero = generateBlankMap(width, height);
            //define the rectangles(rooms)
            numberOfRooms = rand.Next(3, roomAttempts);//this defines how many rooms to attempt to create
            
            for (int i = 0; i < numberOfRooms; i++)
            {
                int x = rand.Next(width);
                int y = rand.Next(height);

                int wide = rand.Next(3, width / 2);
                int high = rand.Next(3, height / 2);

                Room currentroom = new Room(x, y, wide, high);

                //this loops over all the other rooms, to prevent room intersection: disable for room interesection

                //this first loop determines if it is within the bounds of the map
                //if(x + wide < width)
                //{
                //    if(y+high<height)
                //    {
                //        createdrooms.Add(currentroom);
                //    }
                //}

                //now time to loop over all the rooms and check if they collide
                bool doesCollide = false;
                foreach (Room item in rooms)
                {
                    if (currentroom.CollidesWith(item))
                    {
                        doesCollide = true;
                    }
                }
                if (!doesCollide)
                    rooms.Add(currentroom);

            }
            //now our list of rooms is filled out! Time to add them and connect them

            Room lastroom = rooms.ElementAt(0);
            foreach (Room item in rooms)
            {
                for (int y = 0; y < item.height; y++)
                {
                    for (int x = 0; x < item.width; x++)
                    {
                        if (x + item.startX < width && y + item.startY < height)
                            groundZero[x + item.startX, y + item.startY].tile = TileType.path;
                    }
                }
                dig(lastroom, item, groundZero);  //this is the dig call(obviously)

                lastroom = item;
            }
            
            spawnLocation = lastroom.ChooseSpawnPoint();

            //path between them
            //generate random loot? (maybe in the rectangle definition
            //generate the border
            tileMap = groundZero;
            
        }

        private Tile[,] generateBlankMap(int width, int height, TileType type = TileType.middle)
        {
            Tile[,] temp = new Tile[width, height];
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    Tile tile = new Tile();
                    tile.tile = type;
                    temp[j, i] = tile;
                }
            }
            return temp;

        }

        private void dig(Room lastroom, Room item, Tile[,] groundZero)
        {
            int digToY = item.startY + rand.Next(item.height);
            int digFromX = item.startX + rand.Next(item.width);

            if (digToY >= lastroom.centerY)
            {

                for (int i = lastroom.centerY; i < digToY; i++)
                {                    
                    setGroundZeroDirt(lastroom.centerX, i, groundZero);
                }
            }
            else
            {

                for (int i = lastroom.centerY; i > digToY; i--)
                {                   
                    setGroundZeroDirt(lastroom.centerX, i, groundZero);
                }
            }

            if (lastroom.centerX < item.centerX)
            {
                for (int i = lastroom.centerX; i < item.centerX; i++)
                {
                    setGroundZeroDirt(i, digToY, groundZero);
                }
            }
            else
            {
                for (int i = lastroom.centerX; i > item.centerX; i--)
                {
                    setGroundZeroDirt(i, digToY, groundZero);
                }
            }
        }

        private void setGroundZeroDirt(int x, int y, Tile[,] groundZero)
        {
            if (x < groundZero.GetLength(0) && y < groundZero.GetLength(1))
                groundZero[x, y].tile = TileType.path;
        }
        #endregion
        //---------------------------------------------------
        private bool isInBounds(int x, int y)
        {
            if (x < width && x >= 0)
            {
                if (y < height && y >= 0)
                {
                    return true;
                }
            }
            return false;
        }

        
    }
}
