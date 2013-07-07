using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

using MetroFramework;
using MetroFramework.Controls;
using MetroFramework.Drawing;
using MetroFramework.Forms;

namespace QuickShot
{
    public class BrowseTextBox : MetroTextBox
    {
        CommonDialog dialog;
        public CommonDialog Dialog
        {
            get { return dialog; }
            set { dialog = value; }
        }

        MetroButton browseButton;

        public BrowseTextBox()
        {
            browseButton = new MetroButton();
            browseButton.Text = "...";
            browseButton.Click += browseButton_Click;
            browseButton.Size = new Size(25, this.Height - 2);
            browseButton.Location = new Point((this.Width - 25), 1);
            browseButton.Show();

            this.Controls.Add(browseButton);
            browseButton.BringToFront();

            dialog = new FolderBrowserDialog();
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);

            if (browseButton != null)
            {
                browseButton.Size = new Size(25, this.Height - 2);
                browseButton.Location = new Point((this.Width - 25), 1);
                browseButton.BringToFront();
            }
        }

        void browseButton_Click(object sender, EventArgs e)
        {
            if (dialog == null)
                dialog = new FolderBrowserDialog();

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                if (dialog.GetType() == typeof(FolderBrowserDialog))
                {
                    this.Text = ((FolderBrowserDialog)dialog).SelectedPath;
                }
                else if (dialog.GetType() == typeof(SaveFileDialog) || dialog.GetType() == typeof(OpenFileDialog))
                {
                    this.Text = ((FileDialog)dialog).FileName;
                }
            }
        }
    }
}
