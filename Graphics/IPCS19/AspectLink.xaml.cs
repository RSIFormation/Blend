// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AspectLink.xaml.cs" company="">
//   
// </copyright>
// <summary>
//   Interaction logic for AspectLink.xaml
// </summary>
// --------------------------------------------------------------------------------------------------------------------

 // no XGML Source Provided
// Dependency properties created from property usage found in process graphic
namespace IPCS19
{
    using System;
    using System.Text.RegularExpressions;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Media;

    using RSI.Common.WPFTools.Helpers;
    using RSI.OTS.HMI.Controls;

    /* 
    <PropertyDescriptions>
              <PropertyDescription Name="Name" Value="&quot;Aspect View Button7&quot;" />
              <PropertyDescription Name="Transform" Value="Empty" />
              <PropertyDescription Name="Visible" Value="True" />
              <PropertyDescription Name="XPos" Value="548." />
              <PropertyDescription Name="YPos" Value="728." />
              <PropertyDescription Name="Width" Value="16." />
              <PropertyDescription Name="Height" Value="16." />
              <PropertyDescription Name="Rotation" Value="0" />
              <PropertyDescription Name="AspectView" Value="$'vw::HS670326:Logic Display:Main View'" />
              <PropertyDescription Name="BackgroundBrush" Value="Transparent()" />
              <PropertyDescription Name="BackgroundImage" Value="$'im::Sadara Icons:Digital Logic'" />
              <PropertyDescription Name="DisabledBackground" Value="Transparent()" />
              <PropertyDescription Name="DisabledFrame3dEffect" Value="Flat" />
              <PropertyDescription Name="DisabledImage" Value="Empty" />
              <PropertyDescription Name="DisabledText" Value="&quot;Disabled&quot;" />
              <PropertyDescription Name="DisabledTextColor" Value="ARGB(50,255,255,255)" />
              <PropertyDescription Name="DownBackground" Value="DarkGray" />
              <PropertyDescription Name="DownImage" Value="Empty" />
              <PropertyDescription Name="DownText" Value="&quot;&quot;" />
              <PropertyDescription Name="DownTextColor" Value="Black" />
              <PropertyDescription Name="Enabled" Value="True" />
              <PropertyDescription Name="Font" Value="Font( &quot;MS Sans Serif&quot; ,8 ,Regular, Normal)" />
              <PropertyDescription Name="FrameColor1" Value="RGB(200,200,200)" />
              <PropertyDescription Name="FrameWidth" Value="1." />
              <PropertyDescription Name="HighlightCornerRadius" Value="2" />
              <PropertyDescription Name="HighlightPen" Value="Pen(Orange, 1.)" />
              <PropertyDescription Name="PresentationMode" Value="Overlap" />
              <PropertyDescription Name="Text" Value="&quot;&quot;" />
              <PropertyDescription Name="TextColor" Value="Black" />
              <PropertyDescription Name="Tooltip" Value="&quot;&quot;" />
            </PropertyDescriptions>
    */

    /// <summary>
    ///     Interaction logic for AspectLink.xaml
    /// </summary>
    public partial class AspectLink : UserControl
    {
        // Property that identifies target
        #region Static Fields

        /// <summary>
        /// The aspect view property.
        /// </summary>
        public static readonly DependencyProperty AspectViewProperty = DependencyProperty.Register(
            "AspectView", 
            typeof(string), 
            typeof(AspectLink), 
            new PropertyMetadata(string.Empty, AspectViewPropertyChanged));

        // Translation of AspectViewProperty into known template
        /// <summary>
        /// The aspect view template property.
        /// </summary>
        public static readonly DependencyProperty AspectViewTemplateProperty =
            DependencyProperty.Register(
                "AspectViewTemplate", 
                typeof(MimicTemplate), 
                typeof(AspectLink), 
                new PropertyMetadata(null));

        /// <summary>
        /// The border color property.
        /// </summary>
        public static readonly DependencyProperty BorderColorProperty = DependencyProperty.Register(
            "BorderColor", 
            typeof(Brush), 
            typeof(AspectLink), 
            new PropertyMetadata(Brushes.Black));

        /// <summary>
        /// The font property.
        /// </summary>
        public static readonly DependencyProperty FontProperty = DependencyProperty.Register(
            "Font", 
            typeof(string), 
            typeof(AspectLink));

        /// <summary>
        ///     Color of container frame
        /// </summary>
        public static readonly DependencyProperty FrameColor1Property = DependencyProperty.Register(
            "FrameColor1", 
            typeof(string), 
            typeof(AspectLink), 
            new PropertyMetadata("Black"));

        /// <summary>
        ///     Width of container frame
        /// </summary>
        public static readonly DependencyProperty FrameWidthProperty = DependencyProperty.Register(
            "FrameWidth", 
            typeof(double), 
            typeof(AspectLink));

        /// <summary>
        ///     InstructorGraphic - default to true
        ///     Controls the visibility of object visuals that are unnecessary for instructor graphics
        /// </summary>
        public static readonly DependencyProperty InstructorGraphicProperty =
            DependencyProperty.Register(
                "InstructorGraphic", 
                typeof(Boolean), 
                typeof(AspectLink), 
                new PropertyMetadata(true, InstructorGraphicPropertyChanged));

        /// <summary>
        /// The text color property.
        /// </summary>
        public static readonly DependencyProperty TextColorProperty = DependencyProperty.Register(
            "TextColor", 
            typeof(string), 
            typeof(AspectLink), 
            new PropertyMetadata("Black"));

