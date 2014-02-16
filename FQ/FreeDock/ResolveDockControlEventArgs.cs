using System;

namespace FQ.FreeDock
{
    /// <summary>
    /// Provides event data describing a DockControl reference for the consumer to resolve.
    /// 
    /// </summary>
    public class ResolveDockControlEventArgs : EventArgs
    {
        /// <summary>
        /// The unique identifier of the DockControl to resolve.
        /// 
        /// </summary>
        public Guid Guid { get; private set; }

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
        public DockControl DockControl { get; set; }

        internal ResolveDockControlEventArgs(Guid guid)
        {
            this.Guid = guid;
        }
    }
}
