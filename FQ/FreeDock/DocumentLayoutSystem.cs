using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using FQ.FreeDock.Rendering;

namespace FQ.FreeDock
{
    /// <summary>
    /// A layout system for presenting DockControls in a tabbed mdi interface.
    /// 
    /// </summary>
    /// 
    /// <remarks>
    /// 
    /// <para>
    /// This class extends <see cref="T:TD.SandDock.ControlLayoutSystem"/> to provide tabbed mdi functionality.
    /// </para>
    /// 
    /// </remarks>
    public class DocumentLayoutSystem : ControlLayoutSystem
    {
        private const int x1e9b7c427b6c44fa = 14;
        private const int x26539fe4604823df = 15;
        private const int x088e2ac38f89d005 = 17;
        private int x200b7f5a9d983ba4;
        private int x4f8ccd50477a481e;
        private Timer timer;
        private DockControl x9241b98e8e24ab0c;
        private SandDockButton leftScrollButton;
        private SandDockButton rightScrollButton;
        private SandDockButton closeButton;
        private SandDockButton activeFilesButton;

        private DocumentOverflowMode DocumentOverflow
        {
            get
            {
                DocumentContainer dc = this.DockContainer as DocumentContainer;
                return dc != null ? dc.DocumentOverflow : DocumentOverflowMode.Scrollable;
            }
        }

        private bool IntegralClose
        {
            get
            {
                DocumentContainer dc = this.DockContainer as DocumentContainer;
                return dc != null ? dc.IntegralClose : false;
            }
        }

        private DockControl xfccaf77d66322943
        {
            get
            {
                return this.x9241b98e8e24ab0c;
            }
            set
            {
                if (value == this.x9241b98e8e24ab0c)
                    return;
                if (this.DockContainer == null)
                    this.x9241b98e8e24ab0c = value;
                if (this.x9241b98e8e24ab0c != null)
                    this.DockContainer.Invalidate(this.x9241b98e8e24ab0c.tabBounds);
            }
        }

        /// <summary>
        /// The area occupied by the left scroll button.
        /// 
        /// </summary>
        public Rectangle LeftScrollButtonBounds
        {
            get
            {
                return this.leftScrollButton.Bounds;
            }
        }

        /// <summary>
        /// The area occupied by the right scroll button.
        /// 
        /// </summary>
        public Rectangle RightScrollButtonBounds
        {
            get
            {
                return this.rightScrollButton.Bounds;
            }
        }

        /// <summary>
        /// Overridden.
        /// 
        /// </summary>
        public override bool Collapsed
        {
            get
            {
                return false;
            }
            set
            {
            }
        }

        /// <summary>
        /// Overridden.
        /// 
        /// </summary>
        protected virtual int LeftPadding
        {
            get
            {
                return 0;
            }
        }

        /// <summary>
        /// Overridden.
        /// 
        /// </summary>
        protected virtual int RightPadding
        {
            get
            {
                if (this.leftScrollButton.Enabled)
                    return this.Bounds.Right - this.leftScrollButton.Bounds.Left;
                if (this.activeFilesButton.Enabled)
                    return this.Bounds.Right - this.activeFilesButton.Bounds.Left;
                if (this.closeButton.Enabled)
                    return this.Bounds.Right - this.closeButton.Bounds.Left;
                return 0;
//
//                if (!this.leftScrollButton.Enabled)
//                {
//                    if (this.x361886ff08483890.Enabled)
//                        return this.Bounds.Right - this.x361886ff08483890.Bounds.Left;
//                }
//                else
//                    goto label_6;
//                label_3:
//                if (0 == 0)
//                {
//                    if (!this.x26e80f23e22a05ae.Enabled)
//                        return 0;
//                }
//                else if (-1 == 0)
//                    goto label_6;
//                return this.Bounds.Right - this.x26e80f23e22a05ae.Bounds.Left;
//                label_6:
//                if ((int)byte.MaxValue != 0)
//                    return this.Bounds.Right - this.leftScrollButton.Bounds.Left;
//                else
//                    goto label_3;
            }
        }

        /// <summary>
        /// Overridden.
        /// 
        /// </summary>
        // reviewed with 2.4
        public override DockControl SelectedControl
        {
            get
            {
                return base.SelectedControl;
            }
            set
            {
                base.SelectedControl = value;
                if (value == null || this.DockContainer == null)
                    return;
                if (this.DockContainer.IsHandleCreated)
                    this.DockContainer.BeginInvoke((Delegate)new EventHandler(this.x71ad9ee77d4aa721), new object[2]);
            }
        }

