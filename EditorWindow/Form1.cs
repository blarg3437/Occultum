using EditorWindow.DialogEditor;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace EditorWindow
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void dialogEditorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogEditorMainWindow window = new DialogEditorMainWindow();
            window.Activate();
            window.Show();
        }
    }
}
