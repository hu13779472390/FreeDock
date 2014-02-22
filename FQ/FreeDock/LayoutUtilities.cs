using System;
using System.Collections;
using System.Windows.Forms;

namespace FQ.FreeDock
{
    /// <summary>
    /// Provides a set of useful methods for dealing with complex docking scenarios.
    /// 
    /// </summary>
    public sealed class LayoutUtilities
    {
        private static int x9b1e2b1c391ceb59;

        internal static bool LayoutInProgress
        {
            get
            {
                return LayoutUtilities.x9b1e2b1c391ceb59 > 0;
            }
        }

        private LayoutUtilities()
        {
        }

        internal static void x3a04ba0cdf69aff2()
        {
            ++LayoutUtilities.x9b1e2b1c391ceb59;
        }

        internal static void x861aa05d0acfeb39()
        {
            if (LayoutUtilities.x9b1e2b1c391ceb59 <= 0)
                return;
            --LayoutUtilities.x9b1e2b1c391ceb59;
        }

        internal static DockSituation x8d287cc6f0a2f529(DockContainer container)
        {
            if (container == null)
                return DockSituation.None;

            if (container.IsFloating)
                return DockSituation.Floating;

            if (container.Dock == DockStyle.Fill)
                return DockSituation.Document;

            return DockSituation.Docked;

        }

        internal static ControlLayoutSystem[] x1494f515233a1246(DockContainer container)
        {
            ArrayList list = new ArrayList();
            foreach (LayoutSystemBase layout in container.layouts)
            {
                if (layout is ControlLayoutSystem)
                    list.Add(layout);
            }
            return (ControlLayoutSystem[])list.ToArray(typeof(ControlLayoutSystem));
        }