        /// <summary>
        /// Initializes a new instance of the DocumentLayoutSystem class.
        /// 
        /// </summary>
        public DocumentLayoutSystem()
        {
            this.leftScrollButton = new SandDockButton();
            this.rightScrollButton = new SandDockButton();
            this.closeButton = new SandDockButton();
            this.activeFilesButton = new SandDockButton();
            this.timer = new Timer();
            this.timer.Interval = 20;
            this.timer.Tick += new EventHandler(this.OnTimerTick);
        }

        /// <summary>
        /// Initializes a new instance of the DocumentLayoutSystem class, with the specified initial dimensions.
        /// 
        /// </summary>
        /// <param name="desiredWidth">The desired width of this layout system, in pixels.</param><param name="desiredHeight">The desired height of this layout system, in pixels.</param>
        public DocumentLayoutSystem(int desiredWidth, int desiredHeight) : this()
        {
            this.WorkingSize = new SizeF(desiredWidth, desiredHeight);
        }

        /// <summary>
        /// Initializes a new instance of the DocumentLayoutSystem class, with the specified initial dimensions, and with the specified child controls.
        /// 
        /// </summary>
        /// <param name="desiredWidth">The desired width of this layout system, in pixels.</param><param name="desiredHeight">The desired height of this layout system, in pixels.</param><param name="controls">An array of DockControls to populate this layout system with.</param><param name="selectedControl">The control to be made selected.</param>
        [Obsolete("Use the constructor that takes a SizeF instead.")]
        public DocumentLayoutSystem(int desiredWidth, int desiredHeight, DockControl[] controls, DockControl selectedControl) : this(desiredWidth, desiredHeight)
        {
            this.Controls.AddRange(controls);
            if (selectedControl != null)
                this.SelectedControl = selectedControl;
        }

        /// <summary>
        /// Initializes a new instance of the DocumentLayoutSystem class, with the specified working size, and with the specified child controls.
        /// 
        /// </summary>
        /// <param name="workingSize">The working size of the layout system.</param><param name="windows">An array of DockControls to populate this layout system with.</param><param name="selectedWindow">The control to be made selected.</param>
        public DocumentLayoutSystem(SizeF workingSize, DockControl[] windows, DockControl selectedWindow) : this()
        {
            this.WorkingSize = workingSize;
            this.Controls.AddRange(windows);
            if (selectedWindow != null)
                this.SelectedControl = selectedWindow;
        }

        /// <summary>
        /// Overridden. Consult the documentation on the base virtual member for more information.
        /// 
        /// </summary>
        protected internal override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            if (e.Button != MouseButtons.None)
                return;
            this.xfccaf77d66322943 = this.GetControlAt(new Point(e.X, e.Y));
        }

        /// <summary>
        /// Overridden. Consult the documentation on the base virtual member for more information.
        /// 
        /// </summary>
        protected internal override void OnMouseLeave()
        {
            base.OnMouseLeave();
            this.xfccaf77d66322943 = null;
        }

        internal override string xe0e7b93bedab6c05(Point position)
        {
            SandDockButton x0a9f5257a10031b2 = this.GetTitleBarButtonAt(position.X, position.Y);
            if (x0a9f5257a10031b2 == this.leftScrollButton)
                return SandDockLanguage.ScrollLeftText;
            if (x0a9f5257a10031b2 == this.rightScrollButton)
                return SandDockLanguage.ScrollRightText;
            if (x0a9f5257a10031b2 == this.closeButton)
                return SandDockLanguage.CloseText;
            if (x0a9f5257a10031b2 == this.activeFilesButton)
                return SandDockLanguage.ActiveFilesText;
            else
                return base.xe0e7b93bedab6c05(position);
        }
        // reviwed with 2.4
        internal override void x46ff430ed3944e0f(xedb4922162c60d3d.DockTarget target)
        {
            base.x46ff430ed3944e0f(target);
            if (target != null && target.type == xedb4922162c60d3d.DockTargetType.None)
                return;
            if (this.SelectedControl == null || !this.IsInContainer)
                return;
            Point position = this.SelectedControl.PointToClient(Cursor.Position);
            this.DockContainer.x8ba6fce4f4601549(new ShowControlContextMenuEventArgs(this.SelectedControl, position, ContextMenuContext.Other));
        }

