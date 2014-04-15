// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UMHxxxx_GE_DetailDisplay.xaml.cs" company="">
//   
// </copyright>
// <summary>
//   Interaction logic for UMHxxxx_GE_DetailDisplay
//   <ElementId>8d870acc-9f99-4ec3-b053-760d054ddd42:5bf44bc2-2295-4617-bcdc-7e5e2ad7b9fb</ElementId>
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace IPCS19
{
    using System;
    using System.Windows;

    /// <summary>
    ///     Interaction logic for UMHxxxx_GE_DetailDisplay
    ///     <ElementId>8d870acc-9f99-4ec3-b053-760d054ddd42:5bf44bc2-2295-4617-bcdc-7e5e2ad7b9fb</ElementId>
    /// </summary>
    public partial class UMHxxxx_GE_DetailDisplay
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
                typeof(UMHxxxx_GE_DetailDisplay), 
                new PropertyMetadata(0, null));

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="UMHxxxx_GE_DetailDisplay"/> class.
        /// </summary>
        public UMHxxxx_GE_DetailDisplay()
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