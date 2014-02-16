using System;

namespace FQ.FreeDock
{
    /// <summary>
    /// Provides event data describing a DockControl.
    /// 
    /// </summary>
    public class DockControlEventArgs : EventArgs
    {
        /// <summary>
        /// The DockControl associated with this event.
        /// 
        /// </summary>
        public DockControl DockControl { get; private set; }

        internal DockControlEventArgs(DockControl dockControl)
        {
            this.DockControl = dockControl;
        }
    }
}