        /// <summary>
        /// The text property.
        /// </summary>
        public static readonly DependencyProperty TextProperty = DependencyProperty.Register(
            "Text", 
            typeof(string), 
            typeof(AspectLink), 
            new PropertyMetadata(string.Empty));

        #endregion

        #region Fields

        /// <summary>
        /// The _aspect view.
        /// </summary>
        private string _aspectView;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="AspectLink"/> class.
        /// </summary>
        public AspectLink()
        {
            this.InitializeComponent();
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets or sets the aspect view.
        /// </summary>
        public string AspectView
        {
            get
            {
                return (string)this.GetValue(AspectViewProperty);
            }

            set
            {
                this.SetValue(AspectViewProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets the aspect view template.
        /// </summary>
        public MimicTemplate AspectViewTemplate
        {
            get
            {
                if (AspectViewTemplateProperty == null)
                {
                    this.OnAspectViewChanged();
                }

                return (MimicTemplate)this.GetValue(AspectViewTemplateProperty);
            }

            set
            {
                this.SetValue(AspectViewTemplateProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets the font.
        /// </summary>
        public string Font
        {
            get
            {
                return (string)this.GetValue(FontProperty);
            }

            set
            {
                this.SetValue(FontProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets the frame color 1.
        /// </summary>
        public string FrameColor1
        {
            get
            {
                return (string)this.GetValue(FrameColor1Property);
            }

            set
            {
                this.SetValue(FrameColor1Property, value);
                var converter = new BrushConverter();
                var brush = converter.ConvertFromString(value) as Brush;
                this.SetValue(BorderColorProperty, brush);
            }
        }

        /// <summary>
        /// Gets or sets the frame width.
        /// </summary>
        public double FrameWidth
        {
            get
            {
                return (double)this.GetValue(FrameWidthProperty);
            }

            set
            {
                this.SetValue(FrameWidthProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether instructor graphic.
        /// </summary>
        public bool InstructorGraphic
        {
            get
            {
                return (Boolean)this.GetValue(InstructorGraphicProperty);
            }

            set
            {
                this.SetValue(InstructorGraphicProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets the text.
        /// </summary>
        public string Text
        {
            get
            {
                return (string)this.GetValue(TextProperty);
            }

            set
            {
                this.SetValue(TextProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets the text color.
        /// </summary>
        public string TextColor
        {
            get
            {
                return (string)this.GetValue(TextColorProperty);
            }

            set
            {
                this.SetValue(TextColorProperty, value);
            }
        }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// The on aspect view changed.
        /// </summary>
        public void OnAspectViewChanged()
        {
            // [vw::][.:<Aspect Name>:]<View Name>
            // [vw::]<Object Symbol>:<Aspect Name>[:<View Name>]
            // eg: <PropertyDescription Name="AspectView" Value="$'vw::C3020:Graphic Display2:Main View'" />
            // 'vw::V4402:V4402_SFC:Main View'
            if (!string.IsNullOrEmpty(this.AspectView))
            {
                var matchCollection = Regex.Split(this.AspectView, @"\$'vw::([^:]*):([^:]*):([^']*)'");
                if (matchCollection.Length == 5)
                {
                    var unit = matchCollection[1].Trim(new[] { ' ' });
                    var aspect = matchCollection[2].Trim(new[] { ' ' });
                    var view = matchCollection[3].Trim(new[] { ' ' });

                    this._aspectView = aspect; // Keep private copy of the parsed template id
                    var resource = ResourceDictionaryHelper.GetTemplate(aspect);
                    if (resource == null)
                    {
                        // Band-Aid?
                        if (view == "Main View")
                        {
                            var overview = string.Format("{0}_{1}", unit, aspect);
                            overview = overview.Replace(' ', '_');
                            resource = ResourceDictionaryHelper.GetTemplate(overview);
                        }
                    }

                    this.SetValue(AspectViewTemplateProperty, resource);

                    // If no Text parameter specified, or if specified as "", use
                    // the name of view's associated object 
                    /*  if (aspect != "Logic_Display")
                    {
                        if (string.IsNullOrEmpty(Text))
                        {
                            SetValue(TextProperty, unit);
                        }
                    }
                   * */
                    this.OnInstructorGraphicChanged();
                }
 // AspectView valid
            }
 // AspectView specified
        }

        /// <summary>
        /// The on instructor graphic changed.
        /// </summary>
        public void OnInstructorGraphicChanged()
        {
            // Per Houston, AspectLinks to LogicDisplay (ie:faceplates) are not to be shown on Instructor Graphics
            if (this._aspectView == "LogicDisplay")
            {
                this.AspectLinkFrame.Visibility = this.InstructorGraphic ? Visibility.Hidden : Visibility.Visible;
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// The aspect view property changed.
        /// </summary>
        /// <param name="source">
        /// The source.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private static void AspectViewPropertyChanged(DependencyObject source, DependencyPropertyChangedEventArgs e)
        {
            var aspect = source as AspectLink;
            if (aspect != null)
            {
                aspect.OnAspectViewChanged();
            }
        }

        /// <summary>
        /// Callback when InstructorGraphic dependency property changed - need to set visibility accordingly
        /// </summary>
        /// <param name="source">
        /// </param>
        /// <param name="e">
        /// </param>
        private static void InstructorGraphicPropertyChanged(
            DependencyObject source, 
            DependencyPropertyChangedEventArgs e)
        {
            var aspect = source as AspectLink;
            if (aspect != null)
            {
                aspect.OnInstructorGraphicChanged();
            }
        }

        #endregion

        // On AspectViewChanged
    }
}