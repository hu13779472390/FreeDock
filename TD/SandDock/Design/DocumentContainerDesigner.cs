using System.ComponentModel;
using System.Drawing;
using FQ.FreeDock;

namespace FQ.FreeDock.Design
{
    class DocumentContainerDesigner : DockContainerDesigner
    {
        private DockContainer x1f1a3b29d7ed7776;

        protected override bool GetHitTest(System.Drawing.Point point)
        {
            point = this.x1f1a3b29d7ed7776.PointToClient(point);
            do
            {
                if (0 != 0)
                    goto label_3;
                else
                    goto label_8;
                label_1:
                Rectangle scrollButtonBounds1;
                Rectangle scrollButtonBounds2;
                DocumentLayoutSystem documentLayoutSystem;
                if (!scrollButtonBounds1.Contains(point))
                    scrollButtonBounds2 = documentLayoutSystem.RightScrollButtonBounds;
                else
                    goto label_2;
                label_3:
                if (!scrollButtonBounds2.Contains(point) && int.MinValue != 0)
                {
                    if (0 == 0)
                        continue;
                    else
                        goto label_1;
                }
                else
                    goto label_2;
                label_8:
                LayoutSystemBase layoutSystemAt = this.x1f1a3b29d7ed7776.GetLayoutSystemAt(point);
                if (layoutSystemAt is DocumentLayoutSystem)
                {
                    documentLayoutSystem = (DocumentLayoutSystem)layoutSystemAt;
                    scrollButtonBounds1 = documentLayoutSystem.LeftScrollButtonBounds;
                    if (0 == 0)
                        goto label_1;
                    else
                        break;
                }
                else
                    break;
            }
            while (0 != 0);
            goto label_10;
            label_2:
            return true;
            label_10:
            return base.GetHitTest(point);
        }

        public override void Initialize(IComponent component)
        {
            base.Initialize(component);
            this.x1f1a3b29d7ed7776 = component;
        }
    }
}
