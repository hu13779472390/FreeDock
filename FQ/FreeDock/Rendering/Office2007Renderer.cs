using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Windows.Forms;
using FQ.FreeDock;

namespace FQ.FreeDock.Rendering
{
    /// <summary>
    /// Provides rendering facilities to mimic the appearance of Office 2007.
    /// 
    /// </summary>
    public class Office2007Renderer : RendererBase
    {
        private Office2007ColorScheme x62a65b2c0f145432 = Office2007ColorScheme.Black;
        private Color background;
        private Color xf78d540f2ad4eefe;
        private Color x2a8ba610037adcf2;
        private Color xf03842e8454f12ef;
        private Color xd86b7ed9f7ac5bcf;
        private Color x311be0ac2a7ad6f7;
        private Color x4c4dd6a647f58188;
        private Color x9185f4f5b194140e;
        private Color x5581066ec159efc6;
        private Color x4457bc20e07c5384;
        private Color xe339b39f12fe3a06;
        private Color x216af2b9aa27b602;
        private Color xac76de21a6c85f45;
        private Color xeedeb7a1ef6db2c5;
        private ColorBlend x4603d08f845b431d;
        private ColorBlend x6d145d34f6cf6305;
        private ColorBlend x7d4e8244c07128f3;
        private ColorBlend xe127097a0a7bcea3;
        private ColorBlend x34b837871ba5992c;
        private ColorBlend x267ad4ea8c519e4c;
        private ColorBlend xea896c10e961df63;
        private ColorBlend xaeb413d4d357001d;
        private ColorBlend xf654cd91b245064f;
        private ColorBlend x2f53a4063520f7b7;
        private ColorBlend xf320905c8fa15baa;
        private ColorBlend x928270a1d0f072fb;
        private ColorBlend documentContainerBackground;
        private ColorBlend x854213a69311962a;
        private ColorBlend x642be9cb364d5c7e;
        private ColorBlend x55f5ad59d4c9fe0a;
        private BoxModel x3a1fa93b40743331;
        private BoxModel xc742aa5a0f350e7f;
        private BoxModel x6defba3d5d846e0d;
        private int x03bb1ee2adad51ea;
        private TextFormatFlags xae3b2752a89e7464;

        /// <summary>
        /// The color blend with which to draw the background of a selected document tab.
        /// 
        /// </summary>
        public ColorBlend DocumentSelectedTabBackground
        {
            get
            {
                return this.x55f5ad59d4c9fe0a;
            }
            set
            {
                if (value == null)
                    throw new ArgumentNullException("value");
                this.x55f5ad59d4c9fe0a = value;
            }
        }

        /// <summary>
        /// The color blend with which to draw the background of a hot document tab.
        /// 
        /// </summary>
        public ColorBlend DocumentHotTabBackground
        {
            get
            {
                return this.x642be9cb364d5c7e;
            }
            set
            {
                if (value == null)
                    throw new ArgumentNullException("value");
                this.x642be9cb364d5c7e = value;
            }
        }

        /// <summary>
        /// The color blend with which to draw the background of a normal document tab.
        /// 
        /// </summary>
        public ColorBlend DocumentNormalTabBackground
        {
            get
            {
                return this.x854213a69311962a;
            }
            set
            {
                if (value == null)
                    throw new ArgumentNullException("value");
                this.x854213a69311962a = value;
            }
        }

        /// <summary>
        /// The color with which to draw the inner border of a hot document tab.
        /// 
        /// </summary>
        public Color DocumentHotTabInnerBorder
        {
            get
            {
                return this.x216af2b9aa27b602;
            }
            set
            {
                this.x216af2b9aa27b602 = value;
            }
        }

        /// <summary>
        /// The color with which to draw the outer border of a selected document tab.
        /// 
        /// </summary>
        public Color DocumentSelectedTabOuterBorder
        {
            get
            {
                return this.xac76de21a6c85f45;
            }
            set
            {
                this.xac76de21a6c85f45 = value;
            }
        }

        /// <summary>
        /// The color with which to draw the inner border of a selected document tab.
        /// 
        /// </summary>
        public Color DocumentSelectedTabInnerBorder
        {
            get
            {
                return this.xeedeb7a1ef6db2c5;
            }
            set
            {
                this.xeedeb7a1ef6db2c5 = value;
            }
        }

        /// <summary>
        /// The color with which to draw the outer border of a hot document tab.
        /// 
        /// </summary>
        public Color DocumentHotTabOuterBorder
        {
            get
            {
                return this.xe339b39f12fe3a06;
            }
            set
            {
                this.xe339b39f12fe3a06 = value;
            }
        }

        /// <summary>
        /// The color with which to draw the inner border of a normal document tab.
        /// 
        /// </summary>
        public Color DocumentNormalTabInnerBorder
        {
            get
            {
                return this.x4457bc20e07c5384;
            }
            set
            {
                this.x4457bc20e07c5384 = value;
            }
        }

        /// <summary>
        /// The color with which to draw the outer border of a normal document tab.
        /// 
        /// </summary>
        public Color DocumentNormalTabOuterBorder
        {
            get
            {
                return this.x5581066ec159efc6;
            }
            set
            {
                this.x5581066ec159efc6 = value;
            }
        }

        /// <summary>
        /// The color with which to draw the border of a document strip.
        /// 
        /// </summary>
        public Color DocumentStripBorder
        {
            get
            {
                return this.x9185f4f5b194140e;
            }
            set
            {
                this.x9185f4f5b194140e = value;
            }
        }

        /// <summary>
        /// The color blend with which to draw the background of a document container.
        /// 
        /// </summary>
        public ColorBlend DocumentContainerBackground
        {
            get
            {
                return this.documentContainerBackground;
            }
            set
            {
                if (value == null)
                    throw new ArgumentNullException("value is null");
                this.documentContainerBackground = value;
            }
        }

        /// <summary>
        /// The color blend with which to draw the background of a vertical collapsed tab.
        /// 
        /// </summary>
        public ColorBlend CollapsedTabVerticalBackground
        {
            get
            {
                return this.x928270a1d0f072fb;
            }
            set
            {
                if (value == null)
                    throw new ArgumentNullException("value");
                this.x928270a1d0f072fb = value;
            }
        }

        /// <summary>
        /// The color blend with which to draw the background of a horizontal collapsed tab.
        /// 
        /// </summary>
        public ColorBlend CollapsedTabHorizontalBackground
        {
            get
            {
                return this.xf320905c8fa15baa;
            }
            set
            {
                if (value == null)
                    throw new ArgumentNullException("value");
                this.xf320905c8fa15baa = value;
            }
        }

        /// <summary>
        /// The color with which to draw the border of a collapsed tab.
        /// 
        /// </summary>
        public Color CollapsedTabBorder
        {
            get
            {
                return this.x4c4dd6a647f58188;
            }
            set
            {
                this.x4c4dd6a647f58188 = value;
            }
        }

        /// <summary>
        /// The color blend with which to draw the background of a hot button.
        /// 
        /// </summary>
        public ColorBlend ButtonHotBackground
        {
            get
            {
                return this.xea896c10e961df63;
            }
            set
            {
                if (value == null)
                    throw new ArgumentNullException("value");
                this.xea896c10e961df63 = value;
            }
        }

        /// <summary>
        /// The color blend with which to draw the inner border on a hot button.
        /// 
        /// </summary>
        public ColorBlend ButtonHotInnerBorder
        {
            get
            {
                return this.x267ad4ea8c519e4c;
            }
            set
            {
                if (value == null)
                    throw new ArgumentNullException("value");
                this.x267ad4ea8c519e4c = value;
            }
        }

        /// <summary>
        /// The color blend with which to draw the outer border on a hot button.
        /// 
        /// </summary>
        public ColorBlend ButtonHotOuterBorder
        {
            get
            {
                return this.x34b837871ba5992c;
            }
            set
            {
                if (value == null)
                    throw new ArgumentNullException("value");
                this.x34b837871ba5992c = value;
            }
        }

        /// <summary>
        /// The color blend with which to draw the background of a pressed button.
        /// 
        /// </summary>
        public ColorBlend ButtonPressedBackground
        {
            get
            {
                return this.x2f53a4063520f7b7;
            }
            set
            {
                if (value == null)
                    throw new ArgumentNullException("value");
                this.x2f53a4063520f7b7 = value;
            }
        }

        /// <summary>
        /// The color blend with which to draw the inner border on a pressed button.
        /// 
        /// </summary>
        public ColorBlend ButtonPressedInnerBorder
        {
            get
            {
                return this.xf654cd91b245064f;
            }
            set
            {
                if (value == null)
                    throw new ArgumentNullException("value");
                this.xf654cd91b245064f = value;
            }
        }

        /// <summary>
        /// The color blend with which to draw the outer border on a pressed button.
        /// 
        /// </summary>
        public ColorBlend ButtonPressedOuterBorder
        {
            get
            {
                return this.xaeb413d4d357001d;
            }
            set
            {
                if (value == null)
                    throw new ArgumentNullException("value");
                this.xaeb413d4d357001d = value;
            }
        }

        /// <summary>
        /// The color blend with which to draw the border on a selected tab.
        /// 
        /// </summary>
        public ColorBlend TabStripSelectedTabBorder
        {
            get
            {
                return this.xe127097a0a7bcea3;
            }
            set
            {
                if (value == null)
                    throw new ArgumentNullException("value");
                this.xe127097a0a7bcea3 = value;
            }
        }

