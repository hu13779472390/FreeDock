using System;
using System.Collections;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;
using System.Windows.Forms.Design;
using FQ.FreeDock;

namespace FQ.FreeDock.Design
{
    class DockContainerDesigner : ParentControlDesigner
    {
        private Point x6afebf16b45c02e0 = Point.Empty;
        private DockContainer x0467b00af7810f0c;
        private DockControl xaaafffc15ba630b7;
        private xedb4922162c60d3d x531514c39973cbc6;
        private x8e80e1c8bce8caf7 x372569d2ea29984e;
        private x09c1c18390e52ebf x754f1c6f433be75d;
        private IComponentChangeService x4cd3df9bd5e139a3;
        private IDesignerHost xff9c60b45aa37b1e;

        [Browsable(false)]
        [DefaultValue(false)]
        protected override bool DrawGrid
        {
            get
            {
                return false;
            }
            set
            {
                base.DrawGrid = value;
            }
        }

        public override SelectionRules SelectionRules
        {
            get
            {
                return SelectionRules.Visible;
            }
        }

        public DockContainerDesigner()
        {
            this.EnableDragDrop(false);
        }

        private DockControl x37c93a224e23ba95(System.Drawing.Point x13d4cb8d1bd20347)
        {
            LayoutSystemBase layoutSystemAt = this.x0467b00af7810f0c.GetLayoutSystemAt(x13d4cb8d1bd20347);
            if (layoutSystemAt is ControlLayoutSystem)
                return ((ControlLayoutSystem)layoutSystemAt).GetControlAt(x13d4cb8d1bd20347);
            else
                return (DockControl)null;
        }

