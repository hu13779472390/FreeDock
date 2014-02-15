// Type: TD.SandDock.x31248f32f85df1dd
// Assembly: SandDock, Version=3.0.6.1, Culture=neutral, PublicKeyToken=75b7ec17dd7c14c3
// MVID: 86A16A8A-6BB9-495D-A857-1A3306E497E9
// Assembly location: C:\Program Files (x86)\Divelements Limited\SandDock for Windows Forms\SandDock.dll

using System;
using System.Collections;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using FQ.FreeDock.Rendering;

namespace FQ.FreeDock
{
	internal class x31248f32f85df1dd : xedb4922162c60d3d
	{
		private ControlLayoutSystem x5d62a4c2b1aa6ba9;
		private x31248f32f85df1dd.x23d0185c2770c169 xa0a376f49c1ad375;
		private bool x347de2b6e474668a;
		private bool x66992a14bbd05efe;
		private Rectangle x6f306c95372dd403;
		private Rectangle x8caac3836061e4ad;
		private ArrayList x71ba9145749e5eef;

		public x31248f32f85df1dd(SandDockManager manager, DockContainer container, LayoutSystemBase sourceControlSystem, DockControl sourceControl, int dockedSize, System.Drawing.Point startPoint, DockingHints dockingHints)
      : base(manager, container, sourceControlSystem, sourceControl, dockedSize, startPoint, dockingHints)
		{
			this.x71ba9145749e5eef = new ArrayList();
			do
			{
				if (this.x460ab163f44a604d == null)
				{
					if ((uint)dockedSize >= 0U)
						goto label_6;
				}
				else if (this.x460ab163f44a604d.DockSystemContainer == null)
				{
					if (1 != 0)
						goto label_9;
				}
				else
					this.xcaa196e697d8d7c5();
			}
			while ((uint)dockedSize + (uint)dockedSize < 0U);
			goto label_2;
			label_6:
			return;
			label_9:
			return;
			label_2:
			;
		}

		private void xcaa196e697d8d7c5()
		{
			this.x6f306c95372dd403 = xedb4922162c60d3d.xc68a4bb946c59a9e(this.x460ab163f44a604d.DockSystemContainer.ClientRectangle, this.x460ab163f44a604d.DockSystemContainer);
			do
			{
				this.x8caac3836061e4ad = xedb4922162c60d3d.xc68a4bb946c59a9e(xedb4922162c60d3d.x41c62f474d3fb367(this.x460ab163f44a604d.DockSystemContainer), this.x460ab163f44a604d.DockSystemContainer);
				while (this.xe302f2203dc14a18(ContainerDockLocation.Top))
				{
					this.x71ba9145749e5eef.Add((object)new x31248f32f85df1dd.x23d0185c2770c169(this, this.x6f306c95372dd403, DockStyle.Top));
					if (1 != 0)
						break;
				}
				if (this.xe302f2203dc14a18(ContainerDockLocation.Left))
					goto label_30;
				else
					goto label_32;
				label_26:
				if (!this.xe302f2203dc14a18(ContainerDockLocation.Bottom))
					break;
				label_29:
				this.x71ba9145749e5eef.Add((object)new x31248f32f85df1dd.x23d0185c2770c169(this, this.x6f306c95372dd403, DockStyle.Bottom));
				continue;
				label_30:
				this.x71ba9145749e5eef.Add((object)new x31248f32f85df1dd.x23d0185c2770c169(this, this.x6f306c95372dd403, DockStyle.Left));
				goto label_26;
				label_32:
				if (int.MaxValue != 0)
					goto label_26;
				else
					goto label_29;
			}
			while (4 == 0);
			if (!this.xe302f2203dc14a18(ContainerDockLocation.Right))
				goto label_25;
			else
				goto label_28;
			label_14:
			int num1 = 1;
			label_16:
			bool flag1 = num1 != 0;
			if (flag1)
				this.x71ba9145749e5eef.Add((object)new x31248f32f85df1dd.x23d0185c2770c169(this, this.x8caac3836061e4ad, DockStyle.Fill));
			if (this.x460ab163f44a604d == null)
				return;
			bool flag2;
			if ((uint)flag2 >= 0U)
			{
				if (this.x460ab163f44a604d.OwnerForm == null)
				{
					if (0 == 0)
						return;
					if ((uint)flag2 - (uint)flag1 <= uint.MaxValue)
						goto label_22;
				}
				IEnumerator enumerator = this.x71ba9145749e5eef.GetEnumerator();
				try
				{
					while (enumerator.MoveNext())
						this.x460ab163f44a604d.OwnerForm.AddOwnedForm((Form)enumerator.Current);
					return;
				}
				finally
				{
					IDisposable disposable = enumerator as IDisposable;
					if (disposable != null)
						disposable.Dispose();
				}
			}
			else
				goto label_25;
			label_19:
			int num2 = 1;
			label_20:
			flag2 = num2 != 0;
			bool flag3;
			if (!flag3)
			{
				if (!this.xe302f2203dc14a18(ContainerDockLocation.Center))
				{
					num1 = flag2 ? 1 : 0;
					goto label_16;
				}
				else
					goto label_14;
			}
			else
			{
				num1 = 0;
				goto label_16;
			}
			label_21:
			if ((!this.xe302f2203dc14a18(ContainerDockLocation.Right) || ((flag2 ? 1 : 0) | int.MinValue) == 0 || (uint)flag2 - (uint)flag3 > uint.MaxValue) && !this.xe302f2203dc14a18(ContainerDockLocation.Top))
			{
				num2 = this.xe302f2203dc14a18(ContainerDockLocation.Bottom) ? 1 : 0;
				goto label_20;
			}
			else
				goto label_19;
			label_22:
			if (!this.xe302f2203dc14a18(ContainerDockLocation.Left))
				goto label_21;
			else
				goto label_40;
			label_25:
			flag3 = this.xc99dabdb533b119a.Dock == DockStyle.Fill && !this.xc99dabdb533b119a.IsFloating;
			goto label_22;
			label_28:
			this.x71ba9145749e5eef.Add((object)new x31248f32f85df1dd.x23d0185c2770c169(this, this.x6f306c95372dd403, DockStyle.Right));
			bool flag4;
			if (((flag4 ? 1 : 0) & 0) == 0)
				goto label_25;
			label_40:
			if (0 == 0)
			{
				if ((uint)flag3 < 0U)
					goto label_21;
				else
					goto label_19;
			}
			else if (((flag2 ? 1 : 0) | -1) != 0)
				goto label_14;
		}