        /// <summary>
        /// The color blend with which to draw the background of a selected tab.
        /// 
        /// </summary>
        public ColorBlend TabStripSelectedTabBackground
        {
            get
            {
                return this.x7d4e8244c07128f3;
            }
            set
            {
                if (value == null)
                    throw new ArgumentNullException("value");
                this.x7d4e8244c07128f3 = value;
            }
        }

        /// <summary>
        /// The color blend with which to draw the background of an inactive titlebar.
        /// 
        /// </summary>
        public ColorBlend InactiveTitleBarBackground
        {
            get
            {
                return this.x6d145d34f6cf6305;
            }
            set
            {
                if (value == null)
                    throw new ArgumentNullException("value");
                this.x6d145d34f6cf6305 = value;
            }
        }

        /// <summary>
        /// The color blend with which to draw the background of an active titlebar.
        /// 
        /// </summary>
        public ColorBlend ActiveTitleBarBackground
        {
            get
            {
                return this.x4603d08f845b431d;
            }
            set
            {
                if (value == null)
                    throw new ArgumentNullException("value");
                this.x4603d08f845b431d = value;
            }
        }

        /// <summary>
        /// The color with which to draw the foreground of a normal tab.
        /// 
        /// </summary>
        public Color TabStripNormalTabForeground
        {
            get
            {
                return this.x311be0ac2a7ad6f7;
            }
            set
            {
                this.x311be0ac2a7ad6f7 = value;
            }
        }

        /// <summary>
        /// The color with which to draw the inner border of a tabstrip.
        /// 
        /// </summary>
        public Color TabStripInnerBorder
        {
            get
            {
                return this.xd86b7ed9f7ac5bcf;
            }
            set
            {
                this.xd86b7ed9f7ac5bcf = value;
            }
        }

        /// <summary>
        /// The color with which to draw the outer border of a tabstrip.
        /// 
        /// </summary>
        public Color TabStripOuterBorder
        {
            get
            {
                return this.xf03842e8454f12ef;
            }
            set
            {
                this.xf03842e8454f12ef = value;
            }
        }

        /// <summary>
        /// The color with which to draw the background.
        /// 
        /// </summary>
        public Color Background
        {
            get
            {
                return this.background;
            }
            set
            {
                this.background = value;
            }
        }

        /// <summary>
        /// The color with which to draw the outer border of a docked window.
        /// 
        /// </summary>
        public Color DockedWindowOuterBorder
        {
            get
            {
                return this.xf78d540f2ad4eefe;
            }
            set
            {
                this.xf78d540f2ad4eefe = value;
            }
        }

        /// <summary>
        /// The color with which to draw the inner border of a docked window.
        /// 
        /// </summary>
        public Color DockedWindowInnerBorder
        {
            get
            {
                return this.x2a8ba610037adcf2;
            }
            set
            {
                this.x2a8ba610037adcf2 = value;
            }
        }

        /// <summary>
        /// The size of image to draw in window tabs.
        /// 
        /// </summary>
        public override System.Drawing.Size ImageSize
        {
            get
            {
                return base.ImageSize;
            }
            set
            {
                this.x50aa48875b838a15();
                base.ImageSize = value;
            }
        }

        /// <summary>
        /// The color scheme in use by the renderer.
        /// 
        /// </summary>
        public Office2007ColorScheme ColorScheme
        {
            get
            {
                return this.x62a65b2c0f145432;
            }
            set
            {
                if (value == this.x62a65b2c0f145432 || 0 != 0)
                    return;
                this.x62a65b2c0f145432 = value;
                switch (this.x62a65b2c0f145432)
                {
                    case Office2007ColorScheme.Blue:
                        this.x02fed0907aa1493f();
                        break;
                    case Office2007ColorScheme.Silver:
                        this.x6138edaa8ff675bc();
                        break;
                    case Office2007ColorScheme.Black:
                        this.xfd737a986158d659();
                        break;
                    default:
                        if (-1 == 0)
                            break;
                        else
                            break;
                }
            }
        }

        /// <summary>
        /// A standard TextFormatFlags value that can be used during measuring and rendering.
        /// 
        /// </summary>
        protected TextFormatFlags TextFormat
        {
            get
            {
                return this.xae3b2752a89e7464;
            }
        }

        /// <summary>
        /// Overridden. Consult the documentation on the base virtual member for more information.
        /// 
        /// </summary>
        protected internal override BoxModel TabMetrics
        {
            get
            {
                if (this.x3a1fa93b40743331 == null)
                    this.x3a1fa93b40743331 = new BoxModel(0, 0, 0, 0, 0, 0, 0, 0, -1, 0);
                return this.x3a1fa93b40743331;
            }
        }

        /// <summary>
        /// Overridden. Consult the documentation on the base virtual member for more information.
        /// 
        /// </summary>
        protected internal override BoxModel TabStripMetrics
        {
            get
            {
                if (this.xc742aa5a0f350e7f == null)
                    this.xc742aa5a0f350e7f = new BoxModel(0, Math.Max(Control.DefaultFont.Height, this.ImageSize.Height) + 8, 0, 0, 0, 1, 0, 0, 0, 0);
                return this.xc742aa5a0f350e7f;
            }
        }

        /// <summary>
        /// Overridden. Consult the documentation on the base virtual member for more information.
        /// 
        /// </summary>
        protected internal override TabTextDisplayMode TabTextDisplay
        {
            get
            {
                return TabTextDisplayMode.AllTabs;
            }
        }

        /// <summary>
        /// Overridden. Consult the documentation on the base virtual member for more information.
        /// 
        /// </summary>
        protected internal override BoxModel TitleBarMetrics
        {
            get
            {
                if (this.x6defba3d5d846e0d == null)
                    this.x6defba3d5d846e0d = new BoxModel(0, Control.DefaultFont.Height + 8, 0, 0, 0, 0, 0, 0, 0, 0);
                return this.x6defba3d5d846e0d;
            }
        }

        /// <summary>
        /// Overridden. Consult the documentation on the base virtual member for more information.
        /// 
        /// </summary>
        protected internal override int DocumentTabStripSize
        {
            get
            {
                return Math.Max(Control.DefaultFont.Height, this.ImageSize.Height) + 7;
            }
        }

        /// <summary>
        /// Overridden. Consult the documentation on the base virtual member for more information.
        /// 
        /// </summary>
        protected internal override int DocumentTabSize
        {
            get
            {
                return Math.Max(Control.DefaultFont.Height, this.ImageSize.Height) + 5;
            }
        }

        /// <summary>
        /// Overridden. Consult the documentation on the base virtual member for more information.
        /// 
        /// </summary>
        protected internal override int DocumentTabExtra
        {
            get
            {
                return this.ImageSize.Width;
            }
        }

        /// <summary>
        /// Overridden. Consult the documentation on the base virtual member for more information.
        /// 
        /// </summary>
        public override System.Drawing.Size TabControlPadding
        {
            get
            {
                return new System.Drawing.Size(3, 3);
            }
        }

        /// <summary>
        /// Overridden. Consult the documentation on the base virtual member for more information.
        /// 
        /// </summary>
        public override bool ShouldDrawControlBorder
        {
            get
            {
                return false;
            }
        }

        /// <summary>
        /// Initializes a new instance of the Office2007Renderer class.
        /// 
        /// </summary>
        /// <param name="colorScheme">The initial value of the ColorScheme property.</param>
        public Office2007Renderer(Office2007ColorScheme colorScheme)
        {
            this.ColorScheme = colorScheme;
        }

        /// <summary>
        /// Initializes a new instance of the Office2007Renderer class.
        /// 
        /// </summary>
        public Office2007Renderer()
      : this(Office2007ColorScheme.Blue)
        {
        }

        private void x50aa48875b838a15()
        {
            this.x3a1fa93b40743331 = (BoxModel)null;
            this.xc742aa5a0f350e7f = (BoxModel)null;
            this.x6defba3d5d846e0d = (BoxModel)null;
        }

        private ColorBlend x427b83330cc91391(float[] x1692a49b2cba9274, Color[] xa70c7ccd3278240f)
        {
            ColorBlend colorBlend = new ColorBlend(x1692a49b2cba9274.Length);
            for (int index = 0; index < x1692a49b2cba9274.Length; ++index)
            {
                do
                {
                    colorBlend.Positions[index] = x1692a49b2cba9274[index];
                    colorBlend.Colors[index] = xa70c7ccd3278240f[index];
                }
                while (4 == 0);
            }
            return colorBlend;
        }

        private LinearGradientBrush xb9d757f2231cc2a8(Rectangle bounds, ColorBlend colorBlend, LinearGradientMode xa4aa8b4150b11435)
        {
            return new LinearGradientBrush(bounds, Color.Black, Color.White, xa4aa8b4150b11435)
            {
                InterpolationColors = colorBlend
            };
        }

