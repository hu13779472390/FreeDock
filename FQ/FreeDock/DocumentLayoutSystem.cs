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
        private Timer x5d56ae798b9cdf38;
        private DockControl x9241b98e8e24ab0c;
        private x0a9f5257a10031b2 x49dae83181e41d72;
        private x0a9f5257a10031b2 xa8ae81960654bc0b;
        private x0a9f5257a10031b2 x26e80f23e22a05ae;
        private x0a9f5257a10031b2 x361886ff08483890;

        private DocumentOverflowMode x7d2c5325d16e569d
        {
            get
            {
                DocumentContainer documentContainer = this.DockContainer as DocumentContainer;
                if (documentContainer != null)
                    return documentContainer.x7d2c5325d16e569d;
                else
                    return DocumentOverflowMode.Scrollable;
            }
        }

        private bool xa957e8f86f5e6115
        {
            get
            {
                DocumentContainer documentContainer = this.DockContainer as DocumentContainer;
                if (documentContainer != null)
                    return documentContainer.xa957e8f86f5e6115;
                else
                    return false;
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
                label_2:
                if (this.DockContainer == null)
                    goto label_4;
                label_3:
                if (this.x9241b98e8e24ab0c != null)
                {
                    this.DockContainer.Invalidate(this.x9241b98e8e24ab0c.x123e054dab107457);
                    if (-2 == 0 || 0 != 0)
                        goto label_2;
                }
                label_4:
                this.x9241b98e8e24ab0c = value;
                if (this.DockContainer == null || this.x9241b98e8e24ab0c == null)
                    return;
                this.DockContainer.Invalidate(this.x9241b98e8e24ab0c.x123e054dab107457);
                if (int.MaxValue == 0)
                    goto label_3;
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
                return this.x49dae83181e41d72.xda73fcb97c77d998;
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
                return this.xa8ae81960654bc0b.xda73fcb97c77d998;
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
                if (!this.x49dae83181e41d72.x364c1e3b189d47fe)
                {
                    if (this.x361886ff08483890.x364c1e3b189d47fe)
                        return this.Bounds.Right - this.x361886ff08483890.xda73fcb97c77d998.Left;
                }
                else
                    goto label_6;
                label_3:
                if (0 == 0)
                {
                    if (!this.x26e80f23e22a05ae.x364c1e3b189d47fe)
                        return 0;
                }
                else if (-1 == 0)
                    goto label_6;
                return this.Bounds.Right - this.x26e80f23e22a05ae.xda73fcb97c77d998.Left;
                label_6:
                if ((int)byte.MaxValue != 0)
                    return this.Bounds.Right - this.x49dae83181e41d72.xda73fcb97c77d998.Left;
                else
                    goto label_3;
            }
        }

        /// <summary>
        /// Overridden.
        /// 
        /// </summary>
        public override DockControl SelectedControl
        {
            get
            {
                return base.SelectedControl;
            }
            set
            {
                base.SelectedControl = value;
                if (0 == 0 && value == null)
                {
                    if (0 == 0)
                        return;
                }
                else
                    goto label_7;
                label_2:
                if (!this.DockContainer.IsHandleCreated)
                    return;
                this.DockContainer.BeginInvoke((Delegate)new EventHandler(this.x71ad9ee77d4aa721), new object[2]);
                return;
                label_7:
                if (this.DockContainer == null)
                    return;
                if (0 != 0)
                    goto label_2;
                else
                    goto label_2;
            }
        }

        /// <summary>
        /// Initializes a new instance of the DocumentLayoutSystem class.
        /// 
        /// </summary>
        public DocumentLayoutSystem()
        {
            do
            {
                this.x49dae83181e41d72 = new x0a9f5257a10031b2();
                this.xa8ae81960654bc0b = new x0a9f5257a10031b2();
                if (4 != 0)
                {
                    this.x26e80f23e22a05ae = new x0a9f5257a10031b2();
                    this.x361886ff08483890 = new x0a9f5257a10031b2();
                    this.x5d56ae798b9cdf38 = new Timer();
                }
                this.x5d56ae798b9cdf38.Interval = 20;
                this.x5d56ae798b9cdf38.Tick += new EventHandler(this.xcaf19fd9570f4eb4);
            }
            while (4 == 0);
        }

        /// <summary>
        /// Initializes a new instance of the DocumentLayoutSystem class, with the specified initial dimensions.
        /// 
        /// </summary>
        /// <param name="desiredWidth">The desired width of this layout system, in pixels.</param><param name="desiredHeight">The desired height of this layout system, in pixels.</param>
        public DocumentLayoutSystem(int desiredWidth, int desiredHeight)
      : this()
        {
            this.WorkingSize = new SizeF((float)desiredWidth, (float)desiredHeight);
        }

        /// <summary>
        /// Initializes a new instance of the DocumentLayoutSystem class, with the specified initial dimensions, and with the specified child controls.
        /// 
        /// </summary>
        /// <param name="desiredWidth">The desired width of this layout system, in pixels.</param><param name="desiredHeight">The desired height of this layout system, in pixels.</param><param name="controls">An array of DockControls to populate this layout system with.</param><param name="selectedControl">The control to be made selected.</param>
        [Obsolete("Use the constructor that takes a SizeF instead.")]
        public DocumentLayoutSystem(int desiredWidth, int desiredHeight, DockControl[] controls, DockControl selectedControl)
      : this(desiredWidth, desiredHeight)
        {
            this.Controls.AddRange(controls);
            if (selectedControl == null)
                return;
            this.SelectedControl = selectedControl;
        }

        /// <summary>
        /// Initializes a new instance of the DocumentLayoutSystem class, with the specified working size, and with the specified child controls.
        /// 
        /// </summary>
        /// <param name="workingSize">The working size of the layout system.</param><param name="windows">An array of DockControls to populate this layout system with.</param><param name="selectedWindow">The control to be made selected.</param>
        public DocumentLayoutSystem(SizeF workingSize, DockControl[] windows, DockControl selectedWindow)
      : this()
        {
            this.WorkingSize = workingSize;
            this.Controls.AddRange(windows);
            if (selectedWindow == null)
                return;
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
            this.xfccaf77d66322943 = this.GetControlAt(new System.Drawing.Point(e.X, e.Y));
        }

        /// <summary>
        /// Overridden. Consult the documentation on the base virtual member for more information.
        /// 
        /// </summary>
        protected internal override void OnMouseLeave()
        {
            base.OnMouseLeave();
            this.xfccaf77d66322943 = (DockControl)null;
        }

        internal override string xe0e7b93bedab6c05(System.Drawing.Point x13d4cb8d1bd20347)
        {
            x0a9f5257a10031b2 x0a9f5257a10031b2 = this.x07083a4bfd59263d(x13d4cb8d1bd20347.X, x13d4cb8d1bd20347.Y);
            while (x0a9f5257a10031b2 != this.x49dae83181e41d72)
            {
                if (3 != 0)
                {
                    if (x0a9f5257a10031b2 == this.xa8ae81960654bc0b)
                        return SandDockLanguage.ScrollRightText;
                    if (x0a9f5257a10031b2 == this.x26e80f23e22a05ae)
                        return SandDockLanguage.CloseText;
                    if (x0a9f5257a10031b2 == this.x361886ff08483890)
                        return SandDockLanguage.ActiveFilesText;
                    else
                        return base.xe0e7b93bedab6c05(x13d4cb8d1bd20347);
                }
            }
            return SandDockLanguage.ScrollLeftText;
        }

        internal override void x46ff430ed3944e0f(xedb4922162c60d3d.DockTarget x11d58b056c032b03)
        {
            base.x46ff430ed3944e0f(x11d58b056c032b03);
            while (x11d58b056c032b03 == null || x11d58b056c032b03.type == xedb4922162c60d3d.DockTargetType.None)
            {
                if (this.SelectedControl == null)
                {
                    if (2 != 0)
                        goto label_10;
                }
                else
                    goto label_8;
                label_5:
                System.Drawing.Point position = this.SelectedControl.PointToClient(Cursor.Position);
                if (1 == 0)
                    break;
                this.DockContainer.x8ba6fce4f4601549(new ShowControlContextMenuEventArgs(this.SelectedControl, position, ContextMenuContext.Other));
                if (int.MinValue != 0)
                    break;
                else
                    goto label_10;
                label_8:
                if (!this.IsInContainer)
                    break;
                if (8 != 0)
                    goto label_5;
                label_10:
                if (-2 != 0)
                    break;
            }
        }

        internal override void x11e90588eb0baaf1(x0a9f5257a10031b2 x128517d7ded59312)
        {
            if (x128517d7ded59312 != this.x49dae83181e41d72 && x128517d7ded59312 != this.xa8ae81960654bc0b)
                return;
            this.xcf8b319f2bffca87();
        }

        internal override void xa82f7b310984e03e(x0a9f5257a10031b2 x128517d7ded59312)
        {
            if (x128517d7ded59312 != this.x26e80f23e22a05ae)
                goto label_6;
            else
                goto label_15;
            label_2:
            if (this.DockContainer == null)
            {
                if (0 == 0)
                {
                    if (0 == 0)
                        return;
                    else
                        goto label_15;
                }
            }
            else
                goto label_7;
            label_4:
            DockControl[] dockControlArray;
            if (2 != 0)
            {
                this.DockContainer.Manager.OnShowActiveFilesList(new ActiveFilesListEventArgs(dockControlArray, (Control)this.DockContainer, new System.Drawing.Point(this.x361886ff08483890.xda73fcb97c77d998.X, this.x361886ff08483890.xda73fcb97c77d998.Bottom)));
                return;
            }
            else
                goto label_13;
            label_7:
            if (this.DockContainer.Manager == null)
                return;
            dockControlArray = new DockControl[this.Controls.Count];
            this.Controls.CopyTo(dockControlArray, 0);
            goto label_4;
            label_6:
            if (x128517d7ded59312 != this.x49dae83181e41d72 && x128517d7ded59312 != this.xa8ae81960654bc0b)
            {
                if (x128517d7ded59312 != this.x361886ff08483890)
                    return;
                else
                    goto label_2;
            }
            label_13:
            this.xd11b6d3bf98020cb();
            if (int.MinValue != 0)
                return;
            if (0 == 0)
                goto label_6;
            label_15:
            if (1 != 0)
                this.OnCloseButtonClick((EventArgs)new CancelEventArgs());
            else
                goto label_2;
        }

        internal override x0a9f5257a10031b2 x07083a4bfd59263d(int x08db3aeabb253cb1, int x1e218ceaee1bb583)
        {
            if (this.x49dae83181e41d72.x364c1e3b189d47fe && this.x49dae83181e41d72.x2fef7d841879a711 && this.x49dae83181e41d72.xda73fcb97c77d998.Contains(x08db3aeabb253cb1, x1e218ceaee1bb583))
                return this.x49dae83181e41d72;
            if (this.xa8ae81960654bc0b.x364c1e3b189d47fe && (this.xa8ae81960654bc0b.x2fef7d841879a711 && this.xa8ae81960654bc0b.xda73fcb97c77d998.Contains(x08db3aeabb253cb1, x1e218ceaee1bb583)))
                return this.xa8ae81960654bc0b;
            if (!this.x361886ff08483890.x364c1e3b189d47fe)
                goto label_4;
            else
                goto label_13;
            label_1:
            if (!this.x26e80f23e22a05ae.x2fef7d841879a711 && 0 == 0)
                goto label_17;
            label_2:
            if (this.x26e80f23e22a05ae.xda73fcb97c77d998.Contains(x08db3aeabb253cb1, x1e218ceaee1bb583))
                return this.x26e80f23e22a05ae;
            else
                goto label_17;
            label_4:
            if (this.x26e80f23e22a05ae.x364c1e3b189d47fe)
            {
                if ((uint)x1e218ceaee1bb583 - (uint)x1e218ceaee1bb583 <= uint.MaxValue)
                    goto label_1;
            }
            else
                goto label_17;
            label_7:
            if (0 != 0)
            {
                if ((uint)x08db3aeabb253cb1 >= 0U)
                    goto label_1;
                else
                    goto label_2;
            }
            else
                goto label_4;
            label_13:
            if ((uint)x1e218ceaee1bb583 + (uint)x08db3aeabb253cb1 < 0U)
            {
                if ((uint)x08db3aeabb253cb1 + (uint)x1e218ceaee1bb583 > uint.MaxValue)
                    goto label_4;
                else
                    goto label_1;
            }
            else if (this.x361886ff08483890.x2fef7d841879a711)
            {
                if ((uint)x1e218ceaee1bb583 < 0U || this.x361886ff08483890.xda73fcb97c77d998.Contains(x08db3aeabb253cb1, x1e218ceaee1bb583))
                    return this.x361886ff08483890;
                else
                    goto label_7;
            }
            else
                goto label_4;
            label_17:
            return (x0a9f5257a10031b2)null;
        }

        internal override void xd541e2fc281b554b()
        {
            if (this.DockContainer == null)
                return;
            this.DockContainer.Invalidate(this.xa358da7dd5364cab);
        }

        internal override void x84b6f3c22477dacb(RendererBase x38870620fd380a6b, Graphics x41347a961b838962, Font x26094932cf7a9139)
        {
            x38870620fd380a6b.DrawDocumentStripBackground(x41347a961b838962, this.xa358da7dd5364cab);
            int num;
            while (this.SelectedControl == null)
            {
                x38870620fd380a6b.DrawDocumentClientBackground(x41347a961b838962, this.x21ed2ecc088ef4e4, SystemColors.Control);
                if (0 != 0)
                    return;
                if ((int)byte.MaxValue != 0)
                    goto label_16;
            }
            goto label_18;
            label_16:
            do
            {
                Region clip = x41347a961b838962.Clip;
                Rectangle rect = this.xa358da7dd5364cab;
                rect.X += this.LeftPadding;
                rect.Width -= this.LeftPadding;
                rect.Width -= this.RightPadding;
                int index;
                do
                {
                    if (false)
                        goto label_12;
                    else
                        goto label_14;
                    label_9:
                    DockControl x43bec302f92080b9;
                    if (index < 0)
                    {
                        if (this.SelectedControl != null)
                        {
                            this.xc33f5f7a18a754cb(x38870620fd380a6b, x41347a961b838962, this.SelectedControl.Font, this.SelectedControl);
                            continue;
                        }
                        else
                            goto label_8;
                    }
                    else
                        x43bec302f92080b9 = this.Controls[index];
                    label_12:
                    this.xc33f5f7a18a754cb(x38870620fd380a6b, x41347a961b838962, x43bec302f92080b9.Font, x43bec302f92080b9);
                    --index;
                    goto label_9;
                    label_14:
                    x41347a961b838962.SetClip(rect);
                    index = this.Controls.Count - 1;
                    goto label_9;
                }
                while (int.MinValue == 0);
                goto label_6;
                label_4:
                x41347a961b838962.Clip = clip;
                if (!this.xa957e8f86f5e6115)
                    this.xb30ec7cfdf3e5c19(x41347a961b838962, x38870620fd380a6b, this.x26e80f23e22a05ae, SandDockButtonType.Close, true);
                this.xb30ec7cfdf3e5c19(x41347a961b838962, x38870620fd380a6b, this.xa8ae81960654bc0b, SandDockButtonType.ScrollRight, this.xa8ae81960654bc0b.x2fef7d841879a711);
                continue;
                label_6:
                if (this.xa957e8f86f5e6115)
                {
                    this.xb30ec7cfdf3e5c19(x41347a961b838962, x38870620fd380a6b, this.x26e80f23e22a05ae, SandDockButtonType.Close, true);
                    if ((uint)index + (uint)index > uint.MaxValue)
                        goto label_4;
                    else
                        goto label_4;
                }
                else
                    goto label_4;
                label_8:
                if ((uint)index >= 0U)
                    goto label_6;
                else
                    goto label_4;
            }
            while (0 != 0);
            this.xb30ec7cfdf3e5c19(x41347a961b838962, x38870620fd380a6b, this.x49dae83181e41d72, SandDockButtonType.ScrollLeft, this.x49dae83181e41d72.x2fef7d841879a711);
            this.xb30ec7cfdf3e5c19(x41347a961b838962, x38870620fd380a6b, this.x361886ff08483890, SandDockButtonType.ActiveFiles, true);
            return;
            label_18:
            x38870620fd380a6b.DrawDocumentClientBackground(x41347a961b838962, this.x21ed2ecc088ef4e4, this.SelectedControl.BackColor);
            goto label_16;
        }

        private void xc33f5f7a18a754cb(RendererBase x38870620fd380a6b, Graphics x41347a961b838962, Font x26094932cf7a9139, DockControl x43bec302f92080b9)
        {
            DrawItemState state = DrawItemState.Default;
            if (this.SelectedControl == x43bec302f92080b9)
                goto label_40;
            label_29:
            Rectangle tabBounds;
            bool drawSeparator;
            do
            {
                if (this.x9241b98e8e24ab0c != x43bec302f92080b9)
                    goto label_24;
                else
                    goto label_30;
                label_10:
                if (this.xa957e8f86f5e6115)
                    goto label_14;
                else
                    goto label_9;
                label_13:
                tabBounds = x43bec302f92080b9.TabBounds;
                goto label_10;
                label_14:
                if (x43bec302f92080b9.AllowClose)
                {
                    if (0 == 0)
                    {
                        tabBounds.Width -= 17;
                        goto label_20;
                    }
                    else
                        goto label_22;
                }
                else
                    goto label_9;
                label_17:
                if (this.Controls.IndexOf(x43bec302f92080b9) == this.Controls.IndexOf(this.SelectedControl) - 1)
                {
                    drawSeparator = false;
                    goto label_13;
                }
                else if (true)
                    goto label_13;
                label_20:
                if (((drawSeparator ? 1 : 0) & 0) == 0)
                {
                    if (-1 != 0)
                    {
                        if (false)
                            goto label_10;
                        else
                            goto label_3;
                    }
                    else
                        goto label_24;
                }
                else
                    goto label_27;
                label_22:
                if (0 != 0)
                    goto label_30;
                else
                    goto label_17;
                label_24:
                if (!x43bec302f92080b9.Enabled)
                    state |= DrawItemState.Disabled;
                drawSeparator = true;
                if (this.SelectedControl != null)
                {
                    if (0 == 0)
                    {
                        if (false)
                            goto label_17;
                        else
                            goto label_22;
                    }
                }
                else
                    goto label_13;
                label_27:
                if (true)
                    goto label_10;
                else
                    goto label_28;
                label_30:
                if (0 == 0)
                {
                    state |= DrawItemState.HotLight;
                    if (true)
                    {
                        if (true)
                        {
                            if (true)
                                goto label_24;
                            else
                                break;
                        }
                    }
                    else
                        goto label_13;
                }
                else
                    goto label_14;
            }
            while (false);
            goto label_32;
            label_3:
            if (0 == 0)
                goto label_9;
            label_4:
            using (Font font = new Font(x26094932cf7a9139, FontStyle.Bold))
            {
                x38870620fd380a6b.DrawDocumentStripTab(x41347a961b838962, x43bec302f92080b9.x123e054dab107457, tabBounds, x43bec302f92080b9.TabImage, x43bec302f92080b9.TabText, font, x43bec302f92080b9.BackColor, x43bec302f92080b9.ForeColor, state, drawSeparator);
                return;
            }
            label_9:
            if ((state & DrawItemState.Focus) != DrawItemState.Focus)
            {
                if (((drawSeparator ? 1 : 0) | 8) != 0)
                    x38870620fd380a6b.DrawDocumentStripTab(x41347a961b838962, x43bec302f92080b9.x123e054dab107457, tabBounds, x43bec302f92080b9.TabImage, x43bec302f92080b9.TabText, x26094932cf7a9139, x43bec302f92080b9.BackColor, x43bec302f92080b9.ForeColor, state, drawSeparator);
            }
            else
                goto label_4;
            label_28:
            if (0 == 0)
                return;
            label_32:
            if (this.DockContainer.Manager != null && this.DockContainer.Manager.ActiveTabbedDocument == x43bec302f92080b9)
            {
                state |= DrawItemState.Focus;
                goto label_29;
            }
            else
                goto label_29;
            label_40:
            if (0 != 0)
                return;
            state |= DrawItemState.Selected;
            goto label_32;
        }

        /// <summary>
        /// Overridden.
        /// 
        /// </summary>
        public override DockControl GetControlAt(System.Drawing.Point position)
        {
            if (this.xa358da7dd5364cab.Contains(position) && (0 == 0 && position.X < this.xa358da7dd5364cab.X + this.LeftPadding || position.X > this.xa358da7dd5364cab.Right - this.RightPadding))
                return (DockControl)null;
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
            do
            {
                tabstripBounds.Height = renderer.DocumentTabStripSize;
                bounds.Offset(0, renderer.DocumentTabStripSize);
                bounds.Height -= renderer.DocumentTabStripSize;
                clientBounds = bounds;
                joinCatchmentBounds = tabstripBounds;
            }
            while (((floating ? 1 : 0) & 0) != 0);
        }

        /// <summary>
        /// Overridden.
        /// 
        /// </summary>
        protected internal override void Layout(RendererBase renderer, Graphics graphics, Rectangle bounds, bool floating)
        {
            base.Layout(renderer, graphics, bounds, floating);
            this.xd00751399198ecd1(renderer, graphics, this.xa358da7dd5364cab);
            this.x5d6e30ce9634c49e(renderer, graphics, this.xa358da7dd5364cab);
        }

        private void xd00751399198ecd1(RendererBase x38870620fd380a6b, Graphics x41347a961b838962, Rectangle xa358da7dd5364cab)
        {
            int num1 = 0;
            int y = xa358da7dd5364cab.Top + xa358da7dd5364cab.Height / 2 - 7;
            if ((y & 0) != 0)
            {
                if ((uint)y - (uint)y < 0U)
                    return;
                else
                    goto label_10;
            }
            else
                goto label_15;
            label_8:
            while (this.SelectedControl == null)
            {
                if (15 != 0)
                    goto label_10;
            }
            num1 = 0;
            if (this.SelectedControl.AllowClose && !this.xa957e8f86f5e6115)
            {
                this.x26e80f23e22a05ae.x364c1e3b189d47fe = true;
                this.x26e80f23e22a05ae.xda73fcb97c77d998 = new Rectangle(num1 - 14, y, 14, 15);
                num1 -= 15;
                if ((uint)num1 + (uint)y >= 0U)
                    goto label_11;
                else
                    goto label_15;
            }
            label_10:
            this.x26e80f23e22a05ae.x364c1e3b189d47fe = false;
            label_11:
            this.xa8ae81960654bc0b.x364c1e3b189d47fe = false;
            this.x49dae83181e41d72.x364c1e3b189d47fe = false;
            do
            {
                this.x361886ff08483890.x364c1e3b189d47fe = false;
                switch (this.x7d2c5325d16e569d)
                {
                    case DocumentOverflowMode.Scrollable:
                        this.xa8ae81960654bc0b.x364c1e3b189d47fe = true;
                        this.xa8ae81960654bc0b.xda73fcb97c77d998 = new Rectangle(num1 - 14, y, 14, 15);
                        num1 -= 15;
                        continue;
                    case DocumentOverflowMode.Menu:
                        goto label_3;
                    default:
                        return;
                }
            }
            while ((uint)y - (uint)y < 0U);
            goto label_4;
            label_3:
            this.x361886ff08483890.x364c1e3b189d47fe = true;
            this.x361886ff08483890.xda73fcb97c77d998 = new Rectangle(num1 - 14, y, 14, 15);
            int num2 = num1 - 15;
            return;
            label_4:
            this.x49dae83181e41d72.x364c1e3b189d47fe = true;
            this.x49dae83181e41d72.xda73fcb97c77d998 = new Rectangle(num1 - 14, y, 14, 15);
            num1 -= 15;
            if ((y | 8) != 0)
            {
                if (0 == 0)
                    return;
                else
                    goto label_8;
            }
            else
                goto label_10;
            label_15:
            num1 = xa358da7dd5364cab.Right - 2;
            if (0 == 0)
                goto label_8;
        }

        private void x5d6e30ce9634c49e(RendererBase x38870620fd380a6b, Graphics x41347a961b838962, Rectangle xa358da7dd5364cab)
        {
            int x = 3;
            DockControl dockControl = null;
            int num2 = 0;
            IEnumerator enumerator = this.Controls.GetEnumerator();
            int num1 = 0;
            try
            {
                while (true)
                {
                    if (enumerator.MoveNext())
                        goto label_51;
                    else
                        goto label_31;
                    label_26:
                    dockControl = null;
                    if (dockControl.MaximumTabWidth >= num1)
                    {
                        if (0 != 0)
                            goto label_37;
                    }
                    else
                    {
                        num1 = dockControl.MaximumTabWidth;
                        dockControl.xcfac6723d8a41375 = true;
                    }
                    label_28:
                    dockControl.x123e054dab107457 = new Rectangle(x, xa358da7dd5364cab.Bottom - x38870620fd380a6b.DocumentTabSize, num1, x38870620fd380a6b.DocumentTabSize);
                    x += num1 - x38870620fd380a6b.DocumentTabExtra + 1;
                    continue;
                    label_30:
                    if (0 == 0)
                        goto label_28;
                    else
                        goto label_26;
                    label_31:
                    num2 = 0;
                    if ((num2 | 4) == 0)
                    {
                        if ((uint)num1 + (uint)x < 0U)
                            goto label_28;
                        else
                            goto label_30;
                    }
                    else
                        break;
                    label_37:
                    if ((uint)num2 - (uint)num1 < 0U)
                        goto label_42;
                    label_38:
                    DrawItemState state;
                    num1 = x38870620fd380a6b.MeasureDocumentStripTab(x41347a961b838962, dockControl.TabImage, dockControl.TabText, dockControl.Font, state).Width;
                    if (!this.xa957e8f86f5e6115 || !dockControl.AllowClose)
                        goto label_35;
                    else
                        goto label_39;
                    label_25:
                    if (dockControl.MaximumTabWidth == 0)
                        goto label_30;
                    else
                        goto label_26;
                    label_35:
                    if (dockControl.MinimumTabWidth == 0)
                    {
                        if (0 == 0)
                            goto label_25;
                        else
                            goto label_26;
                    }
                    else
                    {
                        num1 = Math.Max(num1, dockControl.MinimumTabWidth);
                        goto label_25;
                    }
                    label_39:
                    num1 += 17;
                    if (int.MaxValue != 0)
                        goto label_35;
                    else
                        goto label_25;
                    label_42:
                    if (this.DockContainer.Manager.ActiveTabbedDocument != dockControl)
                        goto label_38;
                    label_45:
                    state |= DrawItemState.Focus;
                    goto label_38;
                    label_51:
                    dockControl = (DockControl)enumerator.Current;
                    dockControl.xcfac6723d8a41375 = false;
                    if (true)
                        goto label_46;
                    label_43:
                    if (this.DockContainer.Manager != null)
                    {
                        if ((uint)num2 + (uint)num2 >= 0U)
                            goto label_42;
                        else
                            goto label_45;
                    }
                    else
                        goto label_38;
                    label_46:
                    state = DrawItemState.Default;
                    while (false)
                    {
                        if ((num1 & 0) == 0)
                        {
                            if ((uint)x > uint.MaxValue)
                                goto label_26;
                            else
                                goto label_50;
                        }
                    }
                    if (this.SelectedControl != dockControl)
                    {
                        if ((x & 0) == 0)
                            goto label_37;
                        else
                            goto label_42;
                    }
                    label_50:
                    state |= DrawItemState.Selected;
                    goto label_43;
                }
            }
            finally
            {
                IDisposable disposable = enumerator as IDisposable;
                if (disposable != null)
                    disposable.Dispose();
            }
            label_19:
            if (this.Controls.Count != 0)
                goto label_23;
            label_20:
            x += 3;
            label_21:
            int num3 = xa358da7dd5364cab.Width - this.LeftPadding - this.RightPadding;
            this.x4f8ccd50477a481e = x - num3;
            if ((num1 & 0) != 0)
                goto label_17;
            else
                goto label_22;
            label_16:
            if (this.x4f8ccd50477a481e < 0)
                this.x4f8ccd50477a481e = 0;
            label_17:
            if (this.x200b7f5a9d983ba4 > this.x4f8ccd50477a481e)
                goto label_14;
            label_12:
            this.x49dae83181e41d72.x2fef7d841879a711 = this.x200b7f5a9d983ba4 > 0;
            label_13:
            this.xa8ae81960654bc0b.x2fef7d841879a711 = this.x200b7f5a9d983ba4 < this.x4f8ccd50477a481e;
            if (2 != 0)
            {
                foreach (DockControl dc in (CollectionBase) this.Controls)
                {
                    if ((num3 | 8) != 0)
                    {
                        Rectangle rectangle = dc.x123e054dab107457;
                        rectangle.Offset(xa358da7dd5364cab.Left + this.LeftPadding - this.x200b7f5a9d983ba4, 0);
                        dc.x123e054dab107457 = rectangle;
                    }
                }
                if (!this.xa957e8f86f5e6115 || (this.SelectedControl == null || !this.SelectedControl.AllowClose))
                    return;
                this.x26e80f23e22a05ae.x364c1e3b189d47fe = true;
                Rectangle rectangle1 = this.SelectedControl.x123e054dab107457;
                this.x26e80f23e22a05ae.xda73fcb97c77d998 = new Rectangle(rectangle1.Right - 17, rectangle1.Top + 2, 14, rectangle1.Height - 3);
                return;
            }
            else
                goto label_16;
            label_14:
            this.x200b7f5a9d983ba4 = this.x4f8ccd50477a481e;
            if ((uint)num1 <= uint.MaxValue)
            {
                if ((num3 | int.MaxValue) == 0)
                    goto label_13;
                else
                    goto label_12;
            }
            else if ((uint)num1 - (uint)x <= uint.MaxValue || (uint)x + (uint)x <= uint.MaxValue)
                goto label_16;
            else
                goto label_21;
            label_22:
            if ((uint)num1 - (uint)num1 <= uint.MaxValue)
                goto label_16;
            else
                goto label_19;
            label_23:
            x += x38870620fd380a6b.DocumentTabExtra;
            goto label_20;
        }

        private void x71ad9ee77d4aa721(object xe0292b9ed559da7d, EventArgs xfbf34718e704c6bc)
        {
            if (this.DockContainer == null || this.SelectedControl == null)
                return;
            this.xd4949976eef9c304(this.SelectedControl);
        }

        private void xd4949976eef9c304(DockControl x43bec302f92080b9)
        {
            if (this.x4f8ccd50477a481e <= 0)
                return;
            Rectangle rectangle = x43bec302f92080b9.x123e054dab107457;
            int num1;
            int num2;
            if (true)
                goto label_9;
            label_4:
            int xa00f04d8b3a6664c = 0;
            if (true)
                return;
            this.x523c1f22a806032d(xa00f04d8b3a6664c);
            return;
            label_9:
            int num3 = this.xa358da7dd5364cab.Right - this.RightPadding;
            int num4 = this.xa358da7dd5364cab.Left + this.LeftPadding;
            int num5 = num3 - num4;
            xa00f04d8b3a6664c = 0;
            if ((uint)num4 - (uint)num5 < 0U || rectangle.Right > num3)
                goto label_6;
            label_3:
            if (rectangle.Left < num4)
            {
                xa00f04d8b3a6664c = rectangle.Left - num4 - 30;
                goto label_4;
            }
            else
                goto label_4;
            label_6:
            xa00f04d8b3a6664c = rectangle.Right - num5 + 30;
            goto label_3;
        }

        private void xd11b6d3bf98020cb()
        {
            this.x5d56ae798b9cdf38.Enabled = false;
            this.x1f43ebe301d1df45 = (x0a9f5257a10031b2)null;
            this.xfa5e20eb950b9ee1 = false;
            this.xd541e2fc281b554b();
        }

        private void xcf8b319f2bffca87()
        {
            this.x5d56ae798b9cdf38.Enabled = true;
            this.xcaf19fd9570f4eb4((object)this.x5d56ae798b9cdf38, EventArgs.Empty);
        }

        private void x523c1f22a806032d(int xa00f04d8b3a6664c)
        {
            this.x200b7f5a9d983ba4 += xa00f04d8b3a6664c;
            label_7:
            if (this.x200b7f5a9d983ba4 > this.x4f8ccd50477a481e)
                this.x200b7f5a9d983ba4 = this.x4f8ccd50477a481e;
            else
                goto label_8;
            label_6:
            this.xd11b6d3bf98020cb();
            label_8:
            if (this.x200b7f5a9d983ba4 < 0)
                goto label_9;
            label_3:
            this.x3e0280cae730d1f2();
            return;
            label_9:
            if (0 == 0)
                goto label_4;
            label_1:
            if (-1 != 0)
            {
                this.xd11b6d3bf98020cb();
                goto label_3;
            }
            else
                goto label_6;
            label_4:
            this.x200b7f5a9d983ba4 = 0;
            if ((xa00f04d8b3a6664c & 0) == 0)
                goto label_1;
            else
                goto label_7;
        }

        private void xcaf19fd9570f4eb4(object xe0292b9ed559da7d, EventArgs xfbf34718e704c6bc)
        {
            if (this.x1f43ebe301d1df45 != this.x49dae83181e41d72)
            {
                while (this.x1f43ebe301d1df45 == this.xa8ae81960654bc0b)
                {
                    this.x523c1f22a806032d(15);
                    if (-1 != 0 || 0 != 0)
                        return;
                }
                this.xd11b6d3bf98020cb();
                if (0 == 0)
                    return;
            }
            this.x523c1f22a806032d(-15);
        }
    }
}
