using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using MetroFramework;
using MetroFramework.Forms;

namespace QuickShot
{
    public partial class MainForm : MetroForm
    {
        Image capturedImage = null;
        bool onlyHide = true;

        public MainForm()
        {
            InitializeComponent();
        }

        public void ExitApplication()
        {
            onlyHide = false;
            HotKeys.UnregisterHotKey(this.Handle, this.GetType().GetHashCode());
            this.Close();
        }

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == HotKeys.WM_HOTKEYS)
            {
                metroButton2_Click(null, null);
            }

            base.WndProc(ref m);
        }

        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);

            HotKeys.Init();
            HotKeys.RegisterHotKey(this.Handle, this.GetType().GetHashCode(), 0, 44);
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            this.Hide();
            e.Cancel = onlyHide;

            base.OnClosing(e);
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            if (!metroCheckBox1.Checked)
            {
                this.Hide();
                System.Threading.Thread.Sleep(75);
            }

            Image image = ScreenCapture.CapturePrimaryScreen();

            if (!metroCheckBox1.Checked)
                this.Show();

            capturedImage = image;
            pictureBox1.Image = capturedImage;
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            if (browseTextBox1.Text != "Select save path...")
            {
                string file = browseTextBox1.Text;
                capturedImage.Save(file);

                if (System.IO.File.Exists(file))
                {
                    browseTextBox1.Text = "Select save path...";
                }
            }
        }

        private void quitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExitApplication();
        }

        private void notifyIcon1_MouseClick(object sender, MouseEventArgs e)
        {
            if ((e.Button & MouseButtons.Left) == MouseButtons.Left)
            {
                if (!this.Visible)
                    this.Show();
                else
                    this.BringToFront();
            }
        }
    }
}
