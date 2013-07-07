using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace QuickShot
{
    public class ScreenCapture
    {
        public static Image CapturePrimaryScreen()
        {
            Screen screen = Screen.PrimaryScreen;
            Image image = new Bitmap(screen.Bounds.Width, screen.Bounds.Height);

            using (Graphics g = Graphics.FromImage(image))
            {
                g.CopyFromScreen(screen.Bounds.X, screen.Bounds.Y, 0, 0, screen.Bounds.Size);
            }

            return image;
        }

        public static Image CaptureScreen(int screenNum)
        {
            return null;
        }

        public static Image CaptureAllScreens()
        {
            return null;
        }
    }
}
