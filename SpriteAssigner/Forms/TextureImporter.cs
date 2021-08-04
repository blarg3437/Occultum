using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SpriteAssigner.Forms
{
    public partial class TextureImporter : Form
    {
        
        public delegate void getInfo(string info, int res);
        public event getInfo recieveInfo;

        int spriteSize;
        bool correctImageSize;
        string location;
        public TextureImporter()
        {
            InitializeComponent();
            Activate();
            pictureBox2.Hide();
               
        }

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            location = openFileDialog1.FileName;
            Image tempIm = Image.FromFile(location);
            pictureBox1.Image = tempIm;
            label2.Text = "Width: " + tempIm.Width;
            label3.Text = "Height: " + tempIm.Height;
            Focus();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (correctImageSize)
            {
                Close();
                pictureBox1.Image.Dispose();
                recieveInfo(location, spriteSize);
               
            }
            else
            {
                pictureBox2.Show();
                SystemSounds.Exclamation.Play();
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if(int.TryParse(textBox1.Text, out spriteSize))
            {
                pictureBox2.Hide();
                correctImageSize = true;
            }
            else 
            {
                pictureBox2.Show();
                correctImageSize = false;
            }
        }
    }
}
