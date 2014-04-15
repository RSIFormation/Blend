// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UMHxxxx_TMS_GE.xaml.cs" company="">
//   
// </copyright>
// <summary>
//   Interaction logic for UMHxxxx_TMS_GE
//   <ElementId>8d870acc-9f99-4ec3-b053-760d054ddd42:df7d87d4-8c97-4f79-b964-e796df1d67e2</ElementId>
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace IPCS19
{
    using System;
    using System.Windows;

    /// <summary>
    ///     Interaction logic for UMHxxxx_TMS_GE
    ///     <ElementId>8d870acc-9f99-4ec3-b053-760d054ddd42:df7d87d4-8c97-4f79-b964-e796df1d67e2</ElementId>
    /// </summary>
    public partial class UMHxxxx_TMS_GE
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
                typeof(UMHxxxx_TMS_GE), 
                new PropertyMetadata(0, null));

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="UMHxxxx_TMS_GE"/> class.
        /// </summary>
        public UMHxxxx_TMS_GE()
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