        internal static ControlLayoutSystem xba5fd484c0e6478b(SandDockManager x91f347c6e97f1846, DockSituation xd39eba9a9a1b028e, x129cb2a2bdfd0ab2 xfffbdea061bfa120)
        {
            DockContainer[] dockContainers1 = { };
            int index1;
            int index2;
            ControlLayoutSystem[] controlLayoutSystemArray1;
            DockContainer[] dockContainers2;
            switch (xd39eba9a9a1b028e)
            {
                case DockSituation.Docked:
                    dockContainers2 = x91f347c6e97f1846.GetDockContainers();
                    index1 = 0;
                    goto label_25;
                case DockSituation.Document:
                    if (x91f347c6e97f1846.DocumentContainer != null)
                    {
                        controlLayoutSystemArray1 = LayoutUtilities.x1494f515233a1246((DockContainer)x91f347c6e97f1846.DocumentContainer);

                        index2 = 0;
                        goto label_17;

                    }
                    else
                        break;
                case DockSituation.Floating:
                    dockContainers1 = x91f347c6e97f1846.GetDockContainers();
                    goto label_15;
                default:
                    throw new InvalidOperationException();
            }
            label_3:
            return (ControlLayoutSystem)null;
            label_4:
            int index3;
            int index4;
            ControlLayoutSystem[] controlLayoutSystemArray2;
            if (index3 < dockContainers1.Length)
            {
                DockContainer xd3311d815ca25f02 = dockContainers1[index3];

                if (LayoutUtilities.x8d287cc6f0a2f529(xd3311d815ca25f02) == xd39eba9a9a1b028e)
                {
                    controlLayoutSystemArray2 = LayoutUtilities.x1494f515233a1246(xd3311d815ca25f02);
                    index4 = 0;
                    goto label_9;
                }

            }
            else
                goto label_3;
            label_5:
            ++index3;
            goto label_4;
            label_7:
            ControlLayoutSystem controlLayoutSystem1;
            ControlLayoutSystem controlLayoutSystem2;
            if (controlLayoutSystem1.Guid == xfffbdea061bfa120.Guid)
            {
                controlLayoutSystem2 = controlLayoutSystem1;
                goto label_38;
            }
            label_8:
            ++index4;
            label_9:
            if (index4 < controlLayoutSystemArray2.Length)
            {
                controlLayoutSystem1 = controlLayoutSystemArray2[index4];
                goto label_7;
            }
            else
                goto label_5;
            label_15:
            index3 = 0;
            goto label_4;
            label_17:
            ControlLayoutSystem controlLayoutSystem3;
            if (index2 < controlLayoutSystemArray1.Length)
            {
                controlLayoutSystem3 = controlLayoutSystemArray1[index2];

            }
            else
                goto label_3;
            label_20:
            if (!(controlLayoutSystem3.Guid == xfffbdea061bfa120.Guid))
            {
                ++index2;
                goto label_17;
            }
            else
            {
                if ((index2 | -1) != 0)
                {
                    controlLayoutSystem2 = controlLayoutSystem3;
                    goto label_38;
                }
                else
                    goto label_15;
            }


            label_24:
            ++index1;
            label_25:
            if (index1 < dockContainers2.Length)
            {
                DockContainer xd3311d815ca25f02 = dockContainers2[index1];
                if (LayoutUtilities.x8d287cc6f0a2f529(xd3311d815ca25f02) == xd39eba9a9a1b028e)
                {
     
                    goto label_35;
                    label_27:
                    ControlLayoutSystem controlLayoutSystem4;
                    int index5;
                    if (!(controlLayoutSystem4.Guid == xfffbdea061bfa120.Guid))
                    {
                        ++index5;
                    }
                    else
                    {
                        controlLayoutSystem2 = controlLayoutSystem4;
                        goto label_38;
                    }
                    label_29:
                    int num2;
                    ControlLayoutSystem[] controlLayoutSystemArray3;
                    if (index5 >= controlLayoutSystemArray3.Length)
                    {

                        goto label_24;


                    }
                    else
                    {
                        controlLayoutSystem4 = controlLayoutSystemArray3[index5];
                        goto label_27;
                    }
                    label_35:
                    controlLayoutSystemArray3 = LayoutUtilities.x1494f515233a1246(xd3311d815ca25f02);
                    index5 = 0;
                  
                    goto label_29;
                }
                else
                    goto label_24;
            }
            else
                goto label_3;
            label_38:
            return controlLayoutSystem2;
        }

        internal static int[] x27f6597db2aeb7d7(ControlLayoutSystem x5d3b2a2c534d6d79)
        {
            ArrayList arrayList = new ArrayList();
            do
            {
                for (LayoutSystemBase layoutSystem = (LayoutSystemBase)x5d3b2a2c534d6d79; layoutSystem != null; layoutSystem = (LayoutSystemBase)layoutSystem.Parent)
                {
                    if (layoutSystem.Parent != null)
                    {
                        arrayList.Add(layoutSystem.Parent.LayoutSystems.IndexOf(layoutSystem));
      
                    }
                }
            }
            while (15 == 0);
            arrayList.Reverse();
            label_8:
            return (int[])arrayList.ToArray(typeof(int));
        }

        internal static DockStyle xf8330a3964a419ba(ContainerDockLocation location)
        {
            switch (location)
            {
                case ContainerDockLocation.Left:
                    return DockStyle.Left;
                case ContainerDockLocation.Right:
                    return DockStyle.Right;
                case ContainerDockLocation.Top:
                    return DockStyle.Top;
                case ContainerDockLocation.Bottom:
                    return DockStyle.Bottom;
                case ContainerDockLocation.Center:
                default:
                    return DockStyle.Fill;

            }
        }

        internal static ContainerDockLocation x3650f3b579b2b4d2(DockStyle style)
        {
            switch (style)
            {
                case DockStyle.Top:
                    return ContainerDockLocation.Top;
                case DockStyle.Bottom:
                    return ContainerDockLocation.Bottom;
                case DockStyle.Left:
                    return ContainerDockLocation.Left;
                case DockStyle.Right:
                    return ContainerDockLocation.Right;
                case DockStyle.Fill:
                default:
                    return ContainerDockLocation.Center;
            }
        }