        private void x02fed0907aa1493f()
        {
            this.Background = ColorTranslator.FromHtml("#BFDBFF");
            this.DockedWindowOuterBorder = ColorTranslator.FromHtml("#7596BF");
            if (2 != 0)
                goto label_15;
            label_9:
            this.CollapsedTabHorizontalBackground = this.x427b83330cc91391(new float[4]
            {
                0.0f,
                0.3f,
                0.3f,
                1f
            }, new Color[4]
            {
                ColorTranslator.FromHtml("#F7FBFF"),
                ColorTranslator.FromHtml("#EEF5FB"),
                ColorTranslator.FromHtml("#E1EAF6"),
                ColorTranslator.FromHtml("#F7FBFF")
            });
            if (2 != 0)
                goto label_6;
            else
                goto label_5;
            label_4:
            this.DocumentHotTabOuterBorder = ColorTranslator.FromHtml("#6593CF");
            this.DocumentHotTabInnerBorder = ColorTranslator.FromHtml("#FFFFFF");
            this.DocumentHotTabBackground = this.x427b83330cc91391(new float[4]
            {
                0.0f,
                0.5f,
                0.5f,
                1f
            }, new Color[4]
            {
                ColorTranslator.FromHtml("#E1EEFF"),
                ColorTranslator.FromHtml("#D7E8FF"),
                ColorTranslator.FromHtml("#AED2FF"),
                ColorTranslator.FromHtml("#BEDAFF")
            });
            this.DocumentSelectedTabOuterBorder = ColorTranslator.FromHtml("#95774A");
            if (0 != 0)
                return;
            if (0 == 0)
            {
                this.DocumentSelectedTabInnerBorder = ColorTranslator.FromHtml("#CDB69C");
                this.DocumentSelectedTabBackground = this.x427b83330cc91391(new float[3]
                {
                    0.0f,
                    0.25f,
                    1f
                }, new Color[3]
                {
                    ColorTranslator.FromHtml("#FFD19C"),
                    ColorTranslator.FromHtml("#FFDBB3"),
                    ColorTranslator.FromHtml("#FFFFFE")
                });
                return;
            }
            else
                goto label_12;
            label_5:
            this.DocumentNormalTabInnerBorder = ColorTranslator.FromHtml("#E3EFFF");
            if (0 == 0)
            {
                if (0 != 0)
                    return;
                this.DocumentNormalTabBackground = this.x427b83330cc91391(new float[4]
                {
                    0.0f,
                    0.5f,
                    0.5f,
                    1f
                }, new Color[4]
                {
                    ColorTranslator.FromHtml("#BEDAFF"),
                    ColorTranslator.FromHtml("#AED2FF"),
                    ColorTranslator.FromHtml("#8FBCF6"),
                    ColorTranslator.FromHtml("#98C4FD")
                });
                goto label_4;
            }
            else
                goto label_11;
            label_6:
            this.CollapsedTabVerticalBackground = this.x427b83330cc91391(new float[4]
            {
                0.0f,
                0.3f,
                0.3f,
                1f
            }, new Color[4]
            {
                ColorTranslator.FromHtml("#F7FBFF"),
                ColorTranslator.FromHtml("#EEF5FB"),
                ColorTranslator.FromHtml("#E1EAF6"),
                ColorTranslator.FromHtml("#F7FBFF")
            });
            if ((int)byte.MaxValue != 0)
            {
                this.DocumentContainerBackground = this.x427b83330cc91391(new float[3]
                {
                    0.0f,
                    0.7f,
                    1f
                }, new Color[3]
                {
                    ColorTranslator.FromHtml("#A3C2EA"),
                    ColorTranslator.FromHtml("#567DB0"),
                    ColorTranslator.FromHtml("#6591CD")
                });
                this.DocumentStripBorder = ColorTranslator.FromHtml("#678CBD");
                if (0 == 0)
                {
                    this.DocumentNormalTabOuterBorder = ColorTranslator.FromHtml("#6593CF");
                    goto label_5;
                }
                else
                    goto label_14;
            }
            else
                goto label_4;
            label_11:
            this.TabStripSelectedTabBorder = this.x427b83330cc91391(new float[4]
            {
                0.0f,
                0.3f,
                0.7f,
                1f
            }, new Color[4]
            {
                ColorTranslator.FromHtml("#E1EAF6"),
                ColorTranslator.FromHtml("#CDFBFF"),
                ColorTranslator.FromHtml("#D0FBFF"),
                ColorTranslator.FromHtml("#F4F9FF")
            });
            this.TabStripNormalTabForeground = ColorTranslator.FromHtml("#15428B");
            this.ButtonHotOuterBorder = this.x427b83330cc91391(new float[3]
            {
                0.0f,
                0.5f,
                1f
            }, new Color[3]
            {
                ColorTranslator.FromHtml("#DBCE99"),
                ColorTranslator.FromHtml("#B9A074"),
                ColorTranslator.FromHtml("#CBC3AA")
            });
            this.ButtonHotInnerBorder = this.x427b83330cc91391(new float[4]
            {
                0.0f,
                0.5f,
                0.5f,
                1f
            }, new Color[4]
            {
                ColorTranslator.FromHtml("#FFFFFB"),
                ColorTranslator.FromHtml("#FFF9E3"),
                ColorTranslator.FromHtml("#FFF2C9"),
                ColorTranslator.FromHtml("#FFFCDF")
            });
            this.ButtonHotBackground = this.x427b83330cc91391(new float[4]
            {
                0.0f,
                0.5f,
                0.5f,
                1f
            }, new Color[4]
            {
                ColorTranslator.FromHtml("#FFFCE6"),
                ColorTranslator.FromHtml("#FFECA3"),
                ColorTranslator.FromHtml("#FFD844"),
                ColorTranslator.FromHtml("#FFE47F")
            });
            label_12:
            this.ButtonPressedOuterBorder = this.x427b83330cc91391(new float[2]
            {
                0.0f,
                1f
            }, new Color[2]
            {
                ColorTranslator.FromHtml("#7B6645"),
                ColorTranslator.FromHtml("#7B6645")
            });
            this.ButtonPressedInnerBorder = this.x427b83330cc91391(new float[5]
            {
                0.0f,
                0.1f,
                0.6f,
                0.6f,
                1f
            }, new Color[5]
            {
                ColorTranslator.FromHtml("#B2855C"),
                ColorTranslator.FromHtml("#F1B072"),
                ColorTranslator.FromHtml("#F1963B"),
                ColorTranslator.FromHtml("#ED7804"),
                ColorTranslator.FromHtml("#FDAD03")
            });
            this.ButtonPressedBackground = this.x427b83330cc91391(new float[4]
            {
                0.0f,
                0.5f,
                0.5f,
                1f
            }, new Color[4]
            {
                ColorTranslator.FromHtml("#F3A570"),
                ColorTranslator.FromHtml("#E57840"),
                ColorTranslator.FromHtml("#DE550A"),
                ColorTranslator.FromHtml("#FEA14E")
            });
            this.CollapsedTabBorder = ColorTranslator.FromHtml("#7596BF");
            goto label_9;
            label_14:
            this.TabStripSelectedTabBackground = this.x427b83330cc91391(new float[4]
            {
                0.0f,
                0.3f,
                0.3f,
                1f
            }, new Color[4]
            {
                ColorTranslator.FromHtml("#F7FBFF"),
                ColorTranslator.FromHtml("#EEF5FB"),
                ColorTranslator.FromHtml("#E1EAF6"),
                ColorTranslator.FromHtml("#F7FBFF")
            });
            goto label_11;
            label_15:
            this.DockedWindowInnerBorder = ColorTranslator.FromHtml("#FFFFFF");
            do
            {
                this.InactiveTitleBarBackground = this.x427b83330cc91391(new float[4]
                {
                    0.0f,
                    0.35f,
                    0.35f,
                    1f
                }, new Color[4]
                {
                    ColorTranslator.FromHtml("#E4EBF6"),
                    ColorTranslator.FromHtml("#D9E7F9"),
                    ColorTranslator.FromHtml("#CADEF7"),
                    ColorTranslator.FromHtml("#DBF4FE")
                });
                this.ActiveTitleBarBackground = this.x427b83330cc91391(new float[4]
                {
                    0.0f,
                    0.7f,
                    0.7f,
                    1f
                }, new Color[4]
                {
                    ColorTranslator.FromHtml("#FFFCDA"),
                    ColorTranslator.FromHtml("#FFE790"),
                    ColorTranslator.FromHtml("#FFD74C"),
                    ColorTranslator.FromHtml("#FFD346")
                });
                this.TabStripOuterBorder = ColorTranslator.FromHtml("#7596BF");
                this.TabStripInnerBorder = ColorTranslator.FromHtml("#E7EFF8");
            }
            while (-2 == 0);
            goto label_14;
        }