		protected override xedb4922162c60d3d.DockTarget FindDockTarget(System.Drawing.Point position)
		{
			xedb4922162c60d3d.DockTarget x11d58b056c032b03 = (xedb4922162c60d3d.DockTarget)null;
			label_68:
			bool flag1 = this.x6f306c95372dd403.Contains(position);
			bool flag2 = this.x8caac3836061e4ad.Contains(position);
			int index1;
			object[] objArray1;
			do
			{
				if ((uint)index1 - (uint)flag2 <= uint.MaxValue)
					goto label_67;
				else
					goto label_65;
				label_63:
				objArray1 = this.x71ba9145749e5eef.ToArray();
				continue;
				label_65:
				if (flag2 != this.x66992a14bbd05efe)
				{
					if ((uint)index1 <= uint.MaxValue)
					{
						if ((uint)index1 + (uint)flag1 <= uint.MaxValue)
							goto label_63;
					}
					else
						goto label_52;
				}
				else
					goto label_42;
				label_67:
				if (flag1 == this.x347de2b6e474668a)
					goto label_65;
				else
					goto label_63;
			}
			while ((uint)flag1 < 0U);
			goto label_64;
			label_42:
			ControlLayoutSystem controlLayoutSystem;
			do
			{
				controlLayoutSystem = this.x674f2f3b17dc4197(position, out x11d58b056c032b03);
				if ((index1 | int.MinValue) != 0)
				{
					if (controlLayoutSystem == this.xf333586e50dccad2)
					{
						if ((uint)flag2 + (uint)flag2 >= 0U)
						{
							if (this.x59ae058c4a0dec87 == null)
							{
								controlLayoutSystem = (ControlLayoutSystem)null;
								if (((flag2 ? 1 : 0) & 0) == 0)
								{
									if (0 != 0)
									{
										if (0 == 0)
											goto label_50;
									}
									else
										goto label_32;
								}
								else
									goto label_45;
							}
							else
								goto label_32;
						}
						else
							goto label_50;
					}
					else
						goto label_32;
				}
				else
					goto label_20;
			}
			while (0 != 0);
			goto label_44;
			label_2:
			Rectangle x6ae4612a8469678e1;
			if (x6ae4612a8469678e1.Contains(position))
				goto label_8;
			label_4:
			++index1;
			label_5:
			int index2;
			object[] objArray2;
			x31248f32f85df1dd.x23d0185c2770c169 x23d0185c2770c169_1;
			if (index1 < objArray2.Length)
			{
				x23d0185c2770c169_1 = (x31248f32f85df1dd.x23d0185c2770c169)objArray2[index1];
				if (x11d58b056c032b03 == null)
				{
					x6ae4612a8469678e1 = x23d0185c2770c169_1.x6ae4612a8469678e;
					if (2 != 0)
					{
						if (0 == 0)
						{
							if ((uint)flag2 - (uint)index2 > uint.MaxValue)
							{
								if ((uint)flag1 < 0U)
									goto label_60;
							}
							else
								goto label_2;
						}
						else
							goto label_13;
					}
					else
						goto label_17;
				}
				else
					goto label_4;
			}
			else
				goto label_71;
			label_8:
			x11d58b056c032b03 = x23d0185c2770c169_1.x22749e65b5253094(position);
			if (0 == 0)
			{
				if ((uint)index2 - (uint)index2 < 0U)
					goto label_2;
				else
					goto label_4;
			}
			else
				goto label_26;
			label_13:
			objArray2 = this.x71ba9145749e5eef.ToArray();
			index1 = 0;
			goto label_5;
			label_14:
			if ((uint)flag2 + (uint)index2 >= 0U)
			{
				if ((uint)flag1 >= 0U)
				{
					if (2 != 0)
						goto label_13;
					else
						goto label_26;
				}
				else
					goto label_22;
			}
			else
				goto label_17;
			label_15:
			Rectangle x6ae4612a8469678e2;
			if (!x6ae4612a8469678e2.Contains(position))
				goto label_14;
			label_17:
			if (x11d58b056c032b03 != null)
			{
				if ((uint)flag1 - (uint)index1 > uint.MaxValue)
				{
					if (((flag1 ? 1 : 0) | -1) == 0)
						goto label_15;
					else
						goto label_14;
				}
				else
					goto label_13;
			}
			else
				goto label_20;
			label_18:
			if (this.xa0a376f49c1ad375 == null)
			{
				if ((uint)index2 <= uint.MaxValue)
					goto label_13;
				else
					goto label_15;
			}
			else
				goto label_24;
			label_20:
			x11d58b056c032b03 = this.xa0a376f49c1ad375.x22749e65b5253094(position);
			goto label_13;
			label_22:
			if (x11d58b056c032b03.type != xedb4922162c60d3d.DockTargetType.Undefined)
			{
				if ((uint)flag2 >= 0U)
					goto label_18;
			}
			else
			{
				x11d58b056c032b03 = (xedb4922162c60d3d.DockTarget)null;
				if (8 != 0)
					goto label_18;
				else
					goto label_32;
			}
			label_24:
			x6ae4612a8469678e2 = this.xa0a376f49c1ad375.x6ae4612a8469678e;
			goto label_15;
			label_26:
			if ((uint)index1 - (uint)flag2 < 0U)
			{
				if (-1 != 0)
					goto label_68;
			}
			else if ((uint)index1 - (uint)index2 >= 0U)
			{
				if ((uint)flag1 - (uint)flag1 < 0U)
					goto label_58;
				else
					goto label_2;
			}
			else
				goto label_71;
			label_32:
			if (controlLayoutSystem != this.x5d62a4c2b1aa6ba9)
				goto label_33;
			label_30:
			if (x11d58b056c032b03 != null)
			{
				if ((uint)index2 + (uint)flag1 <= uint.MaxValue)
				{
					if ((index2 | 2) != 0)
						goto label_22;
					else
						goto label_18;
				}
				else
					goto label_14;
			}
			else
				goto label_18;
			label_33:
			if (this.xa0a376f49c1ad375 != null)
			{
				this.xa0a376f49c1ad375.x8ffe90e7fbccfccd();
				this.xa0a376f49c1ad375 = (x31248f32f85df1dd.x23d0185c2770c169)null;
			}
			this.x5d62a4c2b1aa6ba9 = controlLayoutSystem;
			if (this.x5d62a4c2b1aa6ba9 != null)
			{
				this.xa0a376f49c1ad375 = new x31248f32f85df1dd.x23d0185c2770c169(this, this.x5d62a4c2b1aa6ba9);
				this.xa0a376f49c1ad375.x35579b297303ed43();
				goto label_30;
			}
			else
				goto label_30;
			label_71:
			return x11d58b056c032b03;
			label_44:
			if (flag1 != this.x347de2b6e474668a)
				goto label_50;
			label_45:
			++index2;
			label_46:
			x31248f32f85df1dd.x23d0185c2770c169 x23d0185c2770c169_2;
			if (index2 >= objArray1.Length)
			{
				this.x347de2b6e474668a = flag1;
				this.x66992a14bbd05efe = flag2;
				goto label_42;
			}
			else
			{
				x23d0185c2770c169_2 = (x31248f32f85df1dd.x23d0185c2770c169)objArray1[index2];
				if ((uint)flag2 <= uint.MaxValue)
				{
					if (x23d0185c2770c169_2.xa9803b9efaf4da87 == DockStyle.Fill)
						goto label_55;
				}
				else
					goto label_60;
			}
			label_49:
			if (x23d0185c2770c169_2.xa9803b9efaf4da87 != DockStyle.Fill)
				goto label_44;
			else
				goto label_45;
			label_50:
			if (flag1)
			{
				x23d0185c2770c169_2.x35579b297303ed43();
				goto label_45;
			}
			label_52:
			x23d0185c2770c169_2.x5486e0b5e830d25c();
			goto label_45;
			label_55:
			if (flag2 == this.x66992a14bbd05efe)
			{
				if ((index2 & 0) == 0)
					goto label_49;
				else
					goto label_44;
			}
			label_56:
			if (!flag2)
			{
				x23d0185c2770c169_2.x5486e0b5e830d25c();
				goto label_45;
			}
			label_58:
			x23d0185c2770c169_2.x35579b297303ed43();
			goto label_45;
			label_60:
			if ((uint)flag2 + (uint)index2 > uint.MaxValue)
			{
				if ((uint)index1 + (uint)flag1 <= uint.MaxValue)
					goto label_56;
				else
					goto label_58;
			}
			else
				goto label_55;
			label_64:
			index2 = 0;
			goto label_46;
		}