        internal override void x11e90588eb0baaf1(SandDockButton button)
        {
            if (button != this.leftScrollButton && button != this.rightScrollButton)
                return;
            this.xcf8b319f2bffca87();
        }
        // reviewed  with 2.4
        internal override void xa82f7b310984e03e(SandDockButton button)
        {
            if (button == this.closeButton)
                this.OnCloseButtonClick(new CancelEventArgs());
            if (button == this.leftScrollButton || button == this.rightScrollButton)
                this.xd11b6d3bf98020cb();
            else
            {
                if (button != this.activeFilesButton || this.DockContainer == null || this.DockContainer.Manager == null)
                    return;
                DockControl[] array = new DockControl[this.Controls.Count];
                this.Controls.CopyTo(array, 0);
                this.DockContainer.Manager.OnShowActiveFilesList(new ActiveFilesListEventArgs(array, this.DockContainer, new Point(this.activeFilesButton.Bounds.X, this.activeFilesButton.Bounds.Bottom)));
            }
        }
        // reviewed with 2.4
        internal override SandDockButton GetTitleBarButtonAt(int x, int y)
        {
            if (this.leftScrollButton.Enabled && this.leftScrollButton.x2fef7d841879a711 && this.leftScrollButton.Bounds.Contains(x, y))
                return this.leftScrollButton;
            if (this.rightScrollButton.Enabled && (this.rightScrollButton.x2fef7d841879a711 && this.rightScrollButton.Bounds.Contains(x, y)))
                return this.rightScrollButton;
            if (this.closeButton.Enabled && this.closeButton.x2fef7d841879a711 && this.closeButton.Bounds.Contains(x, y))
                return this.closeButton;
            if (this.activeFilesButton.Enabled && this.activeFilesButton.x2fef7d841879a711 && this.activeFilesButton.Bounds.Contains(x, y))
                return this.activeFilesButton;
            return null;
        }

        internal override void xd541e2fc281b554b()
        {
            if (this.DockContainer == null)
                return;
            this.DockContainer.Invalidate(this.tabstripBounds);
        }
        // reviewed with 2.4
        internal override void x84b6f3c22477dacb(RendererBase render, Graphics g, Font font)
        {
            render.DrawDocumentStripBackground(g, this.tabstripBounds);

            if (this.SelectedControl != null)
                render.DrawDocumentClientBackground(g, this.clientBounds, this.SelectedControl.BackColor);
            else
                render.DrawDocumentClientBackground(g, this.clientBounds, SystemColors.Control);
            Region clip = g.Clip;
            Rectangle rect = this.tabstripBounds;
            rect.X += this.LeftPadding;
            rect.Width -= this.LeftPadding;
            rect.Width -= this.RightPadding;
            g.SetClip(rect);
            for (int index = this.Controls.Count - 1; index >= 0; --index)
            {
                DockControl dockControl = this.Controls[index];
                this.xc33f5f7a18a754cb(render, g, dockControl.Font, dockControl);
            }
            if (this.SelectedControl != null)
                this.xc33f5f7a18a754cb(render, g, this.SelectedControl.Font, this.SelectedControl);
            if (this.IntegralClose)
                this.xb30ec7cfdf3e5c19(g, render, this.closeButton, SandDockButtonType.Close, true);
            g.Clip = clip;
            if (!this.IntegralClose)
                this.xb30ec7cfdf3e5c19(g, render, this.closeButton, SandDockButtonType.Close, true);
            this.xb30ec7cfdf3e5c19(g, render, this.rightScrollButton, SandDockButtonType.ScrollRight, this.rightScrollButton.x2fef7d841879a711);
            this.xb30ec7cfdf3e5c19(g, render, this.leftScrollButton, SandDockButtonType.ScrollLeft, this.leftScrollButton.x2fef7d841879a711);
            this.xb30ec7cfdf3e5c19(g, render, this.activeFilesButton, SandDockButtonType.ActiveFiles, true);
        }
        // reviewed with 2.4
        private void xc33f5f7a18a754cb(RendererBase render, Graphics g, Font font, DockControl dockControl)
        {
            DrawItemState state = DrawItemState.Default;
            if (this.SelectedControl == dockControl)
            {
                state |= DrawItemState.Selected;
                if (this.DockContainer.Manager != null && this.DockContainer.Manager.ActiveTabbedDocument == dockControl)
                    state |= DrawItemState.Focus;
            }
            if (this.x9241b98e8e24ab0c == dockControl)
                state |= DrawItemState.HotLight;
            if (!dockControl.Enabled)
                state |= DrawItemState.Disabled;

            bool drawSeparator = true;
            if (this.SelectedControl != null && this.Controls.IndexOf(dockControl) == this.Controls.IndexOf(this.SelectedControl) - 1)
                drawSeparator = false;

            Rectangle tabBounds = dockControl.TabBounds;
            if (this.IntegralClose && dockControl.AllowClose)
                tabBounds.Width -= 17;

            if ((state & DrawItemState.Focus) == DrawItemState.Focus)
            {
                using (Font FocusFont = new Font(font, FontStyle.Bold))
                    render.DrawDocumentStripTab(g, dockControl.tabBounds, tabBounds, dockControl.TabImage, dockControl.TabText, FocusFont, dockControl.BackColor, dockControl.ForeColor, state, drawSeparator);
            }
            else
                render.DrawDocumentStripTab(g, dockControl.tabBounds, tabBounds, dockControl.TabImage, dockControl.TabText, font, dockControl.BackColor, dockControl.ForeColor, state, drawSeparator);
        }

