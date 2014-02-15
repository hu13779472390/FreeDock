﻿// Type: TD.SandDock.Design.DockControlDesigner
// Assembly: SandDock, Version=3.0.6.1, Culture=neutral, PublicKeyToken=75b7ec17dd7c14c3
// MVID: 86A16A8A-6BB9-495D-A857-1A3306E497E9
// Assembly location: C:\Program Files (x86)\Divelements Limited\SandDock for Windows Forms\SandDock.dll

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
  internal class DockControlDesigner : ParentControlDesigner
  {
    private static bool xb070ba46e7c7d3b6;
    private DockControl xdeac46e41e0fbcf5;
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
        return (bool) this.ShadowProperties["Collapsed"];
      }
      set
      {
        this.ShadowProperties["Collapsed"] = (object) (bool) (value ? 1 : 0);
        if ((uint) value - (uint) value < 0U)
          return;
        while (this.xdeac46e41e0fbcf5.LayoutSystem != null)
        {
          if (DockControlDesigner.xb070ba46e7c7d3b6)
          {
            if ((uint) value + (uint) value > uint.MaxValue || (uint) value - (uint) value >= 0U)
              break;
          }
          else
          {
            DockControlDesigner.xb070ba46e7c7d3b6 = true;
            try
            {
              IEnumerator enumerator = this.xdeac46e41e0fbcf5.LayoutSystem.Controls.GetEnumerator();
              try
              {
label_8:
                if (!enumerator.MoveNext())
                  break;
                DockControl dockControl = (DockControl) enumerator.Current;
                do
                {
                  if (dockControl == this.xdeac46e41e0fbcf5)
                  {
                    if (((value ? 1 : 0) & 0) == 0)
                      break;
                  }
                  else
                    TypeDescriptor.GetProperties((object) dockControl)["Collapsed"].SetValue((object) dockControl, (object) (bool) (value ? 1 : 0));
                }
                while ((uint) value - (uint) value < 0U);
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
      this.x4cd3df9bd5e139a3 = (IComponentChangeService) this.GetService(typeof (IComponentChangeService));
      if (0 == 0)
        goto label_7;
label_2:
      this.xdeac46e41e0fbcf5.ControlAdded += new ControlEventHandler(this.x5ba88706ad55272f);
      this.xdeac46e41e0fbcf5.ControlRemoved += new ControlEventHandler(this.x5ba88706ad55272f);
      if (0 == 0)
      {
        while (this.xdeac46e41e0fbcf5.Collapsed)
        {
          this.Collapsed = true;
          if (0 == 0)
          {
            this.xdeac46e41e0fbcf5.Collapsed = false;
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
      this.xff9c60b45aa37b1e = (IDesignerHost) this.GetService(typeof (IDesignerHost));
      this.x77da34c6f08140f2 = (ISelectionService) this.GetService(typeof (ISelectionService));
      this.xdeac46e41e0fbcf5 = (DockControl) component;
      this.xdeac46e41e0fbcf5.x81444a37d39a0e4a();
      this.x77da34c6f08140f2.SelectionChanged += new EventHandler(this.x6179d221e3fa4b20);
      if (0 == 0)
        goto label_2;
      else
        goto label_8;
    }

    protected override void Dispose(bool disposing)
    {
      this.xdeac46e41e0fbcf5.ControlAdded -= new ControlEventHandler(this.x5ba88706ad55272f);
      this.xdeac46e41e0fbcf5.ControlRemoved -= new ControlEventHandler(this.x5ba88706ad55272f);
      this.x77da34c6f08140f2.SelectionChanged -= new EventHandler(this.x6179d221e3fa4b20);
      base.Dispose(disposing);
    }

    protected override void PreFilterProperties(IDictionary properties)
    {
      base.PreFilterProperties(properties);
      string[] strArray = new string[1]
      {
        "Collapsed"
      };
      for (int index = 0; index < strArray.Length; ++index)
      {
        string str = strArray[index];
        if (0 != 0)
          goto label_4;
label_3:
        PropertyDescriptor oldPropertyDescriptor = (PropertyDescriptor) properties[(object) str];
label_4:
        if ((index | 2) != 0)
        {
          if (oldPropertyDescriptor == null)
            continue;
          properties[(object) str] = (object) TypeDescriptor.CreateProperty(typeof (DockControlDesigner), oldPropertyDescriptor, new Attribute[0]);
        }
        else
          goto label_3;
      }
    }

    private void x6179d221e3fa4b20(object xe0292b9ed559da7d, EventArgs xfbf34718e704c6bc)
    {
      bool componentSelected = this.x77da34c6f08140f2.GetComponentSelected((object) this.Component);
      if (componentSelected == this.x9f93ebd2ca5601a2)
        return;
      this.x9f93ebd2ca5601a2 = componentSelected;
      ((DockControl) this.Component).LayoutSystem.xd541e2fc281b554b();
    }

    protected override void OnPaintAdornments(PaintEventArgs pe)
    {
      base.OnPaintAdornments(pe);
      if (0 == 0)
        goto label_14;
label_1:
      using (Pen pen = new Pen(SystemColors.ControlDark))
      {
        pen.DashStyle = DashStyle.Dot;
        Rectangle clientRectangle = this.xdeac46e41e0fbcf5.ClientRectangle;
        --clientRectangle.Width;
        --clientRectangle.Height;
        pe.Graphics.DrawRectangle(pen, clientRectangle);
        return;
      }
label_14:
      if (int.MaxValue != 0)
        goto label_12;
      else
        goto label_15;
label_6:
      Rectangle clientRectangle1 = this.xdeac46e41e0fbcf5.ClientRectangle;
      clientRectangle1.Inflate(-10, -10);
label_7:
      using (Font font = new Font(this.xdeac46e41e0fbcf5.Font.Name, 6.75f))
      {
        TextFormatFlags flags = TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter | TextFormatFlags.WordBreak;
        TextRenderer.DrawText((IDeviceContext) pe.Graphics, "To redock windows, click and drag their tabs or titlebars to other locations on your form.", font, clientRectangle1, SystemColors.ControlDarkDark, flags);
        goto label_13;
      }
label_12:
      if (this.xdeac46e41e0fbcf5.Controls.Count == 0)
        goto label_6;
label_13:
      if (this.xdeac46e41e0fbcf5.BorderStyle != FQ.FreeDock.Rendering.BorderStyle.None)
        return;
      else
        goto label_1;
label_15:
      if (2 == 0)
        goto label_7;
      else
        goto label_6;
    }

    private void x5ba88706ad55272f(object xe0292b9ed559da7d, ControlEventArgs xfbf34718e704c6bc)
    {
      if (this.xdeac46e41e0fbcf5.Controls.Count != 0 && this.xdeac46e41e0fbcf5.Controls.Count != 1)
        return;
      this.xdeac46e41e0fbcf5.Invalidate();
    }
  }
}