        private void xfd737a986158d659()
        {
            this.Background = ColorTranslator.FromHtml("#535353");
            if (1 != 0)
                goto label_20;
            label_9:
            do
            {
                this.ButtonPressedBackground = this.x427b83330cc91391(new float[4]
                {
                    0.0f,
                    0.5f,
                    0.5f,
                    1f
                }, new Color[4]
                {
                    ColorTranslator.FromHtml("#F3A570"),
                    ColorTranslator.FromHtml("#E57840"),
                    ColorTranslator.FromHtml("#DE550A"),
                    ColorTranslator.FromHtml("#FEA14E")
                });
                this.CollapsedTabBorder = ColorTranslator.FromHtml("#BEBEBE");
                if (0 == 0)
                {
                    do
                    {
                        this.CollapsedTabHorizontalBackground = this.x427b83330cc91391(new float[4]
                        {
                            0.0f,
                            0.3f,
                            0.3f,
                            1f
                        }, new Color[4]
                        {
                            ColorTranslator.FromHtml("#F0F0F0"),
                            ColorTranslator.FromHtml("#E3E6E9"),
                            ColorTranslator.FromHtml("#D6D9DE"),
                            ColorTranslator.FromHtml("#F0F1F2")
                        });
                        this.CollapsedTabVerticalBackground = this.x427b83330cc91391(new float[4]
                        {
                            0.0f,
                            0.3f,
                            0.3f,
                            1f
                        }, new Color[4]
                        {
                            ColorTranslator.FromHtml("#F0F0F0"),
                            ColorTranslator.FromHtml("#E3E6E9"),
                            ColorTranslator.FromHtml("#D6D9DE"),
                            ColorTranslator.FromHtml("#F0F1F2")
                        });
                    }
                    while (15 == 0);
                    if (0 == 0)
                        this.DocumentContainerBackground = this.x427b83330cc91391(new float[3]
                        {
                            0.0f,
                            0.7f,
                            1f
                        }, new Color[3]
                        {
                            ColorTranslator.FromHtml("#4F4F4F"),
                            ColorTranslator.FromHtml("#3B3B3B"),
                            ColorTranslator.FromHtml("#0A0A0A")
                        });
                    else
                        break;
                }
                else
                    goto label_21;
            }
            while (-1 == 0);
            this.DocumentStripBorder = ColorTranslator.FromHtml("#000000");
            this.DocumentNormalTabOuterBorder = ColorTranslator.FromHtml("#9199A4");
            if (4 != 0)
                goto label_6;
            label_3:
            this.DocumentSelectedTabInnerBorder = ColorTranslator.FromHtml("#CDB69C");
            this.DocumentSelectedTabBackground = this.x427b83330cc91391(new float[3]
            {
                0.0f,
                0.25f,
                1f
            }, new Color[3]
            {
                ColorTranslator.FromHtml("#FFD19C"),
                ColorTranslator.FromHtml("#FFDBB3"),
                ColorTranslator.FromHtml("#FFFFFE")
            });
            if (4 != 0)
                return;
            label_4:
            this.DocumentHotTabOuterBorder = ColorTranslator.FromHtml("#616A76");
            if ((int)byte.MaxValue == 0)
                return;
            this.DocumentHotTabInnerBorder = ColorTranslator.FromHtml("#FFFFFF");
            if (15 != 0)
            {
                this.DocumentHotTabBackground = this.x427b83330cc91391(new float[4]
                {
                    0.0f,
                    0.5f,
                    0.5f,
                    1f
                }, new Color[4]
                {
                    ColorTranslator.FromHtml("#F2F2F3"),
                    ColorTranslator.FromHtml("#F8F8F9"),
                    ColorTranslator.FromHtml("#D3D6DB"),
                    ColorTranslator.FromHtml("#DBDEE1")
                });
                this.DocumentSelectedTabOuterBorder = ColorTranslator.FromHtml("#3D3D3D");
                goto label_3;
            }
            else
                goto label_15;
            label_6:
            this.DocumentNormalTabInnerBorder = ColorTranslator.FromHtml("#F0F1F2");
            if (3 != 0)
            {
                this.DocumentNormalTabBackground = this.x427b83330cc91391(new float[4]
                {
                    0.0f,
                    0.5f,
                    0.5f,
                    1f
                }, new Color[4]
                {
                    ColorTranslator.FromHtml("#DBDEE1"),
                    ColorTranslator.FromHtml("#D3D6DB"),
                    ColorTranslator.FromHtml("#BCC1C8"),
                    ColorTranslator.FromHtml("#C5C9CF")
                });
                goto label_4;
            }
            else if (int.MaxValue == 0)
            {
                if (4 != 0)
                    goto label_16;
                else
                    goto label_14;
            }
            else
                goto label_17;
            label_21:
            return;
            label_14:
            this.TabStripNormalTabForeground = ColorTranslator.FromHtml("#FFFFFF");
            this.ButtonHotOuterBorder = this.x427b83330cc91391(new float[3]
            {
                0.0f,
                0.5f,
                1f
            }, new Color[3]
            {
                ColorTranslator.FromHtml("#DBCE99"),
                ColorTranslator.FromHtml("#B9A074"),
                ColorTranslator.FromHtml("#CBC3AA")
            });
            this.ButtonHotInnerBorder = this.x427b83330cc91391(new float[4]
            {
                0.0f,
                0.5f,
                0.5f,
                1f
            }, new Color[4]
            {
                ColorTranslator.FromHtml("#FFFFFB"),
                ColorTranslator.FromHtml("#FFF9E3"),
                ColorTranslator.FromHtml("#FFF2C9"),
                ColorTranslator.FromHtml("#FFFCDF")
            });
            this.ButtonHotBackground = this.x427b83330cc91391(new float[4]
            {
                0.0f,
                0.5f,
                0.5f,
                1f
            }, new Color[4]
            {
                ColorTranslator.FromHtml("#FFFCE6"),
                ColorTranslator.FromHtml("#FFECA3"),
                ColorTranslator.FromHtml("#FFD844"),
                ColorTranslator.FromHtml("#FFE47F")
            });
            this.ButtonPressedOuterBorder = this.x427b83330cc91391(new float[2]
            {
                0.0f,
                1f
            }, new Color[2]
            {
                ColorTranslator.FromHtml("#7B6645"),
                ColorTranslator.FromHtml("#7B6645")
            });
            label_15:
            this.ButtonPressedInnerBorder = this.x427b83330cc91391(new float[5]
            {
                0.0f,
                0.1f,
                0.6f,
                0.6f,
                1f
            }, new Color[5]
            {
                ColorTranslator.FromHtml("#B2855C"),
                ColorTranslator.FromHtml("#F1B072"),
                ColorTranslator.FromHtml("#F1963B"),
                ColorTranslator.FromHtml("#ED7804"),
                ColorTranslator.FromHtml("#FDAD03")
            });
            if (0 == 0)
                goto label_9;
            else
                goto label_17;
            label_16:
            this.TabStripInnerBorder = ColorTranslator.FromHtml("#D7DADF");
            this.TabStripSelectedTabBackground = this.x427b83330cc91391(new float[4]
            {
                0.0f,
                0.3f,
                0.3f,
                1f
            }, new Color[4]
            {
                ColorTranslator.FromHtml("#F0F0F0"),
                ColorTranslator.FromHtml("#E3E6E9"),
                ColorTranslator.FromHtml("#D6D9DE"),
                ColorTranslator.FromHtml("#F0F1F2")
            });
            this.TabStripSelectedTabBorder = this.x427b83330cc91391(new float[4]
            {
                0.0f,
                0.3f,
                0.7f,
                1f
            }, new Color[4]
            {
                ColorTranslator.FromHtml("#D5DBDC"),
                ColorTranslator.FromHtml("#B8F6FC"),
                ColorTranslator.FromHtml("#B7F7FD"),
                ColorTranslator.FromHtml("#E8EDEF")
            });
            goto label_14;
            label_17:
            this.InactiveTitleBarBackground = this.x427b83330cc91391(new float[4]
            {
                0.0f,
                0.35f,
                0.35f,
                1f
            }, new Color[4]
            {
                ColorTranslator.FromHtml("#D7DADF"),
                ColorTranslator.FromHtml("#C1C6CF"),
                ColorTranslator.FromHtml("#B4BBC5"),
                ColorTranslator.FromHtml("#EBEBEB")
            });
            this.ActiveTitleBarBackground = this.x427b83330cc91391(new float[4]
            {
                0.0f,
                0.7f,
                0.7f,
                1f
            }, new Color[4]
            {
                ColorTranslator.FromHtml("#FFFCDA"),
                ColorTranslator.FromHtml("#FFE790"),
                ColorTranslator.FromHtml("#FFD74C"),
                ColorTranslator.FromHtml("#FFD346")
            });
            this.TabStripOuterBorder = ColorTranslator.FromHtml("#BEBEBE");
            if (0 == 0)
                goto label_16;
            else
                goto label_9;
            label_20:
            this.DockedWindowOuterBorder = ColorTranslator.FromHtml("#8C8E8F");
            this.DockedWindowInnerBorder = ColorTranslator.FromHtml("#FFFFFF");
            goto label_17;
        }

