using System;
using System.Drawing;
using System.Windows.Forms;

namespace FQ.FreeDock
{
    internal class x8e80e1c8bce8caf7 : x890231ddf317379e
    {
        private System.Drawing.Point xcb09bd0cee4909a3 = System.Drawing.Point.Empty;
        internal const int x7ae613ae2690dbe6 = 25;
        private DockContainer xd3311d815ca25f02;
        private SplitLayoutSystem xd0bab8a0f8013a7b;
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
                return this.xd0bab8a0f8013a7b;
            }
        }

        public event x8e80e1c8bce8caf7.SplittingManagerFinishedEventHandler x67ecc0d0e7c9a202;

        public x8e80e1c8bce8caf7(DockContainer container, SplitLayoutSystem splitLayout, LayoutSystemBase aboveLayout, LayoutSystemBase belowLayout, System.Drawing.Point startPoint, DockingHints dockingHints)
      : base((Control)container, dockingHints, false)
        {
            label_12:
            this.xd3311d815ca25f02 = container;
            this.xd0bab8a0f8013a7b = splitLayout;
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
            if (this.x67ecc0d0e7c9a202 == null)
                return;
            this.x67ecc0d0e7c9a202(this.xc13a8191724b6d55, this.x5aa50bbadb0a1e6c, this.x5c2440c931f8d932, this.x4afa341b2323a009);
        }

        public override void OnMouseMove(System.Drawing.Point position)
        {
            Rectangle rectangle = Rectangle.Empty;
            float num1;
            float num2;
            while (this.xd0bab8a0f8013a7b.SplitMode == Orientation.Horizontal)
            {
                rectangle = new Rectangle(this.xd0bab8a0f8013a7b.Bounds.X, position.Y - 2, this.xd0bab8a0f8013a7b.Bounds.Width, 4);
                float num3;
                if ((uint)num3 + (uint)num2 >= 0U)
                {
                    rectangle.Y = Math.Max(rectangle.Y, this.xffa8345bf918658d);
                    rectangle.Y = Math.Min(rectangle.Y, this.xb646339c3b9e735a - 4);
                    num1 = (float)(this.x5aa50bbadb0a1e6c.Bounds.Bottom - this.xc13a8191724b6d55.Bounds.Top - 4);
                    this.x5c2440c931f8d932 = (float)(rectangle.Y - this.xc13a8191724b6d55.Bounds.Top) / num1 * this.x3fb8b43b602e016f;
                    this.x4afa341b2323a009 = this.x3fb8b43b602e016f - this.x5c2440c931f8d932;
                    if (((int)(uint)num2 | -1) == 0)
                        goto label_3;
                    else
                        goto label_2;
                }
            }
            goto label_5;
            label_2:
            this.xe5e4149f382149cc(new Rectangle(this.xd3311d815ca25f02.PointToScreen(rectangle.Location), rectangle.Size), false);
            Cursor.Current = this.xd0bab8a0f8013a7b.SplitMode != Orientation.Horizontal ? Cursors.VSplit : Cursors.HSplit;
            return;
            label_3:
            Rectangle bounds;
            float num4 = (float)(bounds.Right - this.xc13a8191724b6d55.Bounds.Left - 4);
            this.x5c2440c931f8d932 = (float)(rectangle.X - this.xc13a8191724b6d55.Bounds.Left) / num4 * this.x3fb8b43b602e016f;
            if ((uint)num4 - (uint)num1 <= uint.MaxValue)
            {
                this.x4afa341b2323a009 = this.x3fb8b43b602e016f - this.x5c2440c931f8d932;
                if (2 == 0)
                    return;
                else
                    goto label_2;
            }
            else
                goto label_6;
            label_5:
            if ((uint)num2 + (uint)num2 < 0U)
                ;
            label_6:
            rectangle = new Rectangle(position.X - 2, this.xd0bab8a0f8013a7b.Bounds.Y, 4, this.xd0bab8a0f8013a7b.Bounds.Height);
            rectangle.X = Math.Max(rectangle.X, this.xffa8345bf918658d);
            rectangle.X = Math.Min(rectangle.X, this.xb646339c3b9e735a - 4);
            bounds = this.x5aa50bbadb0a1e6c.Bounds;
            goto label_3;
        }

        public delegate void SplittingManagerFinishedEventHandler(LayoutSystemBase aboveLayout,LayoutSystemBase belowLayout,float aboveSize,float belowSize);
    }
}