		private ControlLayoutSystem x674f2f3b17dc4197(System.Drawing.Point x13d4cb8d1bd20347, out xedb4922162c60d3d.DockTarget x11d58b056c032b03)
		{
			x11d58b056c032b03 = (xedb4922162c60d3d.DockTarget)null;
			label_26:
			int num = 1;
			label_1:
			while (num >= 0)
			{
				bool flag = Convert.ToBoolean(num);
				int index;
				ControlLayoutSystem x6e150040c8d97700;
				do
				{
					ControlLayoutSystem[] xcdb018cc067a38ae = this.xcdb018cc067a38ae;
					label_20:
					index = 0;
					while (true)
					{
						do
						{
							if (index >= xcdb018cc067a38ae.Length)
								--num;
							else
								goto label_21;
							label_10:
							continue;
							label_21:
							x6e150040c8d97700 = xcdb018cc067a38ae[index];
							if (x6e150040c8d97700.DockContainer.IsFloating != flag)
							{
								if (8 != 0 && (uint)num + (uint)index >= 0U)
									goto label_3;
							}
							else
								goto label_22;
							label_7:
							Rectangle rectangle;
							if (!rectangle.Contains(x13d4cb8d1bd20347))
							{
								if ((uint)flag + (uint)flag <= uint.MaxValue)
								{
									if (int.MinValue != 0)
										goto label_3;
									else
										goto label_10;
								}
								else
									goto label_20;
							}
							else
								goto label_18;
							label_22:
							rectangle = new Rectangle(x6e150040c8d97700.DockContainer.PointToScreen(x6e150040c8d97700.Bounds.Location), x6e150040c8d97700.Bounds.Size);
							goto label_7;
						}
						while (15 != 0 && (uint)index + (uint)index > uint.MaxValue);
						break;
						label_3:
						++index;
					}
					if ((uint)num >= 0U)
					{
						if (((flag ? 1 : 0) | int.MinValue) == 0)
						{
							if ((uint)num + (uint)flag <= uint.MaxValue)
								goto label_1;
						}
						else
							goto label_25;
					}
					else
						goto label_12;
				}
				while ((uint)flag - (uint)flag >= 0U);
				goto label_16;
				label_12:
				ControlLayoutSystem controlLayoutSystem = (ControlLayoutSystem)null;
				goto label_28;
				label_16:
				if ((uint)flag >= 0U)
					goto label_18;
				label_17:
				do
				{
					controlLayoutSystem = x6e150040c8d97700;
				}
				while ((uint)flag + (uint)flag < 0U);
				goto label_28;
				label_18:
				x11d58b056c032b03 = this.xede53ab1a4b2e20b(x6e150040c8d97700.DockContainer, x6e150040c8d97700, x13d4cb8d1bd20347, false);
				if (x11d58b056c032b03.type != xedb4922162c60d3d.DockTargetType.Undefined)
				{
					if ((num | 4) != 0)
						goto label_12;
				}
				else
					goto label_17;
				label_25:
				if ((index | 1) != 0)
				{
					if ((uint)index >= 0U)
						continue;
				}
				else
					goto label_26;
				label_28:
				return controlLayoutSystem;
			}
			return (ControlLayoutSystem)null;
		}