        private void x6138edaa8ff675bc()
        {
            this.Background = ColorTranslator.FromHtml("#D0D4DD");
            while (0 == 0)
            {
                if (15 != 0)
                    goto label_14;
                label_8:
                this.ButtonPressedOuterBorder = this.x427b83330cc91391(new float[2]
                {
                    0.0f,
                    1f
                }, new Color[2]
                {
                    ColorTranslator.FromHtml("#7B6645"),
                    ColorTranslator.FromHtml("#7B6645")
                });
                this.ButtonPressedInnerBorder = this.x427b83330cc91391(new float[5]
                {
                    0.0f,
                    0.1f,
                    0.6f,
                    0.6f,
                    1f
                }, new Color[5]
                {
                    ColorTranslator.FromHtml("#B2855C"),
                    ColorTranslator.FromHtml("#F1B072"),
                    ColorTranslator.FromHtml("#F1963B"),
                    ColorTranslator.FromHtml("#ED7804"),
                    ColorTranslator.FromHtml("#FDAD03")
                });
                this.ButtonPressedBackground = this.x427b83330cc91391(new float[4]
                {
                    0.0f,
                    0.5f,
                    0.5f,
                    1f
                }, new Color[4]
                {
                    ColorTranslator.FromHtml("#F3A570"),
                    ColorTranslator.FromHtml("#E57840"),
                    ColorTranslator.FromHtml("#DE550A"),
                    ColorTranslator.FromHtml("#FEA14E")
                });
                this.CollapsedTabBorder = ColorTranslator.FromHtml("#838383");
                label_12:
                if (3 != 0)
                {
                    if (int.MaxValue == 0)
                        return;
                    this.CollapsedTabHorizontalBackground = this.x427b83330cc91391(new float[4]
                    {
                        0.0f,
                        0.3f,
                        0.3f,
                        1f
                    }, new Color[4]
                    {
                        ColorTranslator.FromHtml("#FFFFFF"),
                        ColorTranslator.FromHtml("#F7F6F8"),
                        ColorTranslator.FromHtml("#EEF1F5"),
                        ColorTranslator.FromHtml("#F2F7F9")
                    });
                    this.CollapsedTabVerticalBackground = this.x427b83330cc91391(new float[4]
                    {
                        0.0f,
                        0.3f,
                        0.3f,
                        1f
                    }, new Color[4]
                    {
                        ColorTranslator.FromHtml("#FFFFFF"),
                        ColorTranslator.FromHtml("#F7F6F8"),
                        ColorTranslator.FromHtml("#EEF1F5"),
                        ColorTranslator.FromHtml("#F2F7F9")
                    });
                    this.DocumentContainerBackground = this.x427b83330cc91391(new float[3]
                    {
                        0.0f,
                        0.7f,
                        1f
                    }, new Color[3]
                    {
                        ColorTranslator.FromHtml("#CCCFD8"),
                        ColorTranslator.FromHtml("#BDC0C9"),
                        ColorTranslator.FromHtml("#9B9FA6")
                    });
                    goto label_3;
                }
                else
                    continue;
                label_14:
                this.DockedWindowOuterBorder = ColorTranslator.FromHtml("#BDBFC1");
                this.DockedWindowInnerBorder = ColorTranslator.FromHtml("#FFFFFF");
                this.InactiveTitleBarBackground = this.x427b83330cc91391(new float[4]
                {
                    0.0f,
                    0.35f,
                    0.35f,
                    1f
                }, new Color[4]
                {
                    ColorTranslator.FromHtml("#F2F4F8"),
                    ColorTranslator.FromHtml("#E1E6EE"),
                    ColorTranslator.FromHtml("#D5DBE7"),
                    ColorTranslator.FromHtml("#F9F9F9")
                });
                do
                {
                    this.ActiveTitleBarBackground = this.x427b83330cc91391(new float[4]
                    {
                        0.0f,
                        0.7f,
                        0.7f,
                        1f
                    }, new Color[4]
                    {
                        ColorTranslator.FromHtml("#FFFCDA"),
                        ColorTranslator.FromHtml("#FFE790"),
                        ColorTranslator.FromHtml("#FFD74C"),
                        ColorTranslator.FromHtml("#FFD346")
                    });
                    this.TabStripOuterBorder = ColorTranslator.FromHtml("#838383");
                    this.TabStripInnerBorder = ColorTranslator.FromHtml("#F2F4F8");
                    this.TabStripSelectedTabBackground = this.x427b83330cc91391(new float[4]
                    {
                        0.0f,
                        0.3f,
                        0.3f,
                        1f
                    }, new Color[4]
                    {
                        ColorTranslator.FromHtml("#FFFFFF"),
                        ColorTranslator.FromHtml("#F7F6F8"),
                        ColorTranslator.FromHtml("#EEF1F5"),
                        ColorTranslator.FromHtml("#F2F7F9")
                    });
                    this.TabStripSelectedTabBorder = this.x427b83330cc91391(new float[4]
                    {
                        0.0f,
                        0.3f,
                        0.7f,
                        1f
                    }, new Color[4]
                    {
                        ColorTranslator.FromHtml("#EAEFF5"),
                        ColorTranslator.FromHtml("#C1FAFF"),
                        ColorTranslator.FromHtml("#C6FAFF"),
                        ColorTranslator.FromHtml("#ECFAFB")
                    });
                    this.TabStripNormalTabForeground = ColorTranslator.FromHtml("#4C535C");
                    if (0 != 0)
                        ;
                    this.ButtonHotOuterBorder = this.x427b83330cc91391(new float[3]
                    {
                        0.0f,
                        0.5f,
                        1f
                    }, new Color[3]
                    {
                        ColorTranslator.FromHtml("#DBCE99"),
                        ColorTranslator.FromHtml("#B9A074"),
                        ColorTranslator.FromHtml("#CBC3AA")
                    });
                    if (-1 == 0)
                        goto label_12;
                }
                while (-1 == 0);
                this.ButtonHotInnerBorder = this.x427b83330cc91391(new float[4]
                {
                    0.0f,
                    0.5f,
                    0.5f,
                    1f
                }, new Color[4]
                {
                    ColorTranslator.FromHtml("#FFFFFB"),
                    ColorTranslator.FromHtml("#FFF9E3"),
                    ColorTranslator.FromHtml("#FFF2C9"),
                    ColorTranslator.FromHtml("#FFFCDF")
                });
                this.ButtonHotBackground = this.x427b83330cc91391(new float[4]
                {
                    0.0f,
                    0.5f,
                    0.5f,
                    1f
                }, new Color[4]
                {
                    ColorTranslator.FromHtml("#FFFCE6"),
                    ColorTranslator.FromHtml("#FFECA3"),
                    ColorTranslator.FromHtml("#FFD844"),
                    ColorTranslator.FromHtml("#FFE47F")
                });
                goto label_8;
            }
            goto label_6;
            label_3:
            if (0 == 0)
            {
                this.DocumentStripBorder = ColorTranslator.FromHtml("#858585");
                this.DocumentNormalTabOuterBorder = ColorTranslator.FromHtml("#6F7074");
            }
            this.DocumentNormalTabInnerBorder = ColorTranslator.FromHtml("#EDF3F4");
            label_6:
            this.DocumentNormalTabBackground = this.x427b83330cc91391(new float[4]
            {
                0.0f,
                0.5f,
                0.5f,
                1f
            }, new Color[4]
            {
                ColorTranslator.FromHtml("#DCE0E5"),
                ColorTranslator.FromHtml("#D8DDE2"),
                ColorTranslator.FromHtml("#B5BAC3"),
                ColorTranslator.FromHtml("#C6CBD1")
            });
            this.DocumentHotTabOuterBorder = ColorTranslator.FromHtml("#6F7074");
            this.DocumentHotTabInnerBorder = ColorTranslator.FromHtml("#EDF3F4");
            if (15 != 0)
            {
                this.DocumentHotTabBackground = this.x427b83330cc91391(new float[4]
                {
                    0.0f,
                    0.5f,
                    0.5f,
                    1f
                }, new Color[4]
                {
                    ColorTranslator.FromHtml("#FBFBFB"),
                    ColorTranslator.FromHtml("#F1F1F2"),
                    ColorTranslator.FromHtml("#CFD3D6"),
                    ColorTranslator.FromHtml("#DEE0E3")
                });
                this.DocumentSelectedTabOuterBorder = ColorTranslator.FromHtml("#95774A");
                if (4 == 0)
                    return;
                this.DocumentSelectedTabInnerBorder = ColorTranslator.FromHtml("#CDB69C");
                this.DocumentSelectedTabBackground = this.x427b83330cc91391(new float[3]
                {
                    0.0f,
                    0.25f,
                    1f
                }, new Color[3]
                {
                    ColorTranslator.FromHtml("#FFD19C"),
                    ColorTranslator.FromHtml("#FFDBB3"),
                    ColorTranslator.FromHtml("#FFFFFE")
                });
            }
            else
                goto label_3;
        }

        /// <summary>
        /// Overridden. Consult the documentation on the base virtual member for more information.
        /// 
        /// </summary>
        public override string ToString()
        {
            return "Office 2007";
        }

        /// <summary>
        /// Overridden.
        /// 
        /// </summary>
        public override void StartRenderSession(HotkeyPrefix hotKeys)
        {
            this.xae3b2752a89e7464 = TextFormatFlags.EndEllipsis | TextFormatFlags.SingleLine | TextFormatFlags.VerticalCenter | TextFormatFlags.PreserveGraphicsClipping | TextFormatFlags.NoPadding;
            if (-2 == 0 || hotKeys == HotkeyPrefix.None)
                goto label_4;
            label_1:
            if (hotKeys == HotkeyPrefix.Hide)
                this.xae3b2752a89e7464 |= TextFormatFlags.HidePrefix;
            label_3:
            ++this.x03bb1ee2adad51ea;
            return;
            label_4:
            this.xae3b2752a89e7464 |= TextFormatFlags.NoPrefix;
            if (0 != 0)
                goto label_1;
            else
                goto label_3;
        }

        /// <summary>
        /// Overridden.
        /// 
        /// </summary>
        public override void FinishRenderSession()
        {
            this.x03bb1ee2adad51ea = Math.Max(this.x03bb1ee2adad51ea - 1, 0);
        }

        /// <summary>
        /// Overridden. Consult the documentation on the base virtual member for more information.
        /// 
        /// </summary>
        protected internal override void DrawControlClientBackground(Graphics graphics, Rectangle bounds, Color backColor)
        {
            using (Pen pen = new Pen(this.DockedWindowOuterBorder))
            {
                graphics.DrawLine(pen, bounds.Left, bounds.Top, bounds.Left, bounds.Bottom - 1);
                graphics.DrawLine(pen, bounds.Right - 1, bounds.Top, bounds.Right - 1, bounds.Bottom - 1);
                graphics.DrawLine(pen, bounds.Left, bounds.Bottom - 1, bounds.Right - 1, bounds.Bottom - 1);
            }
        }

