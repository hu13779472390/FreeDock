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
        /// <summary>
        /// Indicates whether the user can dock the window to the left of the layout.
        /// 
        /// </summary>
        public bool AllowDockLeft { get; set; }

        /// <summary>
        /// Indicates whether the user can dock the window to the right of the layout.
        /// 
        /// </summary>
        public bool AllowDockRight { get; set; }

        /// <summary>
        /// Indicates whether the user can dock the window at the top of the layout.
        /// 
        /// </summary>
        public bool AllowDockTop { get; set; }

        /// <summary>
        /// Indicates whether the user can dock the window at the bottom of the layout.
        /// 
        /// </summary>
        public bool AllowDockBottom { get; set; }

        /// <summary>
        /// Indicates whether the user can dock the window as a tabbed document.
        /// 
        /// </summary>
        public bool AllowTab { get; set; }

        /// <summary>
        /// Indicates whether the user can float the window.
        /// 
        /// </summary>
        public bool AllowFloat { get; set; }

        /// <summary>
        /// Initializes a new instance of the DockingRules class.
        /// 
        /// </summary>
        public DockingRules()
        {
            this.AllowDockLeft = true;
            this.AllowDockRight = true;
            this.AllowDockTop = true;
            this.AllowDockBottom = true;
            this.AllowTab = true;
            this.AllowFloat = true;
        }

        /// <summary>
        /// Initializes a new instance of the DockingRules class.
        /// 
        /// </summary>
        /// <param name="allowDock">Whether to allow docking.</param><param name="allowTab">Whether to allow tabbing.</param><param name="allowFloat">Whether to allow floating.</param>
        public DockingRules(bool allowDock, bool allowTab, bool allowFloat) : this()
        {
            this.AllowDockLeft = allowDock;
            this.AllowDockRight = allowDock;
            this.AllowDockTop = allowDock;
            this.AllowDockBottom = allowDock;
            this.AllowTab = allowTab;
            this.AllowFloat = allowFloat;
        }

        internal void xd5da23b762ce52a2(DockingRules[] rulesArray)
        {
            foreach (DockingRules rules in rulesArray)
            {
                this.AllowDockLeft = this.AllowDockLeft && rules.AllowDockLeft;
                this.AllowDockRight = this.AllowDockRight && rules.AllowDockRight;
                this.AllowDockTop = this.AllowDockTop && rules.AllowDockTop;
                this.AllowDockBottom = this.AllowDockBottom && rules.AllowDockBottom;
                this.AllowTab = this.AllowTab && rules.AllowTab;
                this.AllowFloat = this.AllowFloat && rules.AllowFloat;
            }
        }
    }
}