        /// <summary>
        /// Locates the first instance of a ControlLayoutSystem within a DockContainer.
        /// 
        /// </summary>
        /// <param name="container">The DockContainer in which to look.</param>
        /// <returns>
        /// The first available ControlLayoutSystem in the container. If no ControlLayoutSystem is found, a null reference is returned.
        /// </returns>
        public static ControlLayoutSystem FindControlLayoutSystem(DockContainer container)
        {
            foreach (LayoutSystemBase layout in container.layouts)
            {
                if (layout is ControlLayoutSystem)
                    return (ControlLayoutSystem)layout;
            }
            return null;
        }

        internal static void xa7513d57b4844d46(Control control)
        {
            if (control.Parent == null)
                return;
            if (control.ContainsFocus)
                goto label_21;
            label_2:
            while (control is DockControl)
            {
                ((DockControl)control).IgnoreFontEvents = true;
 
                break;
            }
            try
            {
                IContainerControl containerControl = control.Parent.GetContainerControl();
    
                goto label_13;

                label_4:
                DockContainer xd3311d815ca25f02;
                if (xd3311d815ca25f02.Manager.OwnerForm == null)
                    goto label_6;
                label_5:
                if (xd3311d815ca25f02.Manager.OwnerForm.IsMdiContainer)
                {
                    LayoutUtilities.xf96eb78473d85a37(xd3311d815ca25f02, xd3311d815ca25f02.LayoutSystem);
                    goto label_8;
                }
                label_6:
                if (containerControl.ActiveControl == control)
                    containerControl.ActiveControl = (Control)null;
                label_8:
                control.Parent.Controls.Remove(control);

                return;
                label_11:
   
                goto label_4;

                label_13:
                if (containerControl != null)
                {
                    xd3311d815ca25f02 = containerControl as DockContainer;
                    if (xd3311d815ca25f02 != null)
                    {
                        if (xd3311d815ca25f02.x5b1f9c5a8906ff95 || xd3311d815ca25f02.Manager == null)
                            goto label_6;
                        else
                            goto label_11;
                    }
                    else
                        goto label_6;
                }
                else
                    goto label_8;
            }
            finally
            {
                if (control is DockControl)
                    ((DockControl)control).IgnoreFontEvents = false;
            }
            label_21:
            control.Parent.Focus();
            goto label_2;
        }

        private static bool xf96eb78473d85a37(DockContainer container, SplitLayoutSystem splitLayout)
        {
            foreach (LayoutSystemBase layout in splitLayout.LayoutSystems)
            {
                if (layout is SplitLayoutSystem)
                {
                    if (LayoutUtilities.xf96eb78473d85a37(container, (SplitLayoutSystem)layout))
                        return true;
                }
                else
                {
                    ControlLayoutSystem controlLayout = (ControlLayoutSystem)layout;
                    if (!controlLayout.Collapsed && (container.Controls.Contains(controlLayout.SelectedControl) || 8 == 0) && (controlLayout.SelectedControl.Visible && controlLayout.SelectedControl.Enabled))
                    {
                        container.ActiveControl = controlLayout.SelectedControl;
                        return true;
                    }
                }
            }
            return false;
        }

