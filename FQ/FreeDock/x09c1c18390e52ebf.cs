using System;
using System.Drawing;
using System.Windows.Forms;

namespace FQ.FreeDock
{
    // e
    class x09c1c18390e52ebf : x890231ddf317379e
    {
        private DockContainer dockContainer;
        private int xffa8345bf918658d;
        private int xb646339c3b9e735a;
        private int x0d4b3b88c5b24565;
        private int xf623ffb827affd4f;

        public event ResizingManagerFinishedEventHandler Committed;

        public x09c1c18390e52ebf(SandDockManager manager, DockContainer container, Point startPoint) : base(container, manager.DockingHints, false)
        {
            Rectangle rectangle;
            int num1;
            int currentSize = 0;
            int num2;

            this.dockContainer = container;
            rectangle = Rectangle.Empty;
            rectangle = xedb4922162c60d3d.xc68a4bb946c59a9e(xedb4922162c60d3d.x41c62f474d3fb367(container.Parent), container.Parent);
            rectangle = new Rectangle(container.PointToClient(rectangle.Location), rectangle.Size);
            int val1 = manager != null ? manager.MinimumDockContainerSize : 30;
            num2 = Math.Max(val1, LayoutUtilities.xc6fb69ef430eaa44(container));
            int num3 = manager != null ? manager.MaximumDockContainerSize : 500;
            num1 = num3;
            currentSize = container.CurrentSize;
            goto label_11;
            label_11:
            switch (container.Dock)
            {
                case DockStyle.Top:
       
                    this.xffa8345bf918658d = startPoint.Y - (currentSize - num2);
                    this.xb646339c3b9e735a = Math.Min(rectangle.Bottom - 20, startPoint.Y + (num1 - currentSize));
                    this.xf623ffb827affd4f = startPoint.Y - container.x0c42f19be578ccee.Y;
                    break;
                case DockStyle.Bottom:
                    this.xffa8345bf918658d = Math.Max(rectangle.Top + 20, startPoint.Y - (num1 - currentSize));
                    this.xb646339c3b9e735a = startPoint.Y + (currentSize - num2);
                    this.xf623ffb827affd4f = startPoint.Y - container.x0c42f19be578ccee.Y;
                    break;
                case DockStyle.Left:
                    this.xffa8345bf918658d = startPoint.X - (currentSize - num2);
                    this.xb646339c3b9e735a = Math.Min(rectangle.Right - 20, startPoint.X + (num1 - currentSize));
                    this.xf623ffb827affd4f = startPoint.X - container.x0c42f19be578ccee.X;
                    break;
                case DockStyle.Right:
                    this.xffa8345bf918658d = Math.Max(rectangle.Left + 20, startPoint.X - (num1 - currentSize));
                    this.xb646339c3b9e735a = startPoint.X + (currentSize - num2);
                    this.xf623ffb827affd4f = startPoint.X - container.x0c42f19be578ccee.X;
                    break;
            }

            this.OnMouseMove(startPoint);
        }

        public override void OnMouseMove(Point position)
        {
            Rectangle rectangle = Rectangle.Empty;
            if (this.dockContainer.Vertical)
            {
                rectangle = new Rectangle(position.X - this.xf623ffb827affd4f, 0, 4, this.dockContainer.Height);
                if (rectangle.X < this.xffa8345bf918658d)
                    rectangle.X = this.xffa8345bf918658d;
                if (rectangle.X > this.xb646339c3b9e735a - 4)
                    rectangle.X = this.xb646339c3b9e735a - 4;
            }
            else
            {
                rectangle = new Rectangle(0, position.Y - this.xf623ffb827affd4f, this.dockContainer.Width, 4);
                if (rectangle.Y < this.xffa8345bf918658d)
                    rectangle.Y = this.xffa8345bf918658d;
                if (rectangle.Y > this.xb646339c3b9e735a - 4)
                    rectangle.Y = this.xb646339c3b9e735a - 4;
            }
//            DockStyle dock = this.dockContainer.Dock;
            switch (this.dockContainer.Dock)
            {
                case DockStyle.Top:
                    this.x0d4b3b88c5b24565 = this.dockContainer.ContentSize + (rectangle.Y - this.dockContainer.x0c42f19be578ccee.Y);
                    break;
                case DockStyle.Bottom:
                    this.x0d4b3b88c5b24565 = this.dockContainer.ContentSize + (this.dockContainer.x0c42f19be578ccee.Y - rectangle.Y);
                    break;
                case DockStyle.Left:
                    this.x0d4b3b88c5b24565 = this.dockContainer.ContentSize + (rectangle.X - this.dockContainer.x0c42f19be578ccee.X);
                    break;
                case DockStyle.Right:
                    this.x0d4b3b88c5b24565 = this.dockContainer.ContentSize + (this.dockContainer.x0c42f19be578ccee.X - rectangle.X);
                    break;
            }
            this.xe5e4149f382149cc(new Rectangle(this.dockContainer.PointToScreen(rectangle.Location), rectangle.Size), false);
            if (this.dockContainer.Dock == DockStyle.Left || this.dockContainer.Dock == DockStyle.Right)
                Cursor.Current = Cursors.VSplit;
            else
                Cursor.Current = Cursors.HSplit;
        }

        public override void Commit()
        {
            base.Commit();
            if (this.Committed != null)
                this.Committed(this.x0d4b3b88c5b24565);
        }

        public delegate void ResizingManagerFinishedEventHandler(int newSize);
    }
}