        protected override void OnMouseDragBegin(int x, int y)
        {
            ISelectionService selectionService = (ISelectionService)this.GetService(typeof(ISelectionService));
            System.Drawing.Point point = this.x0467b00af7810f0c.PointToClient(new System.Drawing.Point(x, y));
            LayoutSystemBase layoutSystemAt = this.x0467b00af7810f0c.GetLayoutSystemAt(point);
            ControlLayoutSystem controlLayoutSystem = null;
            IComponentChangeService componentChangeService = null;
            DockControl controlAt = null;
            label_34:
            do
            {
                if ((uint)x + (uint)y >= 0U)
                    goto label_30;
                else
                    goto label_35;
                label_2:
                SplitLayoutSystem splitLayout;
                if (splitLayout.x090b65ef9b096e0b(point.X, point.Y))
                {
                    LayoutSystemBase xc13a8191724b6d55;
                    LayoutSystemBase x5aa50bbadb0a1e6c;
                    splitLayout.x5a3264f7eba0fe4f(point, out xc13a8191724b6d55, out x5aa50bbadb0a1e6c);
                    this.x372569d2ea29984e = new x8e80e1c8bce8caf7(this.x0467b00af7810f0c, splitLayout, xc13a8191724b6d55, x5aa50bbadb0a1e6c, point, DockingHints.TranslucentFill);
                    this.x372569d2ea29984e.x868a32060451dd2e += new EventHandler(this.xfae511fd7c4fb447);
                    if ((uint)x + (uint)y <= uint.MaxValue)
                    {
                        if ((y & 0) != 0)
                            goto label_23;
                        else
                            goto label_32;
                    }
                    else
                        goto label_21;
                }
                label_3:
                selectionService.SetSelectedComponents((ICollection)new object[1]
                {
                    (object)this.x0467b00af7810f0c
                }, SelectionTypes.MouseDown | SelectionTypes.Click);
                if (3 != 0)
                    goto label_19;
                else
                    goto label_16;
                label_4:
                controlAt = null;
                if (controlAt != null)
                {
                    if ((uint)y + (uint)x > uint.MaxValue)
                        goto label_14;
                }
                else
                    goto label_5;
                label_9:
                controlLayoutSystem = null;
                while (controlLayoutSystem.SelectedControl != null)
                {
                    selectionService.SetSelectedComponents((ICollection)new object[1]
                    {
                        (object)controlLayoutSystem.SelectedControl
                    }, SelectionTypes.Click);
                    if (0 == 0)
                    {
                        if ((uint)x + (uint)x <= uint.MaxValue)
                        {
                            if ((uint)y > uint.MaxValue)
                                goto label_28;
                            else
                                break;
                        }
                        else
                            goto label_11;
                    }
                }
                this.x6afebf16b45c02e0 = new System.Drawing.Point(x, y);
                if ((uint)x >= 0U)
                {
                    if ((uint)y >= 0U)
                        goto label_1;
                    else
                        goto label_19;
                }
                else
                    goto label_14;
                label_11:
                if (0 != 0)
                {
                    if (3 == 0)
                        goto label_2;
                    else
                        goto label_4;
                }
                label_14:
                if (!controlLayoutSystem.xb48529af1739dd06.Contains(point))
                    goto label_4;
                else
                    goto label_9;
                label_15:
                componentChangeService = null;
                if (controlAt != null && controlAt.LayoutSystem.SelectedControl != controlAt)
                    componentChangeService = (IComponentChangeService)this.GetService(typeof(IComponentChangeService));
                else
                    goto label_14;
                label_16:
                if (int.MinValue != 0)
                {
                    componentChangeService.OnComponentChanging((object)this.x0467b00af7810f0c, (MemberDescriptor)TypeDescriptor.GetProperties((object)this.x0467b00af7810f0c)["LayoutSystem"]);
                    controlAt.LayoutSystem.SelectedControl = controlAt;
                    componentChangeService.OnComponentChanged((object)this.x0467b00af7810f0c, (MemberDescriptor)TypeDescriptor.GetProperties((object)this.x0467b00af7810f0c)["LayoutSystem"], (object)null, (object)null);
                    if ((uint)y + (uint)x < 0U)
                        goto label_15;
                    else
                        goto label_11;
                }
                else
                    goto label_30;
                label_19:
                continue;
                label_22:
                if (this.x0467b00af7810f0c.x0c42f19be578ccee != Rectangle.Empty && this.x0467b00af7810f0c.x0c42f19be578ccee.Contains(point))
                {
                    if ((y | 1) != 0)
                    {
                        this.x754f1c6f433be75d = new x09c1c18390e52ebf(this.x0467b00af7810f0c.Manager, this.x0467b00af7810f0c, point);
                        this.x754f1c6f433be75d.x868a32060451dd2e += new EventHandler(this.x30c28c62b1a6040e);
                        this.x754f1c6f433be75d.x67ecc0d0e7c9a202 += new x09c1c18390e52ebf.ResizingManagerFinishedEventHandler(this.xa7afb2334769edc5);
                        if ((uint)y + (uint)x <= uint.MaxValue)
                            goto label_25;
                        else
                            goto label_16;
                    }
                    else
                        goto label_28;
                }
                label_23:
                if (layoutSystemAt is ControlLayoutSystem)
                {
                    controlLayoutSystem = (ControlLayoutSystem)layoutSystemAt;
                    controlAt = controlLayoutSystem.GetControlAt(point);
                    goto label_15;
                }
                else
                    goto label_3;
                label_28:
                if ((y & 0) == 0)
                    goto label_22;
                label_30:
                if (!(layoutSystemAt is SplitLayoutSystem))
                    goto label_22;
                label_35:
                splitLayout = (SplitLayoutSystem)layoutSystemAt;
                goto label_2;
            }
            while ((uint)y < 0U);
            goto label_29;
            label_5:
            selectionService.SetSelectedComponents((ICollection)new object[1]
            {
                (object)this.x0467b00af7810f0c
            }, SelectionTypes.MouseDown | SelectionTypes.Click);
            this.x0467b00af7810f0c.Capture = true;
            return;
            label_1:
            return;
            label_29:
            return;
            label_25:
            this.x0467b00af7810f0c.Capture = true;
            return;
            label_32:
            do
            {
                this.x372569d2ea29984e.x67ecc0d0e7c9a202 += new x8e80e1c8bce8caf7.SplittingManagerFinishedEventHandler(this.xc555e814c1720baf);
                this.x0467b00af7810f0c.Capture = true;
                if (3 != 0)
                    goto label_37;
            }
            while ((uint)y > uint.MaxValue);
            goto label_34;
            label_37:
            return;
            label_21:
            ;
        }

