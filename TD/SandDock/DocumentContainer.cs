using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using FQ.FreeDock.Design;

namespace FQ.FreeDock
{
	/// <summary>
	/// An extended DockContainer to display a hierarchy of documents.
	/// 
	/// </summary>
	/// 
	/// <remarks>
	/// 
	/// <para>
	/// This class extends the DockContainer class with methods for tracking and managing documents on a single level, irrespective of the
	///             hierarchy the documents may actually occupy.
	/// </para>
	/// 
	/// <para>
	/// You should not use this class directly.
	/// </para>
	/// 
	/// </remarks>
	[Designer(typeof(DocumentContainerDesigner))]
	[ToolboxItem(false)]
	public class DocumentContainer : DockContainer, IMessageFilter
	{
		private FQ.FreeDock.Rendering.BorderStyle xacfbd7a08ba56c78 = FQ.FreeDock.Rendering.BorderStyle.Flat;
		private DocumentOverflowMode x8362acb4106ff84c = DocumentOverflowMode.Scrollable;
		private int xabb78e5e36f68ff6 = -1;
		private const int x3ab50d2ad9712e32 = 256;
		private const int xacaf912f8e96627a = 257;
		private const int xa1cfcecc2bbf1b88 = 9;
		private const int x94f3e1f6055486d7 = 17;
		private const int x0e421de239ce3d08 = 16;
		private bool x26be2ab374407894;
		private DockControl[] xe1c7adce7be56121;

		internal bool x1ec2ea49664e1074
		{
			get
			{
				return this.xe1c7adce7be56121 != null;
			}
		}

		internal override bool x0c2484ccd29b8358
		{
			get
			{
				return false;
			}
		}

		private bool xe96ee18ce2c3b205
		{
			get
			{
				if (this.Manager == null)
					return true;
				else
					return this.Manager.AllowKeyboardNavigation;
			}
		}

		[Description("The type of border to be drawn around the control.")]
		[DefaultValue(typeof(FQ.FreeDock.Rendering.BorderStyle), "Flat")]
		[Category("Appearance")]
		internal FQ.FreeDock.Rendering.BorderStyle x64b4c49ed703037e
		{
			get
			{
				return this.xacfbd7a08ba56c78;
			}
			set
			{
				this.xacfbd7a08ba56c78 = value;
				this.OnResize(EventArgs.Empty);
			}
		}

		/// <summary>
		/// Overridden.
		/// 
		/// </summary>
		public override Rectangle DisplayRectangle
		{
			get
			{
				Rectangle displayRectangle = base.DisplayRectangle;
				do
				{
					FQ.FreeDock.Rendering.BorderStyle borderStyle = this.xacfbd7a08ba56c78;
					if (3 != 0)
						goto label_4;
					label_2:
					displayRectangle.Inflate(-2, -2);
					continue;
					label_4:
					switch (borderStyle)
					{
						case FQ.FreeDock.Rendering.BorderStyle.Flat:
						case FQ.FreeDock.Rendering.BorderStyle.RaisedThin:
						case FQ.FreeDock.Rendering.BorderStyle.SunkenThin:
							goto label_1;
						case FQ.FreeDock.Rendering.BorderStyle.RaisedThick:
						case FQ.FreeDock.Rendering.BorderStyle.SunkenThick:
							goto label_2;
						default:
							goto label_5;
					}
				}
				while (int.MaxValue == 0);
				goto label_5;
				label_1:
				displayRectangle.Inflate(-1, -1);
				label_5:
				return displayRectangle;
			}
		}

		internal bool xa957e8f86f5e6115
		{
			get
			{
				return this.x26be2ab374407894;
			}
			set
			{
				this.x26be2ab374407894 = value;
				this.CalculateAllMetricsAndLayout();
			}
		}

		internal DocumentOverflowMode x7d2c5325d16e569d
		{
			get
			{
				return this.x8362acb4106ff84c;
			}
			set
			{
				this.x8362acb4106ff84c = value;
				this.CalculateAllMetricsAndLayout();
			}
		}

		/// <summary>
		/// Overridden.
		/// 
		/// </summary>
		protected override System.Drawing.Size DefaultSize
		{
			get
			{
				return new System.Drawing.Size(300, 300);
			}
		}

		/// <summary>
		/// Overridden.
		/// 
		/// </summary>
		[DefaultValue(typeof(Color), "AppWorkspace")]
		public override Color BackColor
		{
			get
			{
				return base.BackColor;
			}
			set
			{
				base.BackColor = value;
			}
		}

		/// <summary>
		/// Overridden.
		/// 
		/// </summary>
		[DefaultValue(typeof(DockStyle), "Fill")]
		public override DockStyle Dock
		{
			get
			{
				return base.Dock;
			}
			set
			{
				if (value != DockStyle.Fill)
					throw new ArgumentException("Only the Fill dock style is valid for this type of container.");
				base.Dock = value;
			}
		}

		/// <summary>
		/// Initializes a new instance of the DocumentContainer class.
		/// 
		/// </summary>
		public DocumentContainer()
		{
			this.Dock = DockStyle.Fill;
			this.BackColor = SystemColors.AppWorkspace;
		}

		internal override ControlLayoutSystem xd6284ffe96aec512()
		{
			return (ControlLayoutSystem)new DocumentLayoutSystem();
		}