        /// <summary>
        /// Overridden. Consult the documentation on the base virtual member for more information.
        /// 
        /// </summary>
        protected internal override void DrawAutoHideBarBackground(Control container, Control autoHideBar, Graphics graphics, Rectangle bounds)
        {
            using (SolidBrush solidBrush = new SolidBrush(this.Background))
                graphics.FillRectangle((Brush)solidBrush, bounds);
        }

        /// <summary>
        /// Overridden. Consult the documentation on the base virtual member for more information.
        /// 
        /// </summary>
        protected internal override void DrawDockContainerBackground(Graphics graphics, DockContainer container, Rectangle bounds)
        {
            if (bounds.Width <= 0 || bounds.Height <= 0)
                return;

            if (container is DocumentContainer)
            {
                using (Brush brush = this.xb9d757f2231cc2a8(bounds, this.DocumentContainerBackground, LinearGradientMode.Vertical))
                {
                    graphics.FillRectangle(brush, bounds);
                }
            }
            else
                xa811784015ed8842.x91433b5e99eb7cac(graphics, this.Background);

//            goto label_4;
//
//            return;
//
//            label_4:
//            if (container is DocumentContainer)
//                goto label_7;
//            else
//                goto label_2;
//            label_5:
//            if (bounds.Height <= 0)
//                return;
//            goto label_4;
//            label_7:
//            using (Brush brush = this.xb9d757f2231cc2a8(bounds, this.DocumentContainerBackground, LinearGradientMode.Vertical))
//                graphics.FillRectangle(brush, bounds);
//            return;
        }

        /// <summary>
        /// Overridden. Consult the documentation on the base virtual member for more information.
        /// 
        /// </summary>
        protected internal override void DrawSplitter(Control container, Control control, Graphics graphics, Rectangle bounds, Orientation orientation)
        {
            if (control is DocumentContainer)
                return;
            using (SolidBrush solidBrush = new SolidBrush(this.Background))
                graphics.FillRectangle((Brush)solidBrush, bounds);
        }

        /// <summary>
        /// Overridden. Consult the documentation on the base virtual member for more information.
        /// 
        /// </summary>
        protected internal override void DrawTitleBarBackground(Graphics graphics, Rectangle bounds, bool focused)
        {
            using (Pen pen = new Pen(this.DockedWindowOuterBorder))
                graphics.DrawLines(pen, new System.Drawing.Point[6]
                {
                    new System.Drawing.Point(bounds.X, bounds.Bottom - 1),
                    new System.Drawing.Point(bounds.X, bounds.Y + 1),
                    new System.Drawing.Point(bounds.X + 1, bounds.Y),
                    new System.Drawing.Point(bounds.Right - 2, bounds.Y),
                    new System.Drawing.Point(bounds.Right - 1, bounds.Y + 1),
                    new System.Drawing.Point(bounds.Right - 1, bounds.Bottom - 1)
                });
            ++bounds.X;
            ++bounds.Y;
            bounds.Width -= 2;
            --bounds.Height;
            if (bounds.Width > 0)
            {
                if (bounds.Height > 0)
                {
                    using (LinearGradientBrush linearGradientBrush = this.xb9d757f2231cc2a8(bounds, focused ? this.ActiveTitleBarBackground : this.InactiveTitleBarBackground, LinearGradientMode.Vertical))
                        graphics.FillRectangle(linearGradientBrush, bounds);
                }
            }
            else
                goto label_11;
            label_6:
            using (Pen pen = new Pen(this.DockedWindowInnerBorder))
            {
                graphics.DrawLines(pen, new System.Drawing.Point[4]
                {
                    new System.Drawing.Point(bounds.X, bounds.Bottom - 1),
                    new System.Drawing.Point(bounds.X, bounds.Y),
                    new System.Drawing.Point(bounds.Right - 1, bounds.Y),
                    new System.Drawing.Point(bounds.Right - 1, bounds.Bottom - 1)
                });
                return;
            }
            label_11:
            if (int.MaxValue == 0)
                goto label_6;
            else
                goto label_6;
        }

        /// <summary>
        /// Overridden. Consult the documentation on the base virtual member for more information.
        /// 
        /// </summary>
        protected internal override void DrawTitleBarText(Graphics graphics, Rectangle bounds, bool focused, string text, Font font)
        {
            bounds.Inflate(-3, 0);
            TextFormatFlags flags = this.TextFormat | TextFormatFlags.NoPrefix;
            bounds.X += 3;
            TextRenderer.DrawText((IDeviceContext)graphics, text, font, bounds, focused ? Color.Black : Color.Black, flags);
        }

        /// <summary>
        /// Overridden. Consult the documentation on the base virtual member for more information.
        /// 
        /// </summary>
        protected internal override void DrawTabStripBackground(Control container, Control control, Graphics graphics, Rectangle bounds, int selectedTabOffset)
        {
            using (SolidBrush solidBrush = new SolidBrush(this.Background))
                graphics.FillRectangle((Brush)solidBrush, bounds);
            using (Pen pen = new Pen(this.TabStripInnerBorder))
                graphics.DrawLine(pen, bounds.X, bounds.Top + 1, bounds.Right - 1, bounds.Top + 1);
            using (Pen pen = new Pen(this.TabStripOuterBorder))
                graphics.DrawLine(pen, bounds.X, bounds.Top + 2, bounds.Right - 1, bounds.Top + 2);
        }

        /// <summary>
        /// Overridden. Consult the documentation on the base virtual member for more information.
        /// 
        /// </summary>
        protected internal override void DrawTabStripTab(Graphics graphics, Rectangle bounds, Image image, string text, Font font, Color backColor, Color foreColor, DrawItemState state, bool drawSeparator)
        {
            bounds.Y += 2;
            bounds.Height -= 2;
            if ((state & DrawItemState.Selected) == DrawItemState.Selected)
            {
                using (LinearGradientBrush linearGradientBrush = this.xb9d757f2231cc2a8(bounds, this.TabStripSelectedTabBackground, LinearGradientMode.Vertical))
                    xa811784015ed8842.x272eca3f5ebfa9fc(graphics, bounds, image, this.ImageSize, text, font, (Brush)linearGradientBrush, SystemColors.ControlText, this.TabStripOuterBorder, state, this.TextFormat);
            }
            else
                xa811784015ed8842.x272eca3f5ebfa9fc(graphics, bounds, image, this.ImageSize, text, font, SystemInformation.HighContrast ? SystemColors.Control : backColor, SystemInformation.HighContrast ? SystemColors.Control : SystemColors.ControlLightLight, this.TabStripNormalTabForeground, this.TabStripOuterBorder, state, this.TextFormat);
        }

        /// <summary>
        /// Overridden. Consult the documentation on the base virtual member for more information.
        /// 
        /// </summary>
        protected internal override void DrawTitleBarButton(Graphics graphics, Rectangle bounds, SandDockButtonType buttonType, DrawItemState state, bool focused, bool toggled)
        {
            this.x9271fbf5eef553db(graphics, bounds, state, focused);
            using (Pen x90279591611601bc = !focused ? new Pen(Color.Black) : new Pen(Color.Black))
            {
                switch (buttonType)
                {
                    case SandDockButtonType.Close:
                        x9b2777bb8e78938b.x26f0f0028ef01fa5(graphics, bounds, x90279591611601bc);
                        break;
                    case SandDockButtonType.Pin:
                        x9b2777bb8e78938b.x1477b5a75c8a8132(graphics, bounds, x90279591611601bc, toggled);
                        break;
                    case SandDockButtonType.WindowPosition:
                        x9b2777bb8e78938b.xeac2e7eb44dff86e(graphics, bounds, x90279591611601bc);
                        break;
                }
            }
        }

        private void x9271fbf5eef553db(Graphics x41347a961b838962, Rectangle xda73fcb97c77d998, DrawItemState x01b557925841ae51, bool xb0f87b71823b1d4e)
        {
            if ((x01b557925841ae51 & DrawItemState.HotLight) != DrawItemState.HotLight)
                return;
            bool flag = (x01b557925841ae51 & DrawItemState.Selected) == DrawItemState.Selected;
            using (Brush brush = (Brush)this.xb9d757f2231cc2a8(xda73fcb97c77d998, flag ? this.ButtonPressedOuterBorder : this.ButtonHotOuterBorder, LinearGradientMode.Vertical))
            {
                using (Pen pen = new Pen(brush))
                    x41347a961b838962.DrawPolygon(pen, new System.Drawing.Point[8]
                    {
                        new System.Drawing.Point(xda73fcb97c77d998.X + 1, xda73fcb97c77d998.Y),
                        new System.Drawing.Point(xda73fcb97c77d998.Right - 2, xda73fcb97c77d998.Y),
                        new System.Drawing.Point(xda73fcb97c77d998.Right - 1, xda73fcb97c77d998.Y + 1),
                        new System.Drawing.Point(xda73fcb97c77d998.Right - 1, xda73fcb97c77d998.Bottom - 2),
                        new System.Drawing.Point(xda73fcb97c77d998.Right - 2, xda73fcb97c77d998.Bottom - 1),
                        new System.Drawing.Point(xda73fcb97c77d998.X + 1, xda73fcb97c77d998.Bottom - 1),
                        new System.Drawing.Point(xda73fcb97c77d998.X, xda73fcb97c77d998.Bottom - 2),
                        new System.Drawing.Point(xda73fcb97c77d998.X, xda73fcb97c77d998.Y + 1)
                    });
            }
            using (Brush brush = (Brush)this.xb9d757f2231cc2a8(xda73fcb97c77d998, flag ? this.ButtonPressedInnerBorder : this.ButtonHotInnerBorder, LinearGradientMode.Vertical))
            {
                using (Pen pen = new Pen(brush))
                    x41347a961b838962.DrawRectangle(pen, xda73fcb97c77d998.X + 1, xda73fcb97c77d998.Y + 1, xda73fcb97c77d998.Width - 3, xda73fcb97c77d998.Height - 3);
            }
            using (Brush brush = (Brush)this.xb9d757f2231cc2a8(xda73fcb97c77d998, flag ? this.ButtonPressedBackground : this.ButtonHotBackground, LinearGradientMode.Vertical))
                x41347a961b838962.FillRectangle(brush, xda73fcb97c77d998.X + 2, xda73fcb97c77d998.Y + 2, xda73fcb97c77d998.Width - 4, xda73fcb97c77d998.Height - 4);
        }

