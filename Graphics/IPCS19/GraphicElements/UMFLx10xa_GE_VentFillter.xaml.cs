// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UMFLx10xa_GE_VentFillter.xaml.cs" company="">
//   
// </copyright>
// <summary>
//   Interaction logic for UMFLx10xa_GE_VentFillter
//   <ElementId>a4f28d09-8d8e-4646-9b77-9e51b49bc7c5:aa298919-ebc2-4781-8721-8363698f5e4b</ElementId>
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace IPCS19
{
    using System;
    using System.Windows;

    /// <summary>
    ///     Interaction logic for UMFLx10xa_GE_VentFillter
    ///     <ElementId>a4f28d09-8d8e-4646-9b77-9e51b49bc7c5:aa298919-ebc2-4781-8721-8363698f5e4b</ElementId>
    /// </summary>
    public partial class UMFLx10xa_GE_VentFillter
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
                typeof(UMFLx10xa_GE_VentFillter), 
                new PropertyMetadata(0, null));

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="UMFLx10xa_GE_VentFillter"/> class.
        /// </summary>
        public UMFLx10xa_GE_VentFillter()
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