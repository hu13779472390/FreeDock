using System.Drawing;

namespace FQ.FreeDock
{
    /// <summary>
    /// Provides event data describing how to show a context menu for a DockControl.
    /// 
    /// </summary>
    public class ShowControlContextMenuEventArgs : DockControlEventArgs
    {
        private Point position = Point.Empty;

        /// <summary>
        /// The context in which the menu is being shown.
        /// 
        /// </summary>
        public ContextMenuContext Context { get; private set; }

        /// <summary>
        /// The position, in DockContainer client coordinates, to show the context menu.
        /// 
        /// </summary>
        public Point Position
        {
            get
            {
                return this.position;
            }
        }

        internal ShowControlContextMenuEventArgs(DockControl dockControl, Point position, ContextMenuContext context) : base(dockControl)
        {
            this.position = position;
            this.Context = context;
        }
    }
}