        /// <summary>
        /// Overridden. Consult the documentation on the base virtual member for more information.
        /// 
        /// </summary>
        protected internal override void DrawCollapsedTab(Graphics graphics, Rectangle bounds, DockSide dockSide, Image image, string text, Font font, Color backColor, Color foreColor, DrawItemState state, bool vertical)
        {
            using (Brush x6f967439eb9e4ffb = (Brush)this.xb9d757f2231cc2a8(bounds, vertical ? this.CollapsedTabVerticalBackground : this.CollapsedTabHorizontalBackground, vertical ? LinearGradientMode.Horizontal : LinearGradientMode.Vertical))
            {
                if (dockSide == DockSide.Left || dockSide == DockSide.Right)
                {
                    using (Image xe058541ca798c059 = (Image)new Bitmap(image))
                    {
                        xe058541ca798c059.RotateFlip(RotateFlipType.Rotate90FlipNone);
                        xa811784015ed8842.x36c79cea8e98cf3c(graphics, bounds, dockSide, xe058541ca798c059, text, font, x6f967439eb9e4ffb, Brushes.Black, this.CollapsedTabBorder, this.TabTextDisplay == TabTextDisplayMode.AllTabs);
                    }
                }
                else
                    xa811784015ed8842.x36c79cea8e98cf3c(graphics, bounds, dockSide, image, text, font, x6f967439eb9e4ffb, Brushes.Black, this.CollapsedTabBorder, this.TabTextDisplay == TabTextDisplayMode.AllTabs);
            }
        }

        /// <summary>
        /// Overridden. Consult the documentation on the base virtual member for more information.
        /// 
        /// </summary>
        protected internal override void DrawDocumentStripBackground(Graphics graphics, Rectangle bounds)
        {
            if (bounds.Width <= 0 || 0 == 0 && bounds.Height <= 0)
                return;
            using (Pen pen = new Pen(this.DocumentStripBorder))
                graphics.DrawLine(pen, bounds.X, bounds.Bottom - 1, bounds.Right - 1, bounds.Bottom - 1);
        }

        /// <summary>
        /// Overridden. Consult the documentation on the base virtual member for more information.
        /// 
        /// </summary>
        protected internal override void DrawDocumentStripTab(Graphics graphics, Rectangle bounds, Rectangle contentBounds, Image image, string text, Font font, Color backColor, Color foreColor, DrawItemState state, bool drawSeparator)
        {
            if (bounds.Width <= 0 || bounds.Height <= 0)
                return;
            if (false)
                goto label_19;
            else
                goto label_22;
            label_1:
            ColorBlend xdf5de570fec6a668;
            Color color1;
            Color color2;
            bool xb0f87b71823b1d4e;
            using (Brush x6f967439eb9e4ffb = (Brush)this.xb9d757f2231cc2a8(bounds, xdf5de570fec6a668, LinearGradientMode.Vertical))
            {
                using (Pen x19577c9fba5c0e47 = new Pen(color1))
                {
                    using (Pen x7df20da36ed57a6a = new Pen(color2))
                    {
                        this.xf8aac789a7846004(graphics, bounds, contentBounds, image, text, font, backColor, x19577c9fba5c0e47, x7df20da36ed57a6a, x6f967439eb9e4ffb, state, xb0f87b71823b1d4e, this.DocumentTabSize, this.DocumentTabExtra, this.TextFormat);
                        return;
                    }
                }
            }
            label_18:
            if ((state & DrawItemState.HotLight) == DrawItemState.HotLight)
                goto label_20;
            label_19:
            color1 = this.DocumentNormalTabOuterBorder;
            color2 = this.DocumentNormalTabInnerBorder;
            do
            {
                xdf5de570fec6a668 = this.DocumentNormalTabBackground;
                if (0 != 0)
                    goto label_22;
            }
            while (false);
            if (-1 == 0)
            {
                if (false)
                    goto label_18;
            }
            else
                goto label_1;
            label_20:
            color1 = this.DocumentHotTabOuterBorder;
            color2 = this.DocumentHotTabInnerBorder;
            xdf5de570fec6a668 = this.DocumentHotTabBackground;
            goto label_1;
            label_22:
            xb0f87b71823b1d4e = (state & DrawItemState.Checked) == DrawItemState.Checked;
            if ((state & DrawItemState.Selected) == DrawItemState.Selected)
            {
                if (false)
                    return;
                color1 = this.DocumentSelectedTabOuterBorder;
                color2 = this.DocumentSelectedTabInnerBorder;
                xdf5de570fec6a668 = this.DocumentSelectedTabBackground;
                goto label_1;
            }
            else
                goto label_18;
        }

        private void xf8aac789a7846004(Graphics x41347a961b838962, Rectangle xda73fcb97c77d998, Rectangle x0bd0d09521a6c8ef, Image xe058541ca798c059, string xb41faee6912a2313, Font x26094932cf7a9139, Color xe8029028206f7f99, Pen x19577c9fba5c0e47, Pen x7df20da36ed57a6a, Brush x6f967439eb9e4ffb, DrawItemState x01b557925841ae51, bool xb0f87b71823b1d4e, int x6843d1739e949b3a, int xbd5e294caed74c4d, TextFormatFlags xae3b2752a89e7464)
        {
            if ((x01b557925841ae51 & DrawItemState.Selected) == DrawItemState.Selected)
            {
                ++xda73fcb97c77d998.Height;
                do
                {
                    ++x6843d1739e949b3a;
                }
                while (int.MinValue == 0);
            }
            x41347a961b838962.DrawLine(x19577c9fba5c0e47, xda73fcb97c77d998.Left + 1, xda73fcb97c77d998.Bottom - 2, xda73fcb97c77d998.Left + x6843d1739e949b3a - 3, xda73fcb97c77d998.Top + 2);
            x41347a961b838962.DrawLine(x19577c9fba5c0e47, xda73fcb97c77d998.Left + x6843d1739e949b3a - 3, xda73fcb97c77d998.Top + 2, xda73fcb97c77d998.Left + x6843d1739e949b3a - 2, xda73fcb97c77d998.Top + 2);
            if ((uint)(xb0f87b71823b1d4e ? 1 : 0)- (uint)x6843d1739e949b3a < 0U)
                goto label_14;
            else
                goto label_21;
            label_13:
            System.Drawing.Point[] points;
            x41347a961b838962.FillPolygon(x6f967439eb9e4ffb, points);
            xda73fcb97c77d998 = x0bd0d09521a6c8ef;
            label_14:
            xda73fcb97c77d998.X += xbd5e294caed74c4d;
            if ((uint)x6843d1739e949b3a >= 0U)
                goto label_12;
            else
                goto label_11;
            label_6:
            if (xda73fcb97c77d998.Width > 8)
                goto label_9;
            else
                goto label_27;
            label_1:
            Rectangle rectangle;
            rectangle.Height += 2;
            ++rectangle.X;
            --rectangle.Width;
            ControlPaint.DrawFocusRectangle(x41347a961b838962, rectangle);
            return;
            label_3:
            if (!xb0f87b71823b1d4e)
                return;
            else
                goto label_28;
            label_9:
            xae3b2752a89e7464 |= TextFormatFlags.HorizontalCenter;
            if (0 == 0)
            {
                if ((x6843d1739e949b3a | int.MinValue) != 0)
                {
                    xae3b2752a89e7464 &= ~TextFormatFlags.Default;
                    if (0 == 0)
                    {
                        if (false)
                            return;
                        TextRenderer.DrawText((IDeviceContext)x41347a961b838962, xb41faee6912a2313, x26094932cf7a9139, xda73fcb97c77d998, SystemColors.ControlText, xae3b2752a89e7464);
                        goto label_3;
                    }
                }
                else
                    goto label_11;
            }
            else
                goto label_1;
            label_27:
            if (true)
                goto label_3;
            label_28:
            if ((x6843d1739e949b3a & 0) != 0)
                return;
            rectangle = xda73fcb97c77d998;
            rectangle.Inflate(-2, -2);
            if (false)
                goto label_15;
            else
                goto label_1;
            label_8:
            if (xe058541ca798c059 == null)
                goto label_6;
            label_11:
            x41347a961b838962.DrawImage(xe058541ca798c059, xda73fcb97c77d998.X + 4, xda73fcb97c77d998.Y + 2, this.ImageSize.Width, this.ImageSize.Height);
            xda73fcb97c77d998.X += this.ImageSize.Width + 4;
            xda73fcb97c77d998.Width -= this.ImageSize.Width + 4;
            if (8 != 0)
                goto label_6;
            else
                goto label_8;
            label_12:
            xda73fcb97c77d998.Width -= xbd5e294caed74c4d;
            goto label_8;
            label_15:
            points[1] = new System.Drawing.Point(xda73fcb97c77d998.Left + x6843d1739e949b3a - 3, xda73fcb97c77d998.Top + 4);
            points[2] = new System.Drawing.Point(xda73fcb97c77d998.Left + x6843d1739e949b3a + 1, xda73fcb97c77d998.Top + 2);
            points[3] = new System.Drawing.Point(xda73fcb97c77d998.Right - 2, xda73fcb97c77d998.Top + 2);
            points[4] = new System.Drawing.Point(xda73fcb97c77d998.Right - 2, xda73fcb97c77d998.Bottom - 1);
            goto label_13;
            label_21:
            if (true)
            {
                x41347a961b838962.DrawLine(x19577c9fba5c0e47, xda73fcb97c77d998.Left + x6843d1739e949b3a - 1, xda73fcb97c77d998.Top + 1, xda73fcb97c77d998.Left + x6843d1739e949b3a, xda73fcb97c77d998.Top + 1);
                x41347a961b838962.DrawLine(x19577c9fba5c0e47, xda73fcb97c77d998.Left + x6843d1739e949b3a + 1, xda73fcb97c77d998.Top, xda73fcb97c77d998.Right - 3, xda73fcb97c77d998.Top);
                x41347a961b838962.DrawLine(x19577c9fba5c0e47, xda73fcb97c77d998.Right - 3, xda73fcb97c77d998.Top, xda73fcb97c77d998.Right - 1, xda73fcb97c77d998.Top + 2);
                do
                {
                    x41347a961b838962.DrawLine(x19577c9fba5c0e47, xda73fcb97c77d998.Right - 1, xda73fcb97c77d998.Top + 2, xda73fcb97c77d998.Right - 1, xda73fcb97c77d998.Bottom - 2);
                    x41347a961b838962.DrawLine(x7df20da36ed57a6a, xda73fcb97c77d998.Left + 2, xda73fcb97c77d998.Bottom - 2, xda73fcb97c77d998.Left + x6843d1739e949b3a - 3, xda73fcb97c77d998.Top + 3);
                    x41347a961b838962.DrawLine(x7df20da36ed57a6a, xda73fcb97c77d998.Left + x6843d1739e949b3a - 3, xda73fcb97c77d998.Top + 3, xda73fcb97c77d998.Left + x6843d1739e949b3a - 2, xda73fcb97c77d998.Top + 3);
                    x41347a961b838962.DrawLine(x7df20da36ed57a6a, xda73fcb97c77d998.Left + x6843d1739e949b3a - 1, xda73fcb97c77d998.Top + 2, xda73fcb97c77d998.Left + x6843d1739e949b3a, xda73fcb97c77d998.Top + 2);
                    x41347a961b838962.DrawLine(x7df20da36ed57a6a, xda73fcb97c77d998.Left + x6843d1739e949b3a + 1, xda73fcb97c77d998.Top + 1, xda73fcb97c77d998.Right - 4, xda73fcb97c77d998.Top + 1);
                    x41347a961b838962.DrawLine(x7df20da36ed57a6a, xda73fcb97c77d998.Right - 3, xda73fcb97c77d998.Top + 1, xda73fcb97c77d998.Right - 2, xda73fcb97c77d998.Top + 2);
                    x41347a961b838962.DrawLine(x7df20da36ed57a6a, xda73fcb97c77d998.Right - 2, xda73fcb97c77d998.Top + 2, xda73fcb97c77d998.Right - 2, xda73fcb97c77d998.Bottom - 2);
                    if (false)
                        goto label_15;
                }
                while (0 != 0);
                points = new System.Drawing.Point[5];
                points[0] = new System.Drawing.Point(xda73fcb97c77d998.Left + 2, xda73fcb97c77d998.Bottom - 1);
                goto label_15;
            }
            else
                goto label_13;
        }

