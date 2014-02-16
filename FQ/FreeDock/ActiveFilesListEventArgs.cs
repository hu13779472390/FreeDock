using System;
using System.Windows.Forms;

namespace FQ.FreeDock
{
    /// <summary>
    /// Arguments describing an event dealing with a list of active files.
    /// 
    /// </summary>
    public class ActiveFilesListEventArgs : EventArgs
    {
        /// <summary>
        /// The list of windows to choose from.
        /// 
        /// </summary>
        public DockControl[] Windows { get; private set; }

        /// <summary>
        /// The control on which to show a menu.
        /// 
        /// </summary>
        public Control Control { get; private set; }

        /// <summary>
        /// The position, in control coordinates, at which to show a menu.
        /// 
        /// </summary>
        public System.Drawing.Point Position { get; private set; }

        internal ActiveFilesListEventArgs(DockControl[] windows, Control control, System.Drawing.Point position)
        {
            this.Windows = windows;
            this.Control = control;
            this.Position = position;
        }
    }
}
