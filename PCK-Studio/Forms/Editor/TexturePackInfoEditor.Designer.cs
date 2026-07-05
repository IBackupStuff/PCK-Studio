
namespace PckStudio.Forms.Editor
{
    partial class TexturePackInfoEditor
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TexturePackInfoEditor));
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.iconPictureBox = new PckStudio.ToolboxItems.InterpolationPictureBox();
            this.imageContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.importToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.comparisonPictureBox = new PckStudio.ToolboxItems.InterpolationPictureBox();
            this.menuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox)).BeginInit();
            this.imageContextMenuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.comparisonPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveToolStripMenuItem1});
            this.fileToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            resources.ApplyResources(this.fileToolStripMenuItem, "fileToolStripMenuItem");
            // 
            // saveToolStripMenuItem1
            // 
            resources.ApplyResources(this.saveToolStripMenuItem1, "saveToolStripMenuItem1");
            this.saveToolStripMenuItem1.Name = "saveToolStripMenuItem1";
            this.saveToolStripMenuItem1.Click += new System.EventHandler(this.saveToolStripMenuItem1_Click);
            // 
            // menuStrip
            // 
            resources.ApplyResources(this.menuStrip, "menuStrip");
            this.menuStrip.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip.Name = "menuStrip";
            // 
            // iconPictureBox
            // 
            this.iconPictureBox.BackgroundImage = global::PckStudio.Properties.Resources.pack;
            resources.ApplyResources(this.iconPictureBox, "iconPictureBox");
            this.iconPictureBox.BackgroundInterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
            this.iconPictureBox.ContextMenuStrip = this.imageContextMenuStrip;
            this.iconPictureBox.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
            this.iconPictureBox.Name = "iconPictureBox";
            this.iconPictureBox.TabStop = false;
            this.iconPictureBox.Tag = "icon";
            this.iconPictureBox.Click += new System.EventHandler(this.pictureBox_Click);
            // 
            // imageContextMenuStrip
            // 
            this.imageContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.importToolStripMenuItem,
            this.exportToolStripMenuItem});
            this.imageContextMenuStrip.Name = "imageContextMenuStrip";
            resources.ApplyResources(this.imageContextMenuStrip, "imageContextMenuStrip");
            // 
            // importToolStripMenuItem
            // 
            this.importToolStripMenuItem.Name = "importToolStripMenuItem";
            resources.ApplyResources(this.importToolStripMenuItem, "importToolStripMenuItem");
            this.importToolStripMenuItem.Click += new System.EventHandler(this.importToolStripMenuItem_Click);
            // 
            // exportToolStripMenuItem
            // 
            this.exportToolStripMenuItem.Name = "exportToolStripMenuItem";
            resources.ApplyResources(this.exportToolStripMenuItem, "exportToolStripMenuItem");
            this.exportToolStripMenuItem.Click += new System.EventHandler(this.exportToolStripMenuItem_Click);
            // 
            // comparisonPictureBox
            // 
            this.comparisonPictureBox.BackgroundImage = global::PckStudio.Properties.Resources.Comparison;
            resources.ApplyResources(this.comparisonPictureBox, "comparisonPictureBox");
            this.comparisonPictureBox.BackgroundInterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
            this.comparisonPictureBox.ContextMenuStrip = this.imageContextMenuStrip;
            this.comparisonPictureBox.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
            this.comparisonPictureBox.Name = "comparisonPictureBox";
            this.comparisonPictureBox.TabStop = false;
            this.comparisonPictureBox.Tag = "comparison";
            this.comparisonPictureBox.Click += new System.EventHandler(this.pictureBox_Click);
            // 
            // TexturePackInfoEditor
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.comparisonPictureBox);
            this.Controls.Add(this.iconPictureBox);
            this.Controls.Add(this.menuStrip);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TexturePackInfoEditor";
            this.Style = MetroFramework.MetroColorStyle.Silver;
            this.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TexturePackInfoEditor_FormClosing);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox)).EndInit();
            this.imageContextMenuStrip.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.comparisonPictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem1;
        private System.Windows.Forms.MenuStrip menuStrip;
        private ToolboxItems.InterpolationPictureBox iconPictureBox;
        private ToolboxItems.InterpolationPictureBox comparisonPictureBox;
        private System.Windows.Forms.ContextMenuStrip imageContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem importToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportToolStripMenuItem;
    }
}