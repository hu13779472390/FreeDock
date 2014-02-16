namespace FQ.FreeDock
{
    /// <summary>
    /// Provides event data describing a window that is about to be closed.
    /// 
    /// </summary>
    public class DockControlClosingEventArgs : DockControlEventArgs
    {
        /// <summary>
        /// Indicates whether the action that would normally follow the event should be cancelled.
        /// 
        /// </summary>
        public bool Cancel { get; set; }

        internal DockControlClosingEventArgs(DockControl dockControl, bool cancel) : base(dockControl)
        {
            this.Cancel = cancel;
        }
    }
}
