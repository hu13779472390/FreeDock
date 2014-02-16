using System.ComponentModel;
using System.Drawing;
using FQ.FreeDock;

namespace FQ.FreeDock.Design
{
    class DocumentContainerDesigner : DockContainerDesigner
    {
        private DockContainer dockControl;

        protected override bool GetHitTest(System.Drawing.Point point)
        {
            point = this.dockControl.PointToClient(point);
            LayoutSystemBase layoutSystemAt = this.dockControl.GetLayoutSystemAt(point);
            if (layoutSystemAt is DocumentLayoutSystem)
            {
                DocumentLayoutSystem  documentLayoutSystem = (DocumentLayoutSystem)layoutSystemAt;
                Rectangle bounds1 = documentLayoutSystem.LeftScrollButtonBounds;
                Rectangle bounds2 = documentLayoutSystem.RightScrollButtonBounds;

                if (bounds1.Contains(point) || bounds2.Contains(point))
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
