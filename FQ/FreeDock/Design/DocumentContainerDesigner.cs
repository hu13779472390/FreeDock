using System.ComponentModel;
using System.Drawing;
using FQ.FreeDock;

namespace FQ.FreeDock.Design
{
    class DocumentContainerDesigner : DockContainerDesigner
    {
        private DockContainer dockControl;

        // reviewed with 2.4
        protected override bool GetHitTest(Point point)
        {
            point = this.dockControl.PointToClient(point);
            LayoutSystemBase layout = this.dockControl.GetLayoutSystemAt(point);
            if (layout is DocumentLayoutSystem)
            {
                DocumentLayoutSystem  docLayout = (DocumentLayoutSystem)layout;
                if (docLayout.LeftScrollButtonBounds.Contains(point) || docLayout.RightScrollButtonBounds.Contains(point))
                    return true; 
            }
            return base.GetHitTest(point);
        }

        public override void Initialize(IComponent component)
        {
            base.Initialize(component);
            this.dockControl = (DockContainer)component;
        }
    }
}
