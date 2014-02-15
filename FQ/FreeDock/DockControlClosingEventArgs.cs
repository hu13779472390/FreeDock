namespace FQ.FreeDock
{
    /// <summary>
    /// Provides event data describing a window that is about to be closed.
    /// 
    /// </summary>
    public class DockControlClosingEventArgs : DockControlEventArgs
    {
        private bool x57602a0a0d178a2e;

        /// <summary>
        /// Indicates whether the action that would normally follow the event should be cancelled.
        /// 
        /// </summary>
        public bool Cancel
        {
            get
            {
                return this.x57602a0a0d178a2e;
            }
            set
            {
                this.x57602a0a0d178a2e = value;
            }
        }

        internal DockControlClosingEventArgs(DockControl dockControl, bool cancel)
      : base(dockControl)
        {
            this.x57602a0a0d178a2e = cancel;
        }
    }
}