        /// <summary>
        /// Overridden.
        /// 
        /// </summary>
        public override DockControl GetControlAt(System.Drawing.Point position)
        {
            if (this.tabstripBounds.Contains(position) && (position.X < this.tabstripBounds.X + this.LeftPadding || position.X > this.tabstripBounds.Right - this.RightPadding))
                return null;
            else
                return base.GetControlAt(position);
        }

        /// <summary>
        /// Overridden.
        /// 
        /// </summary>
        protected override void CalculateLayout(RendererBase renderer, Rectangle bounds, bool floating, out Rectangle titlebarBounds, out Rectangle tabstripBounds, out Rectangle clientBounds, out Rectangle joinCatchmentBounds)
        {
            titlebarBounds = Rectangle.Empty;
            tabstripBounds = bounds;
            tabstripBounds.Height = renderer.DocumentTabStripSize;
            bounds.Offset(0, renderer.DocumentTabStripSize);
            bounds.Height -= renderer.DocumentTabStripSize;
            clientBounds = bounds;
            joinCatchmentBounds = tabstripBounds;
        }

        /// <summary>
        /// Overridden.
        /// 
        /// </summary>
        protected internal override void Layout(RendererBase renderer, Graphics graphics, Rectangle bounds, bool floating)
        {
            base.Layout(renderer, graphics, bounds, floating);
            this.xd00751399198ecd1(renderer, graphics, this.tabstripBounds);
            this.x5d6e30ce9634c49e(renderer, graphics, this.tabstripBounds);
        }
        // reviewed with 2.4
        private void xd00751399198ecd1(RendererBase renderer, Graphics g, Rectangle bounds)
        {
            int y = bounds.Top + bounds.Height / 2 - 7;
            int num1 = bounds.Right - 2;
            if (this.SelectedControl != null && this.SelectedControl.AllowClose && !this.IntegralClose)
            {
                this.closeButton.Enabled = true;
                this.closeButton.Bounds = new Rectangle(num1 - 14, y, 14, 15);
                num1 -= 15;
            }
            else
                this.closeButton.Enabled = false;

            this.rightScrollButton.Enabled = false;
            this.leftScrollButton.Enabled = false;
            this.activeFilesButton.Enabled = false;
            switch (this.DocumentOverflow)
            {
                case DocumentOverflowMode.Scrollable:
                    this.rightScrollButton.Enabled = true;
                    this.rightScrollButton.Bounds = new Rectangle(num1 - 14, y, 14, 15);
                    num1 -= 15;
                    this.leftScrollButton.Enabled = true;
                    this.leftScrollButton.Bounds = new Rectangle(num1 - 14, y, 14, 15);
                    num1 -= 15;
                    break;
                case DocumentOverflowMode.Menu:
                    this.activeFilesButton.Enabled = true;
                    this.activeFilesButton.Bounds = new Rectangle(num1 - 14, y, 14, 15);
                    int num2 = num1 - 15;
                    break;
            }
        }

