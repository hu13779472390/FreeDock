using System.ComponentModel;

namespace FQ.FreeDock
{
    /// <summary>
    /// Represents rules associated with where a user can move a window.
    /// 
    /// </summary>
    [TypeConverter(typeof(ExpandableObjectConverter))]
    public class DockingRules
    {
        private bool x33b0d41936d07496 = true;
        private bool x608234746b921e23 = true;
        private bool x22d61e656653012c = true;
        private bool xf2ea876cc567e81e = true;
        private bool x789b1ef056ebb726 = true;
        private bool xadbc8fe70595ade0 = true;

        /// <summary>
        /// Indicates whether the user can dock the window to the left of the layout.
        /// 
        /// </summary>
        public bool AllowDockLeft
        {
            get
            {
                return this.x33b0d41936d07496;
            }
            set
            {
                this.x33b0d41936d07496 = value;
            }
        }

        /// <summary>
        /// Indicates whether the user can dock the window to the right of the layout.
        /// 
        /// </summary>
        public bool AllowDockRight
        {
            get
            {
                return this.x608234746b921e23;
            }
            set
            {
                this.x608234746b921e23 = value;
            }
        }

        /// <summary>
        /// Indicates whether the user can dock the window at the top of the layout.
        /// 
        /// </summary>
        public bool AllowDockTop
        {
            get
            {
                return this.x22d61e656653012c;
            }
            set
            {
                this.x22d61e656653012c = value;
            }
        }

        /// <summary>
        /// Indicates whether the user can dock the window at the bottom of the layout.
        /// 
        /// </summary>
        public bool AllowDockBottom
        {
            get
            {
                return this.xf2ea876cc567e81e;
            }
            set
            {
                this.xf2ea876cc567e81e = value;
            }
        }

        /// <summary>
        /// Indicates whether the user can dock the window as a tabbed document.
        /// 
        /// </summary>
        public bool AllowTab
        {
            get
            {
                return this.x789b1ef056ebb726;
            }
            set
            {
                this.x789b1ef056ebb726 = value;
            }
        }

        /// <summary>
        /// Indicates whether the user can float the window.
        /// 
        /// </summary>
        public bool AllowFloat
        {
            get
            {
                return this.xadbc8fe70595ade0;
            }
            set
            {
                this.xadbc8fe70595ade0 = value;
            }
        }

        /// <summary>
        /// Initializes a new instance of the DockingRules class.
        /// 
        /// </summary>
        public DockingRules()
        {
        }

        /// <summary>
        /// Initializes a new instance of the DockingRules class.
        /// 
        /// </summary>
        /// <param name="allowDock">Whether to allow docking.</param><param name="allowTab">Whether to allow tabbing.</param><param name="allowFloat">Whether to allow floating.</param>
        public DockingRules(bool allowDock, bool allowTab, bool allowFloat)
        {
            this.AllowDockLeft = allowDock;
            this.AllowDockRight = allowDock;
            do
            {
                this.AllowDockTop = allowDock;
            }
            while (0 != 0);
            this.AllowDockBottom = allowDock;
            this.AllowTab = allowTab;
            this.AllowFloat = allowFloat;
        }

        internal void xd5da23b762ce52a2(DockingRules[] x7c92c43084985bae)
        {
            DockingRules[] dockingRulesArray = x7c92c43084985bae;
            if (15 == 0)
            {
                if (0 == 0)
                    goto label_5;
            }
            else
                goto label_8;
            label_2:
            int index;
            ++index;
            label_3:
            DockingRules dockingRules;
            if (index >= dockingRulesArray.Length)
            {
                if (15 != 0)
                    return;
                else
                    goto label_8;
            }
            else
            {
                dockingRules = dockingRulesArray[index];
                this.AllowDockLeft = this.AllowDockLeft && dockingRules.AllowDockLeft;
            }
            label_5:
            this.AllowDockRight = this.AllowDockRight && dockingRules.AllowDockRight;
            if (0 != 0)
                return;
            label_6:
            this.AllowDockTop = this.AllowDockTop && dockingRules.AllowDockTop;
            this.AllowDockBottom = this.AllowDockBottom && dockingRules.AllowDockBottom;
            this.AllowTab = this.AllowTab && dockingRules.AllowTab;
            this.AllowFloat = this.AllowFloat && dockingRules.AllowFloat;
            goto label_2;
            label_8:
            index = 0;
            if (0 != 0)
                goto label_6;
            else
                goto label_3;
        }
    }
}
