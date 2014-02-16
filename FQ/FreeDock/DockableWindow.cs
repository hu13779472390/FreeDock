using System.Drawing;
using System.Windows.Forms;

namespace FQ.FreeDock
{
    /// <summary>
    /// An extended DockControl that will open docked to one of the sides of your container.
    /// 
    /// </summary>
    public class DockableWindow : DockControl
    {
        /// <summary>
        /// Overridden.
        /// 
        /// </summary>
        protected override Size DefaultSize
        {
            get
            {
                return new Size(250, 400);
            }
        }

        /// <summary>
        /// Initializes a new instance of the DockableWindow class.
        /// 
        /// </summary>
        public DockableWindow()
        {
            this.Init();
        }

        /// <summary>
        /// Initializes a new instance of the DockableWindow class, containing the specified control and with the specified text.
        /// 
        /// </summary>
        /// <param name="manager">The SandDockManager responsible for layout of the control.</param><param name="control">The control to host within the DockControl.</param><param name="text">The text of the DockControl.</param>
        public DockableWindow(SandDockManager manager, Control control, string text) : base(manager, control, text)
        {
            this.Init();
        }

        /// <summary>
        /// Overridden. Consult the documentation on the base virtual member for more information.
        /// 
        /// </summary>
        protected override DockingRules CreateDockingRules()
        {
            return new DockingRules(true, false, true);
        }

        /// <summary>
        /// Opens the window at its last known location, ensuring it is the selected window in its tab group.
        /// 
        /// </summary>
        public override void Open()
        {
            base.Open(WindowOpenMethod.OnScreenSelect);
        }

        private void Init()
        {
            if (this.Text.Length == 0)
                this.Text = "Dockable Window";
            this.SetPositionMetaData(DockSituation.Docked, ContainerDockLocation.Right);
        }
    }
}
