﻿// Type: TD.SandDock.xd0a1f65420a07725
// Assembly: SandDock, Version=3.0.6.1, Culture=neutral, PublicKeyToken=75b7ec17dd7c14c3
// MVID: 86A16A8A-6BB9-495D-A857-1A3306E497E9
// Assembly location: C:\Program Files (x86)\Divelements Limited\SandDock for Windows Forms\SandDock.dll

using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace FQ.FreeDock
{
  internal class xd0a1f65420a07725 : Form
  {
    protected override CreateParams CreateParams
    {
      get
      {
        CreateParams createParams = base.CreateParams;
        createParams.ExStyle |= 524288;
        return createParams;
      }
    }

    public xd0a1f65420a07725()
    {
      this.FormBorderStyle = FormBorderStyle.None;
    }

    public void x0ecee64b07d2d5b1(Bitmap xe205f0cd81228282, byte x1965e484c4a7c6c6)
    {
      IntPtr dc = xd0a1f65420a07725.x443cc432acaadb1d.GetDC(IntPtr.Zero);
      IntPtr compatibleDc = xd0a1f65420a07725.x443cc432acaadb1d.CreateCompatibleDC(dc);
      IntPtr hObject1 = IntPtr.Zero;
      IntPtr hObject2 = IntPtr.Zero;
      try
      {
        hObject1 = xe205f0cd81228282.GetHbitmap(Color.FromArgb(0));
        hObject2 = xd0a1f65420a07725.x443cc432acaadb1d.SelectObject(compatibleDc, hObject1);
        xd0a1f65420a07725.x443cc432acaadb1d.BLENDFUNCTION pblend;
        xd0a1f65420a07725.x443cc432acaadb1d.Point pptDst;
        xd0a1f65420a07725.x443cc432acaadb1d.Size psize;
        xd0a1f65420a07725.x443cc432acaadb1d.Point pprSrc;
        do
        {
          psize = new xd0a1f65420a07725.x443cc432acaadb1d.Size(xe205f0cd81228282.Width, xe205f0cd81228282.Height);
          pprSrc = new xd0a1f65420a07725.x443cc432acaadb1d.Point(0, 0);
          pptDst = new xd0a1f65420a07725.x443cc432acaadb1d.Point(this.Left, this.Top);
          pblend = new xd0a1f65420a07725.x443cc432acaadb1d.BLENDFUNCTION();
          pblend.BlendOp = (byte) 0;
        }
        while ((uint) hObject1 + (uint) dc > uint.MaxValue);
        pblend.BlendFlags = (byte) 0;
        pblend.SourceConstantAlpha = x1965e484c4a7c6c6;
        pblend.AlphaFormat = (byte) 1;
        xd0a1f65420a07725.x443cc432acaadb1d.UpdateLayeredWindow(this.Handle, dc, ref pptDst, ref psize, compatibleDc, ref pprSrc, 0, ref pblend, 2);
      }
      finally
      {
        if (hObject1 != IntPtr.Zero)
        {
          xd0a1f65420a07725.x443cc432acaadb1d.SelectObject(compatibleDc, hObject2);
          xd0a1f65420a07725.x443cc432acaadb1d.DeleteObject(hObject1);
        }
        xd0a1f65420a07725.x443cc432acaadb1d.ReleaseDC(IntPtr.Zero, dc);
        xd0a1f65420a07725.x443cc432acaadb1d.DeleteDC(compatibleDc);
      }
    }

    private class x443cc432acaadb1d
    {
      public const int x5369785684a974f4 = 1;
      public const int x93b283a033d1b54a = 2;
      public const int x11a0985503a2d2df = 4;
      public const byte xdd6043f42253ee15 = (byte) 0;
      public const byte xa34cc3e091661d7f = (byte) 1;

      private x443cc432acaadb1d()
      {
      }

      [DllImport("user32.dll", SetLastError = true)]
			public static extern bool UpdateLayeredWindow(IntPtr hwnd, IntPtr hdcDst, ref xd0a1f65420a07725.x443cc432acaadb1d.Point pptDst, ref xd0a1f65420a07725.x443cc432acaadb1d.Size psize, IntPtr hdcSrc, ref xd0a1f65420a07725.x443cc432acaadb1d.Point pprSrc, int crKey, ref xd0a1f65420a07725.x443cc432acaadb1d.BLENDFUNCTION pblend, int dwFlags);

      [DllImport("user32.dll", SetLastError = true)]
			public static extern IntPtr GetDC(IntPtr hWnd);

      [DllImport("user32.dll")]
			public static extern int ReleaseDC(IntPtr hWnd, IntPtr hDC);

      [DllImport("gdi32.dll", SetLastError = true)]
			public static extern IntPtr CreateCompatibleDC(IntPtr hDC);

      [DllImport("gdi32.dll", SetLastError = true)]
			public static extern bool DeleteDC(IntPtr hdc);

      [DllImport("gdi32.dll")]
			public static extern IntPtr SelectObject(IntPtr hDC, IntPtr hObject);

      [DllImport("gdi32.dll", SetLastError = true)]
			public static extern bool DeleteObject(IntPtr hObject);

      public struct Size
      {
        public int cx;
        public int cy;

        public Size(int cx, int cy)
        {
          this.cx = cx;
          this.cy = cy;
        }
      }

      public struct Point
      {
        public int x;
        public int y;

        public Point(int x, int y)
        {
          this.x = x;
          this.y = y;
        }
      }

      [StructLayout(LayoutKind.Sequential, Pack = 1)]
      public struct BLENDFUNCTION
      {
        public byte BlendOp;
        public byte BlendFlags;
        public byte SourceConstantAlpha;
        public byte AlphaFormat;
      }
    }
  }
}