		public override void Dispose()
		{
			if (this.xa0a376f49c1ad375 != null)
			{
				this.xa0a376f49c1ad375.x8ffe90e7fbccfccd();
				this.xa0a376f49c1ad375 = (x31248f32f85df1dd.x23d0185c2770c169)null;
			}
			foreach (x31248f32f85df1dd.x23d0185c2770c169 x23d0185c2770c169 in this.x71ba9145749e5eef)
				x23d0185c2770c169.x8ffe90e7fbccfccd();
			this.x71ba9145749e5eef.Clear();
			if (0 != 0)
				;
			base.Dispose();
		}

		private class x23d0185c2770c169 : xd0a1f65420a07725
		{
			private Rectangle xda73fcb97c77d998 = Rectangle.Empty;
			private DockSide xf33779c598cac695 = DockSide.None;
			private const int xca96dc7024c32126 = 88;
			private const int xc82cb74794544a35 = 88;
			private const int x6b0037d5c155e862 = 200;
			private const int x77bf04ec211c4a37 = 16;
			private const int x339acab5bf3e83ae = 64;
			private x31248f32f85df1dd x91f347c6e97f1846;
			private ControlLayoutSystem x6e150040c8d97700;
			private bool x3321191c6256921e;
			private Bitmap xaf410773a496d7d0;
			private bool x3b280f462145bf12;
			private Timer x1700d731d6397130;
			private int x1a5b1715d3a0d7a6;
			private bool x9063896ecf738664;
			private DockStyle xca9af438b5818619;

			public DockStyle xa9803b9efaf4da87
			{
				get
				{
					return this.xca9af438b5818619;
				}
			}

			private Rectangle xa449c67cf6031591
			{
				get
				{
					return new Rectangle(28, 28, 32, 32);
				}
			}

			private Rectangle x922c86dd03ed0805
			{
				get
				{
					return new Rectangle(29, 0, 29, 28);
				}
			}

			private Rectangle x71b3d93f18a3424c
			{
				get
				{
					return new Rectangle(60, 29, 28, 29);
				}
			}

			private Rectangle xaf8b7fb67e0c3bcb
			{
				get
				{
					return new Rectangle(29, 60, 29, 28);
				}
			}

			private Rectangle xd163ca0298f48d0e
			{
				get
				{
					return new Rectangle(0, 29, 28, 29);
				}
			}

			public Rectangle x6ae4612a8469678e
			{
				get
				{
					return this.xda73fcb97c77d998;
				}
			}

			private x23d0185c2770c169()
			{
				do
				{
					this.FormBorderStyle = FormBorderStyle.None;
					this.ShowInTaskbar = false;
					this.StartPosition = FormStartPosition.Manual;
					this.x1700d731d6397130 = new Timer();
					this.x1700d731d6397130.Interval = 50;
					if (int.MinValue != 0)
						this.x1700d731d6397130.Tick += new EventHandler(this.xa1ebc192abdef013);
					this.xaf410773a496d7d0 = new Bitmap(88, 88, PixelFormat.Format32bppArgb);
				}
				while (-1 == 0);
			}

			public x23d0185c2770c169(x31248f32f85df1dd manager, Rectangle fc, DockStyle dockStyle)
        : this()
			{
				this.x91f347c6e97f1846 = manager;
				this.xca9af438b5818619 = dockStyle;
				DockStyle dockStyle1 = dockStyle;
				if (0 == 0)
					goto label_5;
				else
					goto label_9;
				label_1:
				this.xda73fcb97c77d998 = new Rectangle(fc.X + fc.Width / 2 - 44, fc.Y + fc.Height / 2 - 44, 88, 88);
				label_2:
				this.x912beb3fd0dd9feb();
				return;
				label_5:
				switch (dockStyle1)
				{
					case DockStyle.Top:
						this.xda73fcb97c77d998 = new Rectangle(fc.X + fc.Width / 2 - 44, fc.Y + 15, 88, 88);
						if (-2 == 0)
							goto case DockStyle.Bottom;
						else
							goto label_2;
					case DockStyle.Bottom:
						this.xda73fcb97c77d998 = new Rectangle(fc.X + fc.Width / 2 - 44, fc.Bottom - 88 - 15, 88, 88);
						goto label_2;
					case DockStyle.Left:
						this.xda73fcb97c77d998 = new Rectangle(fc.X + 15, fc.Y + fc.Height / 2 - 44, 88, 88);
						goto label_2;
					case DockStyle.Right:
						this.xda73fcb97c77d998 = new Rectangle(fc.Right - 88 - 15, fc.Y + fc.Height / 2 - 44, 88, 88);
						if (4 == 0)
							goto case DockStyle.Top;
						else
							goto label_2;
					case DockStyle.Fill:
						goto label_1;
					default:
						goto label_2;
				}
				label_9:
				if (2 != 0)
					goto label_1;
			}

