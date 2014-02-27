using System;
using System.Drawing;
using System.Windows.Forms;

namespace FQ.FreeDock
{
    // F
    class SplittingManager : x890231ddf317379e
    {
        private Point startPoint = Point.Empty;
        internal const int x7ae613ae2690dbe6 = 25;
        private DockContainer container;
        private SplitLayoutSystem splitLayoutSystem;
        private LayoutSystemBase aboveLayout;
        private LayoutSystemBase belowLayout;
        private int xffa8345bf918658d;
        private int xb646339c3b9e735a;
        private float aboveSize;
        private float belowSize;
        private float totalSize;

        public SplitLayoutSystem SplitLayoutSystem
        {
            get
            {
                return this.splitLayoutSystem;
            }
        }

        public event SplittingManagerFinishedEventHandler Committed;

        public SplittingManager(DockContainer container, SplitLayoutSystem splitLayout, LayoutSystemBase aboveLayout, LayoutSystemBase belowLayout, Point startPoint, DockingHints dockingHints) : base(container, dockingHints, false)
        {
            this.container = container;
            this.splitLayoutSystem = splitLayout;
            this.aboveLayout = aboveLayout;
            this.belowLayout = belowLayout;
            this.startPoint = startPoint;

            if (splitLayout.SplitMode == Orientation.Horizontal)
            {
                this.xffa8345bf918658d = aboveLayout.Bounds.Y + 25;
                this.xb646339c3b9e735a = belowLayout.Bounds.Bottom - 25;
                this.totalSize = aboveLayout.WorkingSize.Height + belowLayout.WorkingSize.Height;
            }
            else
            {
                this.xffa8345bf918658d = aboveLayout.Bounds.X + 25;
                this.xb646339c3b9e735a = belowLayout.Bounds.Right - 25;
                this.totalSize = aboveLayout.WorkingSize.Width + belowLayout.WorkingSize.Width;
            }
            this.OnMouseMove(startPoint);
        }

        public override void Commit()
        {
            base.Commit();
            if (this.Committed != null)
                this.Committed(this.aboveLayout, this.belowLayout, this.aboveSize, this.belowSize);
        }

        public override void OnMouseMove(Point position)
        {
            Rectangle rectangle = Rectangle.Empty;
            float num1;
            if (this.splitLayoutSystem.SplitMode == Orientation.Horizontal)
            {
                rectangle = new Rectangle(this.splitLayoutSystem.Bounds.X, position.Y - 2, this.splitLayoutSystem.Bounds.Width, 4);
                rectangle.Y = Math.Max(rectangle.Y, this.xffa8345bf918658d);
                rectangle.Y = Math.Min(rectangle.Y, this.xb646339c3b9e735a - 4);
                num1 = (float)(this.belowLayout.Bounds.Bottom - this.aboveLayout.Bounds.Top - 4);
                this.aboveSize = (float)(rectangle.Y - this.aboveLayout.Bounds.Top) / num1 * this.totalSize;
                this.belowSize = this.totalSize - this.aboveSize;
            }
            else
            {
                rectangle = new Rectangle(position.X - 2, this.splitLayoutSystem.Bounds.Y, 4, this.splitLayoutSystem.Bounds.Height);
                rectangle.X = Math.Max(rectangle.X, this.xffa8345bf918658d);
                rectangle.X = Math.Min(rectangle.X, this.xb646339c3b9e735a - 4);
                float num4 = (float)(this.belowLayout.Bounds.Right - this.aboveLayout.Bounds.Left - 4);
                this.aboveSize = (float)(rectangle.X - this.aboveLayout.Bounds.Left) / num4 * this.totalSize;
                this.belowSize = this.totalSize - this.aboveSize;
            }
            this.xe5e4149f382149cc(new Rectangle(this.container.PointToScreen(rectangle.Location), rectangle.Size), false);
            Cursor.Current = this.splitLayoutSystem.SplitMode != Orientation.Horizontal ? Cursors.VSplit : Cursors.HSplit;
        }

        public delegate void SplittingManagerFinishedEventHandler(LayoutSystemBase aboveLayout, LayoutSystemBase belowLayout, float aboveSize, float belowSize);
    }
}