        private void x1b91eb6f6bb77abc()
        {
            this.x754f1c6f433be75d.x868a32060451dd2e -= new EventHandler(this.x30c28c62b1a6040e);
            this.x754f1c6f433be75d.x67ecc0d0e7c9a202 -= new x09c1c18390e52ebf.ResizingManagerFinishedEventHandler(this.xa7afb2334769edc5);
            this.x754f1c6f433be75d = (x09c1c18390e52ebf)null;
        }

        private void xa7afb2334769edc5(int x0d4b3b88c5b24565)
        {
            this.x1b91eb6f6bb77abc();
            DesignerTransaction transaction = this.xff9c60b45aa37b1e.CreateTransaction("Resize Docked Windows");
            do
            {
                this.RaiseComponentChanging((MemberDescriptor)TypeDescriptor.GetProperties((object)this.Component)["ContentSize"]);
                this.x0467b00af7810f0c.ContentSize = x0d4b3b88c5b24565;
                this.RaiseComponentChanged((MemberDescriptor)TypeDescriptor.GetProperties((object)this.Component)["ContentSize"], (object)null, (object)null);
            }
            while (0 != 0);
            transaction.Commit();
        }

        private void x30c28c62b1a6040e(object xe0292b9ed559da7d, EventArgs xfbf34718e704c6bc)
        {
            this.x1b91eb6f6bb77abc();
        }

        protected override void OnMouseDragEnd(bool cancel)
        {
            this.x6afebf16b45c02e0 = System.Drawing.Point.Empty;
            try
            {
                if (this.x372569d2ea29984e != null)
                {


                    this.x372569d2ea29984e.Commit();
                }
                else
                    goto label_12;
                label_11:
                this.x0467b00af7810f0c.Capture = false;
                return;
                label_12:
                if (this.x754f1c6f433be75d == null)
                {
                    while (this.x531514c39973cbc6 == null)
                    {
                        DockControl dockControl = this.x37c93a224e23ba95(this.x0467b00af7810f0c.PointToClient(Cursor.Position));
                        if (0 == 0)
                        {
                            if (((cancel ? 1 : 0) | 15) != 0 && (0 == 0 && (dockControl == null && this.x0467b00af7810f0c.GetLayoutSystemAt(this.x0467b00af7810f0c.PointToClient(Cursor.Position)) is ControlLayoutSystem)))
                                return;
                            else
                                return;
                        }
                    }
                    this.x531514c39973cbc6.Commit();

                    this.x0467b00af7810f0c.Capture = false;


                }
                else
                {
                    this.x754f1c6f433be75d.Commit();
                    this.x0467b00af7810f0c.Capture = false;
                }
            }
            finally
            {
                if (this.Control != null)
                    this.Control.Capture = false;
            }
        }

        protected override void OnMouseDragMove(int x, int y)
        {
            Rectangle rectangle = Rectangle.Empty;
            System.Drawing.Point position = this.x0467b00af7810f0c.PointToClient(new System.Drawing.Point(x, y));
            if (0 == 0)
                goto label_24;
            else
                goto label_17;
            label_1:
            if (!(this.x6afebf16b45c02e0 != System.Drawing.Point.Empty))
                return;
            rectangle = new Rectangle(this.x6afebf16b45c02e0, SystemInformation.DragSize);
            rectangle.Offset(-SystemInformation.DragSize.Width / 2, -SystemInformation.DragSize.Height / 2);
            if ((uint)x + (uint)x > uint.MaxValue)
                goto label_6;
            label_2:
            if (rectangle.Contains(x, y))
                return;
            else
                goto label_6;
            label_3:
            if ((uint)x + (uint)x >= 0U)
            {
                if ((uint)x + (uint)y > uint.MaxValue || (uint)y >= 0U)
                    return;
                else
                    goto label_15;
            }
            else
                goto label_1;
            label_6:
            this.xe2e0ed61975ce467(this.x0467b00af7810f0c.PointToClient(this.x6afebf16b45c02e0));
            if ((uint)y + (uint)y > uint.MaxValue)
                return;
            this.x6afebf16b45c02e0 = System.Drawing.Point.Empty;
            goto label_3;
            label_15:
            if ((uint)y - (uint)y >= 0U)
            {
                if (this.x531514c39973cbc6.x42f4c234c9358072 != null)
                {
                    if ((uint)x + (uint)x <= uint.MaxValue)
                    {
                        if (this.x531514c39973cbc6.x42f4c234c9358072.type != xedb4922162c60d3d.DockTargetType.None)
                        {
                            Cursor.Current = Cursors.Default;
                            return;
                        }
                    }
                    else
                        goto label_2;
                }
                Cursor.Current = Cursors.No;
                if ((uint)y + (uint)x >= 0U)
                    return;
            }
            label_17:
            if (this.x531514c39973cbc6 != null)
            {
                this.x531514c39973cbc6.OnMouseMove(Cursor.Position);
                goto label_15;
            }
            else
                goto label_1;
            label_24:
            if ((y & 0) == 0)
            {
                if ((uint)x >= 0U)
                {
                    if (this.x372569d2ea29984e == null)
                    {
                        if (this.x754f1c6f433be75d != null)
                            this.x754f1c6f433be75d.OnMouseMove(position);
                        else
                            goto label_17;
                    }
                    else
                        this.x372569d2ea29984e.OnMouseMove(position);
                }
                else
                    goto label_17;
            }
            else
                goto label_3;
        }

