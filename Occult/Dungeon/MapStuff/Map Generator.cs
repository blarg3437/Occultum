
using Microsoft.Xna.Framework;
using Occult.Util.Graphics;
using Occult.World;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
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
                foreach (Room item in createdrooms)
                {
                    if(currentroom.CollidesWith(item))
                    {
                        doesCollide = true;
                    }
                }
                if(!doesCollide)
                createdrooms.Add(currentroom);

            }
            //now our list of rooms is filled out! Time to add them and connect them

            Room lastroom = createdrooms.ElementAt(0);
            foreach (Room item in createdrooms)
            {              
                for (int y = 0; y < item.height; y++)
                {
                    for (int x = 0; x < item.width; x++)
                    {
                        if(x+item.startX < width && y+item.startY < height)
                        groundZero[x+item.startX, y+item.startY].tile = TileType.path;
                    }
                }
                dig(lastroom, item, groundZero);  //this is the dig call(obviously)
                                  
                lastroom = item;
            }
            constructionsite.spawnLocation = lastroom.ChooseSpawnPoint();
             
            //path between them
            //generate random loot? (maybe in the rectangle definition
            //generate the border
            constructionsite.setTileMap(groundZero);
            return constructionsite;
        }

        private static void dig(Room lastroom, Room item, Tile[,] groundZero)
        {
            int digToY = item.startY + rand.Next(item.height);
            int digFromX = item.startX + rand.Next(item.width);

            if (digToY >= lastroom.centerY)
            {

                for (int i = lastroom.centerY; i < digToY; i++)
                {
                    Debug.WriteLine("digging");                   
                    setGroundZeroDirt(lastroom.centerX, i, groundZero);
                }
            }
            else
            {

                for (int i = lastroom.centerY; i > digToY; i--)
                {
                    Debug.WriteLine("digging2");                    
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

        private static void setGroundZeroDirt(int x, int y, Tile[,] groundZero)
        {
            if(x < constructionsite.width && y < constructionsite.height)
            groundZero[x, y].tile = TileType.path;
        }

        public static MapLayer generateRandomSizedMap(int bound)
        {
            return generatenewMap(rand.Next(bound), rand.Next(bound));
        }

        private static Tile[,] generateBlankMap(int width, int height, TileType type = TileType.middle)
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

        
    }
}
