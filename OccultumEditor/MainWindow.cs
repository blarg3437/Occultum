using Microsoft.Xna.Framework.Input;
using OccultumEditor.Designer;
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
        BlockManager manager;
        public MainWindow()
        {
            InitializeComponent();
            graph = SceneViewer.CreateGraphics();
            manager = new BlockManager();
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

        //this is when you drag and drop into the menu
        private void ActionLayout_MouseEnter(object sender, EventArgs e)
        {
            
        }

        //this is when you drag and drop into the menu
        private void MainWindow_DragEnter(object sender, DragEventArgs e)
        {
            manager.addBlock
        }
    }
}