        private void xe2e0ed61975ce467(System.Drawing.Point x13d4cb8d1bd20347)
        {
            LayoutSystemBase layoutSystemAt = this.x0467b00af7810f0c.GetLayoutSystemAt(x13d4cb8d1bd20347);
            if ((int)byte.MaxValue != 0)
                goto label_2;
            label_1:
            this.x531514c39973cbc6.x67ecc0d0e7c9a202 += new xedb4922162c60d3d.DockingManagerFinishedEventHandler(this.x46ff430ed3944e0f);
            this.x531514c39973cbc6.x868a32060451dd2e += new EventHandler(this.x0ae87c4881d90427);
            this.x0467b00af7810f0c.Capture = true;
            return;
            label_2:
            while (layoutSystemAt is ControlLayoutSystem && this.x531514c39973cbc6 == null)
            {
                ControlLayoutSystem controlLayoutSystem = (ControlLayoutSystem)layoutSystemAt;
                DockControl controlAt;
                do
                {
                    controlAt = controlLayoutSystem.GetControlAt(x13d4cb8d1bd20347);
                }
                while (0 != 0);
                this.x531514c39973cbc6 = (xedb4922162c60d3d)new x31248f32f85df1dd(this.x0467b00af7810f0c.Manager, this.x0467b00af7810f0c, (LayoutSystemBase)controlLayoutSystem, controlAt, controlLayoutSystem.SelectedControl.MetaData.DockedContentSize, x13d4cb8d1bd20347, DockingHints.TranslucentFill);
                if (0 == 0)
                {
                    if (3 == 0)
                        break;
                    else
                        goto label_1;
                }
            }
        }

        private void xf6aefb7d0abb95ba()
        {
            this.x531514c39973cbc6.x67ecc0d0e7c9a202 -= new xedb4922162c60d3d.DockingManagerFinishedEventHandler(this.x46ff430ed3944e0f);
            this.x531514c39973cbc6.x868a32060451dd2e -= new EventHandler(this.x0ae87c4881d90427);
            this.x531514c39973cbc6 = (xedb4922162c60d3d)null;
        }

