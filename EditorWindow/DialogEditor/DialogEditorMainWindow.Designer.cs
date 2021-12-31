namespace EditorWindow.DialogEditor
{
    partial class DialogEditorMainWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dialogEditorMono1 = new EditorWindow.DialogEditor.Custom_Control.DialogEditorMono();
            this.SuspendLayout();
            // 
            // dialogEditorMono1
            // 
            this.dialogEditorMono1.Location = new System.Drawing.Point(12, 32);
            this.dialogEditorMono1.MouseHoverUpdatesOnly = false;
            this.dialogEditorMono1.Name = "dialogEditorMono1";
            this.dialogEditorMono1.Size = new System.Drawing.Size(549, 406);
            this.dialogEditorMono1.TabIndex = 0;
            this.dialogEditorMono1.Text = "dialogEditorMono1";
            // 
            // DialogEditorMainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dialogEditorMono1);
            this.Name = "DialogEditorMainWindow";
            this.Text = "DialogEditorMainWindow";
            this.ResumeLayout(false);

        }

        #endregion

        private Custom_Control.DialogEditorMono dialogEditorMono1;
    }
}