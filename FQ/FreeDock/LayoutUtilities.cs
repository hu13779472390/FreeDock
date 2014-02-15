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

        internal static bool x12627d27d864cd19
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

        internal static DockSituation x8d287cc6f0a2f529(DockContainer xd3311d815ca25f02)
        {
            if (xd3311d815ca25f02 != null)
                goto label_5;
            label_4:
            return DockSituation.None;
            label_5:
            if (!xd3311d815ca25f02.IsFloating)
            {
                if (xd3311d815ca25f02.Dock == DockStyle.Fill)
                    return DockSituation.Document;
                if (-2 != 0)
                    return DockSituation.Docked;
                else
                    goto label_4;
            }
            else if (0 == 0)
                return DockSituation.Floating;
            else
                goto label_4;
        }

        internal static ControlLayoutSystem[] x1494f515233a1246(DockContainer xd3311d815ca25f02)
        {
            ArrayList arrayList = new ArrayList();
            IEnumerator enumerator = xd3311d815ca25f02.x83627743ea4ce5a2.GetEnumerator();
            try
            {
                while (enumerator.MoveNext())
                {
                    LayoutSystemBase layoutSystemBase = (LayoutSystemBase)enumerator.Current;
                    if (layoutSystemBase is ControlLayoutSystem)
                        arrayList.Add((object)layoutSystemBase);
                }
            }
            finally
            {
                IDisposable disposable = enumerator as IDisposable;
                if (0 != 0 || disposable != null)
                    disposable.Dispose();
            }
            return (ControlLayoutSystem[])arrayList.ToArray(typeof(ControlLayoutSystem));
        }

        internal static ControlLayoutSystem xba5fd484c0e6478b(SandDockManager x91f347c6e97f1846, DockSituation xd39eba9a9a1b028e, x129cb2a2bdfd0ab2 xfffbdea061bfa120)
        {
            DockContainer[] dockContainers1 = {};
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
                        if (0 == 0)
                        {
                            index2 = 0;
                            goto label_17;
                        }
                        else
                            goto label_20;
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
                if (true)
                {
                    if (LayoutUtilities.x8d287cc6f0a2f529(xd3311d815ca25f02) == xd39eba9a9a1b028e)
                    {
                        controlLayoutSystemArray2 = LayoutUtilities.x1494f515233a1246(xd3311d815ca25f02);
                        index4 = 0;
                        goto label_9;
                    }
                }
                else
                    goto label_38;
            }
            else
                goto label_3;
            label_5:
            ++index3;
            goto label_4;
            label_7:
            ControlLayoutSystem controlLayoutSystem1;
            ControlLayoutSystem controlLayoutSystem2;
            if (controlLayoutSystem1.x0217cda8370c1f17 == xfffbdea061bfa120.x703937d70a13725c)
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
                if (-2 == 0)
                    goto label_24;
            }
            else
                goto label_3;
            label_20:
            if (!(controlLayoutSystem3.x0217cda8370c1f17 == xfffbdea061bfa120.x703937d70a13725c))
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
                    int num1;

                    goto label_35;
                    label_27:
                    ControlLayoutSystem controlLayoutSystem4;
                    int index5;
                    if (!(controlLayoutSystem4.x0217cda8370c1f17 == xfffbdea061bfa120.x703937d70a13725c))
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
                    if (0 != 0)
                    {
                        if ((uint)index1 + (uint)num2 >= 0U)
                            goto label_8;
                        else
                            goto label_7;
                    }
                    else
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
                        arrayList.Add((object)layoutSystem.Parent.LayoutSystems.IndexOf(layoutSystem));
                        if (int.MaxValue == 0)
                            goto label_8;
                    }
                }
            }
            while (15 == 0);
            arrayList.Reverse();
            label_8:
            return (int[])arrayList.ToArray(typeof(int));
        }

        internal static DockStyle xf8330a3964a419ba(ContainerDockLocation x9c911703d455884e)
        {
            ContainerDockLocation containerDockLocation = x9c911703d455884e;
            if (1 != 0)
                goto label_4;
            label_1:
            return DockStyle.Right;
            label_4:
            switch (containerDockLocation)
            {
                case ContainerDockLocation.Left:
                    return DockStyle.Left;
                case ContainerDockLocation.Right:
                    goto label_1;
                case ContainerDockLocation.Top:
                    return DockStyle.Top;
                case ContainerDockLocation.Bottom:
                    return DockStyle.Bottom;
                case ContainerDockLocation.Center:
                    return DockStyle.Fill;
                default:
                    if (15 == 0)
                        goto case ContainerDockLocation.Center;
                    else
                        goto case ContainerDockLocation.Center;
            }
        }

        internal static ContainerDockLocation x3650f3b579b2b4d2(DockStyle xca9af438b5818619)
        {
            switch (xca9af438b5818619)
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
                    return ContainerDockLocation.Center;
                default:
                    if (4 == 0)
                        goto case DockStyle.Bottom;
                    else
                        goto case DockStyle.Fill;
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
            foreach (LayoutSystemBase layoutSystemBase in container.x83627743ea4ce5a2)
            {
                if (layoutSystemBase is ControlLayoutSystem)
                    return (ControlLayoutSystem)layoutSystemBase;
            }
            return (ControlLayoutSystem)null;
        }

        internal static void xa7513d57b4844d46(Control x43bec302f92080b9)
        {
            if (x43bec302f92080b9.Parent == null)
                return;
            if (x43bec302f92080b9.ContainsFocus)
                goto label_21;
            label_2:
            while (x43bec302f92080b9 is DockControl)
            {
                ((DockControl)x43bec302f92080b9).xadad18dc04073a00 = true;
                if (0 != 0)
                {
                    if (0 != 0)
                        return;
                }
                else
                    break;
            }
            try
            {
                IContainerControl containerControl = x43bec302f92080b9.Parent.GetContainerControl();
                if (int.MinValue != 0)
                    goto label_13;
                else
                    goto label_11;
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
                if (containerControl.ActiveControl == x43bec302f92080b9)
                    containerControl.ActiveControl = (Control)null;
                label_8:
                x43bec302f92080b9.Parent.Controls.Remove(x43bec302f92080b9);
                if (2 != 0)
                    return;
                label_11:
                if ((int)byte.MaxValue != 0)
                    goto label_4;
                else
                    goto label_5;
                label_13:
                if (containerControl != null)
                {
                    xd3311d815ca25f02 = containerControl as DockContainer;
                    if (xd3311d815ca25f02 != null)
                    {
                        if (-2 == 0)
                        {
                            if (0 == 0)
                                goto label_4;
                            else
                                goto label_6;
                        }
                        else if (xd3311d815ca25f02.x5b1f9c5a8906ff95 || xd3311d815ca25f02.Manager == null)
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
                if (x43bec302f92080b9 is DockControl)
                    ((DockControl)x43bec302f92080b9).xadad18dc04073a00 = false;
            }
            label_21:
            x43bec302f92080b9.Parent.Focus();
            goto label_2;
        }

        private static bool xf96eb78473d85a37(DockContainer xd3311d815ca25f02, SplitLayoutSystem xb25822984a90695b)
        {
            foreach (LayoutSystemBase layoutSystemBase in (CollectionBase) xb25822984a90695b.LayoutSystems)
            {
                if (!(layoutSystemBase is SplitLayoutSystem))
                {
                    ControlLayoutSystem controlLayoutSystem = (ControlLayoutSystem)layoutSystemBase;
                    if (!controlLayoutSystem.Collapsed && (xd3311d815ca25f02.Controls.Contains((Control)controlLayoutSystem.SelectedControl) || 8 == 0) && (controlLayoutSystem.SelectedControl.Visible && controlLayoutSystem.SelectedControl.Enabled))
                    {
                        xd3311d815ca25f02.ActiveControl = (Control)controlLayoutSystem.SelectedControl;
                        return true;
                    }
                }
                else
                {
                    bool flag = LayoutUtilities.xf96eb78473d85a37(xd3311d815ca25f02, (SplitLayoutSystem)layoutSystemBase);
                    if (flag)
                        return true;
                    if (0 != 0)
                        ;
                }
            }
            return false;
        }

        internal static void x4487f2f8917e3fd0(ControlLayoutSystem x6e150040c8d97700)
        {
            if (x6e150040c8d97700 == null)
            {
                if (15 != 0)
                    throw new ArgumentNullException();
            }
            else
                goto label_21;
            label_3:
            DockContainer dockContainer;
            while (dockContainer.x61d88745bde7a5ec())
            {
                if (dockContainer is DocumentContainer && dockContainer.Manager != null && dockContainer.Manager.EnableEmptyEnvironment)
                {
                    if (0 == 0)
                        break;
                }
                else
                {
                    dockContainer.Dispose();
                    if (0 == 0)
                    {
                        if (0 == 0)
                        {
                            if ((int)byte.MaxValue == 0)
                                break;
                            else
                                break;
                        }
                    }
                    else
                        goto label_17;
                }
            }
            return;
            label_11:
            if (x6e150040c8d97700.Parent == null)
                return;
            x6e150040c8d97700.Parent.LayoutSystems.Remove((LayoutSystemBase)x6e150040c8d97700);
            if (0 == 0)
            {
                if (dockContainer == null)
                    return;
                else
                    goto label_3;
            }
            label_16:
            if (x6e150040c8d97700.x10ac79a4257c7f52 == null)
                goto label_11;
            label_17:
            if (x6e150040c8d97700.x10ac79a4257c7f52.x23498f53d87354d4 == x6e150040c8d97700)
            {
                x6e150040c8d97700.x10ac79a4257c7f52.xcdb145600c1b7224(true);
                goto label_11;
            }
            else
                goto label_11;
            label_21:
            dockContainer = x6e150040c8d97700.DockContainer;
            goto label_16;
        }

        internal static void xf1cbd48a28ce6e74(DockControl x43bec302f92080b9)
        {
            if (x43bec302f92080b9 != null)
            {
                ControlLayoutSystem layoutSystem = x43bec302f92080b9.LayoutSystem;
                if (layoutSystem == null)
                    return;
                DockContainer dockContainer = layoutSystem.DockContainer;
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
                layoutSystem.Controls.Remove(x43bec302f92080b9);
                if (layoutSystem.Controls.Count == 0)
                    goto label_9;
                label_2:
                if (!containsFocus)
                    return;
                if (x43bec302f92080b9.Manager == null)
                {
                    if (0 == 0)
                        return;
                    else
                        goto label_1;
                }
                else
                {
                    dockControl = x43bec302f92080b9.Manager.FindMostRecentlyUsedWindow(DockSituation.Document, x43bec302f92080b9) ?? x43bec302f92080b9.Manager.FindMostRecentlyUsedWindow(DockSituation.None, x43bec302f92080b9);
                    goto label_1;
                }
                label_9:
                LayoutUtilities.x4487f2f8917e3fd0(layoutSystem);
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
            else
            {
                bool flag;

                throw new ArgumentNullException();
            }
        }

        internal static int xc6fb69ef430eaa44(DockContainer x0467b00af7810f0c)
        {
            return (x0467b00af7810f0c.AllowResize ? 4 : 0) + LayoutUtilities.xd47535e893e9796b(x0467b00af7810f0c.LayoutSystem, x0467b00af7810f0c.x61c108cc44ef385a ? Orientation.Vertical : Orientation.Horizontal) * 5;
        }

        private static int xd47535e893e9796b(SplitLayoutSystem x6e150040c8d97700, Orientation xf65758d54b79fc7a)
        {
            int val1 = 0;
            IEnumerator enumerator = x6e150040c8d97700.LayoutSystems.GetEnumerator();
            try
            {
                while (enumerator.MoveNext())
                {
                    SplitLayoutSystem x6e150040c8d97700_1 = (LayoutSystemBase)enumerator.Current as SplitLayoutSystem;
                    if (x6e150040c8d97700_1 != null)
                        val1 = Math.Max(val1, LayoutUtilities.xd47535e893e9796b(x6e150040c8d97700_1, xf65758d54b79fc7a));
                }
            }
            finally
            {
                IDisposable disposable = enumerator as IDisposable;
                if ((val1 | -2) == 0 || disposable != null)
                    disposable.Dispose();
            }
            int num = val1;
            if (((num | -1) == 0 || (x6e150040c8d97700.LayoutSystems.Count > 1 || 4 == 0)) && x6e150040c8d97700.SplitMode == xf65758d54b79fc7a)
                num += x6e150040c8d97700.LayoutSystems.Count - 1;
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
            if (-1 == 0)
            {
                if (0 != 0 || 0 == 0)
                    goto label_5;
            }
            else
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
