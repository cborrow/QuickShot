using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace QuickShot
{
    public class HotKeys
    {
        public static event EventHandler Activated;

        public static int ALT_MODIFIER = 1;
        public static int CTRL_MODIFIER = 2;
        public static int SHIFT_MODIFIER = 4;
        public static int WIN_MODIFIER = 8;

        public static int WM_HOTKEYS = 0x0312;

        public HotKeys()
        {
            
        }

        public static void Init()
        {
            Activated = new EventHandler(HotKeyActivated);
        }

        protected static void HotKeyActivated(object sender, EventArgs e)
        {

        }

        [DllImport("user32.dll")]
        public static extern bool RegisterHotKey(IntPtr hWnd,
          int id, int fsModifiers, int vlc);

        [DllImport("user32.dll")]
        public static extern bool UnregisterHotKey(IntPtr hWnd, int id);


    }
}