        internal virtual void x46ff430ed3944e0f(xedb4922162c60d3d.DockTarget x11d58b056c032b03)
        {
            IComponentChangeService componentChangeService = (IComponentChangeService)this.GetService(typeof(IComponentChangeService));
            bool flag;






            goto label_45;
            label_2:
            bool x49cf4e0157d9436c;
            if (x11d58b056c032b03.type == xedb4922162c60d3d.DockTargetType.AlreadyActioned || ((x49cf4e0157d9436c ? 1 : 0) | 4) == 0)
                return;
            IDesignerHost designerHost;
            DesignerTransaction transaction = designerHost.CreateTransaction("Move DockControl");
            ControlLayoutSystem x6e150040c8d97700;
            DockControl selectedControl;
            ISelectionService selectionService;
            try
            {
                if (this.x0467b00af7810f0c.Manager != null)
                    goto label_36;
                label_35:
                Control control1 = (Control)null;
                goto label_37;
                label_36:
                control1 = this.x0467b00af7810f0c.Manager.DockSystemContainer;
                label_37:
                Control control2 = control1;



                goto label_38;
                label_18:
                componentChangeService.OnComponentChanged((object)this.x0467b00af7810f0c, (MemberDescriptor)TypeDescriptor.GetProperties((object)this.x0467b00af7810f0c)["LayoutSystem"], (object)null, (object)null);
                if (((x49cf4e0157d9436c ? 1 : 0) | 4) != 0)
                {


                }
                else
                    goto label_33;
                label_20:
                if (0 != 0)
                    goto label_14;
                else
                    goto label_21;
                label_5:
                transaction.Commit();
                if (0 == 0)
                    goto label_22;
                label_11:
                if (x11d58b056c032b03.type == xedb4922162c60d3d.DockTargetType.CreateNewContainer)
                {
                    do
                    {
                        if (control2 != null)
                            goto label_8;
                        label_6:
                        x6e150040c8d97700.x6b145af772038ef2(selectedControl.Manager, selectedControl, x49cf4e0157d9436c, x11d58b056c032b03);
                        designerHost.Container.Add((IComponent)selectedControl.LayoutSystem.DockContainer);
                        if (control2 != null)
                        {
                            componentChangeService.OnComponentChanged((object)control2, (MemberDescriptor)TypeDescriptor.GetProperties((object)control2)["Controls"], (object)null, (object)null);
                            continue;
                        }
                        else
                            break;
                        label_8:
                        componentChangeService.OnComponentChanging((object)control2, (MemberDescriptor)TypeDescriptor.GetProperties((object)control2)["Controls"]);
                        goto label_6;
                    }
                    while (int.MaxValue == 0);
                    goto label_5;
                }
                else
                    goto label_5;
                label_14:
                x6e150040c8d97700.x6b145af772038ef2(x11d58b056c032b03.dockContainer.Manager, selectedControl, x49cf4e0157d9436c, x11d58b056c032b03);
                if (((x49cf4e0157d9436c ? 1 : 0) & 0) == 0)
                {
                    componentChangeService.OnComponentChanged((object)x11d58b056c032b03.dockContainer, (MemberDescriptor)TypeDescriptor.GetProperties((object)x11d58b056c032b03.dockContainer)["LayoutSystem"], (object)null, (object)null);
                    goto label_5;
                }
                else
                    goto label_22;
                label_21:
                if (4 != 0)
                {
                    componentChangeService.OnComponentChanged((object)this.x0467b00af7810f0c, (MemberDescriptor)TypeDescriptor.GetProperties((object)this.x0467b00af7810f0c)["Manager"], (object)null, (object)null);
                    if (control2 != null)
                        goto label_16;
                    else
                        goto label_17;
                    label_10:
                    if (x11d58b056c032b03.dockContainer == null)
                        goto label_11;
                    label_13:
                    componentChangeService.OnComponentChanging((object)x11d58b056c032b03.dockContainer, (MemberDescriptor)TypeDescriptor.GetProperties((object)x11d58b056c032b03.dockContainer)["LayoutSystem"]);
                    goto label_14;
                    label_16:
                    componentChangeService.OnComponentChanged((object)control2, (MemberDescriptor)TypeDescriptor.GetProperties((object)control2)["Controls"], (object)null, (object)null);
                    goto label_10;
                    label_17:
                    if (2 != 0)
                        goto label_10;
                    else
                        goto label_13;
                }
                label_22:
                if (0 == 0)
                    return;
                if (0 != 0)
                {
                    if (2 == 0)
                    {

                        goto label_31;
                    }
                    else
                        goto label_32;
                }
                else
                    goto label_35;
                label_26:
                LayoutUtilities.xf1cbd48a28ce6e74(selectedControl);
                goto label_18;
                label_29:
                if (0 != 0 || x49cf4e0157d9436c)
                {
                    LayoutUtilities.x4487f2f8917e3fd0(x6e150040c8d97700);
                    goto label_18;
                }
                else
                    goto label_26;
                label_31:
                if (control2 != null)
                    componentChangeService.OnComponentChanging((object)control2, (MemberDescriptor)TypeDescriptor.GetProperties((object)control2)["Controls"]);
                componentChangeService.OnComponentChanging((object)this.x0467b00af7810f0c, (MemberDescriptor)TypeDescriptor.GetProperties((object)this.x0467b00af7810f0c)["Manager"]);
                componentChangeService.OnComponentChanging((object)this.x0467b00af7810f0c, (MemberDescriptor)TypeDescriptor.GetProperties((object)this.x0467b00af7810f0c)["LayoutSystem"]);
                goto label_29;
                label_32:
                selectionService.SetSelectedComponents((ICollection)new object[1]
                {
                    (object)this.x0467b00af7810f0c.Manager.DockSystemContainer
                }, SelectionTypes.Replace);
                label_33:
                if (((x49cf4e0157d9436c ? 1 : 0) & 0) != 0)
                    goto label_20;
                else
                    goto label_31;
                label_38:
                if (control2 == null)
                {
                    selectionService.SetSelectedComponents((ICollection)new object[1]
                    {
                        (object)designerHost.RootComponent
                    }, SelectionTypes.Replace);
                    goto label_31;
                }
                else
                    goto label_32;
            }
            catch
            {
                transaction.Cancel();
                return;
            }
            label_41:
            this.xf6aefb7d0abb95ba();
            if (x11d58b056c032b03 == null || 0 == 0 && x11d58b056c032b03.type == xedb4922162c60d3d.DockTargetType.None)
                return;
            else
                goto label_2;
            label_44:
            selectionService = (ISelectionService)this.GetService(typeof(ISelectionService));
            x6e150040c8d97700 = (ControlLayoutSystem)this.x531514c39973cbc6.xf333586e50dccad2;
            x49cf4e0157d9436c = this.x531514c39973cbc6.x59ae058c4a0dec87 == null;
            selectedControl = x6e150040c8d97700.SelectedControl;
            goto label_41;
            label_45:
            designerHost = (IDesignerHost)this.GetService(typeof(IDesignerHost));
            if (2 == 0)
                goto label_2;
            else
                goto label_44;
        }