			public x23d0185c2770c169(x31248f32f85df1dd manager, ControlLayoutSystem layoutSystem)
        : this()
			{
				this.x91f347c6e97f1846 = manager;
				this.x6e150040c8d97700 = layoutSystem;
				this.xda73fcb97c77d998 = new Rectangle(layoutSystem.DockContainer.PointToScreen(layoutSystem.Bounds.Location), layoutSystem.Bounds.Size);
				this.xda73fcb97c77d998 = new Rectangle(this.xda73fcb97c77d998.X + this.xda73fcb97c77d998.Width / 2 - 44, this.xda73fcb97c77d998.Y + this.xda73fcb97c77d998.Height / 2 - 44, 88, 88);
				if (0 != 0)
					;
				this.x912beb3fd0dd9feb();
			}

			[DllImport("user32.dll")]
			private static extern bool SetWindowPos(HandleRef hWnd, int hWndInsertAfter, int x, int y, int cx, int cy, int flags);

			private void x912beb3fd0dd9feb()
			{
				using (Graphics x41347a961b838962 = Graphics.FromImage((Image)this.xaf410773a496d7d0))
				{
					xa811784015ed8842.x91433b5e99eb7cac(x41347a961b838962, Color.Transparent);
					if (1 != 0)
						goto label_66;
					else
						goto label_21;
					label_4:
					if (this.xca9af438b5818619 == DockStyle.None)
						goto label_3;
					else
						goto label_7;
					label_2:
					if (this.xca9af438b5818619 != DockStyle.Fill)
					{
						if (-1 != 0)
							goto label_71;
						else
							goto label_10;
					}
					label_3:
					Color transparent;
					Color highlight;
					this.x6e8df868b7130012(x41347a961b838962, !this.x3321191c6256921e || this.xf33779c598cac695 != DockSide.None ? transparent : highlight);
					if (3 == 0)
						goto label_2;
					else
						goto label_31;
					label_7:
					if (0 == 0 || 2 != 0)
						goto label_2;
					else
						goto label_8;
					label_5:
					if (this.xca9af438b5818619 != DockStyle.None && this.xca9af438b5818619 != DockStyle.Fill)
						goto label_8;
					label_6:
					do
					{
						this.x46d7024135bf7082(x41347a961b838962, !this.x3321191c6256921e || this.xf33779c598cac695 != DockSide.Left ? transparent : highlight);
					}
					while (-1 == 0);
					goto label_4;
					label_8:
					if (this.xca9af438b5818619 != DockStyle.Left)
						goto label_4;
					else
						goto label_6;
					label_10:
					if (this.xca9af438b5818619 != DockStyle.Bottom)
						goto label_5;
					label_11:
					this.x9ceea7a4567f6a5f(x41347a961b838962, !this.x3321191c6256921e || this.xf33779c598cac695 != DockSide.Bottom ? transparent : highlight);
					goto label_5;
					label_12:
					this.xa1ff3514b97ff955(x41347a961b838962, !this.x3321191c6256921e || this.xf33779c598cac695 != DockSide.Right ? transparent : highlight);
					label_13:
					if (this.xca9af438b5818619 == DockStyle.None || this.xca9af438b5818619 == DockStyle.Fill)
						goto label_11;
					else
						goto label_10;
					label_21:
					if (this.xca9af438b5818619 == DockStyle.Left)
					{
						using (Image image = Image.FromStream(typeof(x31248f32f85df1dd.x23d0185c2770c169).Assembly.GetManifestResourceStream("TD.SandDock.Resources.dockinghintleft.png")))
						{
							x41347a961b838962.DrawImageUnscaled(image, 0, 29);
							goto label_29;
						}
					}
					label_22:
					if (this.xca9af438b5818619 == DockStyle.Right)
					{
						if (0 == 0)
						{
							using (Image image = Image.FromStream(typeof(x31248f32f85df1dd.x23d0185c2770c169).Assembly.GetManifestResourceStream("TD.SandDock.Resources.dockinghintright.png")))
								x41347a961b838962.DrawImageUnscaled(image, 57, 29);
						}
						else
							goto label_12;
					}
					label_29:
					highlight = SystemColors.Highlight;
					transparent = Color.Transparent;
					if (0 == 0)
						goto label_19;
					else
						goto label_30;
					label_14:
					this.xd349d1e0601e763e(x41347a961b838962, !this.x3321191c6256921e || this.xf33779c598cac695 != DockSide.Top ? transparent : highlight);
					label_16:
					if (this.xca9af438b5818619 == DockStyle.None || (this.xca9af438b5818619 == DockStyle.Fill || this.xca9af438b5818619 == DockStyle.Right))
						goto label_12;
					else
						goto label_13;
					label_19:
					if (0 == 0)
					{
						if (this.xca9af438b5818619 != DockStyle.None)
						{
							if (1 != 0)
							{
								if (0 != 0)
									goto label_21;
							}
							else
								goto label_60;
						}
						else
							goto label_14;
					}
					else
						goto label_21;
					label_30:
					if (-1 != 0)
					{
						if (this.xca9af438b5818619 == DockStyle.Fill || this.xca9af438b5818619 == DockStyle.Top)
							goto label_14;
						else
							goto label_16;
					}
					label_31:
					if (int.MaxValue != 0)
						goto label_71;
					else
						goto label_66;
					label_60:
					using (Image image = Image.FromStream(typeof(x31248f32f85df1dd.x23d0185c2770c169).Assembly.GetManifestResourceStream("TD.SandDock.Resources.dockinghintcenter.png")))
					{
						x41347a961b838962.DrawImageUnscaled(image, 0, 0);
						goto label_29;
					}
					label_66:
					if (int.MaxValue != 0)
					{
						if (this.xca9af438b5818619 != DockStyle.None)
						{
							if (0 == 0)
							{
								if (0 != 0)
									goto label_53;
								else
									goto label_58;
								label_38:
								using (Image image = Image.FromStream(typeof(x31248f32f85df1dd.x23d0185c2770c169).Assembly.GetManifestResourceStream("TD.SandDock.Resources.dockinghintbottom.png")))
								{
									x41347a961b838962.DrawImageUnscaled(image, 29, 57);
									goto label_29;
								}
								label_45:
								if (-1 == 0)
									goto label_56;
								label_46:
								if (this.xca9af438b5818619 != DockStyle.Top)
								{
									if (this.xca9af438b5818619 != DockStyle.Bottom)
									{
										if (4 == 0)
											goto label_58;
										else
											goto label_21;
									}
									else
										goto label_38;
								}
								else
								{
									using (Image image = Image.FromStream(typeof(x31248f32f85df1dd.x23d0185c2770c169).Assembly.GetManifestResourceStream("TD.SandDock.Resources.dockinghinttop.png")))
									{
										x41347a961b838962.DrawImageUnscaled(image, 29, 0);
										goto label_29;
									}
								}
								label_53:
								if (int.MinValue != 0)
								{
									if (8 != 0)
									{
										if (8 != 0)
											goto label_45;
									}
									else
										goto label_22;
								}
								else
									goto label_58;
								label_56:
								if (2 != 0)
								{
									if (0 == 0)
									{
										if ((int)byte.MaxValue != 0)
											goto label_46;
										else
											goto label_45;
									}
									else
										goto label_38;
								}
								else
									goto label_53;
								label_58:
								if (this.xca9af438b5818619 != DockStyle.Fill)
								{
									if (0 == 0)
										goto label_56;
									else
										goto label_53;
								}
								else
									goto label_60;
							}
							else
								goto label_21;
						}
						else
							goto label_60;
					}
					else
						goto label_6;
				}
				label_71:
				this.x0ecee64b07d2d5b1(this.xaf410773a496d7d0, byte.MaxValue);
			}

