using Microsoft.Xna.Framework;
using Occult.Dungeon.MapStuff;
using SpriteAssigner.Data;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace SpriteAssigner
{
    class Encoder:IDisposable
    {
        StreamWriter writer;
        TextParser parse;
        int size;
        Form1 form;
        string texLocation;
        Dictionary<TileType, Vector2> tempData;
        public Encoder(Form1 form, string texToDrawFrom)
        {
            texLocation = texToDrawFrom;
            parse = new TextParser(@"C:\Users\Nicholas\Source\Repos\Occultum\SpriteAssigner\Setting.txt");//@"C:\Users\Nicholas\Source\Repos\Occultum\SpriteAssigner\Setting.txt"
            parse.Begin(true);
            size = parse.retreiveInteger("MaxSpriteLength");
            parse.End(true);
            this.form = form;
        }

        public void Dispose()
        {
            writer.Close();
        }

        public void writeToFile(string location)
        {
            Debug.WriteLine("REcievied");
            Bitmap copyFrom = new Bitmap(texLocation);

            Bitmap tempImage = new Bitmap(form.spriteSize * size, (int)Math.Ceiling((double)form.maxEnums/size));
            Graphics g = Graphics.FromImage(tempImage);
            generateLocationsWithoutFile();//make sure we have the locations on file
            for (int i = 0; i < form.maxEnums; i++)
            {
                Bitmap copyData = new Bitmap(form.spriteSize, form.spriteSize);
                //Copy from form.refs
                if (form.refs.ContainsKey((TileType)i))
                {
                    //here I am sampling the pixels at the rectangle position, and taking them 
                    Microsoft.Xna.Framework.Rectangle copyRect = form.refs[(TileType)i];
                    for (int y = 0; y < copyRect.Height; y++)
                    {
                        for (int x = 0; x < copyRect.Width; x++)
                        {
                            copyData.SetPixel(x, y, copyFrom.GetPixel(x + copyRect.X*form.spriteSize, y + copyRect.Y*form.spriteSize));
                        }
                    }
                }
                else
                {
                    //here we are generating a square image of pink pixels, and we will draw that as a error image in place of missing ID's
                    for (int y = 0; y < form.spriteSize; y++)
                    {
                        for (int x = 0; x < form.spriteSize; x++)
                        {
                            copyData.SetPixel(x, y, System.Drawing.Color.HotPink);
                        }
                    }
                    //fill the rectangle with pink pixels and paste
                }

                g.DrawImage(copyData, new System.Drawing.Point((int)tempData[(TileType)i].X * form.spriteSize, (int)tempData[(TileType)i].Y * form.spriteSize));
                //paste at tempdata * spritesize
            }
            tempImage.Save(texLocation, ImageFormat.Png);
            writer = new StreamWriter(location);
            int numberPerRow;           
        }

        /**
         * this is a semi useful method to generate the source file for use in the game and the editor
         * Specifically this will contain an Id, and a 2 value number which will represent that textures location on a spritesheet.
         */
        public void generateSpriteIDFile(string location)
        {
            writer = new StreamWriter(location);
            int x = 0;
            int y = 0;
            for (int i = 0; i < form.maxEnums; i++)
            {
                //this section saves it locally
                Vector2 temp = new Vector2(x, y);
                tempData.Add((TileType)i, temp);


                writer.Write(((TileType)i).ToString() + ",");
                writer.Write(x + "," + y);
                if(x == size)
                {
                    x = 0;
                    y++;
                }
                else
                {
                    x++;
                }
                writer.WriteLine();
            }
            writer.Close();
        }

       private void generateLocationsWithoutFile()
        {
            int x = 0;
            int y = 0;
            for (int i = 0; i < form.maxEnums; i++)
            {
                //this section saves it locally
                Vector2 temp = new Vector2(x, y);
                tempData.Add((TileType)i, temp);        
                if (x == size)
                {
                    x = 0;
                    y++;
                }
                else
                {
                    x++;
                }
                
            }
        }

    }
}