        internal virtual void x0ae87c4881d90427(object xe0292b9ed559da7d, EventArgs xfbf34718e704c6bc)
        {
            this.xf6aefb7d0abb95ba();
        }

        private void x367ada130c39f434()
        {
            this.x372569d2ea29984e.x868a32060451dd2e -= new EventHandler(this.xfae511fd7c4fb447);
            this.x372569d2ea29984e.x67ecc0d0e7c9a202 -= new x8e80e1c8bce8caf7.SplittingManagerFinishedEventHandler(this.xc555e814c1720baf);
            this.x372569d2ea29984e = (x8e80e1c8bce8caf7)null;
        }

        private void xfae511fd7c4fb447(object xe0292b9ed559da7d, EventArgs xfbf34718e704c6bc)
        {
            this.x367ada130c39f434();
        }

        private void xc555e814c1720baf(LayoutSystemBase xc13a8191724b6d55, LayoutSystemBase x5aa50bbadb0a1e6c, float x5c2440c931f8d932, float x4afa341b2323a009)
        {
            SplitLayoutSystem x07bf3386da210f81 = this.x372569d2ea29984e.x07bf3386da210f81;
            label_12:
            this.x367ada130c39f434();
            DesignerTransaction transaction = this.xff9c60b45aa37b1e.CreateTransaction("Resize Docked Windows");
            IComponentChangeService componentChangeService = (IComponentChangeService)this.GetService(typeof(IComponentChangeService));
            componentChangeService.OnComponentChanging((object)this.x0467b00af7810f0c, (MemberDescriptor)TypeDescriptor.GetProperties((object)this.x0467b00af7810f0c)["LayoutSystem"]);
            SizeF workingSize1 = xc13a8191724b6d55.WorkingSize;
            SizeF workingSize2 = x5aa50bbadb0a1e6c.WorkingSize;
            while (x07bf3386da210f81.SplitMode == Orientation.Horizontal)
            {
                workingSize1.Height = x5c2440c931f8d932;
                if (0 == 0)
                {
                    if ((uint)x5c2440c931f8d932 <= uint.MaxValue)
                    {
                        if ((uint)x5c2440c931f8d932 >= 0U)
                            goto label_4;
                    }
                    else
                        goto label_12;
                }
                else
                    goto label_3;
            }
            goto label_5;
            label_3:
            xc13a8191724b6d55.WorkingSize = workingSize1;
            x5aa50bbadb0a1e6c.WorkingSize = workingSize2;
            if ((uint)x5c2440c931f8d932 + (uint)x5c2440c931f8d932 < 0U)
                return;
            else
                goto label_6;
            label_4:
            workingSize2.Height = x4afa341b2323a009;
            goto label_3;
            label_5:
            workingSize1.Width = x5c2440c931f8d932;
            if (int.MaxValue != 0)
            {
                workingSize2.Width = x4afa341b2323a009;
                goto label_3;
            }
            label_6:
            if (-1 == 0)
                return;
            componentChangeService.OnComponentChanged((object)this.x0467b00af7810f0c, (MemberDescriptor)TypeDescriptor.GetProperties((object)this.x0467b00af7810f0c)["LayoutSystem"], (object)null, (object)null);
            transaction.Commit();
            x07bf3386da210f81.x3e0280cae730d1f2();
            if (8 == 0)
                goto label_4;
        }