        /// <summary>
        /// Overridden. Consult the documentation on the base virtual member for more information.
        /// 
        /// </summary>
        protected internal override System.Drawing.Size MeasureTabStripTab(Graphics graphics, Image image, string text, Font font, DrawItemState state)
        {
            return xa811784015ed8842.xcdfce0e0f2641503(graphics, image, this.ImageSize, text, font, this.TextFormat);
        }

        /// <summary>
        /// Overridden. Consult the documentation on the base virtual member for more information.
        /// 
        /// </summary>
        protected internal override System.Drawing.Size MeasureDocumentStripTab(Graphics graphics, Image image, string text, Font font, DrawItemState state)
        {
            TextFormatFlags flags = this.TextFormat & ~TextFormatFlags.NoPrefix;
            int width;
            using (Font font1 = new Font(font, FontStyle.Bold))
                width = TextRenderer.MeasureText((IDeviceContext)graphics, text, font1, new System.Drawing.Size(int.MaxValue, int.MaxValue), flags).Width;
            label_9:
            width += 14;
            if (15 != 0)
                goto label_3;
            label_1:
            width += this.ImageSize.Width + 4;
            if (0 == 0)
            {
                if ((uint)width - (uint)width >= 0U)
                    goto label_4;
            }
            else
                goto label_9;
            label_3:
            if (image != null)
                goto label_1;
            label_4:
            return new System.Drawing.Size(width + this.DocumentTabExtra, 0);
        }

        /// <summary>
        /// Overridden. Consult the documentation on the base virtual member for more information.
        /// 
        /// </summary>
        protected internal override void DrawDocumentStripButton(Graphics graphics, Rectangle bounds, SandDockButtonType buttonType, DrawItemState state)
        {
            this.x9271fbf5eef553db(graphics, bounds, state, true);
            switch (buttonType)
            {
                case SandDockButtonType.Close:
                    x9b2777bb8e78938b.x26f0f0028ef01fa5(graphics, bounds, SystemPens.ControlText);
                    break;
                case SandDockButtonType.Pin:
                    break;
                case SandDockButtonType.ScrollLeft:
                    x9b2777bb8e78938b.xd70a4c1a2378c84e(graphics, bounds, SystemColors.ControlText, (state & DrawItemState.Disabled) != DrawItemState.Disabled);
                    if (4 != 0)
                        break;
                    else
                        break;
                case SandDockButtonType.ScrollRight:
                    x9b2777bb8e78938b.x793dc1a7cf4113f9(graphics, bounds, SystemColors.ControlText, (state & DrawItemState.Disabled) != DrawItemState.Disabled);
                    break;
                case SandDockButtonType.WindowPosition:
                    break;
                case SandDockButtonType.ActiveFiles:
                    bounds.Inflate(1, 1);
                    --bounds.X;
                    if (0 == 0)
                    {
                        x9b2777bb8e78938b.xeac2e7eb44dff86e(graphics, bounds, SystemPens.ControlText);
                        break;
                    }
                    else
                        goto case 2;
                default:
                    if (8 != 0)
                        break;
                    else
                        goto case 3;
            }
        }

        /// <summary>
        /// Overridden. Consult the documentation on the base virtual member for more information.
        /// 
        /// </summary>
        protected internal override void DrawDocumentClientBackground(Graphics graphics, Rectangle bounds, Color backColor)
        {
            using (SolidBrush solidBrush = new SolidBrush(backColor))
                graphics.FillRectangle((Brush)solidBrush, bounds);
            using (Pen pen = new Pen(this.DocumentStripBorder))
                graphics.DrawLines(pen, new System.Drawing.Point[4]
                {
                    new System.Drawing.Point(bounds.X, bounds.Y),
                    new System.Drawing.Point(bounds.X, bounds.Bottom - 1),
                    new System.Drawing.Point(bounds.Right - 1, bounds.Bottom - 1),
                    new System.Drawing.Point(bounds.Right - 1, bounds.Y)
                });
        }

        /// <summary>
        /// Overridden. Consult the documentation on the base virtual member for more information.
        /// 
        /// </summary>
        protected internal override Rectangle AdjustDockControlClientBounds(ControlLayoutSystem layoutSystem, DockControl control, Rectangle clientBounds)
        {
            if (!(layoutSystem is DocumentLayoutSystem))
                return base.AdjustDockControlClientBounds(layoutSystem, control, clientBounds);
            ++clientBounds.X;
            clientBounds.Width -= 2;
            --clientBounds.Height;
            return clientBounds;
        }

        /// <summary>
        /// Overridden. Consult the documentation on the base virtual member for more information.
        /// 
        /// </summary>
        public override void DrawTabControlBackground(Graphics graphics, Rectangle bounds, Color backColor, bool client)
        {
            if (client)
                return;
            using (SolidBrush solidBrush = new SolidBrush(backColor))
                graphics.FillRectangle((Brush)solidBrush, bounds);
            using (Pen pen = new Pen(this.DocumentStripBorder))
                graphics.DrawLines(pen, new System.Drawing.Point[4]
                {
                    new System.Drawing.Point(bounds.X, bounds.Y),
                    new System.Drawing.Point(bounds.X, bounds.Bottom - 1),
                    new System.Drawing.Point(bounds.Right - 1, bounds.Bottom - 1),
                    new System.Drawing.Point(bounds.Right - 1, bounds.Y)
                });
        }

        /// <summary>
        /// Overridden. Consult the documentation on the base virtual member for more information.
        /// 
        /// </summary>
        public override void ModifyDefaultWindowColors(DockControl window, ref Color backColor, ref Color borderColor)
        {
            borderColor = this.DockedWindowOuterBorder;
        }
    }
}