        internal static void x4487f2f8917e3fd0(ControlLayoutSystem controlLayout)
        {
            if (controlLayout == null)
                throw new ArgumentNullException();

            goto label_21;
            label_3:
            DockContainer dockContainer;
            while (dockContainer.x61d88745bde7a5ec())
            {
                if (dockContainer is DocumentContainer && dockContainer.Manager != null && dockContainer.Manager.EnableEmptyEnvironment)
                {
              
                    break;
                }
                else
                {
                    dockContainer.Dispose();
           
 
                    break;
                

                }
            }
            return;
            label_11:
            if (controlLayout.Parent == null)
                return;
            controlLayout.Parent.LayoutSystems.Remove((LayoutSystemBase)controlLayout);
     
            if (dockContainer == null)
                return;
            else
                goto label_3;
     
            label_16:
            if (controlLayout.AutoHideBar == null)
                goto label_11;
            label_17:
            if (controlLayout.AutoHideBar.ShowingLayoutSystem == controlLayout)
            {
                controlLayout.AutoHideBar.xcdb145600c1b7224(true);
                goto label_11;
            }
            else
                goto label_11;
            label_21:
            dockContainer = controlLayout.DockContainer;
            goto label_16;
        }

        internal static void xf1cbd48a28ce6e74(DockControl x43bec302f92080b9)
        {
            if (x43bec302f92080b9 == null)
                throw new ArgumentNullException();

            ControlLayoutSystem layout = x43bec302f92080b9.LayoutSystem;
            if (layout == null)
                return;
            DockContainer dockContainer = layout.DockContainer;
                
            bool containsFocus = x43bec302f92080b9.ContainsFocus;
                
            if (!containsFocus)
                goto label_8;
            else
                goto label_19;
            label_1:
            DockControl dockControl = null;
            if (dockControl == null)
                return;
            dockControl.x6d1b64d6c637a91d(true);
            return;
            label_8:
            layout.Controls.Remove(x43bec302f92080b9);
            if (layout.Controls.Count == 0)
                goto label_9;
            label_2:
            if (!containsFocus)
                return;
            if (x43bec302f92080b9.Manager == null)
            {

                return;

            }
            else
            {
                dockControl = x43bec302f92080b9.Manager.FindMostRecentlyUsedWindow(DockSituation.Document, x43bec302f92080b9) ?? x43bec302f92080b9.Manager.FindMostRecentlyUsedWindow(DockSituation.None, x43bec302f92080b9);
                goto label_1;
            }
            label_9:
            LayoutUtilities.x4487f2f8917e3fd0(layout);
            goto label_2;
            label_19:
            if (((containsFocus ? 1 : 0) & 0) == 0)
            {
                Form form = x43bec302f92080b9.FindForm();
                if (form != null)
                {
                    form.ActiveControl = (Control)null;
                    goto label_8;
                }
                else
                    goto label_8;
            }
            else
                goto label_1;

        }

        internal static int xc6fb69ef430eaa44(DockContainer container)
        {
            return (container.AllowResize ? 4 : 0) + LayoutUtilities.xd47535e893e9796b(container.LayoutSystem, container.Vertical ? Orientation.Vertical : Orientation.Horizontal) * 5;
        }

        private static int xd47535e893e9796b(SplitLayoutSystem splitLayout, Orientation orientation)
        {
            int val1 = 0;
            foreach (LayoutSystemBase layout in splitLayout.LayoutSystems)
            {
                SplitLayoutSystem splitLayout1 = layout as SplitLayoutSystem;
                if (splitLayout1 != null)
                    val1 = Math.Max(val1, LayoutUtilities.xd47535e893e9796b(splitLayout1, orientation));
            }
               
            int num = val1;
            if (splitLayout.LayoutSystems.Count > 1 && splitLayout.SplitMode == orientation)
                num += splitLayout.LayoutSystems.Count - 1;
            return num;
        }

