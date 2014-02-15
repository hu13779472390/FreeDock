using System;

namespace FQ.FreeDock
{
    /// <summary>
    /// Provides event data describing a DockControl.
    /// 
    /// </summary>
    public class DockControlEventArgs : EventArgs
    {
        private DockControl xdeac46e41e0fbcf5;

        /// <summary>
        /// The DockControl associated with this event.
        /// 
        /// </summary>
        public DockControl DockControl
        {
            get
            {
                return this.xdeac46e41e0fbcf5;
            }
        }

        internal DockControlEventArgs(DockControl dockControl)
        {
            this.xdeac46e41e0fbcf5 = dockControl;
        }
    }
}
