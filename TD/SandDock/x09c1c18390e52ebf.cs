// Type: TD.SandDock.x09c1c18390e52ebf
// Assembly: SandDock, Version=3.0.6.1, Culture=neutral, PublicKeyToken=75b7ec17dd7c14c3
// MVID: 86A16A8A-6BB9-495D-A857-1A3306E497E9
// Assembly location: C:\Program Files (x86)\Divelements Limited\SandDock for Windows Forms\SandDock.dll

using System;
using System.Drawing;
using System.Windows.Forms;

namespace FQ.FreeDock
{
  internal class x09c1c18390e52ebf : x890231ddf317379e
  {
    private DockContainer xd3311d815ca25f02;
    private int xffa8345bf918658d;
    private int xb646339c3b9e735a;
    private int x0d4b3b88c5b24565;
    private int xf623ffb827affd4f;

    public event x09c1c18390e52ebf.ResizingManagerFinishedEventHandler x67ecc0d0e7c9a202;

    public x09c1c18390e52ebf(SandDockManager manager, DockContainer container, System.Drawing.Point startPoint)
      : base((Control) container, manager.DockingHints, false)
    {
      Rectangle rectangle;
      int num1;
      int x555227b0d2a372bd;
      int num2;
      do
      {
        this.xd3311d815ca25f02 = container;
        rectangle = Rectangle.Empty;
        rectangle = xedb4922162c60d3d.xc68a4bb946c59a9e(xedb4922162c60d3d.x41c62f474d3fb367(container.Parent), container.Parent);
        rectangle = new Rectangle(container.PointToClient(rectangle.Location), rectangle.Size);
        int val1;
        if (manager != null)
          val1 = manager.MinimumDockContainerSize;
        else
          goto label_20;
label_19:
        num2 = Math.Max(val1, LayoutUtilities.xc6fb69ef430eaa44(container));
        if (0 == 0)
          goto label_13;
label_11:
        switch (container.Dock)
        {
          case DockStyle.Top:
            do
            {
              this.xffa8345bf918658d = startPoint.Y - (x555227b0d2a372bd - num2);
            }
            while ((uint) num2 - (uint) x555227b0d2a372bd < 0U);
            if ((uint) num2 >= 0U)
            {
              if ((uint) x555227b0d2a372bd + (uint) num1 >= 0U)
              {
                if ((uint) num1 - (uint) x555227b0d2a372bd < 0U)
                  goto label_20;
                else
                  goto label_5;
              }
              else
                goto label_23;
            }
            else
              goto label_14;
          case DockStyle.Bottom:
            goto label_1;
          case DockStyle.Left:
            goto label_12;
          case DockStyle.Right:
            this.xffa8345bf918658d = Math.Max(rectangle.Left + 20, startPoint.X - (num1 - x555227b0d2a372bd));
            continue;
          default:
            goto label_2;
        }
label_13:
        int num3;
        if (manager == null)
        {
          num3 = 500;
          goto label_15;
        }
label_14:
        num3 = manager.MaximumDockContainerSize;
label_15:
        num1 = num3;
        if ((uint) num1 - (uint) num1 >= 0U)
        {
          x555227b0d2a372bd = container.x555227b0d2a372bd;
          goto label_11;
        }
        else
          goto label_11;
label_20:
        val1 = 30;
        goto label_19;
      }
      while ((x555227b0d2a372bd & 0) != 0);
      goto label_6;
label_1:
      this.xffa8345bf918658d = Math.Max(rectangle.Top + 20, startPoint.Y - (num1 - x555227b0d2a372bd));
      this.xb646339c3b9e735a = startPoint.Y + (x555227b0d2a372bd - num2);
      this.xf623ffb827affd4f = startPoint.Y - container.x0c42f19be578ccee.Y;
label_2:
      this.OnMouseMove(startPoint);
      return;
label_5:
      if ((uint) num2 > uint.MaxValue)
        return;
      this.xb646339c3b9e735a = Math.Min(rectangle.Bottom - 20, startPoint.Y + (num1 - x555227b0d2a372bd));
      this.xf623ffb827affd4f = startPoint.Y - container.x0c42f19be578ccee.Y;
      goto label_2;
label_6:
      this.xb646339c3b9e735a = startPoint.X + (x555227b0d2a372bd - num2);
      this.xf623ffb827affd4f = startPoint.X - container.x0c42f19be578ccee.X;
      goto label_2;
label_23:
      return;
label_12:
      this.xffa8345bf918658d = startPoint.X - (x555227b0d2a372bd - num2);
      this.xb646339c3b9e735a = Math.Min(rectangle.Right - 20, startPoint.X + (num1 - x555227b0d2a372bd));
      this.xf623ffb827affd4f = startPoint.X - container.x0c42f19be578ccee.X;
      goto label_2;
    }