        internal static x5678bb8d80c0f12e x4689c8634e31fc55(SandDockManager x91f347c6e97f1846, WindowMetaData xfffbdea061bfa120)
        {
            DockContainer[] dockContainers = x91f347c6e97f1846.GetDockContainers(LayoutUtilities.xf8330a3964a419ba(xfffbdea061bfa120.LastFixedDockSide));
            if (dockContainers.Length == 0)
                return new x5678bb8d80c0f12e(x91f347c6e97f1846.CreateNewDockContainer(xfffbdea061bfa120.LastFixedDockSide, ContainerDockEdge.Inside, xfffbdea061bfa120.DockedContentSize).LayoutSystem, 0);
            if (dockContainers.Length >= xfffbdea061bfa120.xe62a3d24e0fde928.xd25c313925dc7d4e)
                goto label_12;
            else
                goto label_9;
            label_2:
            if (xfffbdea061bfa120.xe62a3d24e0fde928.xd25c313925dc7d4e >= 2)
                goto label_5;
            label_3:
            if (dockContainers.Length != 0)
                return LayoutUtilities.x2f8f74d308cc9f3f(dockContainers[0], xfffbdea061bfa120.xe62a3d24e0fde928.x61743036ad30763d);
            DockContainer newDockContainer = x91f347c6e97f1846.CreateNewDockContainer(xfffbdea061bfa120.LastFixedDockSide, ContainerDockEdge.Inside, xfffbdea061bfa120.DockedContentSize);
            if (15 != 0)
                return new x5678bb8d80c0f12e(newDockContainer.LayoutSystem, 0);
            label_5:
            if (xfffbdea061bfa120.xe62a3d24e0fde928.x71a5d248534c8557 != 0)
            {
                if (xfffbdea061bfa120.xe62a3d24e0fde928.x71a5d248534c8557 == xfffbdea061bfa120.xe62a3d24e0fde928.xd25c313925dc7d4e - 1)
                    return new x5678bb8d80c0f12e(x91f347c6e97f1846.CreateNewDockContainer(xfffbdea061bfa120.LastFixedDockSide, ContainerDockEdge.Inside, xfffbdea061bfa120.DockedContentSize).LayoutSystem, 0);
                else
                    goto label_3;
            }
            else
                goto label_11;
            label_9:

            goto label_2;
            label_11:
            return new x5678bb8d80c0f12e(x91f347c6e97f1846.CreateNewDockContainer(xfffbdea061bfa120.LastFixedDockSide, ContainerDockEdge.Outside, xfffbdea061bfa120.DockedContentSize).LayoutSystem, 0);
            label_12:
            if (xfffbdea061bfa120.xe62a3d24e0fde928.x71a5d248534c8557 < dockContainers.Length && xfffbdea061bfa120.xe62a3d24e0fde928.x71a5d248534c8557 != -1)
                return LayoutUtilities.x2f8f74d308cc9f3f(dockContainers[xfffbdea061bfa120.xe62a3d24e0fde928.x71a5d248534c8557], xfffbdea061bfa120.xe62a3d24e0fde928.x61743036ad30763d);
            else
                goto label_2;
        }

        internal static x5678bb8d80c0f12e x2f8f74d308cc9f3f(DockContainer xd3311d815ca25f02, int[] x27bf3f6bb3609d15)
        {
            SplitLayoutSystem splitLayoutSystem1 = xd3311d815ca25f02.LayoutSystem;
            int[] numArray = x27bf3f6bb3609d15;
            int index1 = 0;
            label_1:
            while (index1 < numArray.Length)
            {
                int index2 = numArray[index1];
                if (index2 >= splitLayoutSystem1.LayoutSystems.Count)
                    return new x5678bb8d80c0f12e(splitLayoutSystem1, splitLayoutSystem1.LayoutSystems.Count);
                SplitLayoutSystem splitLayoutSystem2;
                do
                {
                    splitLayoutSystem2 = splitLayoutSystem1.LayoutSystems[index2] as SplitLayoutSystem;
                    if ((index1 & 0) != 0)
                        goto label_1;
                }
                while ((int)byte.MaxValue != 0 && 0 != 0);
                if (splitLayoutSystem2 == null)
                    return new x5678bb8d80c0f12e(splitLayoutSystem1, index2);
                splitLayoutSystem1 = splitLayoutSystem2;
                ++index1;
            }
            return new x5678bb8d80c0f12e(xd3311d815ca25f02.LayoutSystem, 0);
        }
    }
}