        protected override void OnSetCursor()
        {
            System.Drawing.Point point = this.x0467b00af7810f0c.PointToClient(Cursor.Position);
            SplitLayoutSystem splitLayoutSystem;
            do
            {
                splitLayoutSystem = this.x0467b00af7810f0c.GetLayoutSystemAt(point) as SplitLayoutSystem;
                if (0 == 0)
                    goto label_14;
                else
                    goto label_24;
                label_1:
                if (this.x0467b00af7810f0c.x0c42f19be578ccee != Rectangle.Empty)
                    goto label_12;
                label_4:
                Cursor.Current = Cursors.Default;
                continue;
                label_8:
                if (0 != 0)
                    goto label_13;
                else
                    goto label_1;
                label_12:
                Rectangle x0c42f19be578ccee = this.x0467b00af7810f0c.x0c42f19be578ccee;
                if (0 == 0)
                {
                    if (!x0c42f19be578ccee.Contains(point))
                    {
                        if (15 == 0)
                            goto label_20;
                        else
                            goto label_4;
                    }
                    else
                        goto label_5;
                }
                label_13:
                if (0 == 0)
                {
                    if (1 != 0)
                    {
                        if (2 != 0)
                        {
                            if (int.MaxValue != 0)
                                goto label_1;
                            else
                                goto label_12;
                        }
                        else
                            goto label_25;
                    }
                    else
                        goto label_8;
                }
                else
                    goto label_18;
                label_14:
                if (splitLayoutSystem != null)
                {
                    if (1 == 0)
                        goto label_4;
                }
                else
                    goto label_18;
                label_16:
                if (!splitLayoutSystem.x090b65ef9b096e0b(point.X, point.Y))
                {
                    if (8 != 0)
                        goto label_13;
                }
                else
                    goto label_20;
                label_18:
                if (3 == 0)
                    goto label_16;
                else
                    goto label_8;
                label_24:
                if (8 == 0 || 15 == 0)
                    goto label_20;
                else
                    goto label_16;
            }
            while (0 != 0);
            goto label_22;
            label_5:
            if (!this.x0467b00af7810f0c.x61c108cc44ef385a)
            {
                Cursor.Current = Cursors.HSplit;
                return;
            }
            else
            {
                Cursor.Current = Cursors.VSplit;
                return;
            }
            label_22:
            return;
            label_25:
            return;
            label_20:
            if (splitLayoutSystem.SplitMode != Orientation.Horizontal)
                Cursor.Current = Cursors.VSplit;
            else
                Cursor.Current = Cursors.HSplit;
        }

        public override void InitializeNewComponent(IDictionary defaultValues)
        {
            base.InitializeNewComponent(defaultValues);
            this.x391093a02bb10339();
        }

