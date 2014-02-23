using System;
using System.Drawing;
using System.Windows.Forms;

namespace FQ.FreeDock
{
    // F
    class x8e80e1c8bce8caf7 : x890231ddf317379e
    {
        private Point xcb09bd0cee4909a3 = Point.Empty;
        internal const int x7ae613ae2690dbe6 = 25;
        private DockContainer xd3311d815ca25f02;
        private SplitLayoutSystem splitLayoutSystem;
        private LayoutSystemBase xc13a8191724b6d55;
        private LayoutSystemBase x5aa50bbadb0a1e6c;
        private int xffa8345bf918658d;
        private int xb646339c3b9e735a;
        private float x5c2440c931f8d932;
        private float x4afa341b2323a009;
        private float x3fb8b43b602e016f;

        public SplitLayoutSystem x07bf3386da210f81
        {
            get
            {
                return this.splitLayoutSystem;
            }
        }

        public event x8e80e1c8bce8caf7.SplittingManagerFinishedEventHandler Committed;

        public x8e80e1c8bce8caf7(DockContainer container, SplitLayoutSystem splitLayout, LayoutSystemBase aboveLayout, LayoutSystemBase belowLayout, Point startPoint, DockingHints dockingHints) : base(container, dockingHints, false)
        {
            label_12:
            this.xd3311d815ca25f02 = container;
            this.splitLayoutSystem = splitLayout;
            while (0 == 0)
            {
                this.xc13a8191724b6d55 = aboveLayout;
                this.x5aa50bbadb0a1e6c = belowLayout;
                this.xcb09bd0cee4909a3 = startPoint;
                if (splitLayout.SplitMode == Orientation.Horizontal)
                    goto label_7;
                else
                    goto label_5;
                label_2:
                this.OnMouseMove(startPoint);
                if (0 == 0)
                    break;
                if ((int)byte.MaxValue != 0)
                    goto label_12;
                else
                    continue;
                label_5:
                this.xffa8345bf918658d = aboveLayout.Bounds.X + 25;
                this.xb646339c3b9e735a = belowLayout.Bounds.Right - 25;
                this.x3fb8b43b602e016f = aboveLayout.WorkingSize.Width + belowLayout.WorkingSize.Width;
                if (4 == 0)
                {
                    if (0 == 0)
                        continue;
                }
                else
                {
                    if (0 != 0)
                        break;
                    if (0 != 0)
                        goto label_8;
                    else
                        goto label_2;
                }
                label_7:
                this.xffa8345bf918658d = aboveLayout.Bounds.Y + 25;
                label_8:
                this.xb646339c3b9e735a = belowLayout.Bounds.Bottom - 25;
                this.x3fb8b43b602e016f = aboveLayout.WorkingSize.Height + belowLayout.WorkingSize.Height;
                goto label_2;
            }
        }

        public override void Commit()
        {
            base.Commit();
            if (this.Committed != null)
                this.Committed(this.xc13a8191724b6d55, this.x5aa50bbadb0a1e6c, this.x5c2440c931f8d932, this.x4afa341b2323a009);
        }

        public override void OnMouseMove(System.Drawing.Point position)
        {
            Rectangle rectangle = Rectangle.Empty;
            float num1;
            if (this.splitLayoutSystem.SplitMode == Orientation.Horizontal)
            {
                rectangle = new Rectangle(this.splitLayoutSystem.Bounds.X, position.Y - 2, this.splitLayoutSystem.Bounds.Width, 4);
                rectangle.Y = Math.Max(rectangle.Y, this.xffa8345bf918658d);
                rectangle.Y = Math.Min(rectangle.Y, this.xb646339c3b9e735a - 4);
                num1 = (float)(this.x5aa50bbadb0a1e6c.Bounds.Bottom - this.xc13a8191724b6d55.Bounds.Top - 4);
                this.x5c2440c931f8d932 = (float)(rectangle.Y - this.xc13a8191724b6d55.Bounds.Top) / num1 * this.x3fb8b43b602e016f;
                this.x4afa341b2323a009 = this.x3fb8b43b602e016f - this.x5c2440c931f8d932;
            }
            else
            {
                rectangle = new Rectangle(position.X - 2, this.splitLayoutSystem.Bounds.Y, 4, this.splitLayoutSystem.Bounds.Height);
                rectangle.X = Math.Max(rectangle.X, this.xffa8345bf918658d);
                rectangle.X = Math.Min(rectangle.X, this.xb646339c3b9e735a - 4);
                float num4 = (float)(this.x5aa50bbadb0a1e6c.Bounds.Right - this.xc13a8191724b6d55.Bounds.Left - 4);
                this.x5c2440c931f8d932 = (float)(rectangle.X - this.xc13a8191724b6d55.Bounds.Left) / num4 * this.x3fb8b43b602e016f;
                this.x4afa341b2323a009 = this.x3fb8b43b602e016f - this.x5c2440c931f8d932;
            }

            this.xe5e4149f382149cc(new Rectangle(this.xd3311d815ca25f02.PointToScreen(rectangle.Location), rectangle.Size), false);
            Cursor.Current = this.splitLayoutSystem.SplitMode != Orientation.Horizontal ? Cursors.VSplit : Cursors.HSplit;

        }

        public delegate void SplittingManagerFinishedEventHandler(LayoutSystemBase aboveLayout,LayoutSystemBase belowLayout,float aboveSize,float belowSize);
    }
}