			protected override void Dispose(bool disposing)
			{
				if (disposing)
				{
					this.xaf410773a496d7d0.Dispose();
					this.x1700d731d6397130.Tick -= new EventHandler(this.xa1ebc192abdef013);
					this.x1700d731d6397130.Dispose();
				}
				base.Dispose(disposing);
			}

			private xedb4922162c60d3d.DockTarget xd9d182c023a01aa8(System.Drawing.Point x6b2bb9f943411698)
			{
				xedb4922162c60d3d.DockTarget dockTarget = (xedb4922162c60d3d.DockTarget)null;
				if (0 == 0)
					goto label_17;
				label_3:
				dockTarget.type = xedb4922162c60d3d.DockTargetType.Undefined;
				label_4:
				dockTarget.bounds = this.x91f347c6e97f1846.x3102817291e84207(this.x6e150040c8d97700.DockContainer, this.x6e150040c8d97700, dockTarget.dockSide);
				return dockTarget;
				label_17:
				dockTarget = new xedb4922162c60d3d.DockTarget(xedb4922162c60d3d.DockTargetType.SplitExistingSystem);
				if (-1 != 0)
					goto label_16;
				label_14:
				dockTarget.dockSide = DockSide.Top;
				goto label_4;
				label_16:
				do
				{
					dockTarget.layoutSystem = this.x6e150040c8d97700;
					dockTarget.dockContainer = this.x6e150040c8d97700.DockContainer;
					if (!this.x2e982e5b420711bf(this.x922c86dd03ed0805, x6b2bb9f943411698))
					{
						if (!this.x2e982e5b420711bf(this.x71b3d93f18a3424c, x6b2bb9f943411698))
						{
							if (int.MinValue == 0)
								goto label_8;
						}
						else
							goto label_15;
					}
					else
						goto label_14;
				}
				while (2 == 0);
				goto label_12;
				label_8:
				if (!this.x2e982e5b420711bf(this.xd163ca0298f48d0e, x6b2bb9f943411698))
				{
					while (this.x2e982e5b420711bf(this.xa449c67cf6031591, x6b2bb9f943411698))
					{
						dockTarget.type = xedb4922162c60d3d.DockTargetType.JoinExistingSystem;
						if (3 == 0)
						{
							if (4 == 0)
								goto label_14;
						}
						else
						{
							dockTarget.dockSide = DockSide.None;
							goto label_4;
						}
					}
					goto label_3;
				}
				else
				{
					dockTarget.dockSide = DockSide.Left;
					goto label_4;
				}
				label_12:
				if (-2 == 0 || this.x2e982e5b420711bf(this.xaf8b7fb67e0c3bcb, x6b2bb9f943411698))
				{
					dockTarget.dockSide = DockSide.Bottom;
					goto label_4;
				}
				else
					goto label_8;
				label_15:
				dockTarget.dockSide = DockSide.Right;
				goto label_4;
			}