        // reviewed with 2.4
        private void x5d6e30ce9634c49e(RendererBase render, Graphics g, Rectangle bounds)
        {
            int x = 3;
            foreach (DockControl dockControl in this.Controls)
            {
                dockControl.xcfac6723d8a41375 = false;
                DrawItemState state = DrawItemState.Default;
                if (this.SelectedControl == dockControl)
                {
                    state |= DrawItemState.Selected;
                    if (this.DockContainer.Manager != null && this.DockContainer.Manager.ActiveTabbedDocument == dockControl)
                        state |= DrawItemState.Focus;
                }
                int num1 = render.MeasureDocumentStripTab(g, dockControl.TabImage, dockControl.TabText, dockControl.Font, state).Width;
                if (this.IntegralClose && dockControl.AllowClose)
                    num1 += 17;
                if (dockControl.MinimumTabWidth != 0)
                    num1 = Math.Max(num1, dockControl.MinimumTabWidth);
                if (dockControl.MaximumTabWidth != 0 && dockControl.MaximumTabWidth < num1)
                {
                    num1 = dockControl.MaximumTabWidth;
                    dockControl.xcfac6723d8a41375 = true;
                }
                dockControl.tabBounds = new Rectangle(x, bounds.Bottom - render.DocumentTabSize, num1, render.DocumentTabSize);
                x += num1 - render.DocumentTabExtra + 1;
            }
    
            if (this.Controls.Count != 0)
                x += render.DocumentTabExtra;
            this.x4f8ccd50477a481e = x + 3 - (bounds.Width - this.LeftPadding - this.RightPadding);
            if (this.x4f8ccd50477a481e < 0)
                this.x4f8ccd50477a481e = 0;
            if (this.x200b7f5a9d983ba4 > this.x4f8ccd50477a481e)
                this.x200b7f5a9d983ba4 = this.x4f8ccd50477a481e;
            this.leftScrollButton.x2fef7d841879a711 = this.x200b7f5a9d983ba4 > 0;
            this.rightScrollButton.x2fef7d841879a711 = this.x200b7f5a9d983ba4 < this.x4f8ccd50477a481e;
            foreach (DockControl dc in this.Controls)
            {

                Rectangle rectangle = dc.tabBounds;
                rectangle.Offset(bounds.Left + this.LeftPadding - this.x200b7f5a9d983ba4, 0);
                dc.tabBounds = rectangle;
            }
            if (!this.IntegralClose || this.SelectedControl == null || !this.SelectedControl.AllowClose)
                return;
            this.closeButton.Enabled = true;
            Rectangle rectangle1 = this.SelectedControl.tabBounds;
            this.closeButton.Bounds = new Rectangle(rectangle1.Right - 17, rectangle1.Top + 2, 14, rectangle1.Height - 3);
        }

        private void x71ad9ee77d4aa721(object sender, EventArgs e)
        {
            if (this.DockContainer == null || this.SelectedControl == null)
                return;
            this.xd4949976eef9c304(this.SelectedControl);
        }
        // reviewed with 2.4
        private void xd4949976eef9c304(DockControl dockControl)
        {
            if (this.x4f8ccd50477a481e <= 0)
                return;
            Rectangle rectangle = dockControl.tabBounds;
            int num3 = this.tabstripBounds.Right - this.RightPadding;
            int num4 = this.tabstripBounds.Left + this.LeftPadding;
            int num5 = num3 - num4;
            int xa00f04d8b3a6664c = 0;
            if (rectangle.Right > num3)
                xa00f04d8b3a6664c = rectangle.Right - num5 + 30;
            if (rectangle.Left < num4)
                xa00f04d8b3a6664c = rectangle.Left - num4 - 30;
            this.x523c1f22a806032d(xa00f04d8b3a6664c);
        }

        private void xd11b6d3bf98020cb()
        {
            this.timer.Enabled = false;
            this.HighlightedButton = null;
            this.xfa5e20eb950b9ee1 = false;
            this.xd541e2fc281b554b();
        }

        private void xcf8b319f2bffca87()
        {
            this.timer.Enabled = true;
            this.OnTimerTick(this.timer, EventArgs.Empty);
        }
        // reviewed with 2.4
        private void x523c1f22a806032d(int xa00f04d8b3a6664c)
        {
            this.x200b7f5a9d983ba4 += xa00f04d8b3a6664c;
            if (this.x200b7f5a9d983ba4 > this.x4f8ccd50477a481e)
            {
                this.x200b7f5a9d983ba4 = this.x4f8ccd50477a481e;
                this.xd11b6d3bf98020cb();
            }
            if (this.x200b7f5a9d983ba4 < 0)
            {     
                this.x200b7f5a9d983ba4 = 0;
                this.xd11b6d3bf98020cb();   
            }
            this.x3e0280cae730d1f2();
        }

        private void OnTimerTick(object sender, EventArgs e)
        {
            if (this.HighlightedButton == this.leftScrollButton)
                this.x523c1f22a806032d(-15);
            else if (this.HighlightedButton == this.rightScrollButton)
                this.x523c1f22a806032d(15);
            else
                this.xd11b6d3bf98020cb();
        }
    }
}
