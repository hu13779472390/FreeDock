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
        private static int sessions;

        internal static bool LayoutInProgress
        {
            get
            {
                return LayoutUtilities.sessions > 0;
            }
        }

        private LayoutUtilities()
        {
        }

        internal static void StartLayoutSession()
        {
            ++LayoutUtilities.sessions;
        }

        internal static void FinishLayoutSession()
        {
            if (LayoutUtilities.sessions <= 0)
                return;
            --LayoutUtilities.sessions;
        }

        internal static DockSituation CheckForDockSituation(DockContainer container)
        {
            if (container == null)
                return DockSituation.None;

            if (container.IsFloating)
                return DockSituation.Floating;

            if (container.Dock == DockStyle.Fill)
                return DockSituation.Document;

            return DockSituation.Docked;

        }

        internal static ControlLayoutSystem[] GetLayoutSystemsFor(DockContainer container)
        {
            ArrayList list = new ArrayList();
            foreach (LayoutSystemBase layout in container.layouts)
            {
                if (layout is ControlLayoutSystem)
                    list.Add(layout);
            }
            return (ControlLayoutSystem[])list.ToArray(typeof(ControlLayoutSystem));
        }

        internal static ControlLayoutSystem xba5fd484c0e6478b(SandDockManager manager, DockSituation dockSituation, x129cb2a2bdfd0ab2 xfffbdea061bfa120)
        {
            DockContainer[] dockContainers1 = { };
            int index1;
            int index2;
            ControlLayoutSystem[] controlLayoutSystemArray1;
            DockContainer[] dockContainers2;
            switch (dockSituation)
            {
                case DockSituation.Docked:
                    dockContainers2 = manager.GetDockContainers();
                    index1 = 0;
                    goto label_25;
                case DockSituation.Document:
                    if (manager.DocumentContainer != null)
                    {
                        controlLayoutSystemArray1 = LayoutUtilities.GetLayoutSystemsFor((DockContainer)manager.DocumentContainer);

                        index2 = 0;
                        goto label_17;

                    }
                    else
                        break;
                case DockSituation.Floating:
                    dockContainers1 = manager.GetDockContainers();
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

                if (LayoutUtilities.CheckForDockSituation(xd3311d815ca25f02) == dockSituation)
                {
                    controlLayoutSystemArray2 = LayoutUtilities.GetLayoutSystemsFor(xd3311d815ca25f02);
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
                if (LayoutUtilities.CheckForDockSituation(xd3311d815ca25f02) == dockSituation)
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
                    controlLayoutSystemArray3 = LayoutUtilities.GetLayoutSystemsFor(xd3311d815ca25f02);
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

        internal static int[] GetIndexesTopDown(ControlLayoutSystem layout)
        {
            ArrayList arrayList = new ArrayList();

            for (LayoutSystemBase ly = layout; ly != null; ly = ly.Parent)
            {
                if (ly.Parent != null)
                {
                    arrayList.Add(ly.Parent.LayoutSystems.IndexOf(ly));
      
                }
            }
            arrayList.Reverse();
            return (int[])arrayList.ToArray(typeof(int));
        }

        internal static DockStyle Convert(ContainerDockLocation location)
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

        internal static ContainerDockLocation Convert(DockStyle style)
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
        // reviewed with 2.4
        internal static void xa7513d57b4844d46(Control control)
        {
            if (control.Parent == null)
                return;
            if (control.ContainsFocus)
                control.Parent.Focus();
            if (control is DockControl)
                ((DockControl)control).IgnoreFontEvents = true;
            try
            {
                IContainerControl containerControl = control.Parent.GetContainerControl();
                if (containerControl != null)
                {
                    DockContainer dockContainer = containerControl as DockContainer;
                    if (dockContainer != null && !dockContainer.x5b1f9c5a8906ff95 && dockContainer.Manager != null && (dockContainer.Manager.OwnerForm != null && dockContainer.Manager.OwnerForm.IsMdiContainer))
                        LayoutUtilities.xf96eb78473d85a37(dockContainer, dockContainer.LayoutSystem);
                    else if (containerControl.ActiveControl == control)
                        containerControl.ActiveControl = null;
                }
                control.Parent.Controls.Remove(control);
            }
            finally
            {
                if (control is DockControl)
                    ((DockControl)control).IgnoreFontEvents = false;
            }
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
        // reviewed with 2.4
        internal static void x4487f2f8917e3fd0(ControlLayoutSystem controlLayout)
        {
            if (controlLayout == null)
                throw new ArgumentNullException();
            DockContainer dockContainer = controlLayout.DockContainer;
            if (controlLayout.AutoHideBar != null && controlLayout.AutoHideBar.ShowingLayoutSystem == controlLayout)
                controlLayout.AutoHideBar.xcdb145600c1b7224(true);
            if (controlLayout.Parent == null)
                return;
            controlLayout.Parent.LayoutSystems.Remove((LayoutSystemBase)controlLayout);
            if (dockContainer == null || !dockContainer.x61d88745bde7a5ec())
                return;
            if (!(dockContainer is DocumentContainer) || dockContainer.Manager == null || !dockContainer.Manager.EnableEmptyEnvironment)
                dockContainer.Dispose();
        }
        // reviewed with 2.4
        internal static void RemoveDockControl(DockControl dockControl)
        {
            if (dockControl == null)
                throw new ArgumentNullException();
            ControlLayoutSystem layout = dockControl.LayoutSystem;
            if (layout == null)
                return;
            DockContainer dockContainer = layout.DockContainer;
            bool containsFocus = dockControl.ContainsFocus;
            if (containsFocus)
            {
                Form form = dockControl.FindForm();
                if (form != null)
                    form.ActiveControl = null;
            }
            layout.Controls.Remove(dockControl);
            if (layout.Controls.Count == 0)
                LayoutUtilities.x4487f2f8917e3fd0(layout);

            if (!containsFocus || dockControl.Manager == null)
                return;

            DockControl MRUW = dockControl.Manager.FindMostRecentlyUsedWindow(DockSituation.Document, dockControl) ?? dockControl.Manager.FindMostRecentlyUsedWindow(DockSituation.None, dockControl);
            if (MRUW != null)
                MRUW.SetActive(true);
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

        internal static SplitLayoutEntry x4689c8634e31fc55(SandDockManager manager, WindowMetaData metaData)
        {
            DockContainer[] dockContainers = manager.GetDockContainers(LayoutUtilities.Convert(metaData.LastFixedDockSide));
            if (dockContainers.Length == 0)
                return new SplitLayoutEntry(manager.CreateNewDockContainer(metaData.LastFixedDockSide, ContainerDockEdge.Inside, metaData.DockedContentSize).LayoutSystem, 0);
            if (dockContainers.Length >= metaData.xe62a3d24e0fde928.xd25c313925dc7d4e)
            {
                if (metaData.xe62a3d24e0fde928.x71a5d248534c8557 < dockContainers.Length && metaData.xe62a3d24e0fde928.x71a5d248534c8557 != -1)
                    return LayoutUtilities.x2f8f74d308cc9f3f(dockContainers[metaData.xe62a3d24e0fde928.x71a5d248534c8557], metaData.xe62a3d24e0fde928.Indices);
            }
            DockContainer newDockContainer;
            if (metaData.xe62a3d24e0fde928.xd25c313925dc7d4e >= 2)
            {
                if (metaData.xe62a3d24e0fde928.x71a5d248534c8557 != 0)
                {
                    if (metaData.xe62a3d24e0fde928.x71a5d248534c8557 == metaData.xe62a3d24e0fde928.xd25c313925dc7d4e - 1)
                        return new SplitLayoutEntry(manager.CreateNewDockContainer(metaData.LastFixedDockSide, ContainerDockEdge.Inside, metaData.DockedContentSize).LayoutSystem, 0);

                }
                else
                    return new SplitLayoutEntry(manager.CreateNewDockContainer(metaData.LastFixedDockSide, ContainerDockEdge.Outside, metaData.DockedContentSize).LayoutSystem, 0);
            }

            if (dockContainers.Length != 0)
                return LayoutUtilities.x2f8f74d308cc9f3f(dockContainers[0], metaData.xe62a3d24e0fde928.Indices);
            newDockContainer = manager.CreateNewDockContainer(metaData.LastFixedDockSide, ContainerDockEdge.Inside, metaData.DockedContentSize);
            return new SplitLayoutEntry(newDockContainer.LayoutSystem, 0);
        }

        internal static SplitLayoutEntry x2f8f74d308cc9f3f(DockContainer dockContainer, int[] x27bf3f6bb3609d15)
        {
            SplitLayoutSystem splitLayout1 = dockContainer.LayoutSystem;
            int[] numArray = x27bf3f6bb3609d15;
            for (int i = 0; i < numArray.Length; i++)
            {
                int index2 = numArray[i];
                if (index2 >= splitLayout1.LayoutSystems.Count)
                    return new SplitLayoutEntry(splitLayout1, splitLayout1.LayoutSystems.Count);
                SplitLayoutSystem splitLayou2 = splitLayout1.LayoutSystems[index2] as SplitLayoutSystem;
                if (splitLayou2 == null)
                    return new SplitLayoutEntry(splitLayout1, index2);
                splitLayout1 = splitLayou2;
            }
            return new SplitLayoutEntry(dockContainer.LayoutSystem, 0);
        }
    }
}