        private void x391093a02bb10339()
        {
            IExtenderProvider[] extenderProviders = ((IExtenderListService)this.GetService(typeof(IExtenderListService))).GetExtenderProviders();
            int index = 0;
            while (index < extenderProviders.Length)
            {
                IExtenderProvider extenderProvider = extenderProviders[index];
                if (!(extenderProvider.GetType().FullName == "System.ComponentModel.Design.Serialization.CodeDomDesignerLoader+ModifiersExtenderProvider"))
                    ++index;
                else
                    goto label_9;
                label_6:
                if (0 != 0)
                    continue;
                else
                    continue;
                label_9:
                if (2 != 0)
                {
                    MethodInfo method = extenderProvider.GetType().GetMethod("SetGenerateMember", BindingFlags.Instance | BindingFlags.Public);
                    while (0 == 0 && method == null)
                    {
                        if (0 == 0)
                            return;
                    }
                    method.Invoke((object)extenderProvider, new object[2]
                    {
                        (object)this.Component,
                        (object)false
                    });
                    break;
                }
                else
                    goto label_6;
            }
        }

        public override void Initialize(IComponent component)
        {
            base.Initialize(component);
            if (4 == 0)
            {
                if (0 == 0)
                    goto label_3;
            }
            else
                goto label_6;
            label_2:
            this.x0467b00af7810f0c = (DockContainer)component;
            if (0 == 0)
                return;
            label_3:
            if (!(component is DockContainer))
                goto label_7;
            label_4:
            ISelectionService selectionService = (ISelectionService)this.GetService(typeof(ISelectionService));
            label_5:
            this.x4cd3df9bd5e139a3 = (IComponentChangeService)this.GetService(typeof(IComponentChangeService));
            this.xff9c60b45aa37b1e = (IDesignerHost)this.GetService(typeof(IDesignerHost));
            this.x4cd3df9bd5e139a3.ComponentRemoving += new ComponentEventHandler(this.x97263465e88c9d8e);
            this.x4cd3df9bd5e139a3.ComponentRemoved += new ComponentEventHandler(this.x5c6da9d6db2adc7a);
            goto label_2;
            label_6:
            if (0 == 0)
                goto label_3;
            label_7:
            SandDockLanguage.ShowCachedAssemblyError(component.GetType().Assembly, this.GetType().Assembly);
            if (8 == 0)
            {
                if (0 != 0)
                    goto label_5;
                else
                    goto label_3;
            }
            else
                goto label_4;
        }

        protected override void Dispose(bool disposing)
        {
            ISelectionService selectionService = (ISelectionService)this.GetService(typeof(ISelectionService));
            this.x4cd3df9bd5e139a3.ComponentRemoving += new ComponentEventHandler(this.x97263465e88c9d8e);
            this.x4cd3df9bd5e139a3.ComponentRemoved += new ComponentEventHandler(this.x5c6da9d6db2adc7a);
            base.Dispose(disposing);
        }

        private void x97263465e88c9d8e(object xe0292b9ed559da7d, ComponentEventArgs xfbf34718e704c6bc)
        {
            DockControl dockControl = xfbf34718e704c6bc.Component as DockControl;
            if (0 != 0 || dockControl == null || (dockControl.LayoutSystem == null || dockControl.LayoutSystem.DockContainer != this.x0467b00af7810f0c))
                return;
            this.xaaafffc15ba630b7 = dockControl;
            this.RaiseComponentChanging((MemberDescriptor)TypeDescriptor.GetProperties((object)this.x0467b00af7810f0c)["LayoutSystem"]);
        }

        private void x5c6da9d6db2adc7a(object xe0292b9ed559da7d, ComponentEventArgs xfbf34718e704c6bc)
        {
            if (xfbf34718e704c6bc.Component != this.xaaafffc15ba630b7)
                return;
            this.xaaafffc15ba630b7 = (DockControl)null;
            this.RaiseComponentChanged((MemberDescriptor)TypeDescriptor.GetProperties((object)this.x0467b00af7810f0c)["LayoutSystem"], (object)null, (object)null);
        }
    }
}
