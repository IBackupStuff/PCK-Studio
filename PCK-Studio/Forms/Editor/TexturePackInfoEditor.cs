using OMI.Formats.Pck;
using PckStudio.Controls;
using PckStudio.Core.Extensions;
using PckStudio.Interfaces;
using PckStudio.Properties;
using PckStudio.ToolboxItems;
using System;
using System.Drawing;
using System.IO;
using System.Security.Cryptography;
using System.Windows.Forms;

namespace PckStudio.Forms.Editor
{
	public partial class TexturePackInfoEditor : EditorForm<PckFile>
	{
		PckAsset iconAsset = null;
		PckAsset comparisonAsset = null;
        ImageConverter converter = new ImageConverter();

        readonly string iconString = "icon.png";
        readonly string comparisonString = "comparison.png";

        public TexturePackInfoEditor(PckFile texturePackInfoFile, ISaveContext<PckFile> saveContext)
			: base(texturePackInfoFile, saveContext)
        {
			texturePackInfoFile.TryGetAsset(iconString, PckAssetType.TextureFile, out iconAsset);

            if (iconAsset == null)
                resetIconImage();

            texturePackInfoFile.TryGetAsset(comparisonString, PckAssetType.TextureFile, out comparisonAsset);

            if (comparisonAsset == null)
                resetComparisonImage();

            InitializeComponent();
            iconPictureBox.BackgroundImage = iconAsset.GetTexture();
            comparisonPictureBox.BackgroundImage = comparisonAsset.GetTexture();
            saveToolStripMenuItem1.Visible = !saveContext.AutoSave;
        }
		private void saveToolStripMenuItem1_Click(object sender, EventArgs e)
		{
			Save();
			DialogResult = DialogResult.OK;
		}

        private void resetIconImage()
        {
            iconAsset = new PckAsset(iconString, PckAssetType.TextureFile);
            iconAsset.SetData((byte[])converter.ConvertTo(Resources.pack, typeof(byte[])));
        }

        private void resetComparisonImage()
        {
            comparisonAsset = new PckAsset(iconString, PckAssetType.TextureFile);
            comparisonAsset.SetData((byte[])converter.ConvertTo(Resources.Comparison, typeof(byte[])));
        }

        private void TexturePackInfoEditor_FormClosing(object sender, FormClosingEventArgs e)
        {
			if (Settings.Default.AutoSaveChanges)
			{
				saveToolStripMenuItem1_Click(sender, EventArgs.Empty);
			}
        }

        private void setImage(string filepath, in PckAsset asset, in InterpolationPictureBox pictureBox)
        {
            try
            {
                asset.SetData(File.ReadAllBytes(filepath));
                pictureBox.BackgroundImage = asset.GetTexture();
            }
            catch (Exception ex)
            {
                bool icon = pictureBox == iconPictureBox;
                pictureBox.Image = icon ? Resources.pack : Resources.Comparison;
                if (icon)
                    resetIconImage();
                else
                    resetComparisonImage();
                MessageBox.Show(this, "Not a valid .PNG image or invalid image data found");
            }
        }

        private void importImage(bool icon)
        {
            using var ofd = new OpenFileDialog();

            string fileExt = ".png";

            ofd.Filter = $"PNG Images (*{fileExt})|*{fileExt}";
            if (ofd.ShowDialog(this) == DialogResult.OK)
            {
                if (icon)
                    setImage(ofd.FileName, iconAsset, iconPictureBox);
                else
                    setImage(ofd.FileName, comparisonAsset, comparisonPictureBox);
            }
        }

        private void importToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool icon = imageContextMenuStrip.SourceControl == iconPictureBox;
            importImage(icon);
        }

        private void exportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool icon = imageContextMenuStrip.SourceControl == iconPictureBox;
            string filename = icon ? iconString : comparisonString;

            string fileExt = ".png";

            using SaveFileDialog exFile = new SaveFileDialog();
            exFile.FileName = filename;
            exFile.Filter = $"PNG Images (*{fileExt})|*{fileExt}";
            if (exFile.ShowDialog(this) != DialogResult.OK ||
                // Makes sure chosen directory isn't null or whitespace AKA makes sure its usable
                string.IsNullOrWhiteSpace(Path.GetDirectoryName(exFile.FileName)))
            {
                MessageBox.Show(this, "The chosen directory is invalid. Please choose a different one and try again.", "Node not extracted");

                return;
            }

            File.WriteAllBytes(exFile.FileName, icon ? iconAsset.Data : comparisonAsset.Data);
        }

        private void pictureBox_Click(object sender, EventArgs e)
        {
            bool icon = sender == iconPictureBox;
            importImage(icon);
        }
    }
}
