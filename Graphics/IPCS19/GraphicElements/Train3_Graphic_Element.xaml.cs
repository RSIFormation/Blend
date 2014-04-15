// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Train3_Graphic_Element.xaml.cs" company="">
//   
// </copyright>
// <summary>
//   Interaction logic for Train3_Graphic_Element
//   <ElementId>44b09519-fa7e-4fd7-b05a-e9d9cafe249b:6912ba21-ed3b-4576-b4f8-14ffabdeeae0</ElementId>
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace SadaraLibrary
{
    using System;
    using System.Windows;

    /// <summary>
    ///     Interaction logic for Train3_Graphic_Element
    ///     <ElementId>44b09519-fa7e-4fd7-b05a-e9d9cafe249b:6912ba21-ed3b-4576-b4f8-14ffabdeeae0</ElementId>
    /// </summary>
    public partial class Train3_Graphic_Element
    {
        // Input Properties 
        #region Static Fields

        /// <summary>
        /// The subscription rate property.
        /// </summary>
        public static readonly DependencyProperty SubscriptionRateProperty =
            DependencyProperty.Register(
                "SubscriptionRate", 
                typeof(Int32), 
                typeof(Train3_Graphic_Element), 
                new PropertyMetadata(0, null));

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="Train3_Graphic_Element"/> class.
        /// </summary>
        public Train3_Graphic_Element()
        {
            this.InitializeComponent();
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets or sets the subscription rate.
        /// </summary>
        public int SubscriptionRate
        {
            get
            {
                return (Int32)this.GetValue(SubscriptionRateProperty);
            }

            set
            {
                this.SetValue(SubscriptionRateProperty, value);
            }
        }

        #endregion

        // Expression Variables 
    }
}