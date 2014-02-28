using System;

namespace FQ.FreeDock
{
    /// <summary>
    /// Provides memory for a dockable window and its situation.
    /// 
    /// </summary>
    public class WindowMetaData
    {
        private DateTime lastFocused = DateTime.FromFileTime(0L);
        private int dockedContentSize = -1;
        private ContainerDockLocation lastFixedDockSide = ContainerDockLocation.Right;
        private DockSituation lastOpenDockSituation;
        private DockSituation lastFixedDockSituation;
        private x129cb2a2bdfd0ab2 xa93c1ee3649251c3;
        private x129cb2a2bdfd0ab2 xd322344ef33dfd34;
        private xd0aa9d0e7d3446c0 x02053c1a8559b85f;
        private Guid lastFloatingWindowGuid;

        /// <summary>
        /// The time that the window last received keyboard focus.
        /// 
        /// </summary>
        public DateTime LastFocused
        {
            get
            {
                return this.lastFocused;
            }
        }

        /// <summary>
        /// The location at which the window was last docked.
        /// 
        /// </summary>
        public ContainerDockLocation LastFixedDockSide
        {
            get
            {
                return this.lastFixedDockSide;
            }
        }

        /// <summary>
        /// The content size a container should adopt to host the window.
        /// 
        /// </summary>
        public int DockedContentSize
        {
            get
            {
                if (this.dockedContentSize == -1)
                    return 200;
                else
                    return this.dockedContentSize;
            }
        }

        internal bool x057495d927e64b9e
        {
            get
            {
                return this.dockedContentSize != -1;
            }
        }

        /// <summary>
        /// The dock situation of the window when it was last open.
        /// 
        /// </summary>
        public DockSituation LastOpenDockSituation
        {
            get
            {
                return this.lastOpenDockSituation;
            }
        }

        /// <summary>
        /// The dock situation of the window when it was last open in a non-floating state.
        /// 
        /// </summary>
        public DockSituation LastFixedDockSituation
        {
            get
            {
                return this.lastFixedDockSituation;
            }
        }

        internal xd0aa9d0e7d3446c0 xe62a3d24e0fde928
        {
            get
            {
                return this.x02053c1a8559b85f;
            }
        }

        internal x129cb2a2bdfd0ab2 x25e1dbd0e63329bf
        {
            get
            {
                return this.xa93c1ee3649251c3;
            }
        }

        internal x129cb2a2bdfd0ab2 xba74b873ae2f845a
        {
            get
            {
                return this.xd322344ef33dfd34;
            }
        }

        public Guid LastFloatingWindowGuid
        {
            get
            {
                return this.lastFloatingWindowGuid;
            }
        }

        internal WindowMetaData()
        {
            this.x02053c1a8559b85f = new xd0aa9d0e7d3446c0();
            this.xa93c1ee3649251c3 = new x129cb2a2bdfd0ab2();
            this.xd322344ef33dfd34 = new x129cb2a2bdfd0ab2();
        }

        internal void SetLastFocused(DateTime datetime)
        {
            this.lastFocused = datetime;
        }

        internal void SetLastFixedDockSide(ContainerDockLocation location)
        {
            this.lastFixedDockSide = location;
        }

        internal void SetDockedContentSize(int size)
        {
            this.dockedContentSize = size;
        }

        internal void SetLastOpenDockSituation(DockSituation situation)
        {
            this.lastOpenDockSituation = situation;
        }

        internal void SetLastFixedDockSituation(DockSituation situation)
        {
            this.lastFixedDockSituation = situation;
        }

        internal void SetLastFloatingWindowGuid(Guid guid)
        {
            this.lastFloatingWindowGuid = guid;
        }
    }
}