		/// <summary>
		/// Overridden.
		/// 
		/// </summary>
		protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
		{
			if (keyData != (Keys.Tab | Keys.Control))
			{
				int num;
				if ((uint)num <= uint.MaxValue)
					goto label_21;
			}
			else
				goto label_3;
			label_2:
			return true;
			label_3:
			int index;
			if (!this.xe96ee18ce2c3b205)
			{
				if ((index | 3) != 0)
					goto label_23;
			}
			else
			{
				DockControl[] dockControls = this.Manager.GetDockControls(DockSituation.Document);
				if (3 != 0)
					goto label_18;
				label_5:
				this.xabb78e5e36f68ff6 = 1;
				label_6:
				do
				{
					this.xf166541af22172c9();
					Application.AddMessageFilter((IMessageFilter)this);
					if ((index & 0) != 0)
						goto label_17;
				}
				while ((uint)index - (uint)index > uint.MaxValue);
				if (0 == 0)
				{
					if (int.MinValue != 0)
						goto label_20;
					else
						goto label_11;
				}
				label_9:
				this.xabb78e5e36f68ff6 = this.xe1c7adce7be56121.Length - 1;
				goto label_6;
				label_11:
				if ((keyData & Keys.Shift) == Keys.Shift)
				{
					if ((index & 0) == 0)
						goto label_9;
					else
						goto label_20;
				}
				else
					goto label_5;
				label_14:
				DateTime[] keys;
				if (index >= dockControls.Length)
				{
					Array.Sort<DateTime, DockControl>(keys, dockControls);
					this.xe1c7adce7be56121 = dockControls;
					goto label_11;
				}
				label_17:
				keys[index] = dockControls[index].MetaData.LastFocused;
				if ((index & 0) == 0)
				{
					++index;
					goto label_14;
				}
				else
					goto label_20;
				label_18:
				if (dockControls.Length < 2)
					return true;
				keys = new DateTime[dockControls.Length];
				index = 0;
				goto label_14;
				label_20:
				if (0 == 0)
					goto label_2;
			}
			label_21:
			if (keyData == (Keys.Tab | Keys.Shift | Keys.Control))
				goto label_3;
			label_23:
			return base.ProcessCmdKey(ref msg, keyData);
		}

		private DockControl xf166541af22172c9()
		{
			if (this.xabb78e5e36f68ff6 > this.xe1c7adce7be56121.Length)
				this.xabb78e5e36f68ff6 = this.xe1c7adce7be56121.Length;
			int index = this.xe1c7adce7be56121.Length - 1 - this.xabb78e5e36f68ff6;
			this.xe1c7adce7be56121[index].x6d1b64d6c637a91d(true);
			return this.xe1c7adce7be56121[index];
		}

		bool IMessageFilter.PreFilterMessage(ref Message x6088325dec1baa2a)
		{
			IntPtr num;
			if (x6088325dec1baa2a.Msg == 256 && ((uint)num - (uint)num > uint.MaxValue || ((int)(uint)num & 0) == 0))
				goto label_20;
			label_8:
			if (x6088325dec1baa2a.Msg == 256)
				goto label_9;
			label_4:
			IntPtr wparam1;
			IntPtr wparam2;
			IntPtr wparam3;
			do
			{
				if (x6088325dec1baa2a.Msg == 257)
					goto label_7;
				else
					goto label_5;
				label_2:
				if (x6088325dec1baa2a.Msg != 256)
					goto label_24;
				label_3:
				DockControl dockControl = this.xf166541af22172c9();
				this.xabb78e5e36f68ff6 = -1;
				this.xe1c7adce7be56121 = (DockControl[])null;
				dockControl.x6d1b64d6c637a91d(true);
				Application.RemoveMessageFilter((IMessageFilter)this);
				continue;
				label_5:
				if ((uint)wparam1 + (uint)wparam2 > uint.MaxValue)
					goto label_16;
				else
					goto label_2;
				label_7:
				wparam3 = x6088325dec1baa2a.WParam;
				if (wparam3.ToInt32() == 17)
					goto label_3;
				else
					goto label_2;
			}
			while (0 != 0);
			if (-1 != 0)
				return true;
			label_24:
			return false;
			label_9:
			wparam2 = x6088325dec1baa2a.WParam;
			if (wparam2.ToInt32() == 16)
				return true;
			else
				goto label_4;
			label_16:
			++this.xabb78e5e36f68ff6;
			label_17:
			while (this.xabb78e5e36f68ff6 > this.xe1c7adce7be56121.Length - 1)
			{
				if (0 == 0)
				{
					this.xabb78e5e36f68ff6 = 0;
					break;
				}
				else if (0 == 0)
					goto label_20;
			}
			if (this.xabb78e5e36f68ff6 < 0)
				goto label_14;
			label_10:
			this.xf166541af22172c9();
			return true;
			label_14:
			this.xabb78e5e36f68ff6 = this.xe1c7adce7be56121.Length - 1;
			goto label_10;
			label_20:
			wparam1 = x6088325dec1baa2a.WParam;
			if (wparam1.ToInt32() == 9)
			{
				if ((uint)wparam3 < 0U)
					goto label_22;
				label_15:
				if ((Control.ModifierKeys & Keys.Shift) == Keys.Shift)
					goto label_23;
				else
					goto label_16;
				label_22:
				if (((int)(uint)wparam3 | 4) == 0)
					goto label_17;
				label_23:
				--this.xabb78e5e36f68ff6;
				if ((int)byte.MaxValue != 0)
					goto label_17;
				else
					goto label_15;
			}
			else
				goto label_8;
		}

		/// <summary>
		/// Overridden.
		/// 
		/// </summary>
		protected override void OnPaint(PaintEventArgs e)
		{
			base.OnPaint(e);
			DockControl.xe1da469e4d960f02((Control)this, e.Graphics, this.xacfbd7a08ba56c78);
		}
	}
}
