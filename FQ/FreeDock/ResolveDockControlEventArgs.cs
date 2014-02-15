using System;

namespace FQ.FreeDock
{
    /// <summary>
    /// Provides event data describing a DockControl reference for the consumer to resolve.
    /// 
    /// </summary>
    public class ResolveDockControlEventArgs : EventArgs
    {
        private DockControl x43bec302f92080b9;
        private Guid xb51cd75f17ace1ec;

        /// <summary>
        /// The unique identifier of the DockControl to resolve.
        /// 
        /// </summary>
        public Guid Guid
        {
            get
            {
                return this.xb51cd75f17ace1ec;
            }
        }

        /// <summary>
        /// The DockControl that the Guid property references.
        /// 
        /// </summary>
        /// 
        /// <remarks>
        /// 
        /// <para>
        /// The consumer of this event should set this property.
        /// </para>
        /// 
        /// </remarks>
        public DockControl DockControl
        {
            get
            {
                return this.x43bec302f92080b9;
            }
            set
            {
                this.x43bec302f92080b9 = value;
            }
        }

        internal ResolveDockControlEventArgs(Guid guid)
        {
            this.xb51cd75f17ace1ec = guid;
        }
    }
}
