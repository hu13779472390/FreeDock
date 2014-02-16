using System;
using System.Drawing;
using System.Windows.Forms;

namespace FQ.FreeDock
{
    class x7fc004d490c8a431 : x890231ddf317379e
    {
        private x10ac79a4257c7f52 x2ee8392f53a01b93;
        private x87cf4de36131799d x5fea292ffeb2c28c;
        private System.Drawing.Point xcb09bd0cee4909a3;
        private int xe7e5c1179f5c7ae1;
        private int xffa8345bf918658d;
        private int xb646339c3b9e735a;
        private int x0d4b3b88c5b24565;

        public event x7fc004d490c8a431.ResizingManagerFinishedEventHandler x67ecc0d0e7c9a202;

        public x7fc004d490c8a431(x10ac79a4257c7f52 bar, x87cf4de36131799d popupContainer, System.Drawing.Point startPoint)
      : base((Control)bar, bar.x460ab163f44a604d != null ? bar.x460ab163f44a604d.DockingHints : DockingHints.TranslucentFill, false)
        {
            int num1;
            int num3 = 0;
            goto label_40;
            label_37:
            if (bar.x460ab163f44a604d == null)
                goto label_39;
            label_31:
            int num2 = bar.x460ab163f44a604d.MinimumDockContainerSize;
            label_32:
            int val2 = num2;
            if (bar.x460ab163f44a604d != null)
                goto label_35;
            else
                goto label_33;
            label_2:
            num3 = 0;
            this.xffa8345bf918658d = startPoint.Y - (num3 - this.xe7e5c1179f5c7ae1);
            this.xb646339c3b9e735a = startPoint.Y + (this.xe7e5c1179f5c7ae1 - val2);
            label_3:
            this.OnMouseMove(startPoint);
            return;
            label_5:
            num3 = Math.Max(popupContainer.Bounds.Bottom - val2, val2);
            goto label_2;
            label_10:
            if ((uint)num3 + (uint)val2 < 0U)
                goto label_41;
            label_11:
            this.xffa8345bf918658d = startPoint.Y - (this.xe7e5c1179f5c7ae1 - val2);
            this.xb646339c3b9e735a = startPoint.Y + (num3 - this.xe7e5c1179f5c7ae1);
            goto label_3;
            label_12:
            while (bar.x460ab163f44a604d.DockSystemContainer == null)
            {
                if (0 == 0)
                    goto label_11;
            }
            goto label_15;
            label_13:
            if (bar.x460ab163f44a604d != null)
            {
                if ((uint)val2 + (uint)num3 >= 0U)
                    goto label_12;
            }
            else
                goto label_11;
            label_15:
            num3 = Math.Max(bar.x460ab163f44a604d.DockSystemContainer.Height - popupContainer.Bounds.Top - val2, val2);
            if ((uint)val2 >= 0U)
            {
                if ((uint)val2 - (uint)num3 >= 0U)
                {
                    if (0 == 0)
                    {
                        while (0 == 0)
                        {
                            if (15 == 0)
                            {
                                if ((uint)val2 + (uint)val2 >= 0U)
                                {
                                    if (0 != 0)
                                        goto label_37;
                                    else
                                        goto label_31;
                                }
                            }
                            else
                                goto label_10;
                        }
                        goto label_13;
                    }
                    else
                        goto label_13;
                }
            }
            else
                goto label_5;
            label_27:
            this.xe7e5c1179f5c7ae1 = popupContainer.xca843b3e9a1c605f;
            if ((uint)val2 + (uint)val2 <= uint.MaxValue)
            {
                switch (bar.Dock)
                {
                    case DockStyle.Top:
                        goto label_13;
                    case DockStyle.Bottom:
                        if (bar.x460ab163f44a604d != null)
                        {
                            if (bar.x460ab163f44a604d.DockSystemContainer == null)
                            {
                                if ((uint)num3 + (uint)val2 < 0U)
                                    return;
                                if ((uint)num3 - (uint)val2 > uint.MaxValue)
                                    goto label_5;
                                else
                                    goto label_2;
                            }
                            else
                                goto label_5;
                        }
                        else
                            goto label_2;
                    case DockStyle.Left:
                        if (bar.x460ab163f44a604d != null)
                            goto label_23;
                        else
                            goto label_26;
                        label_22:
                        this.xffa8345bf918658d = startPoint.X - (this.xe7e5c1179f5c7ae1 - val2);
                        this.xb646339c3b9e735a = startPoint.X + (num3 - this.xe7e5c1179f5c7ae1);
                        if ((uint)num3 + (uint)val2 >= 0U)
                            goto label_3;
                        else
                            break;
                        label_23:
                        if (bar.x460ab163f44a604d.DockSystemContainer != null)
                        {
                            num3 = Math.Max(bar.x460ab163f44a604d.DockSystemContainer.Width - popupContainer.Bounds.Left - val2, val2);
                            goto label_22;
                        }
                        else
                            goto label_22;
                        label_26:
                        if ((uint)val2 > uint.MaxValue)
                            goto label_10;
                        else
                            goto label_22;
                    case DockStyle.Right:
                        if (bar.x460ab163f44a604d != null && bar.x460ab163f44a604d.DockSystemContainer != null)
                        {
                            num3 = Math.Max(popupContainer.Bounds.Right - val2, val2);
                            break;
                        }
                        else
                            break;
                    default:
                        goto label_3;
                }
                this.xffa8345bf918658d = startPoint.X - (num3 - this.xe7e5c1179f5c7ae1);
                this.xb646339c3b9e735a = startPoint.X + (this.xe7e5c1179f5c7ae1 - val2);
                goto label_3;
            }
            else
                goto label_13;
            label_33:
            int num4;
            if ((uint)val2 >= 0U)
            {
                num4 = 500;
                goto label_36;
            }
            else
                goto label_12;
            label_35:
            num4 = bar.x460ab163f44a604d.MaximumDockContainerSize;
            label_36:
            num3 = num4;
            goto label_27;
            label_39:
            num2 = 30;
            goto label_32;
            label_40:
            this.x2ee8392f53a01b93 = bar;
            label_41:
            this.x5fea292ffeb2c28c = popupContainer;
            this.xcb09bd0cee4909a3 = startPoint;
            goto label_37;
        }

