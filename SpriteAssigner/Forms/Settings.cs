using SpriteAssigner.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SpriteAssigner.Forms
{
    public partial class Settings : Form
    {
        TextParser parser;
        public Settings()
        {
            parser = new TextParser(@"C:\Users\Nicholas\Source\Repos\Occultum\SpriteAssigner\Setting.txt");
            
            InitializeComponent();
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {
            parser.Begin(true);
            textBox1.Text = parser.retreiveInteger("MaxSpriteLength").ToString();
            parser.End(true);
        }
    }
}
