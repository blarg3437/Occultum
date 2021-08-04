using Occult.Dungeon.MapStuff;
using SpriteAssigner.Data;
using System;
using System.Collections.Generic;
using System.Drawing;
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
            Bitmap copyFrom = new Bitmap(texLocation);

            Bitmap tempImage = new Bitmap(form.spriteSize * size, (int)Math.Ceiling((double)form.maxEnums/size));
            Graphics g = Graphics.FromImage(tempImage);
            for (int i = 0; i < form.maxEnums; i++)
            {
                if(form.refs.ContainsKey((TileType)i))
                {
                   //heres the interesting part. I need to put certain ID's in certain locations on the map everytime.
                   //luckily enough, you can find these locations in the occcultum drawing thingy, as they are sourced there.
                   //Id recommend offloading that crap into a file, maybe somesort of structure or something, that way you can 
                   //reference the same thing here and in occultum.
                   //source the image using get pixel from copyfrom and the refs rectangle, then draw it at that mentioned rectangle value.
                }
            }
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

    }
}
