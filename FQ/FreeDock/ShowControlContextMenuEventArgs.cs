namespace FQ.FreeDock
{
    /// <summary>
    /// Provides event data describing how to show a context menu for a DockControl.
    /// 
    /// </summary>
    public class ShowControlContextMenuEventArgs : DockControlEventArgs
    {
        private System.Drawing.Point x13d4cb8d1bd20347 = System.Drawing.Point.Empty;
        private ContextMenuContext x0f7b23d1c393aed9;

        /// <summary>
        /// The context in which the menu is being shown.
        /// 
        /// </summary>
        public ContextMenuContext Context
        {
            get
            {
                return this.x0f7b23d1c393aed9;
            }
        }

        /// <summary>
        /// The position, in DockContainer client coordinates, to show the context menu.
        /// 
        /// </summary>
        public System.Drawing.Point Position
        {
            get
            {
                return this.x13d4cb8d1bd20347;
            }
        }

        internal ShowControlContextMenuEventArgs(DockControl dockControl, System.Drawing.Point position, ContextMenuContext context)
      : base(dockControl)
        {
            this.x13d4cb8d1bd20347 = position;
            this.x0f7b23d1c393aed9 = context;
        }
    }
}
