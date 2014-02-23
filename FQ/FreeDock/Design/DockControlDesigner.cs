using System;
using System.Collections;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.Windows.Forms.Design;
using FQ.FreeDock;

namespace FQ.FreeDock.Design
{
    class DockControlDesigner : ParentControlDesigner
    {
        private static bool xb070ba46e7c7d3b6;
        private DockControl dockControl;
        private bool x9f93ebd2ca5601a2;
        private IComponentChangeService x4cd3df9bd5e139a3;
        private IDesignerHost xff9c60b45aa37b1e;
        private ISelectionService x77da34c6f08140f2;

        public override SelectionRules SelectionRules
        {
            get
            {
                return SelectionRules.None;
            }
        }

        public bool Collapsed
        {
            get
            {
                return (bool)this.ShadowProperties["Collapsed"];
            }
            set
            {
                this.ShadowProperties["Collapsed"] = (value);


                while (this.dockControl.LayoutSystem != null)
                {
                    if (DockControlDesigner.xb070ba46e7c7d3b6)
                    {

                        break;
                    }
                    else
                    {
                        DockControlDesigner.xb070ba46e7c7d3b6 = true;
                        try
                        {
                            IEnumerator enumerator = this.dockControl.LayoutSystem.Controls.GetEnumerator();
                            try
                            {
                                label_8:
                                if (!enumerator.MoveNext())
                                    break;
                                DockControl dockControl = (DockControl)enumerator.Current;

                                if (dockControl == this.dockControl)
                                {
                                    if (((value ? 1 : 0) & 0) == 0)
                                        break;
                                }
                                else
                                    TypeDescriptor.GetProperties(dockControl)["Collapsed"].SetValue(dockControl, value);

                                goto label_8;
                            }
                            finally
                            {
                                IDisposable disposable = enumerator as IDisposable;
                                if (disposable != null)
                                    disposable.Dispose();
                            }
                        }
                        finally
                        {
                            DockControlDesigner.xb070ba46e7c7d3b6 = false;
                        }
                    }
                }
            }
        }

        public override void Initialize(IComponent component)
        {
            base.Initialize(component);
            label_8:
            if (0 != 0 || !(component is DockControl))
                SandDockLanguage.ShowCachedAssemblyError(component.GetType().Assembly, this.GetType().Assembly);
            this.x4cd3df9bd5e139a3 = (IComponentChangeService)this.GetService(typeof(IComponentChangeService));
            if (0 == 0)
                goto label_7;
            label_2:
            this.dockControl.ControlAdded += new ControlEventHandler(this.x5ba88706ad55272f);
            this.dockControl.ControlRemoved += new ControlEventHandler(this.x5ba88706ad55272f);
            if (0 == 0)
            {
                while (this.dockControl.Collapsed)
                {
                    this.Collapsed = true;
                    if (0 == 0)
                    {
                        this.dockControl.Collapsed = false;
                        if (0 == 0)
                            break;
                        if (0 == 0)
                            goto label_8;
                        else
                            goto label_7;
                    }
                }
                return;
            }
            label_7:
            this.xff9c60b45aa37b1e = (IDesignerHost)this.GetService(typeof(IDesignerHost));
            this.x77da34c6f08140f2 = (ISelectionService)this.GetService(typeof(ISelectionService));
            this.dockControl = (DockControl)component;
            this.dockControl.x81444a37d39a0e4a();
            this.x77da34c6f08140f2.SelectionChanged += new EventHandler(this.x6179d221e3fa4b20);
            if (0 == 0)
                goto label_2;
            else
                goto label_8;
        }

        protected override void Dispose(bool disposing)
        {
            this.dockControl.ControlAdded -= new ControlEventHandler(this.x5ba88706ad55272f);
            this.dockControl.ControlRemoved -= new ControlEventHandler(this.x5ba88706ad55272f);
            this.x77da34c6f08140f2.SelectionChanged -= new EventHandler(this.x6179d221e3fa4b20);
            base.Dispose(disposing);
        }

        protected override void PreFilterProperties(IDictionary properties)
        {
            base.PreFilterProperties(properties);
            string[] strArray = new string[]
            {
                "Collapsed"
            };
            for (int index = 0; index < strArray.Length; ++index)
            {
                string str = strArray[index];

                label_3:
                PropertyDescriptor oldPropertyDescriptor = (PropertyDescriptor)properties[(object)str];
                label_4:
   
                if (oldPropertyDescriptor == null)
                    continue;
                properties[(object)str] = (object)TypeDescriptor.CreateProperty(typeof(DockControlDesigner), oldPropertyDescriptor, new Attribute[0]);

            }
        }

        private void x6179d221e3fa4b20(object xe0292b9ed559da7d, EventArgs xfbf34718e704c6bc)
        {
            bool componentSelected = this.x77da34c6f08140f2.GetComponentSelected((object)this.Component);
            if (componentSelected == this.x9f93ebd2ca5601a2)
                return;
            this.x9f93ebd2ca5601a2 = componentSelected;
            ((DockControl)this.Component).LayoutSystem.xd541e2fc281b554b();
        }

        protected override void OnPaintAdornments(PaintEventArgs pe)
        {
            base.OnPaintAdornments(pe);
     
            goto label_14;
            label_1:
            using (Pen pen = new Pen(SystemColors.ControlDark))
            {
                pen.DashStyle = DashStyle.Dot;
                Rectangle clientRectangle = this.dockControl.ClientRectangle;
                --clientRectangle.Width;
                --clientRectangle.Height;
                pe.Graphics.DrawRectangle(pen, clientRectangle);
                return;
            }
            label_14:

            goto label_12;

            label_6:
            Rectangle clientRectangle1 = this.dockControl.ClientRectangle;
            clientRectangle1.Inflate(-10, -10);
            label_7:
            using (Font font = new Font(this.dockControl.Font.Name, 6.75f))
            {
                TextFormatFlags flags = TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter | TextFormatFlags.WordBreak;
                TextRenderer.DrawText((IDeviceContext)pe.Graphics, "To redock windows, click and drag their tabs or titlebars to other locations on your form.", font, clientRectangle1, SystemColors.ControlDarkDark, flags);
                goto label_13;
            }
            label_12:
            if (this.dockControl.Controls.Count == 0)
                goto label_6;
            label_13:
            if (this.dockControl.BorderStyle != FQ.FreeDock.Rendering.BorderStyle.None)
                return;
            else
                goto label_1;
        }

        private void x5ba88706ad55272f(object sender, ControlEventArgs e)
        {
            if (this.dockControl.Controls.Count > 1)
                this.dockControl.Invalidate();
        }
    }
}
