using Microsoft.Xna.Framework.Graphics;
using SpriteAssigner.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Occult.Dungeon.MapStuff;
using SpriteAssigner.Data;

namespace SpriteAssigner
{
    public partial class Form1 : Form
    {

        string TexLocation;
        public int spriteSize;
        public int maxEnums;
        public Dictionary<TileType, Microsoft.Xna.Framework.Rectangle> refs;
        int selectedindex;
        bool isRunning;
        

        
        public Form1()
        {
            InitializeComponent();
            mainWindow1.Enabled = true;
            refs = new Dictionary <TileType, Microsoft.Xna.Framework.Rectangle>();
            mainWindow1.clickedEvent += addRectangle;
            mainWindow1.giveMeForm(this);


            selectedindex = 0;
            maxEnums = Enum.GetValues(typeof(TileType)).Length;
           for (int i = 0; i < maxEnums; i++)
            {
                TileType current = (TileType)i;
                listBox1.Items.Add(current.ToString());
            }
        }

        private void addRectangle(Microsoft.Xna.Framework.Rectangle rect)
        {
            if (selectedindex < maxEnums)
            {
                refs.Add((TileType)selectedindex, rect);
                selectedindex++;
            }
            else
            {
                button1.Text = "Start";
                Finish();
            }
            
            

        }

        //when the clicking fiasco is completed
        private void Finish()
        {
            
        }

        private void importToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void exportToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void textureImporterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TextureImporter import = new TextureImporter();
            import.recieveInfo += recieveTexture;
            import.Show();
            
        }

        public void recieveTexture(string info, int spriteSize)
        {
            TexLocation = info;
            this.spriteSize = spriteSize;
            mainWindow1.GimmeTheGoods(info, spriteSize);
            mainWindow1.Enabled = true;
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            //debug control
            if(e.KeyCode == Keys.Enter)
            {
                Debug.Write("Hedo");
                //mainWindow1.Enabled = true;//switch back to false, just for debug             
               // mainWindow1.GimmeTheGoods(@"U:\Nicholas\Downloads\0x72_DungeonTilesetII_v1.4\0x72_DungeonTilesetII_v1.4.png", 16);
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedindex = listBox1.SelectedIndex;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(isRunning)
            {
                quit();
            }
            else 
            {
                //begin to godown the list
                button1.Text = "Quit";
                selectedindex = 0;
                listBox1.SelectedIndex = 0;

            }
            mainWindow1.BigButtonClick();
            selectedindex = 0;
            
        }

        private void quit()
        {
            isRunning = false;
            button1.Text = "Start";
            ContinueForm contForm = new ContinueForm();
           
            using(Encoder enc = new Encoder(this, TexLocation))
            {
                contForm.save += enc.writeToFile;//passing it over to the encoder to write to a file
                contForm.Activate();
                contForm.Show();
            }
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Settings settings = new Settings();
            settings.Activate();
            settings.Show();
        }

        private void generateTileIDRefToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Encoder parse = new Encoder(this,@"C:\Users\Nicholas\Source\Repos\Occultum\SpriteAssigner\Data\IdDrawPairs.txt");
            parse.generateSpriteIDFile(@"C:\Users\Nicholas\Source\Repos\Occultum\SpriteAssigner\Data\IdDrawPairs.txt");
        }
    }
}