    public override void OnMouseMove(System.Drawing.Point position)
    {
      Rectangle rectangle = Rectangle.Empty;
      if (!this.xd3311d815ca25f02.x61c108cc44ef385a)
        goto label_21;
      else
        goto label_26;
label_7:
      this.xe5e4149f382149cc(new Rectangle(this.xd3311d815ca25f02.PointToScreen(rectangle.Location), rectangle.Size), false);
      if (0 != 0)
        return;
      if (this.xd3311d815ca25f02.Dock != DockStyle.Left)
        goto label_2;
label_1:
      Cursor.Current = Cursors.VSplit;
      return;
label_2:
      while (this.xd3311d815ca25f02.Dock != DockStyle.Right)
      {
        Cursor.Current = Cursors.HSplit;
        if (0 != 0)
        {
          if (int.MaxValue == 0)
            break;
        }
        else if (8 != 0)
          return;
        else
          goto label_23;
      }
      goto label_1;
label_10:
      this.x0d4b3b88c5b24565 = this.xd3311d815ca25f02.ContentSize + (rectangle.X - this.xd3311d815ca25f02.x0c42f19be578ccee.X);
      goto label_7;
label_13:
      DockStyle dock = this.xd3311d815ca25f02.Dock;
      if (0 == 0)
      {
        switch (dock)
        {
          case DockStyle.Top:
            this.x0d4b3b88c5b24565 = this.xd3311d815ca25f02.ContentSize + (rectangle.Y - this.xd3311d815ca25f02.x0c42f19be578ccee.Y);
            goto label_7;
          case DockStyle.Bottom:
            this.x0d4b3b88c5b24565 = this.xd3311d815ca25f02.ContentSize + (this.xd3311d815ca25f02.x0c42f19be578ccee.Y - rectangle.Y);
            goto label_7;
          case DockStyle.Left:
            goto label_10;
          case DockStyle.Right:
            this.x0d4b3b88c5b24565 = this.xd3311d815ca25f02.ContentSize + (this.xd3311d815ca25f02.x0c42f19be578ccee.X - rectangle.X);
            goto label_7;
        }
      }
      if (0 != 0)
        return;
      else
        goto label_7;
label_16:
      if (rectangle.X <= this.xb646339c3b9e735a - 4)
      {
        if (0 == 0)
          goto label_13;
      }
      else
      {
        rectangle.X = this.xb646339c3b9e735a - 4;
        goto label_13;
      }
label_17:
      if (rectangle.Y <= this.xb646339c3b9e735a - 4)
        goto label_13;
label_19:
      rectangle.Y = this.xb646339c3b9e735a - 4;
      if (0 == 0)
        goto label_13;
      else
        goto label_16;
label_21:
      rectangle = new Rectangle(0, position.Y - this.xf623ffb827affd4f, this.xd3311d815ca25f02.Width, 4);
      if (rectangle.Y < this.xffa8345bf918658d)
      {
        rectangle.Y = this.xffa8345bf918658d;
        if (2 != 0)
        {
          if (0 == 0)
            goto label_17;
          else
            goto label_19;
        }
        else
          goto label_10;
      }
      else
        goto label_17;
label_23:
      if (rectangle.X < this.xffa8345bf918658d)
        goto label_27;
      else
        goto label_16;
label_26:
      rectangle = new Rectangle(position.X - this.xf623ffb827affd4f, 0, 4, this.xd3311d815ca25f02.Height);
      if (0 == 0)
        goto label_23;
label_27:
      rectangle.X = this.xffa8345bf918658d;
      if (0 != 0)
        goto label_26;
      else
        goto label_16;
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
