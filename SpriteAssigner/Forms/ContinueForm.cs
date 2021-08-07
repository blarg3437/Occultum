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
    public partial class ContinueForm : Form
    {
        public delegate void ButtonClick(string args);
        public event ButtonClick save;
        public event ButtonClick abandon;
        public ContinueForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.DefaultExt = @"C:\Users\Nicholas\Pictures";//could cause an error on another computer
            dialog.ShowDialog();
            save(dialog.FileName);
            Close();
            //save as and return
        }
        private void button2_Click(object sender, EventArgs e)
        {
            save(@"C:\Users\Nicholas\Pictures\Efrat.png");
            Close();
            //save and return
        }    

        private void button3_Click(object sender, EventArgs e)
        {
            abandon("Rah");
            Close();
            //dont save and return
        }

        
    }
}
