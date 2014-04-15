using System;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using RSI.Common.WPFTools.Helpers;
using RSI.OTS.HMI.Controls;
// no XGML Source Provided
// Dependency properties created from property usage found in process graphic
namespace IPCS19
{
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
    /// Interaction logic for AspectLink.xaml
    /// </summary>
    public partial class AspectLink : UserControl
    {
        // Property that identifies target
        public static readonly DependencyProperty AspectViewProperty =
            DependencyProperty.Register(
            "AspectView",
            typeof(String),
            typeof(AspectLink),
            new PropertyMetadata(String.Empty, AspectViewPropertyChanged)
            );
        public string AspectView
        {
            get { return (String)GetValue(AspectViewProperty); }
            set { SetValue(AspectViewProperty, value); }
        }

        private string _aspectView;
        // Translation of AspectViewProperty into known template
        public static readonly DependencyProperty AspectViewTemplateProperty =
            DependencyProperty.Register(
            "AspectViewTemplate",
            typeof(MimicTemplate),
            typeof(AspectLink),
            new PropertyMetadata(null)
            );
        public MimicTemplate AspectViewTemplate
        {
            get
            {
                if (AspectViewTemplateProperty == null)
                {
                    OnAspectViewChanged();
                }
                return (MimicTemplate)GetValue(AspectViewTemplateProperty);
            }
            set { SetValue(AspectViewTemplateProperty, value); }
        }


        // Content shown on button
        public static readonly DependencyProperty TextProperty =
            DependencyProperty.Register(
            "Text",
            typeof(String),
            typeof(AspectLink),
            new PropertyMetadata("")
            );
        public string Text
        {
            get { return (String)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }
        // Foreground color for text
        public static readonly DependencyProperty TextColorProperty =
            DependencyProperty.Register(
            "TextColor",
            typeof(String),
            typeof(AspectLink),
            new PropertyMetadata("Black")
            );

        public string TextColor
        {
            get { return (String)GetValue(TextColorProperty); }
            set { SetValue(TextColorProperty, value); }
        }
        // 
        public static readonly DependencyProperty FontProperty =
            DependencyProperty.Register(
            "Font",
            typeof(String),
            typeof(AspectLink)
            );
        public string Font
        {
            get { return (String)GetValue(FontProperty); }
            set { SetValue(FontProperty, value); }
        }
        /// <summary>
        /// Color of container frame
        /// </summary>
        public static readonly DependencyProperty FrameColor1Property =
            DependencyProperty.Register(
            "FrameColor1",
            typeof(String),
            typeof(AspectLink),
            new PropertyMetadata("Black")
            );
        public string FrameColor1
        {
            get { return (String)GetValue(FrameColor1Property); }
            set
            {
                SetValue(FrameColor1Property, value);
                var converter = new BrushConverter();
                var brush = converter.ConvertFromString(value) as Brush;
                SetValue(BorderColorProperty, brush);
            }
        }
        // Dependency property to convert string FrameColor1 -> BorderBrush
        public static readonly DependencyProperty BorderColorProperty =
            DependencyProperty.Register(
            "BorderColor",
            typeof(Brush),
            typeof(AspectLink),
            new PropertyMetadata(Brushes.Black)
            );
        /// <summary>
        /// Width of container frame
        /// </summary>
        public static readonly DependencyProperty FrameWidthProperty =
            DependencyProperty.Register(
            "FrameWidth",
            typeof(double),
            typeof(AspectLink)
            );
        public double FrameWidth
        {
            get { return (double)GetValue(FrameWidthProperty); }
            set { SetValue(FrameWidthProperty, value); }
        }

        /// <summary>
        /// InstructorGraphic - default to true
        /// Controls the visibility of object visuals that are unnecessary for instructor graphics
        /// </summary>
        public static readonly DependencyProperty InstructorGraphicProperty =
                   DependencyProperty.Register(
                   "InstructorGraphic",
                   typeof(Boolean),
                   typeof(AspectLink),
                   new PropertyMetadata(true, InstructorGraphicPropertyChanged)
                   );
        public Boolean InstructorGraphic
        {
            get { return (Boolean)GetValue(InstructorGraphicProperty); }
            set { SetValue(InstructorGraphicProperty, value); }
        }

        public AspectLink()
        {
            InitializeComponent();

        }
        /// <summary>
        /// Callback when InstructorGraphic dependency property changed - need to set visibility accordingly
        /// </summary>
        /// <param name="source"></param>
        /// <param name="e"></param>
        private static void InstructorGraphicPropertyChanged(DependencyObject source, DependencyPropertyChangedEventArgs e)
        {
            var aspect = source as AspectLink;
            if (aspect != null) aspect.OnInstructorGraphicChanged();
        }
        public void OnInstructorGraphicChanged()
        {
            // Per Houston, AspectLinks to LogicDisplay (ie:faceplates) are not to be shown on Instructor Graphics
            if (_aspectView == "LogicDisplay")
            {
                AspectLinkFrame.Visibility = InstructorGraphic ? Visibility.Hidden : Visibility.Visible;
            }

        }

        private static void AspectViewPropertyChanged(DependencyObject source, DependencyPropertyChangedEventArgs e)
        {
            var aspect = source as AspectLink;
            if (aspect != null) aspect.OnAspectViewChanged();
        }
        public void OnAspectViewChanged()
        {


            // [vw::][.:<Aspect Name>:]<View Name>
            // [vw::]<Object Symbol>:<Aspect Name>[:<View Name>]
            // eg: <PropertyDescription Name="AspectView" Value="$'vw::C3020:Graphic Display2:Main View'" />
            //                                                    'vw::V4402:V4402_SFC:Main View'
            if (!String.IsNullOrEmpty(AspectView))
            {
                var matchCollection = Regex.Split(AspectView, @"\$'vw::([^:]*):([^:]*):([^']*)'");
                if (matchCollection.Length == 5)
                {
                    var unit = matchCollection[1].Trim(new char[] { ' ' });
                    var aspect = matchCollection[2].Trim(new char[] { ' ' });
                    var view = matchCollection[3].Trim(new char[] { ' ' });


                    _aspectView = aspect; // Keep private copy of the parsed template id
                    var resource = ResourceDictionaryHelper.GetTemplate(aspect);
                    if (resource == null)
                    {
                        // Band-Aid?
                        if (view == "Main View")
                        {
                            var overview = String.Format("{0}_{1}", unit,aspect);
                            overview = overview.Replace(' ', '_');
                            resource = ResourceDictionaryHelper.GetTemplate(overview);
                        }
                    }

                    SetValue(AspectViewTemplateProperty, resource);

                    // If no Text parameter specified, or if specified as "", use
                    // the name of view's associated object 
                  /*  if (aspect != "Logic_Display")
                    {
                        if (String.IsNullOrEmpty(Text))
                        {
                            SetValue(TextProperty, unit);
                        }
                    }
                   * */
                    OnInstructorGraphicChanged();

                }// AspectView valid
            } // AspectView specified

        } // On AspectViewChanged


    }
}