			private xedb4922162c60d3d.DockTarget x54f27420b41557c2(System.Drawing.Point x6b2bb9f943411698)
			{
				xedb4922162c60d3d.DockTarget dockTarget = new xedb4922162c60d3d.DockTarget(xedb4922162c60d3d.DockTargetType.SplitExistingSystem);
				if (0 != 0)
					goto label_39;
				else
					goto label_40;
				label_2:
				if (dockTarget.type != xedb4922162c60d3d.DockTargetType.Undefined)
				{
					dockTarget.type = xedb4922162c60d3d.DockTargetType.CreateNewContainer;
					dockTarget.middle = this.xca9af438b5818619 == DockStyle.Fill;
					dockTarget.bounds = xedb4922162c60d3d.xc68a4bb946c59a9e(this.x91f347c6e97f1846.x257d5a0e25592705(dockTarget.dockLocation, this.x91f347c6e97f1846.xf8ec28822747d4db, dockTarget.middle), this.x91f347c6e97f1846.x460ab163f44a604d.DockSystemContainer);
				}
				return dockTarget;
				label_27:
				if (!this.x2e982e5b420711bf(this.x71b3d93f18a3424c, x6b2bb9f943411698))
					goto label_20;
				else
					goto label_28;
				label_1:
				dockTarget.type = xedb4922162c60d3d.DockTargetType.Undefined;
				goto label_2;
				label_8:
				dockTarget.dockSide = DockSide.None;
				goto label_2;
				label_10:
				dockTarget.dockLocation = ContainerDockLocation.Center;
				if (0 != 0)
				{
					if (int.MinValue != 0)
						goto label_1;
					else
						goto label_1;
				}
				else
					goto label_8;
				label_12:
				if (this.x2e982e5b420711bf(this.xd163ca0298f48d0e, x6b2bb9f943411698))
					goto label_13;
				label_4:
				if (this.x2e982e5b420711bf(this.xa449c67cf6031591, x6b2bb9f943411698) && this.x91f347c6e97f1846.xe302f2203dc14a18(ContainerDockLocation.Center))
				{
					if (this.xca9af438b5818619 != DockStyle.Fill)
					{
						if (3 == 0)
						{
							if (0 != 0)
								goto label_8;
						}
						else
							goto label_1;
					}
					else
						goto label_10;
				}
				else
					goto label_1;
				label_9:
				if (this.xca9af438b5818619 == DockStyle.Fill)
					goto label_16;
				else
					goto label_4;
				label_13:
				if (!this.x91f347c6e97f1846.xe302f2203dc14a18(ContainerDockLocation.Left))
				{
					if (0 != 0)
						goto label_38;
					else
						goto label_4;
				}
				else if (this.xca9af438b5818619 != DockStyle.Left)
				{
					if (0 == 0)
					{
						if (0 != 0)
							goto label_2;
						else
							goto label_9;
					}
					else
						goto label_20;
				}
				label_16:
				dockTarget.dockLocation = ContainerDockLocation.Left;
				dockTarget.dockSide = DockSide.Left;
				goto label_2;
				label_19:
				if (this.xca9af438b5818619 == DockStyle.Bottom || this.xca9af438b5818619 == DockStyle.Fill)
				{
					dockTarget.dockLocation = ContainerDockLocation.Bottom;
					goto label_21;
				}
				else
					goto label_12;
				label_20:
				if (this.x2e982e5b420711bf(this.xaf8b7fb67e0c3bcb, x6b2bb9f943411698))
					goto label_24;
				else
					goto label_12;
				label_21:
				dockTarget.dockSide = DockSide.Bottom;
				goto label_2;
				label_24:
				if (this.x91f347c6e97f1846.xe302f2203dc14a18(ContainerDockLocation.Bottom))
				{
					if (0 == 0)
					{
						if (int.MaxValue != 0)
							goto label_19;
						else
							goto label_27;
					}
					else
						goto label_21;
				}
				else
					goto label_12;
				label_28:
				do
				{
					if (!this.x91f347c6e97f1846.xe302f2203dc14a18(ContainerDockLocation.Right))
					{
						if (15 != 0)
							goto label_37;
					}
					else
						goto label_33;
					label_30:
					if (-1 == 0)
					{
						if (0 == 0)
							continue;
						else
							goto label_33;
					}
					label_31:
					dockTarget.dockLocation = ContainerDockLocation.Right;
					dockTarget.dockSide = DockSide.Right;
					continue;
					label_33:
					while (this.xca9af438b5818619 != DockStyle.Right)
					{
						if (this.xca9af438b5818619 == DockStyle.Fill)
						{
							if (0 == 0)
							{
								if (0 == 0 && 0 == 0)
									goto label_30;
							}
							else
								goto label_10;
						}
						else
							goto label_20;
					}
					goto label_31;
				}
				while (0 != 0);
				goto label_2;
				label_37:
				if (int.MinValue != 0)
				{
					if (15 != 0)
						goto label_20;
					else
						goto label_24;
				}
				else
					goto label_19;
				label_38:
				dockTarget.dockLocation = ContainerDockLocation.Top;
				dockTarget.dockSide = DockSide.Top;
				goto label_2;
				label_39:
				if (!this.x91f347c6e97f1846.xe302f2203dc14a18(ContainerDockLocation.Top) || 15 == 0 || (0 != 0 || this.xca9af438b5818619 != DockStyle.Top) && this.xca9af438b5818619 != DockStyle.Fill)
					goto label_27;
				else
					goto label_38;
				label_40:
				dockTarget.layoutSystem = this.x6e150040c8d97700;
				if (0 == 0)
				{
					dockTarget.dockContainer = this.x6e150040c8d97700 != null ? this.x6e150040c8d97700.DockContainer : (DockContainer)null;
					if (this.x2e982e5b420711bf(this.x922c86dd03ed0805, x6b2bb9f943411698))
						goto label_39;
					else
						goto label_27;
				}
				else
					goto label_2;
			}

			public xedb4922162c60d3d.DockTarget x22749e65b5253094(System.Drawing.Point x13d4cb8d1bd20347)
			{
				System.Drawing.Point x6b2bb9f943411698 = this.PointToClient(x13d4cb8d1bd20347);
				xedb4922162c60d3d.DockTarget dockTarget = this.x6e150040c8d97700 == null ? this.x54f27420b41557c2(x6b2bb9f943411698) : this.xd9d182c023a01aa8(x6b2bb9f943411698);
				label_5:
				bool flag = dockTarget.type != xedb4922162c60d3d.DockTargetType.Undefined;
				DockSide dockSide = dockTarget.type == xedb4922162c60d3d.DockTargetType.Undefined ? this.xf33779c598cac695 : dockTarget.dockSide;
				if (flag != this.x3321191c6256921e)
					goto label_3;
				label_1:
				if (dockSide == this.xf33779c598cac695)
					goto label_6;
				label_3:
				this.x3321191c6256921e = flag;
				if (-1 != 0)
				{
					do
					{
						this.xf33779c598cac695 = dockSide;
						this.x912beb3fd0dd9feb();
						if (0 != 0)
							goto label_1;
					}
					while (2 == 0);
				}
				else
					goto label_5;
				label_6:
				return dockTarget;
			}

