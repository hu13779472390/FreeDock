using System;
using System.Drawing;
using System.Windows.Forms;

namespace FQ.FreeDock
{
    // E
    class ResizingManager : x890231ddf317379e
    {
        private AutoHideBar autoHideBar;
        private PopupContainer popupContainer;
        private Point startPoint;
        private int xe7e5c1179f5c7ae1;
        private int xffa8345bf918658d;
        private int xb646339c3b9e735a;
        private int newSize;

        public event ResizingManagerFinishedEventHandler Committed;

        public ResizingManager(AutoHideBar bar, PopupContainer popupContainer, Point startPoint) : base(bar, bar.Manager != null ? bar.Manager.DockingHints : DockingHints.TranslucentFill, false)
        {
            int num3 = 0;
            this.autoHideBar = bar;
            this.popupContainer = popupContainer;
            this.startPoint = startPoint;
            int num2 = bar.Manager != null ? bar.Manager.MinimumDockContainerSize : 30;
            int val2 = num2;
            int num4 = bar.Manager != null ? bar.Manager.MaximumDockContainerSize : 500;
            num3 = num4;
            switch (bar.Dock)
            {
                case DockStyle.Top:
                    if (bar.Manager != null && bar.Manager.DockSystemContainer != null)
                        num3 = Math.Max(bar.Manager.DockSystemContainer.Height - popupContainer.Bounds.Top - val2, val2);
                    this.xffa8345bf918658d = startPoint.Y - (this.xe7e5c1179f5c7ae1 - val2);
                    this.xb646339c3b9e735a = startPoint.Y + (num3 - this.xe7e5c1179f5c7ae1);
                    break;
                case DockStyle.Bottom:
                    if (bar.Manager != null && bar.Manager.DockSystemContainer != null)
                        num3 = Math.Max(popupContainer.Bounds.Bottom - val2, val2);
                    this.xffa8345bf918658d = startPoint.Y - (num3 - this.xe7e5c1179f5c7ae1);
                    this.xb646339c3b9e735a = startPoint.Y + (this.xe7e5c1179f5c7ae1 - val2);
                    break;
                case DockStyle.Left:
                    if (bar.Manager != null && bar.Manager.DockSystemContainer != null)
                        num3 = Math.Max(bar.Manager.DockSystemContainer.Width - popupContainer.Bounds.Left - val2, val2);
                    this.xffa8345bf918658d = startPoint.X - (this.xe7e5c1179f5c7ae1 - val2);
                    this.xb646339c3b9e735a = startPoint.X + (num3 - this.xe7e5c1179f5c7ae1);
                    break;
                case DockStyle.Right:
                    if (bar.Manager != null && bar.Manager.DockSystemContainer != null)
                        num3 = Math.Max(popupContainer.Bounds.Right - val2, val2);
                    this.xffa8345bf918658d = startPoint.X - (num3 - this.xe7e5c1179f5c7ae1);
                    this.xb646339c3b9e735a = startPoint.X + (this.xe7e5c1179f5c7ae1 - val2);
                    break;
            }
            this.OnMouseMove(startPoint);
        }

        public override void OnMouseMove(Point position)
        {
            Rectangle rectangle = Rectangle.Empty;
            if (this.autoHideBar.Vertical)
            {
                if (position.X < this.xffa8345bf918658d)
                    position.X = this.xffa8345bf918658d;
                if (position.X > this.xb646339c3b9e735a)
                    position.X = this.xb646339c3b9e735a;
                rectangle = new Rectangle(position.X - 2, 0, 4, this.popupContainer.Height);
            }
            else
            {
                if (position.Y < this.xffa8345bf918658d)
                    position.Y = this.xffa8345bf918658d;
                if (position.Y > this.xb646339c3b9e735a)
                    position.Y = this.xb646339c3b9e735a;
                rectangle = new Rectangle(0, position.Y - 2, this.popupContainer.Width, 4);
            }

            switch (this.autoHideBar.Dock)
            {
                case DockStyle.Top:
                    this.newSize = this.xe7e5c1179f5c7ae1 + (position.Y - this.startPoint.Y);
                    break;
                case DockStyle.Bottom:
                    this.newSize = this.xe7e5c1179f5c7ae1 + (this.startPoint.Y - position.Y);
                    break;
                case DockStyle.Left:
                    this.newSize = this.xe7e5c1179f5c7ae1 + (position.X - this.startPoint.X);
                    break;
                case DockStyle.Right:
                    this.newSize = this.xe7e5c1179f5c7ae1 + (this.startPoint.X - position.X);
                    break;
            }
            this.xe5e4149f382149cc(new Rectangle(this.popupContainer.PointToScreen(rectangle.Location), rectangle.Size), false);
        }

        public override void Commit()
        {
            base.Commit();
            if (this.Committed != null)
            this.Committed(this.newSize);
        }

        public delegate void ResizingManagerFinishedEventHandler(int newSize);
    }
}
