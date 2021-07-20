using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OccultumEditor
{
    public partial class MainWindow : Form
    {
        Graphics graph;
        public MainWindow()
        {
            InitializeComponent();
            graph = SceneViewer.CreateGraphics();
           
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {

        }

        private void idReferenceToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void SceneViewer_Click(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {
            
        }
    }
}