			private bool x2e982e5b420711bf(Rectangle xe125219852864557, System.Drawing.Point x13d4cb8d1bd20347)
			{
				return xe125219852864557.Contains(x13d4cb8d1bd20347);
			}

			private void x6e8df868b7130012(Graphics x41347a961b838962, Color x3c4da2980d043c95)
			{
				using (Pen pen = new Pen(x3c4da2980d043c95))
				{
					x41347a961b838962.DrawLine(pen, 22, 29, 29, 22);
					x41347a961b838962.DrawLine(pen, 57, 22, 64, 29);
					x41347a961b838962.DrawLine(pen, 64, 57, 57, 64);
					x41347a961b838962.DrawLine(pen, 29, 64, 22, 57);
				}
			}

			private void x46d7024135bf7082(Graphics x41347a961b838962, Color x3c4da2980d043c95)
			{
				using (Pen pen = new Pen(x3c4da2980d043c95))
				{
					x41347a961b838962.DrawLine(pen, 0, 29, 0, 57);
					x41347a961b838962.DrawLine(pen, 0, 57, 23, 57);
					x41347a961b838962.DrawLine(pen, 0, 29, 23, 29);
				}
			}

			private void x9ceea7a4567f6a5f(Graphics x41347a961b838962, Color x3c4da2980d043c95)
			{
				using (Pen pen = new Pen(x3c4da2980d043c95))
				{
					x41347a961b838962.DrawLine(pen, 29, 87, 57, 87);
					x41347a961b838962.DrawLine(pen, 29, 87, 29, 64);
					x41347a961b838962.DrawLine(pen, 57, 87, 57, 64);
				}
			}

			private void xa1ff3514b97ff955(Graphics x41347a961b838962, Color x3c4da2980d043c95)
			{
				using (Pen pen = new Pen(x3c4da2980d043c95))
				{
					x41347a961b838962.DrawLine(pen, 87, 29, 87, 57);
					x41347a961b838962.DrawLine(pen, 87, 29, 64, 29);
					x41347a961b838962.DrawLine(pen, 87, 57, 64, 57);
				}
			}

			private void xd349d1e0601e763e(Graphics x41347a961b838962, Color x3c4da2980d043c95)
			{
				using (Pen pen = new Pen(x3c4da2980d043c95))
				{
					x41347a961b838962.DrawLine(pen, 29, 0, 57, 0);
					x41347a961b838962.DrawLine(pen, 57, 0, 57, 23);
					x41347a961b838962.DrawLine(pen, 29, 0, 29, 23);
				}
			}

			public void x8ffe90e7fbccfccd()
			{
				this.x9063896ecf738664 = true;
				this.x5486e0b5e830d25c();
			}

			public void x5486e0b5e830d25c()
			{
				if (this.Visible)
					goto label_10;
				label_1:
				if (this.x3b280f462145bf12)
					return;
				label_2:
				if (!this.x1700d731d6397130.Enabled)
					return;
				label_10:
				this.x1a5b1715d3a0d7a6 = Environment.TickCount;
				this.x3b280f462145bf12 = true;
				if (-2 != 0)
				{
					this.x1700d731d6397130.Start();
					if (2 != 0)
					{
						if ((int)byte.MaxValue != 0)
						{
							if ((int)byte.MaxValue == 0)
								goto label_1;
						}
						else if (int.MinValue == 0 || 1 != 0)
							goto label_1;
					}
					else
						goto label_2;
				}
				else
					goto label_1;
			}

			public void x35579b297303ed43()
			{
				this.x0ecee64b07d2d5b1(this.xaf410773a496d7d0, (byte)0);
				this.x2c6f5ac62ee048e5();
				this.x1a5b1715d3a0d7a6 = Environment.TickCount;
				this.x3b280f462145bf12 = false;
				this.x1700d731d6397130.Start();
			}

			public void x2c6f5ac62ee048e5()
			{
				x31248f32f85df1dd.x23d0185c2770c169.SetWindowPos(new HandleRef((object)this, this.Handle), -1, this.xda73fcb97c77d998.X, this.xda73fcb97c77d998.Y, this.xda73fcb97c77d998.Width, this.xda73fcb97c77d998.Height, 80);
			}

			private void xa1ebc192abdef013(object xe0292b9ed559da7d, EventArgs xfbf34718e704c6bc)
			{
				int num1 = Environment.TickCount - this.x1a5b1715d3a0d7a6;
				if (num1 <= 200)
				{
					if (2 == 0)
						;
				}
				else
					goto label_12;
				label_10:
				double num2 = (double)num1 / 200.0;
				double num3 = !this.x3b280f462145bf12 ? num2 * (double)byte.MaxValue : (1.0 - num2) * (double)byte.MaxValue;
				do
				{
					this.x0ecee64b07d2d5b1(this.xaf410773a496d7d0, (byte)num3);
					if (num1 >= 200)
						goto label_8;
				}
				while (((int)(uint)num3 & 0) != 0);
				label_3:
				if ((int)byte.MaxValue != 0)
					return;
				label_4:
				if (!this.x9063896ecf738664)
				{
					if (15 != 0)
					{
						if ((uint)num3 - (uint)num3 >= 0U)
							return;
					}
					else
						goto label_3;
				}
				base.Dispose();
				return;
				label_8:
				this.x1700d731d6397130.Stop();
				this.Visible = !this.x3b280f462145bf12;
				goto label_4;
				label_12:
				num1 = 200;
				goto label_10;
			}
		}
	}
}