        public override void OnMouseMove(System.Drawing.Point position)
        {
            Rectangle rectangle = Rectangle.Empty;
            label_26:
            while (0 != 0)
            {
                if (2 != 0)
                {
                    if (0 == 0)
                        goto label_20;
                }
                else
                    goto label_5;
            }
            goto label_17;
            label_2:
            this.x0d4b3b88c5b24565 = this.xe7e5c1179f5c7ae1 + (this.xcb09bd0cee4909a3.Y - position.Y);
            label_3:
            this.xe5e4149f382149cc(new Rectangle(this.x5fea292ffeb2c28c.PointToScreen(rectangle.Location), rectangle.Size), false);
            if (3 != 0)
                return;
            if (3 != 0)
                goto label_26;
            else
                goto label_25;
            label_5:
            rectangle = new Rectangle(0, position.Y - 2, this.x5fea292ffeb2c28c.Width, 4);
            label_6:
            DockStyle dock = this.x2ee8392f53a01b93.Dock;
            label_7:
            switch (dock)
            {
                case DockStyle.Top:
                    this.x0d4b3b88c5b24565 = this.xe7e5c1179f5c7ae1 + (position.Y - this.xcb09bd0cee4909a3.Y);
                    goto label_3;
                case DockStyle.Bottom:
                    goto label_2;
                case DockStyle.Left:
                    this.x0d4b3b88c5b24565 = this.xe7e5c1179f5c7ae1 + (position.X - this.xcb09bd0cee4909a3.X);
                    goto label_3;
                case DockStyle.Right:
                    this.x0d4b3b88c5b24565 = this.xe7e5c1179f5c7ae1 + (this.xcb09bd0cee4909a3.X - position.X);
                    goto label_3;
                default:
                    goto label_3;
            }
            label_17:
            if (!this.x2ee8392f53a01b93.x61c108cc44ef385a)
            {
                if (0 == 0)
                {
                    if (position.Y < this.xffa8345bf918658d)
                        goto label_15;
                    label_10:
                    if (position.Y > this.xb646339c3b9e735a)
                    {
                        position.Y = this.xb646339c3b9e735a;
                        if (0 == 0)
                        {
                            if (3 != 0)
                                goto label_5;
                            else
                                goto label_6;
                        }
                        else
                            goto label_3;
                    }
                    else if (0 == 0)
                        goto label_5;
                    else
                        goto label_25;
                    label_15:
                    if (-1 != 0)
                    {
                        position.Y = this.xffa8345bf918658d;
                        goto label_10;
                    }
                    else
                        goto label_7;
                }
                else
                    goto label_2;
            }
            else
                goto label_20;
            label_18:
            rectangle = new Rectangle(position.X - 2, 0, 4, this.x5fea292ffeb2c28c.Height);
            goto label_6;
            label_20:
            if (position.X >= this.xffa8345bf918658d)
            {
                if (-1 != 0)
                    goto label_23;
            }
            else
                goto label_25;
            label_22:
            position.X = this.xb646339c3b9e735a;
            goto label_18;
            label_23:
            if (position.X <= this.xb646339c3b9e735a)
            {
                if (int.MinValue != 0)
                    goto label_18;
            }
            else
                goto label_22;
            label_25:
            position.X = this.xffa8345bf918658d;
            goto label_23;
        }

        public override void Commit()
        {
            base.Commit();
            if (this.x67ecc0d0e7c9a202 == null)
                return;
            this.x67ecc0d0e7c9a202(this.x0d4b3b88c5b24565);
        }

        public delegate void ResizingManagerFinishedEventHandler(int newSize);
    }
}
